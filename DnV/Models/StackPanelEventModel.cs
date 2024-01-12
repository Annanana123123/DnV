using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnV.Models
{
    public class StackPanelEventModel
    {
        public string NameEventBtn { get; set; }
        public ICommand Event { get; set; }
    }
}
