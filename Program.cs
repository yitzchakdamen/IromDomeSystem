namespace IromDomeSystem
{
    class Program
    {
        static void Main()
        {
            // double ElapsedTime; // t זמן מהשיגור
            //                     // מיקום X Y Z

            Missile missile = new Missile.Builder()
                .SetAcceleration(0)      // More realistic acceleration
                .SetTimeAcceleration(5)   // Shorter burn time
                .SetLanunchAngle(45)      // 45-degree launch angle
                .SetGeographicAngle(50)    // Simplified for testing
                .SetLatitude(31.497642435306812)
                .SetLongitude(34.447034780157175)
                .Build();
                
            // Calculate.acceleration = 50;
            // Calculate.timeAcceleration = 15;
            // Calculate.angle = Calculate.DegreesToRadians(60);

            MissileSimulation.Run(missile);
        }
    }
}