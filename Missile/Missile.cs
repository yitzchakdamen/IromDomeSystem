using System.Dynamic;

namespace IromDomeSystem
{
    class Missile
    {
        // public double InitialVelocity { set; get; } // Vo = מטר לשניה 
        public double LanunchAngle { set; get; }
        public double GeographicAngle { get; set; }
        public double Acceleration { set; get; } // תאוצה
        public double TimeAcceleration { set; get; } // משך שלב התאוצה
        public double Longitude { set; get; } // קו אורך
        public double Latitude { set; get; } // קו רוחב



        private Missile() { }


        public class Builder
        {
            private Missile missile = new();

            public Builder SetAcceleration(double acceleration)
            {
                missile.Acceleration = acceleration;
                return this;
            }
            public Builder SetTimeAcceleration(double timeAcceleration)
            {
                missile.TimeAcceleration = timeAcceleration;
                return this;
            }
            public Builder SetLanunchAngle(double lanunchAngle)
            {
                missile.LanunchAngle = lanunchAngle;
                return this;
            }
            public Builder SetGeographicAngle(double geographicAngle)
            {
                missile.GeographicAngle = geographicAngle;
                return this;
            }


            public Missile Build()
            {
                // if (!missile.InitialVelocity.HasValue || !missile.LanunchAngle.HasValue)
                // {
                //     throw new InvalidOperationException("Missing fields");
                // }
                return missile;
            }


        }
        
    }
    
}