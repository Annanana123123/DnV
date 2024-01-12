using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnV.Services;

namespace DnV.Models
{
    public class NPCModel
    {
        public int id { get; set; }
		public string name {get; set;}
        public string imag {get; set;}
        public int defence {get; set;}
        public int health {get; set;}
        public int power {get; set;}
        public int powerMod {get; set;}
        public int p
        {
            get
            {
                return Calc.CalcModify(power, powerMod);
            }
        }
        public int dexterity {get; set;}
        public int dexterityMod {get; set;}
        public int d
        {
            get
            {
                return Calc.CalcModify(dexterity, dexterityMod);
            }
        }
        public int endurance {get; set;}
        public int enduranceMod {get; set;}
        public int e
        {
            get
            {
                return Calc.CalcModify(endurance, enduranceMod);
            }
        }
        public int wisdom {get; set;}
        public int wisdomMod {get; set;}
        public int w
        {
            get
            {
                return Calc.CalcModify(wisdom, wisdomMod);
            }
        }
        public int intelligence {get; set;}
        public int intelligenceMod {get; set;}
        public int i
        {
            get
            {
                return Calc.CalcModify(intelligence, intelligenceMod);
            }
        }
        public int charisma {get; set;}
        public int charismaMod {get; set;}
        public int c
        {
            get
            {
                return Calc.CalcModify(charisma, charismaMod);
            }
        }
        public int passivWisdom {get; set;}
        public string classNPS {get; set;}
        public string attack {get; set;}
        public string note {get; set;}
        public string history {get; set; }
        public int roomId { get; set; }

        public int SkillBonus { get; set; }

        public int PowerSave { get; set; }
        public int DexteritySave { get; set; }
        public int EnduranceSave { get; set; }
        public int WisdomSave { get; set; }
        public int IntelligenceSave { get; set; }
        public int CharismaSave { get; set; }

        public int Acrobatics { get; set; }
        public int Analysis { get; set; }
        public int Athletics { get; set; }
        public int Perception { get; set; }
        public int Survival { get; set; }
        public int Performance { get; set; }
        public int Intimidation { get; set; }
        public int History { get; set; }
        public int SleightOfHand { get; set; }
        public int Magic { get; set; }
        public int Medicine { get; set; }
        public int Deception { get; set; }
        public int Nature { get; set; }
        public int Insight { get; set; }
        public int Religion { get; set; }
        public int Stealth { get; set; }
        public int Persuasion { get; set; }
        public int AnimalCare { get; set; }
    }
}
