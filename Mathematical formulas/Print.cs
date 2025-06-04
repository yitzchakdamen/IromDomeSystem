namespace IromDomeSystem
{
    static class Print
    {
        public static void PrintStatus(IFlightPhase phase, double time, string status)
        {
            // שמירת הצבע המקורי
            var defaultColor = Console.ForegroundColor;

            // כותרת
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===== Missile Status =====");
            Console.WriteLine($" ----- {status} ----- ");

            // זמן
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Time: ");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine($"{time:F3} s");

            // מיקום
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Position: ");

            Console.ForegroundColor = defaultColor;
            double x = phase.XPosition(time);
            double y = phase.YPosition(time);

            Console.WriteLine($"X = {x:F3} m, Y = {y:F3} m");
            Console.WriteLine($"Height from ground: {Math.Max(y, 0):F3} m");

            // מהירות
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Velocity: ");
            Console.ForegroundColor = defaultColor;
            double vx = phase.XVelocity(time);
            double vy = phase.YVelocity(time);
            double totalVelocity = phase.TotalVelocity(time);
            Console.WriteLine($"Vx = {vx:F3} m/s, Vy = {vy:F3} m/s");
            Console.WriteLine($"Total Velocity: {totalVelocity:F3} m/s");

            // זווית
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Angle    : ");
            Console.ForegroundColor = defaultColor;
            double angleRad = phase.AngleMovement(time);
            Console.WriteLine($"{angleRad:F3}°");

            // Debug Info
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nDebug Info:");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine($"Acceleration due to gravity: {Calculate.gravity:F3} m/s²");

            // שורת הפרדה
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("==========================\n");

            // החזרת צבע מקורי
            Console.ForegroundColor = defaultColor;
        }

        public static void PrintStatus(FlightSnapshot snapshot)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 40));

            if (snapshot.HasHitGround)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" >> The missile has HIT the ground.");
                if (snapshot.TimeSinceImpact.HasValue)
                    Console.WriteLine($" Time since impact: {snapshot.TimeSinceImpact.Value:F2} seconds");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" >> The missile is still in the AIR.");
                if (snapshot.TimeUntilImpact.HasValue)
                    Console.WriteLine($" Time until impact: {snapshot.TimeUntilImpact.Value:F2} seconds");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 40));
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}