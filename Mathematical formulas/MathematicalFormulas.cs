using System;

namespace IromDomeSystem
{
    static class Calculate
    {
        public static double gravity = 9.81; // כוח המשיכה (m/s²)
        public static double EarthRadius = 6_371_000;

        public static double DegreesToRadians(double Degrees)
        {
            return Degrees * Math.PI / 180;
        }
        
        public static double RadiansToDegrees(double Radians)
        {
            return Radians * (180.0 / Math.PI);
        }
    }
}
