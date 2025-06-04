namespace IromDomeSystem
{
    class MissileCalculation
    {
        public static double gravity = Calculate.gravity; // כוח המשיכה (m/s²)
        public static double acceleration; // תאוצה
        public static double timeAcceleration; // משך שלב התאוצה
        public static double launchAngle; // זווית שיגור ברדיאנים
        public static double GeographicAngle; //  זווית גיאוגרפית ברדיאנים
        Calculate.PoweredFlight PoweredFlight;
        Calculate.BallisticFlight BallisticFlight;

        public MissileCalculation(Missile missile)
        {
            launchAngle = Calculate.DegreesToRadians(missile.LanunchAngle);
            GeographicAngle = Calculate.DegreesToRadians(missile.GeographicAngle);
            acceleration = missile.Acceleration;
            timeAcceleration = missile.TimeAcceleration;

            PoweredFlight = new Calculate.PoweredFlight(acceleration, launchAngle);
            double initialPositionX = PoweredFlight.XPosition(timeAcceleration);
            double initialPositionY = PoweredFlight.YPosition(timeAcceleration);
            double initialVelocityX = PoweredFlight.XVelocity(timeAcceleration);
            double initialVelocityY = PoweredFlight.YVelocity(timeAcceleration);
            BallisticFlight = new Calculate.BallisticFlight(initialPositionX, initialPositionY, initialVelocityX, initialVelocityY);
        }

        public void run(double time)
        {
            Console.Clear();
            var snapshot = FlightSnapshot.GetSnapshot(BallisticFlight, time, timeAcceleration );

            if (time <= timeAcceleration)
            {
                Print.PrintStatus(PoweredFlight, time, "Powered Flight");

                Print.PrintStatus(snapshot);
            }
            else
            {
                double ballisticTime = time - timeAcceleration;
                Print.PrintStatus(BallisticFlight, ballisticTime, "Ballistic Flight");

                Print.PrintStatus(snapshot);

            }
        }
        
    }
}