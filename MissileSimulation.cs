using System;
using System.Threading;
using System.Threading.Tasks;

namespace IromDomeSystem
{
    class MissileSimulation
    {
        public static async Task Run(Missile missile)
        {
            MissileCalculation missileCalculation = new();
            await missileCalculation.CalculateMissile(missile);

            double time = 0;

            while (true)
            {
                missileCalculation.run(time);
                Thread.Sleep(1000);
                time ++;
            }
        }
    }
}
