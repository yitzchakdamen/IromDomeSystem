namespace IromDomeSystem
{
    class MissileCalculation
    {
        public  double acceleration, timeAcceleration;
        public  double launchAngle; // זווית שיגור ברדיאנים
        public  double GeographicAngle; //  זווית גיאוגרפית ברדיאנים
        public double Longitude, Latitude;
        PoweredFlight PoweredFlight;
        BallisticFlight BallisticFlight;
        GeographicFlightCalculation geographicFlightCalculation;

        public MissileCalculation(Missile missile)
        {
            launchAngle = Calculate.DegreesToRadians(missile.LanunchAngle);
            GeographicAngle = Calculate.DegreesToRadians(missile.GeographicAngle);
            acceleration = missile.Acceleration;
            timeAcceleration = missile.TimeAcceleration;

            PoweredFlight = new PoweredFlight(acceleration, launchAngle);

            var (initialPositionX, initialPositionY, initialVelocityX, initialVelocityY) = PoweredFlight.EndPoweredFlight(timeAcceleration);

            BallisticFlight = new BallisticFlight(initialPositionX, initialPositionY, initialVelocityX, initialVelocityY);

            geographicFlightCalculation = new(GeographicAngle, Longitude, Latitude);
        }

        public void run(double time)
        {
            Console.Clear();
            var snapshot = FlightSnapshot.GetSnapshot(BallisticFlight, time, timeAcceleration );

            if (time <= timeAcceleration)
            {
                double distance = PoweredFlight.XPosition(time);
                geographicFlightCalculation.CalculatLongitudeLatitude(distance: distance);

                Print.PrintStatus(PoweredFlight, time, "Powered Flight");
                Print.PrintStatus(snapshot);
            }
            else
            {
                double ballisticTime = time - timeAcceleration;
                double distance = BallisticFlight.XPosition(ballisticTime);
                geographicFlightCalculation.CalculatLongitudeLatitude(distance: distance);

                Print.PrintStatus(BallisticFlight, ballisticTime, "Ballistic Flight");
                Print.PrintStatus(snapshot);

            }
        }
        
    }
}