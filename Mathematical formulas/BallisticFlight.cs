namespace IromDomeSystem
{
    public class BallisticFlight : IFlightPhase
    {
        double InitialPositionX, InitialPositionY, InitialVelocityX, InitialVelocityY;
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
            return InitialVelocityY - Calculate.gravity * time;
        }

        public double XPosition(double time)
        {
            return time * InitialVelocityX + InitialPositionX;
        }

        public double YPosition(double time)
        {
            return InitialPositionY + InitialVelocityY * time - 0.5 * Calculate.gravity * Math.Pow(time, 2);
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