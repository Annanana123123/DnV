using DnV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnV.Models
{
    public class EventModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public string imag { get; set; }
        public string sound { get; set; }
        public int order { get; set; }
        public int roomId { get; set; }
        public int Milsec
        {
            get
            {
                return Calc.ToMilsec(sound);
            }
        }
    }
}
