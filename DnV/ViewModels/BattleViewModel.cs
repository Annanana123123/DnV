using DnV.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DnV.ViewModels
{
    public class BattleViewModel : ViewModelBase
    {
        #region Конструктор

        public BattleViewModel()
        {
            PreVeiwWindow = new PreViewModel();
            D4 = new RelayCommand(() => RndDise(4));
            D6 = new RelayCommand(() => RndDise(6));
            D8 = new RelayCommand(() => RndDise(8));
            D10 = new RelayCommand(() => RndDise(10));
            D12 = new RelayCommand(() => RndDise(12));
            D20 = new RelayCommand(() => RndDise(20));
            D100 = new RelayCommand(() => RndDise(100));
            ViewVSBtn = new RelayCommand(() => ViewVS());
            ViewLogoBtn = new RelayCommand(() => ViewLogo());
            NextRoundBtn = new RelayCommand(() => NextRound());
            ColorBackLabel = "#12131A";
            LeftDamageBtn = new RelayCommand(() => Damage(0));
            RightDamageBtn = new RelayCommand(() => Damage(1));

            EndBattleBtn = new RelayCommand(() => EndBattle());
            RStatusBtn_1 = new RelayCommand(() => AddStatus(1,1));
            LStatusBtn_1 = new RelayCommand(() => AddStatus(1,0));
            RStatusBtn_2 = new RelayCommand(() => AddStatus(2,1));
            LStatusBtn_2 = new RelayCommand(() => AddStatus(2,0));
            RStatusBtn_3 = new RelayCommand(() => AddStatus(3,1));
            LStatusBtn_3 = new RelayCommand(() => AddStatus(3,0));
            RStatusBtn_4 = new RelayCommand(() => AddStatus(4,1));
            LStatusBtn_4 = new RelayCommand(() => AddStatus(4,0));
            RStatusBtn_5 = new RelayCommand(() => AddStatus(5,1));
            LStatusBtn_5 = new RelayCommand(() => AddStatus(5,0));
            RStatusBtn_6 = new RelayCommand(() => AddStatus(6,1));
            LStatusBtn_6 = new RelayCommand(() => AddStatus(6,0));
            RStatusBtn_7 = new RelayCommand(() => AddStatus(7,1));
            LStatusBtn_7 = new RelayCommand(() => AddStatus(7,0));
            RStatusBtn_8 = new RelayCommand(() => AddStatus(8,1));
            LStatusBtn_8 = new RelayCommand(() => AddStatus(8,0));
            RStatusBtn_9 = new RelayCommand(() => AddStatus(9,1));
            LStatusBtn_9 = new RelayCommand(() => AddStatus(9,0));
            RStatusBtn_10 = new RelayCommand(() => AddStatus(10,1));
            LStatusBtn_10 = new RelayCommand(() => AddStatus(10,0));
            RStatusBtn_11 = new RelayCommand(() => AddStatus(11,1));
            LStatusBtn_11 = new RelayCommand(() => AddStatus(11,0));
            RStatusBtn_12 = new RelayCommand(() => AddStatus(12,1));
            LStatusBtn_12 = new RelayCommand(() => AddStatus(12,0));
            RStatusBtn_13 = new RelayCommand(() => AddStatus(13,1));
            LStatusBtn_13 = new RelayCommand(() => AddStatus(13,0));
            RStatusBtn_14 = new RelayCommand(() => AddStatus(14,1));
            LStatusBtn_14 = new RelayCommand(() => AddStatus(14,0));
            RStatusBtn_15 = new RelayCommand(() => AddStatus(15,1));
            LStatusBtn_15 = new RelayCommand(() => AddStatus(15,0));
            RStatusBtn_16 = new RelayCommand(() => AddStatus(16,1));
            LStatusBtn_16 = new RelayCommand(() => AddStatus(16,0));
            RStatusBtn_17 = new RelayCommand(() => AddStatus(17,1));
            LStatusBtn_17 = new RelayCommand(() => AddStatus(17,0));
            RStatusBtn_18 = new RelayCommand(() => AddStatus(18,1));
            LStatusBtn_18 = new RelayCommand(() => AddStatus(18,0));
            RStatusBtn_19 = new RelayCommand(() => AddStatus(19,1));
            LStatusBtn_19 = new RelayCommand(() => AddStatus(19,0));
            RStatusBtn_20 = new RelayCommand(() => ClearStatus(1));
            LStatusBtn_20 = new RelayCommand(() => ClearStatus(0));
            InitiativeBtn = new RelayCommand(() => CalcInitiative());
            AllNPCBtn = new RelayCommand(() => ViewLRTablePerson(Person));
            //NextStep = new RelayCommand(() => AddStackPanelStatusImag(1));
            LeftStackPanelStatusImag = new ObservableCollection<ListModel>();
            RightStackPanelStatusImag = new ObservableCollection<ListModel>();
        }

        #endregion

        #region Методы

        public void EndBattle()
        {
            PreVeiwWindow.NoShowVs();
            Main.EndBattle(Person);
            bv.Close();
            //CloseAction();
        }

        public void Damage(int isNPC)
        {
            if (isNPC == 0)
            {
                CurrentHero.Health -= Convert.ToInt32(LeftCountDamage);
                LeftHP = CurrentHero.Health.ToString();
                PreVeiwWindow.LeftHP = CurrentHero.Health.ToString();
            }
            else
            {
                CurrentNPC.Health -= Convert.ToInt32(RightCountDamage);
                RightHP = CurrentNPC.Health.ToString();
            }
        }

        public void NextRound()
        {
            foreach (BattleModel her in HeroTable)
            {
                if(her.Status.Count()>0)
                {
                    ActionByStatus(her);
                }
            }
        }

        public void ActionByStatus(BattleModel person)
        {
            foreach(ListModel status in person.Status)
            {
                switch(status.Id)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                }
            }
        }

        public void ClearStatus(int n)
        {
            if (n == 0)
            {
                CurrentHero.Status.Clear();
                LeftStackPanelStatusImag.Clear();
                PreVeiwWindow.LeftStackPanelStatusImag.Clear();
            }
            else
            {
                CurrentNPC.Status.Clear();
                RightStackPanelStatusImag.Clear();
                PreVeiwWindow.RightStackPanelStatusImag.Clear();
            }
        }

        public void ViewLogo()
        {
            PreVeiwWindow.ViewLogo();
        }

        public void ViewVS()
        {
            if(PreVeiwWindow.VisibilityVS == Visibility.Hidden)
            {
                PreVeiwWindow.ShowVs();
                ColorBackLabel = "#FF0000";
            }
            else
            {
                PreVeiwWindow.NoShowVs();
                ColorBackLabel = "#12131A";
            }
            
        }

        public void AddStatus(int n, int isNPC)
        {
            BattleModel OnePerson = new BattleModel();
            if (isNPC == 0)
            {
                OnePerson = Person.Where(x => x.Id == CurrentHero.Id && x.IsNPC == isNPC).First();
            }
            else
            {
                OnePerson = Person.Where(x => x.Id == CurrentNPC.Id && x.IsNPC == isNPC).First();
            }
            ListModel oneStatus = Statuses.Where(x => x.Id == n).First();
            OnePerson.Status.Add(new ListModel()
            {
                Id = n,
                Imag = @"C:\Users\genii\source\repos\DnV\DnV\bin\Debug\Media\Interface\status_" + n + ".png",
                Name = oneStatus.Name,
                Text = oneStatus.Text
            });
            
            
            AddStackPanelStatusImag(n, isNPC);
            PreVeiwWindow.AddStackPanelStatusImag(n, isNPC);
        }

        public void AddStackPanelStatusImag(int n, int isNPC)
        {
            ListModel oneStatus = Statuses.Where(x => x.Id == n).First();
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

        public void ShowBattleWindowVM(int _historyId, int _currentRoomId, PreViewModel preView, MainWindowViewModel MainWindow)
        {
            HistoryId = _historyId;
            RoomId = _currentRoomId;
            PreVeiwWindow = preView;
            bv = new BattleView(this);
            bv.Show();
            Person = Processor.GetBattlePerson(HistoryId);
            ViewLRTablePerson(Person, RoomId);
            //PathImag = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + n + "\\Images\\";
            //PathStatus = AppDomain.CurrentDomain.BaseDirectory + "Media\\Interface\\";
            PathHero = AppDomain.CurrentDomain.BaseDirectory + "Media\\Heros\\";
            PathNPC = AppDomain.CurrentDomain.BaseDirectory + "Media\\NPC\\";
            Statuses = Processor.GetStatus();
            Main = MainWindow;
            //VersusVisibility = Visibility.Visible;
        }

        public void CalcInitiative()
        {
            List<BattleModel> _battle = Person.Where(x => x.Initiative != 0).OrderByDescending(x => x.Initiative).ToList();
            int _order = 1;
            foreach (var bat in _battle)
            {
                bat.Initiative = _order;
                _order++;
            }
            ViewLRTablePerson(_battle);
        }

        public void ViewLRTablePerson(List<BattleModel> Battle, int currentRoomId = 0)
        {
            HeroTable = new ObservableCollection<BattleModel>(Battle.Where(x => x.IsNPC == 0).OrderBy(x => x.Initiative).ToList());
            if (currentRoomId == 0)
            {
                NPCTable = new ObservableCollection<BattleModel>(Battle.Where(x => x.IsNPC == 1).OrderBy(x => x.Initiative).ToList());
            }
            else
            {
                NPCTable = new ObservableCollection<BattleModel>(Battle.Where(x => x.IsNPC == 1 && x.RoomId == currentRoomId).OrderBy(x => x.Initiative).ToList());
            }
        }

        public void RndDise(int dise)
        {
            if (BeforDise == dise)
            {
                Random rnd = new Random();
                SumDise += rnd.Next(1, dise + 1);
                CountDise++;
                Dise = CountDise + "D" + dise + " = " + SumDise;
            }
            else
            {
                CountDise = 1;
                SumDise = 0;
                BeforDise = dise;
                Random rnd = new Random();
                SumDise = rnd.Next(1, dise + 1);
                Dise = CountDise + "D" + dise + " = " + SumDise;
            }
        }

        public void ViewNPC()
        {
            if (CurrentNPC != null)
            {
                RightSourceImag = PathNPC + CurrentNPC.Imag;
                RightDF = CurrentNPC.Defence.ToString();
                RightHP = CurrentNPC.Health.ToString();
                TextNPC = "";
                foreach (var text in CurrentNPC.Status)
                {
                    TextNPC += text.Name + "\n" + text.Text + "\n\r";
                }
                TextNPC = CurrentNPC.Attack + "" + CurrentNPC.Note;
                RightStackPanelStatusImag.Clear();
                PreVeiwWindow.ViewRightImag(CurrentNPC.Imag, CurrentNPC.Status);
                //PreVeiwWindow.ImageView=PathNPC + CurrentNPC.Imag;
                foreach (var curr in CurrentNPC.Status)
                {
                    AddStackPanelStatusImag(curr.Id, 1);
                }
            };
        }
        public void ViewHero()
        {
            if (CurrentHero != null)
            {
                LeftSourceImag = PathHero + CurrentHero.Imag;
                LeftStackPanelStatusImag.Clear();
                LeftDF = CurrentHero.Defence.ToString();
                LeftHP = CurrentHero.Health.ToString();
                TextHero = "";
                foreach(var text in CurrentHero.Status)
                {
                    TextHero += text.Name + "\n" + text.Text + "\n\r";
                }
                
                PreVeiwWindow.ViewLeftImag(CurrentHero.Imag, CurrentHero.Defence, CurrentHero.Health, CurrentHero.Status);
                foreach (var curr in CurrentHero.Status)
                {
                    AddStackPanelStatusImag(curr.Id, 0);
                }
                //TextNPC = CurrentNPC.attack + "" + CurrentNPC.note;
            };
        }

        public void Update(object sender, DataGridRowEditEndingEventArgs e)
        {
            var rr = e.Row.Item;
            var r = e.GetType();
        }

        #endregion

        #region Свойства
        public int HistoryId = 0;
        public int RoomId = 0;

        public int BeforDise = 0;
        public int CountDise = 1;
        public int SumDise = 0;

        string PathNPC = "";
        string PathHero = "";

        public MainWindowViewModel Main { get; set; }

        public PreViewModel PreVeiwWindow { get; set; }

        public BattleView bv { get; set; }

        List<ListModel> Statuses = new List<ListModel>();

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

        private string _rightHP;
        public string RightHP
        {
            get { return _rightHP; }
            set
            {
                _rightHP = value;

                RaisePropertyChanged(nameof(RightHP));
            }
        }
        private string _rightDF;
        public string RightDF
        {
            get { return _rightDF; }
            set
            {
                _rightDF = value;

                RaisePropertyChanged(nameof(RightDF));
            }
        }

        private string _leftCountDamage;
        public string LeftCountDamage
        {
            get { return _leftCountDamage; }
            set
            {
                _leftCountDamage = value;

                RaisePropertyChanged(nameof(LeftCountDamage));
            }
        }
        private string _rightCountDamage;
        public string RightCountDamage
        {
            get { return _rightCountDamage; }
            set
            {
                _rightCountDamage = value;

                RaisePropertyChanged(nameof(RightCountDamage));
            }
        }

        private string _textNPC;
        public string TextNPC
        {
            get { return _textNPC; }
            set
            {
                _textNPC = value;

                RaisePropertyChanged(nameof(TextNPC));
            }
        }

        private string _textHero;
        public string TextHero
        {
            get { return _textHero; }
            set
            {
                _textHero = value;

                RaisePropertyChanged(nameof(TextHero));
            }
        }

        private string _rightSourceImag;
        public string RightSourceImag
        {
            get { return _rightSourceImag; }
            set
            {
                _rightSourceImag = value;

                RaisePropertyChanged(nameof(RightSourceImag));
            }
        }

        private string _lefSourceImag;
        public string LeftSourceImag
        {
            get { return _lefSourceImag; }
            set
            {
                _lefSourceImag = value;

                RaisePropertyChanged(nameof(LeftSourceImag));
            }
        }

        private string _dise;
        public string Dise
        {
            get { return _dise; }
            set
            {
                _dise = value;

                RaisePropertyChanged(nameof(Dise));
            }
        }

        private string _colorBackLabel;
        public string ColorBackLabel
        {
            get { return _colorBackLabel; }
            set
            {
                _colorBackLabel = value;

                RaisePropertyChanged(nameof(ColorBackLabel));
            }
        }

        private BattleModel _currentNPC;
        public BattleModel CurrentNPC
        {
            get { return _currentNPC; }
            set
            {
                _currentNPC = value;
                ViewNPC();
            }
        }
        private BattleModel _currentHero;
        public BattleModel CurrentHero
        {
            get { return _currentHero; }
            set
            {
                _currentHero = value;
                ViewHero();
            }
        }

        private ObservableCollection<BattleModel> _heroTable;
        public ObservableCollection<BattleModel> HeroTable
        {
            get { return _heroTable; }
            set
            {
                _heroTable = value;

                RaisePropertyChanged(nameof(HeroTable));
            }
        }

        private ObservableCollection<BattleModel> _npcTable;
        public ObservableCollection<BattleModel> NPCTable
        {
            get { return _npcTable; }
            set
            {
                _npcTable = value;

                RaisePropertyChanged(nameof(NPCTable));
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

        private List<BattleModel> _person;
        public List<BattleModel> Person
        {
            get { return _person; }
            set
            {
                _person = value;

                RaisePropertyChanged(nameof(Person));
            }
        }

        #endregion

        #region Команды

        public ICommand D4 { get; set; }
        public ICommand D6 { get; set; }
        public ICommand D8 { get; set; }
        public ICommand D10 { get; set; }
        public ICommand D12 { get; set; }
        public ICommand D20 { get; set; }
        public ICommand D100 { get; set; }
        public ICommand InitiativeBtn { get; set; }
        public ICommand AllNPCBtn { get; set; }
        public ICommand NextStep { get; set; }
        public ICommand ViewVSBtn { get; set; }
        public ICommand ViewLogoBtn { get; set; }
        public ICommand ClearStatusBtn { get; set; }
        public ICommand LeftDamageBtn { get; set; }
        public ICommand RightDamageBtn { get; set; }
        public ICommand NextRoundBtn { get; set; }
        public ICommand EndBattleBtn { get; set; }
        public ICommand RStatusBtn_1 { get; set; }
        public ICommand LStatusBtn_1 { get; set; }
        public ICommand RStatusBtn_2 { get; set; }
        public ICommand LStatusBtn_2 { get; set; }
        public ICommand RStatusBtn_3 { get; set; }
        public ICommand LStatusBtn_3 { get; set; }
        public ICommand RStatusBtn_4 { get; set; }
        public ICommand LStatusBtn_4 { get; set; }
        public ICommand RStatusBtn_5 { get; set; }
        public ICommand LStatusBtn_5 { get; set; }
        public ICommand RStatusBtn_6 { get; set; }
        public ICommand LStatusBtn_6 { get; set; }
        public ICommand RStatusBtn_7 { get; set; }
        public ICommand LStatusBtn_7 { get; set; }
        public ICommand RStatusBtn_8 { get; set; }
        public ICommand LStatusBtn_8 { get; set; }
        public ICommand RStatusBtn_9 { get; set; }
        public ICommand LStatusBtn_9 { get; set; }
        public ICommand RStatusBtn_10 { get; set; }
        public ICommand LStatusBtn_10 { get; set; }
        public ICommand RStatusBtn_11 { get; set; }
        public ICommand LStatusBtn_11 { get; set; }
        public ICommand RStatusBtn_12 { get; set; }
        public ICommand LStatusBtn_12 { get; set; }
        public ICommand RStatusBtn_13 { get; set; }
        public ICommand LStatusBtn_13 { get; set; }
        public ICommand RStatusBtn_14 { get; set; }
        public ICommand LStatusBtn_14 { get; set; }
        public ICommand RStatusBtn_15 { get; set; }
        public ICommand LStatusBtn_15 { get; set; }
        public ICommand RStatusBtn_16 { get; set; }
        public ICommand LStatusBtn_16 { get; set; }
        public ICommand RStatusBtn_17 { get; set; }
        public ICommand LStatusBtn_17 { get; set; }
        public ICommand RStatusBtn_18 { get; set; }
        public ICommand LStatusBtn_18 { get; set; }
        public ICommand RStatusBtn_19{ get; set; }
        public ICommand LStatusBtn_19 { get; set; }
        public ICommand RStatusBtn_20 { get; set; }
        public ICommand LStatusBtn_20 { get; set; }

        #endregion
    }
}
