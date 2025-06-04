namespace IromDomeSystem
{
    public class PoweredFlight : IFlightPhase
    {
        private double AccelerationX, AccelerationY, LaunchAngle;
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
            return time * (AccelerationY - Calculate.gravity);
        }

        public double XPosition(double time)
        {
            return Math.Pow(time, 2) * AccelerationX * 0.5;
        }

        public double YPosition(double time)
        {
            return 0.5 * Math.Pow(time, 2) * (AccelerationY - Calculate.gravity);
        }

        public double AngleMovement(double time)
        {
            double vx = XVelocity(time);
            double vy = YVelocity(time);
            double angleRadians = Math.Atan2(vy, vx);
            return Calculate.RadiansToDegrees(angleRadians);
        }
        public double TotalVelocity(double time)
        {
            double vx = XVelocity(time);
            double vy = YVelocity(time);
            return Math.Sqrt(vx * vx + vy * vy);
        }

        public (double, double, double, double) EndPoweredFlight(double timeAcceleration)
        {
            double initialPositionX = XPosition(timeAcceleration);
            double initialPositionY = YPosition(timeAcceleration);
            double initialVelocityX = XVelocity(timeAcceleration);
            double initialVelocityY = YVelocity(timeAcceleration);
            return (initialPositionX, initialPositionY, initialVelocityX, initialVelocityY);
        }
        

    }
    
}