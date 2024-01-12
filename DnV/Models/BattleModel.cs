using DnV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace DnV.Models
{
    public class BattleModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameUser { get; set; }
        public string Species { get; set; }
        public string Imag { get; set; }
        public int HistoryId { get; set; }
        public int Defence { get; set; }
        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;

                RaisePropertyChanged(nameof(Health));
            }
        }
        public int Power { get; set; }
        public int PowerMod { get; set; }
        public int P
        {
            get
            {
                return Calc.CalcModify(Power, PowerMod);
            }
        }
        public int Dexterity { get; set; }
        public int DexterityMod { get; set; }
        public int D
        {
            get
            {
                return Calc.CalcModify(Dexterity, DexterityMod);
            }
        }
        public int Endurance { get; set; }
        public int EnduranceMod { get; set; }
        public int E
        {
            get
            {
                return Calc.CalcModify(Endurance, EnduranceMod);
            }
        }
        public int Wisdom { get; set; }
        public int WisdomMod { get; set; }
        public int W
        {
            get
            {
                return Calc.CalcModify(Wisdom, WisdomMod);
            }
        }
        public int Intelligence { get; set; }
        public int IntelligenceMod { get; set; }
        public int I
        {
            get
            {
                return Calc.CalcModify(Intelligence, IntelligenceMod);
            }
        }
        public int Charisma { get; set; }
        public int CharismaMod { get; set; }
        public int C
        {
            get
            {
                return Calc.CalcModify(Charisma, CharismaMod);
            }
        }
        public int PassivWisdom { get; set; }
        public string ClassPerson { get; set; }
        public string Attack { get; set; }
        public string Note { get; set; }
        public string HistoryText { get; set; }
        public int RoomId { get; set; }
        public int IsNPC { get; set; }

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
        public int NPCId { get; set; }

        private int _initiative;
        public int Initiative
        {
            get { return _initiative; }
            set
            {
                _initiative = value;

                RaisePropertyChanged(nameof(Initiative));
            }
        }

        public List<ListModel> Status = new List<ListModel>();
        public List<ListModel> Log = new List<ListModel>();
        public List<ListModel> Description = new List<ListModel>();
    }
}
