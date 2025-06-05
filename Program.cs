using System.Threading.Tasks;

namespace IromDomeSystem
{
    class Program
    {
        static async Task Main()
        {
            Missile missile = new Missile.Builder()
                .SetAcceleration(400)      // More realistic acceleration
                .SetTimeAcceleration(3)   // Shorter burn time
                .SetLanunchAngle(45)      // 45-degree launch angle
                .SetGeographicAngle(50)    // Simplified for testing
                .SetLatitude(34.47)
                .SetLongitude(31.5)
                .Build();


            await MissileSimulation.Run(missile);
            
        }
    }
}