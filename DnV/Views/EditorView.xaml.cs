using DnV.ViewModels;
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

namespace DnV.Views
{
    /// <summary>
    /// Логика взаимодействия для EditorView.xaml
    /// </summary>
    public partial class EditorView : Window
    {
        EditorViewModel vm = new EditorViewModel();
        public EditorView(EditorViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
        private void GridNPC_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            vm.Update(sender, e);
        }
    }
}
