namespace IromDomeSystem
{
    static class Print
    {
        public static void PrintStatus(double x, double y, double vx, double vy, double totalVelocity, double angleRad, double time, string status, double timeAcceleration)
        {
            var defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("              === MISSILE STATUS ===              ");
            Console.WriteLine($"           >>> Current Phase: {status} <<<");
            Console.WriteLine(new string('=', 60));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Elapsed Time (s): ");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine($"{time:F3}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Position (meters):");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine($"  • X (horizontal):     {x:F3} m");
            Console.WriteLine($"  • Y (vertical):       {y:F3} m");
            Console.WriteLine($"  • Height from ground: {Math.Max(y, 0):F3} m");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Velocity (m/s):");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine($"  • Vx (horizontal):    {vx:F3} m/s");
            Console.WriteLine($"  • Vy (vertical):      {vy:F3} m/s");
            Console.WriteLine($"  • Total Velocity:     {totalVelocity:F3} m/s");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Launch Angle (degrees): ");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine($"{angleRad:F3}°");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n--- Debug Info ---");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine($"  • Gravity Acceleration:   {Calculate.gravity:F3} m/s²");
            Console.WriteLine($"  • Time Acceleration:      {timeAcceleration}");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('=', 60) + "\n");
            Console.ForegroundColor = defaultColor;
        }

        public static void PrintStatus(double time, double impactTime)
        {
            System.Console.WriteLine(time + " " + impactTime);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 60));

            if (impactTime - time <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(">> STATUS: Missile has HIT the ground.");
                Console.WriteLine($"Time since impact: {time - impactTime:F2} seconds");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(">> STATUS: Missile is still in the AIR.");
                Console.WriteLine($"Time until impact: {impactTime - time:F2} seconds");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 60) + "\n");
            Console.ResetColor();
        }

        public static void PrintCoordinatesNicely(double latitude, double longitude)
        {
            string latitudeDirection = latitude >= 0 ? "North" : "South";
            double absoluteLatitude = Math.Abs(latitude);

            string longitudeDirection = longitude >= 0 ? "East" : "West";
            double absoluteLongitude = Math.Abs(longitude);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("               === LOCATION DETAILS ===               ");
            Console.WriteLine(new string('-', 60));
            Console.ResetColor();

            Console.WriteLine($"Latitude :  {absoluteLatitude:F6}° {latitudeDirection}");
            Console.WriteLine($"Longitude:  {absoluteLongitude:F6}° {longitudeDirection}");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('=', 60) + "\n");
            Console.ResetColor();
        }
    }
}
