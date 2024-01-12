using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnV.Services
{
    public class Calc
    {
        public static int CalcModify(int charact, int charactMod)
        {
            int charactOut = 0;
            charact += charactMod;

            if (charact == 1) { charactOut = -5; }
            if (charact == 2 || charact == 3) { charactOut = -4; }
            if (charact == 4 || charact == 5) { charactOut = -3; }
            if (charact == 6 || charact == 7) { charactOut = -2; }
            if (charact == 8 || charact == 9) { charactOut = -1; }
            if (charact == 10 || charact == 11) { charactOut = 0; }
            if (charact == 12 || charact == 13) { charactOut = 1; }
            if (charact == 14 || charact == 15) { charactOut = 2; }
            if (charact == 16 || charact == 17) { charactOut = 3; }
            if (charact == 18 || charact == 19) { charactOut = 4; }
            if (charact == 20 || charact == 21) { charactOut = 5; }
            if (charact == 22 || charact == 23) { charactOut = 6; }
            if (charact == 24 || charact == 25) { charactOut = 7; }
            if (charact == 26 || charact == 27) { charactOut = 8; }
            if (charact == 28 || charact == 29) { charactOut = 9; }
            if (charact == 30) { charactOut = 10; }

            //charactOut += charactMod;

            return charactOut;
        }

        public static int ToMilsec(string name)
        {
            int Milsect = 0;
            if (name != "" && name != "null")
            { 
                string[] sec = name.Split('-');

                Milsect = (Convert.ToInt32(sec[1]) * 60 + Convert.ToInt32(sec[2]));
            }
            
            return Milsect;
        }
    }
}
