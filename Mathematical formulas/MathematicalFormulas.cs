using System;

namespace IromDomeSystem
{
    static class Calculate
    {
        public static double gravity = 9.81; // כוח המשיכה (m/s²)

        public static double DegreesToRadians(double Degrees)
        {
            return Degrees * Math.PI / 180;
        }
        
        public static double RadiansToDegrees(double Radians)
        {
            return Radians * (180.0 / Math.PI);
        }



        public class PoweredFlight : IFlightPhase
        {
            private double AccelerationX;
            private double AccelerationY;
            private double LaunchAngle;
            public PoweredFlight(double acceleration, double launchAngle)
            {
                LaunchAngle = launchAngle;
                AccelerationX = Math.Cos(LaunchAngle) * acceleration;
                AccelerationY = Math.Sin(LaunchAngle) * acceleration;
            }
            public double XVelocity(double time)
            {
                return time * AccelerationX;
            }

            public double YVelocity(double time)
            {
                return time * (AccelerationY - gravity);
            }

            public double XPosition(double time)
            {
                return Math.Pow(time, 2) * AccelerationX * 0.5;
            }

            public double YPosition(double time)
            {
                return 0.5 * Math.Pow(time, 2) * (AccelerationY - gravity);
            }

            public double AngleMovement(double time)
            {
                double vx = XVelocity(time);
                double vy = YVelocity(time);
                double angleRadians = Math.Atan2(vy, vx);
                return RadiansToDegrees(angleRadians);
            }
            public double TotalVelocity(double time)
            {
                double vx = XVelocity(time);
                double vy = YVelocity(time);
                return Math.Sqrt(vx * vx + vy * vy);
            }

        }

        public class BallisticFlight : IFlightPhase
        {
            double InitialPositionX;
            double InitialPositionY;
            double InitialVelocityX;
            double InitialVelocityY;
            public BallisticFlight(double initialPositionX, double initialPositionY, double initialVelocityX, double initialVelocityY)
            {
                InitialPositionX = initialPositionX;
                InitialPositionY = initialPositionY;
                InitialVelocityX = initialVelocityX;
                InitialVelocityY = initialVelocityY;
            }
            public double XVelocity(double time)
            {
                return InitialVelocityX;
            }

            public double YVelocity(double time)
            {
                return InitialVelocityY - gravity * time;
            }

            public double XPosition(double time)
            {
                return time * InitialVelocityX + InitialPositionX;
            }

            public double YPosition(double time)
            {
                return InitialPositionY + InitialVelocityY * time - 0.5 * gravity * Math.Pow(time, 2);
            }

            public double AngleMovement(double time)
            {
                double vx = XVelocity(time);
                double vy = YVelocity(time);
                double angleRadians = Math.Atan(vy / vx);
                return angleRadians * (180.0 / Math.PI);
            }

            public double TotalVelocity(double time)
            {
                double vx = XVelocity(time);
                double vy = YVelocity(time);
                return Math.Sqrt(vx * vx + vy * vy);
            }

        }
    }
}
