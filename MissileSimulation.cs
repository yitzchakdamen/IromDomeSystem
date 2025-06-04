using System;
using System.Threading;

namespace IromDomeSystem
{
    class MissileSimulation
    {
        public static void Run(Missile missile)
        {
            MissileCalculation missileCalc = new MissileCalculation(missile);

            double time = 0;

            while (true)
            {
                missileCalc.run(time);
                Thread.Sleep(1000);
                time ++;
            }
        }
    }
}
