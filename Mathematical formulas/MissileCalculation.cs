using Microsoft.VisualBasic;

namespace IromDomeSystem
{
    class MissileCalculation
    {
        public double acceleration, timeAcceleration, launchAngle, GeographicAngle, launchLongitude, launchLatitude, impactTime, impactdistance;
        PoweredFlight PoweredFlight;
        BallisticFlight BallisticFlight;
        GeographicFlightCalculation geographicFlightCalculation;

        public MissileCalculation(Missile missile)
        {
            launchAngle = Calculate.DegreesToRadians(missile.LanunchAngle);
            GeographicAngle = missile.GeographicAngle;
            acceleration = missile.Acceleration;
            timeAcceleration = missile.TimeAcceleration;
            launchLongitude = missile.Longitude;
            launchLatitude = missile.Latitude;

            PoweredFlight = new PoweredFlight(acceleration, launchAngle);
            var (initialPositionX, initialPositionY, initialVelocityX, initialVelocityY) = PoweredFlight.EndPoweredFlight(timeAcceleration);
            BallisticFlight = new BallisticFlight(initialPositionX, initialPositionY, initialVelocityX, initialVelocityY);
            geographicFlightCalculation = new(GeographicAngle, launchLongitude, launchLatitude);
            impactTime = (double)ImpactTime(BallisticFlight, timeAcceleration)!;
            impactdistance = BallisticFlight.XPosition(impactTime - timeAcceleration);
        }

        public void run(double time)
        {
            Console.Clear();

            var (impactLongitude, impactLatitude) = geographicFlightCalculation.CalculatLongitudeLatitude(distance: impactdistance);
            Console.WriteLine(impactLongitude + " " + impactLatitude);
            Print.PrintCoordinatesNicely(impactLongitude, impactLatitude);
            Print.PrintStatus(time, impactTime);


            if (time <= timeAcceleration)
            {
                double distance = PoweredFlight.XPosition(time);
                var (Longitude, Latitude) = geographicFlightCalculation.CalculatLongitudeLatitude(distance: distance);

                var (x, y, vx, vy, totalVelocity, angle) = Calculation(PoweredFlight, time);

                Print.PrintStatus(x, y, vx, vy, totalVelocity, angle, time, "Powered Flight", timeAcceleration);
                Print.PrintCoordinatesNicely(Longitude, Latitude);
            }
            else
            {
                double ballisticTime = time - timeAcceleration;
                double distance = BallisticFlight.XPosition(ballisticTime);
                var (Longitude, Latitude) = geographicFlightCalculation.CalculatLongitudeLatitude(distance: distance);

                var (x, y, vx, vy, totalVelocity, angle) = Calculation(BallisticFlight, ballisticTime);

                Print.PrintStatus(x, y, vx, vy, totalVelocity, angle, ballisticTime, "Ballistic Flight", timeAcceleration);
                Print.PrintCoordinatesNicely(Longitude, Latitude);

            }
        }

        public (double, double, double, double, double, double) Calculation(IFlightPhase phase, double time)
        {
            double x = phase.XPosition(time);
            double y = phase.YPosition(time);
            double vx = phase.XVelocity(time);
            double vy = phase.YVelocity(time);
            double totalVelocity = phase.TotalVelocity(time);
            double angle = phase.AngleMovement(time);
            return (x, y, vx, vy, totalVelocity, angle);
        }

        public double? ImpactTime(IFlightPhase phase, double timeAcceleration, double maxTimeToLookAhead = 1000, double step = 1)
        {
            double? impactTime = null;
            for (double t = 0; t <= maxTimeToLookAhead; t += step)
            {
                if (phase.YPosition(t) <= 0)
                {
                    if (t <= 0)
                    {
                        impactTime = t;
                        break;
                    }
                    impactTime = t + timeAcceleration;
                    break;
                }
            }
            return impactTime;
        }
    }
}