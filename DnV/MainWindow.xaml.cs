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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DnV.ViewModels;

namespace DnV
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
            //this.Loaded += OnLoad;
            //string htmlContent = "<body style='margin:0; background: #1C1C25; overflow:hidden;'><h1> <span style='color:#ff0000;'>Hello</span>, <i>WPF</i> with <b>HTML</b>!</h1></body>";
            //webBrowser.NavigateToString(htmlContent);
        }
        private void GridNPC_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            vm.Update(sender, e);
        }
    }
}
