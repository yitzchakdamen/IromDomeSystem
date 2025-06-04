namespace IromDomeSystem
{
    class Program
    {
        static void Main()
        {
            // double ElapsedTime; // t זמן מהשיגור
            //                     // מיקום X Y Z

            Missile missile = new Missile.Builder()
                .SetAcceleration(50)      // More realistic acceleration
                .SetTimeAcceleration(20)   // Shorter burn time
                .SetLanunchAngle(45)      // 45-degree launch angle
                .SetGeographicAngle(0)    // Simplified for testing
                .Build();
                
            // Calculate.acceleration = 50;
            // Calculate.timeAcceleration = 15;
            // Calculate.angle = Calculate.DegreesToRadians(60);

            MissileSimulation.Run(missile);
        }
    }
}