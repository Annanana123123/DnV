using DnV.Models;
using DnV.Views;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DnV.ViewModels
{
    public class PreViewModel : ViewModelBase
    {
        #region Конструктор

        public PreViewModel()
        {
            VisibilityLeftImag = Visibility.Hidden;
            VisibilityRightImag = Visibility.Hidden;
            VisibilityVS = Visibility.Hidden;
            VisibilityLogo = Visibility.Hidden;
            LeftStackPanelStatusImag = new ObservableCollection<ListModel>();
            RightStackPanelStatusImag = new ObservableCollection<ListModel>();
            //PathInterface = AppDomain.CurrentDomain.BaseDirectory + "/Media/Interface/";
            //CloseWindow = new RelayCommand(() => Close());
            //RightVisibility = Visibility.Hidden;
            //LeftVisibility = Visibility.Hidden;
            //VersusVisibility = Visibility.Hidden;
            //RShitImg = PathInterface + "Shit0.png";
            //LShitImg = PathInterface + "Shit0.png";
            //L0 = PathInterface + "layer_0.png";
            //L1 = PathInterface + "layer_1.png";
            //H = PathInterface + "Hard.png";
            //Cen = PathInterface + "CenterPanel.png";
            //VisibilityR = Visibility.Hidden;
            //VisibilityL = Visibility.Hidden;
            //ViB = Visibility.Hidden;
            //ViT = Visibility.Hidden;
            //OpacityR = 1;
            //OpacityL = 1;
            //StartTimer();
        }

        #endregion

        #region Методы

        public void ShowPreWindowVM(int n, string nameHistory, string image)
        {
            pv = new PreView(this);
            pv.Show();
            ImageHistory = image;
            PathImag = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + n + "\\Images\\";
            NameHistory = nameHistory;
        }

        public void ViewLogo()
        {
            if (VisibilityLogo == Visibility.Hidden)
            {
                VisibilityLogo = Visibility.Visible;
                HistoryName = NameHistory;
                LogoImag = PathImag + ImageHistory;
            }
            else
            {
                VisibilityLogo = Visibility.Hidden;
            }
        }

        public void ShowImag(string name)
        {
            if (ImageView != name)
            {
                ImageView = name;
                //ImageView = PathImag + name;
                //ImageView = "../Images/NPC/" +name;
                VisibilityImageView = Visibility.Visible;
            }
            else
            {
                NoShowImag();
                ImageView = "";
            }
        }
        public void NoShowImag()
        {
            VisibilityImageView = Visibility.Hidden;
        }

        public void ViewLeftImag(string _imag, int _df, int _hp, List<ListModel> _status)
        {
            LeftImag = @"C:\Users\genii\source\repos\DnV\DnV\bin\Debug\Media\Heros\" + _imag;
            LeftDF = _df.ToString();
            LeftHP = _hp.ToString();
            LeftStackPanelStatusImag.Clear();
            foreach (var stat in _status)
            {
                AddStackPanelStatusImag(stat.Id, 0);
            }
        }

        public void ViewRightImag(string _imag, List<ListModel> _status)
        {
            RightImag = @"C:\Users\genii\source\repos\DnV\DnV\bin\Debug\Media\NPC\" + _imag;
            RightStackPanelStatusImag.Clear();
            foreach (var stat in _status)
            {
                AddStackPanelStatusImag(stat.Id, 1);
            }
        }

        public void AddStackPanelStatusImag(int n, int isNPC)
        {
            if (isNPC == 0)
            {
                LeftStackPanelStatusImag.Add(new ListModel()
                {
                    Id = n,
                    Imag = @"C:\Users\genii\source\repos\DnV\DnV\bin\Debug\Media\Interface\status_" + n + ".png"
                });
            }
            else
            {
                RightStackPanelStatusImag.Add(new ListModel()
                {
                    Id = n,
                    Imag = @"C:\Users\genii\source\repos\DnV\DnV\bin\Debug\Media\Interface\status_" + n + ".png"
                });
            }
        }

        public void ShowVs()
        {
            VisibilityLeftImag = Visibility.Visible;
            VisibilityRightImag = Visibility.Visible;
            VisibilityVS = Visibility.Visible;
        }

        public void NoShowVs()
        {
            VisibilityLeftImag = Visibility.Hidden;
            VisibilityRightImag = Visibility.Hidden;
            VisibilityVS = Visibility.Hidden;
        }

        #endregion

        #region Свойства

        string PathImag = "";
        string NameHistory = "";
        string ImageHistory = "";

        public PreView pv { get; set; }

        private string _imageView;
        public string ImageView
        {
            get { return _imageView; }
            set
            {
                _imageView = value;

                RaisePropertyChanged(nameof(ImageView));
            }
        }

        private ObservableCollection<ListModel> _leftStackPanelStatusImag;
        public ObservableCollection<ListModel> LeftStackPanelStatusImag
        {
            get { return _leftStackPanelStatusImag; }
            set { Set(ref _leftStackPanelStatusImag, value); }
        }

        private ObservableCollection<ListModel> _rightStackPanelStatusImag;
        public ObservableCollection<ListModel> RightStackPanelStatusImag
        {
            get { return _rightStackPanelStatusImag; }
            set { Set(ref _rightStackPanelStatusImag, value); }
        }

        private Visibility _visibilityImageView;
        public Visibility VisibilityImageView
        {
            get { return _visibilityImageView; }
            set
            {
                _visibilityImageView = value;
                RaisePropertyChanged(nameof(VisibilityImageView));
            }
        }
        private Visibility _visibilityRightImag;
        public Visibility VisibilityRightImag
        {
            get { return _visibilityRightImag; }
            set
            {
                _visibilityRightImag = value;
                RaisePropertyChanged(nameof(VisibilityRightImag));
            }
        }
        private Visibility _visibilityLeftImag;
        public Visibility VisibilityLeftImag
        {
            get { return _visibilityLeftImag; }
            set
            {
                _visibilityLeftImag = value;
                RaisePropertyChanged(nameof(VisibilityLeftImag));
            }
        }
        private Visibility _visibilityVS;
        public Visibility VisibilityVS
        {
            get { return _visibilityVS; }
            set
            {
                _visibilityVS = value;
                RaisePropertyChanged(nameof(VisibilityVS));
            }
        }

        private string _leftImag;
        public string LeftImag
        {
            get { return _leftImag; }
            set
            {
                _leftImag = value;
                RaisePropertyChanged(nameof(LeftImag));
            }
        }
        private string _leftHP;
        public string LeftHP
        {
            get { return _leftHP; }
            set
            {
                _leftHP = value;
                RaisePropertyChanged(nameof(LeftHP));
            }
        }
        private string _leftDF;
        public string LeftDF
        {
            get { return _leftDF; }
            set
            {
                _leftDF = value;
                RaisePropertyChanged(nameof(LeftDF));
            }
        }
        private string _rightImag;
        public string RightImag
        {
            get { return _rightImag; }
            set
            {
                _rightImag = value;
                RaisePropertyChanged(nameof(RightImag));
            }
        }

        private Visibility _visibilityLogo;
        public Visibility VisibilityLogo
        {
            get { return _visibilityLogo; }
            set
            {
                _visibilityLogo = value;
                RaisePropertyChanged(nameof(VisibilityLogo));
            }
        }
        private string _logoImag;
        public string LogoImag
        {
            get { return _logoImag; }
            set
            {
                _logoImag = value;
                RaisePropertyChanged(nameof(LogoImag));
            }
        }
        private string _historyName;
        public string HistoryName
        {
            get { return _historyName; }
            set
            {
                _historyName = value;
                RaisePropertyChanged(nameof(HistoryName));
            }
        }
        #endregion
    }
}
