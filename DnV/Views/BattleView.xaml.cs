using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DnV.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для BattleView.xaml
    /// </summary>
    public partial class BattleView : Window
    {
        BattleViewModel vm = new BattleViewModel();

        public BattleView(BattleViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            //if (vm.CloseAction == null)
            //    vm.CloseAction = new Action(this.Close);
        }
        private void GridNPC_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            vm.Update(sender, e);
        }
        private void GridHero_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            vm.Update(sender, e);
        }
    }
}
