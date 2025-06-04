public interface IFlightPhase
{
    double XPosition(double time);
    double YPosition(double time);
    double XVelocity(double time);
    double YVelocity(double time);
    double AngleMovement(double time);
    public double TotalVelocity(double time);
}
