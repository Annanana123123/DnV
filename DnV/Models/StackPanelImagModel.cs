using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnV.Models
{
    public class StackPanelImagModel
    {
        public int X { get; set; }
        public string SourceImag { get; set; }
        public ICommand ViewImag { get; set; }
    }
}
