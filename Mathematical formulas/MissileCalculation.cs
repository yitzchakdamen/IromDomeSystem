
namespace IromDomeSystem
{
    class MissileCalculation
    {
        double acceleration, timeAcceleration, launchAngle, GeographicAngle, launchLongitude, launchLatitude, impactTime, impactdistance, impactLongitude, impactLatitude;
        PoweredFlight? PoweredFlight;
        BallisticFlight? BallisticFlight;
        GeographicFlightCalculation? geographicFlightCalculation;
        LocationData? locationData;

        public async Task CalculateMissile(Missile missile)
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
            (impactLongitude, impactLatitude) = geographicFlightCalculation.CalculatLongitudeLatitude(distance: impactdistance);

            locationData = await Http.SendToServer(impactLatitude, impactLongitude);
        }

        public void run(double time)
        {
            double x, y, vx, vy, totalVelocity, angle, Longitude, Latitude;
            string status;

            if (time <= timeAcceleration)
            {
                status = "Powered Flight";
                double distance = PoweredFlight.XPosition(time);
                (Longitude, Latitude) = geographicFlightCalculation.CalculatLongitudeLatitude(distance: distance);
                (x, y, vx, vy, totalVelocity, angle) = Calculation(PoweredFlight, time);
            }
            else
            {
                status = "Ballistic Flight";
                double ballisticTime = time - timeAcceleration;
                double distance = BallisticFlight.XPosition(ballisticTime);
                (Longitude, Latitude) = geographicFlightCalculation.CalculatLongitudeLatitude(distance: distance);
                (x, y, vx, vy, totalVelocity, angle) = Calculation(BallisticFlight, ballisticTime);
            }

            PrintStatus(x, y, vx, vy, totalVelocity, angle, time, status, timeAcceleration, Longitude, Latitude);
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
        void PrintStatus(double x, double y, double vx, double vy, double totalVelocity, double angle, double time, string status, double timeAcceleration, double Longitude, double Latitude)
        {
            Console.Clear();
            Print.PrintStatus(x, y, vx, vy, totalVelocity, angle, time, status, timeAcceleration);
            Print.PrintStatus(time, impactTime);
            Print.PrintCoordinatesNicely(impactLongitude, impactLatitude);
            if (locationData != null)
                Console.WriteLine(locationData.display_name);
            Console.WriteLine(impactLongitude + " " + impactLatitude);
            Print.PrintCoordinatesNicely(Longitude, Latitude);
        }
        
    }
}