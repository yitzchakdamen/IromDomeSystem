namespace IromDomeSystem
{
    public class FlightSnapshot
    {

        public double Y { get; set; }
        public double Velocity { get; set; }
        public double Angle { get; set; }
        public bool HasHitGround { get; set; }
        public double? TimeSinceImpact { get; set; }
        public double? TimeUntilImpact { get; set; }
        public static FlightSnapshot GetSnapshot(IFlightPhase phase, double time, double timeAcceleration, double maxTimeToLookAhead = 1000, double step = 1)
        {
            double? impactTime = null;
            for (double t = timeAcceleration; t <= time + maxTimeToLookAhead; t += step)
            {
                if (phase.YPosition(t) <= 0)
                {
                    impactTime = t + timeAcceleration;
                    break;
                }
            }

            bool hasHit = impactTime - time <= 0; //phase.YPosition(time)  <= 0;

            return new FlightSnapshot
            {
                HasHitGround = hasHit,
                TimeSinceImpact = hasHit && impactTime.HasValue ? time - impactTime : null,
                TimeUntilImpact = !hasHit && impactTime.HasValue ? impactTime - time: null
            };
        }

    }

}