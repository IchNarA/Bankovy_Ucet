using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankovyUcetF
{
    internal class Banka
    {
        private int Peniaze = 0;

        public int Vklad(int Suma)
        {
            Peniaze += Suma;
            return Peniaze;
        }

        public int Vyber(int Suma)
        {
            if (Peniaze >= Suma)
            {
                Peniaze -= Suma;
                return Peniaze;
            }
            else
            {
                return -1;
            }
        }

        public int GetPeniaze()
        {
            return Peniaze;
        }
    }
}
