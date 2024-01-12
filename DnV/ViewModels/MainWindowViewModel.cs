using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnV.Models;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using DnV.Services;
using System.Windows.Threading;

namespace DnV.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Конструктор

        public MainWindowViewModel()
        {
            //MainWindow = new MainWindow();
            PreVeiwWindow = new PreViewModel();
            BattleVeiwWindow = new BattleViewModel();
            EditorVeiwWindow = new EditorViewModel();
            ComboBoxHistory = Processor.GetHistory(1);
            ComboOk = new RelayCommand(() => LoadHystory());
            BackRoomBtn = new RelayCommand(() => BackRoom());
            NextRoomBtn = new RelayCommand(() => NextRoom());
            ViewEventBtn = new RelayCommand(() => ViewEventList());
            ViewNPCBtn = new RelayCommand(() => ViewNPCList());
            StackPanelEvent = new ObservableCollection<StackPanelEventModel>();
            StackPanelImag = new ObservableCollection<StackPanelImagModel>();
            VisibilityCountEvent = Visibility.Hidden;
            VisibilityCountNPC = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            VisibilityDise = Visibility.Hidden;
            VisiilityHeroList = Visibility.Hidden;
            VisibilityPlaySound = Visibility.Hidden;
            Sound = "";
            Milsec = 0;
            ViewDiseBtn = new RelayCommand(() => ViewDise());
            ShowPreWindow = new RelayCommand(() => ShowPreWindowVM());
            ShowBattleWindow = new RelayCommand(() => ShowBattleWindowVM());
            ShowEditorBtn = new RelayCommand(() => ShowEditorWindowVM());
            ViewLogoBtn = new RelayCommand(() => ViewLogo());
            ShowNPCBtn = new RelayCommand(() => ShowNPC());
            ShowHeroListBtn = new RelayCommand(() => ViewHeroList());
            ListBoxItem = new ObservableCollection<string>();
            D4 = new RelayCommand(() => RndDise(4));
            D6 = new RelayCommand(() => RndDise(6));
            D8 = new RelayCommand(() => RndDise(8));
            D10 = new RelayCommand(() => RndDise(10));
            D12 = new RelayCommand(() => RndDise(12));
            D20 = new RelayCommand(() => RndDise(20));
            D100 = new RelayCommand(() => RndDise(100));
            Event_0 = new RelayCommand(() => OpenEvent(0, orderRoom));
            Event_1 = new RelayCommand(() => OpenEvent(1, orderRoom));
            Event_2 = new RelayCommand(() => OpenEvent(2, orderRoom));
            Event_3 = new RelayCommand(() => OpenEvent(3, orderRoom));
            Event_4 = new RelayCommand(() => OpenEvent(4, orderRoom));
            Event_5 = new RelayCommand(() => OpenEvent(5, orderRoom));
            Event_6 = new RelayCommand(() => OpenEvent(6, orderRoom));
            Event_7 = new RelayCommand(() => OpenEvent(7, orderRoom));
            Event_8 = new RelayCommand(() => OpenEvent(8, orderRoom));
            Event_9 = new RelayCommand(() => OpenEvent(9, orderRoom));
            Event_10 = new RelayCommand(() => OpenEvent(10, orderRoom));
            Imag_0 = new RelayCommand(() => ViewImage(0));
            Imag_1 = new RelayCommand(() => ViewImage(1));
            Imag_2 = new RelayCommand(() => ViewImage(2));
            Imag_3 = new RelayCommand(() => ViewImage(3));
            Imag_4 = new RelayCommand(() => ViewImage(4));
            Imag_5 = new RelayCommand(() => ViewImage(5));
            Imag_6 = new RelayCommand(() => ViewImage(6));
            Push0Btn = new RelayCommand(() => PlayAndStop());
            PlaySoundBtn = new RelayCommand(() => PlayAndStop());
            Push1Btn = new RelayCommand(() => ViewImage(0));
            Push2Btn = new RelayCommand(() => ViewImage(1));
            Push3Btn = new RelayCommand(() => ViewImage(2));
            Push4Btn = new RelayCommand(() => ViewImage(3));
            Push5Btn = new RelayCommand(() => ViewImage(4));
            Push6Btn = new RelayCommand(() => ViewImage(5));
            Push7Btn = new RelayCommand(() => ViewImage(6));
            IconSound = @"C:\Users\genii\source\repos\DnV\DnV\Interface\play.png";
            StartTimer();
            //HtmlToDisplay = "<html><meta charset='UTF-8'><body style='margin: 0; background: #1C1C25; overflow:hidden; color: #AAAAAA; font-size: 30px; font-family: Verdana;'></body></html>";
        }

        #endregion

        #region Методы

        private void TimerTick(object sender, EventArgs e)
        {
            if (Duration == SecTimer)
            {
                media.Stop();
                IconSound = @"C:\Users\genii\source\repos\DnV\DnV\Interface\play.png";  
                PlaySound = false;
                Timer.Stop();
            }
            Duration++;
            LoaderSound(Duration);
        }

        public void StartTimer()
        {
            Timer.Tick += new EventHandler(TimerTick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }

        public void LoaderSound(int Dur)
        {
            double step = 57 / (double)SecTimer;
            LoadSoundRec = step * Dur;
        }

        public void PlayAndStop()
        {
            if (PlaySound)
            {
                media.Stop();
                IconSound = @"C:\Users\genii\source\repos\DnV\DnV\Interface\play.png";
                PlaySound = false;
                Timer.Stop();
                LoadSoundRec = 0;
            }
            else
            {
                Duration = 0;
                LoadSoundRec = 0;
                media.Stop();
                media.Open(Sound);
                media.Play();
                IconSound = @"C:\Users\genii\source\repos\DnV\DnV\Interface\pause.png";
                PlaySound = true;
                SecTimer = Milsec;
                Timer.Start();
            }
        }

        public void ShowNPC()
        {
            PreVeiwWindow.ShowImag(PathNPC + CurrentNPC.Imag);
        }

        public void ViewLogo()
        {
            PreVeiwWindow.ViewLogo();
        }

        public void ShowPreWindowVM()
        {
            if (SelectItemHistory is null)
            {
                MessageBox.Show("Выбери историю");
            }
            else
            {
                PreVeiwWindow.ShowPreWindowVM(SelectItemHistory.Id, SelectItemHistory.Name, SelectItemHistory.Imag);
            }
            
        }

        public void ShowBattleWindowVM()
        {
            //BattleVeiwWindow.ShowBattleWindowVM(4, Rooms.Where(x => x.order == orderRoom).First().id);
            BattleVeiwWindow.ShowBattleWindowVM(SelectItemHistory.Id, Rooms.Where(x => x.order == orderRoom).First().id, PreVeiwWindow, this);
        }
        public void ShowEditorWindowVM()
        {
            EditorVeiwWindow.ShowEditorWindowVM();
        }

        public void LoadHystory()
        {
            if (SelectItemHistory is null)
            {
                MessageBox.Show("Выбери историю");
            }
            else
            {
                Rooms.Clear();
                Events.Clear();
                Rooms = Processor.GetRoom(SelectItemHistory.Id);
                Events = Processor.GetEvent(SelectItemHistory.Id);
                NPCs = Processor.GetNPC(SelectItemHistory.Id);
                HeroTable = new ObservableCollection<BattleModel>(Processor.GetHero(SelectItemHistory.Id));
                PathImag = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + SelectItemHistory.Id + "\\Images\\";
                PathNPC = AppDomain.CurrentDomain.BaseDirectory + "Media\\NPC\\";
                PathSound = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + SelectItemHistory.Id + "\\Sounds\\";
                OpenRoom(orderRoom);
            }
        }

        public void EndBattle(List<BattleModel> list)
        {
            foreach (BattleModel pers in list.Where(x => x.IsNPC == 0).ToList())
            {
                BattleModel hero = HeroTable.Where(x => x.Id == pers.Id).First();
                hero.Health = pers.Health;
            }
        }

        public void OpenRoom(int order)
        {
            RoomModel _room = Rooms.Where(x => x.order == order).First();
            List<EventModel> _events = Events.Where(x => x.roomId == _room.id).ToList();
            NPCTable = new ObservableCollection<BattleModel>(NPCs.Where(x => x.RoomId == _room.id).ToList());
            if (NPCTable.Count() > 0)
            {
                CountNPC = NPCTable.Count();
                VisibilityCountNPC = Visibility.Visible;
            }
            else
            {
                VisibilityCountNPC = Visibility.Hidden;
            }
            //FormatText(_room.text);
            TextRoom = _room.text;
            HeadRoom = _room.name;
            CountEvent = _events.Count();
            VisibilityEventList = Visibility.Hidden;
            AvaNPC = "";
            TextNPC = "";
            if (CountEvent > 0)
            {
                VisibilityCountEvent = Visibility.Visible;
                StackPanelEvent.Clear();
                int eventNum = 1;
                foreach (var even in _events)
                {
                    AddEventButton(even.order, even.name);
                    eventNum++;
                }
            }
            else
            {
                StackPanelEvent.Clear();
                VisibilityCountEvent = Visibility.Hidden;
            }
            AddViewImages(_room.imag);
            Sound = PathSound + _room.sound;
            Milsec = _room.Milsec;
            if (Milsec == 0)
            {
                VisibilityPlaySound = Visibility.Hidden;
            }
            else
            {
                VisibilityPlaySound = Visibility.Visible;
            }
        }

        public void ViewImage(int ord)
        {
            PreVeiwWindow.ShowImag(StackPanelImag[ord].SourceImag);
        }

        public void AddViewImages(string text)
        {
            StackPanelImag.Clear();
            if (text != null)
            { 
                string[] arrayImages = text.Split(';');
                int countImag = 0;
                foreach (var img in arrayImages)
                {
                    switch (countImag)
                    {
                        case 0:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 0,
                                ViewImag = Imag_0
                            });
                            break;
                        case 1:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X=260,
                                ViewImag = Imag_1
                            });
                            break;
                        case 2:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X=520,
                                ViewImag = Imag_2
                            });
                            break;
                        case 3:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 780,
                                ViewImag = Imag_3
                            });
                            break;
                        case 4:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X= 1040,
                                ViewImag = Imag_4
                            });
                            break;
                        case 5:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 1300,
                                ViewImag = Imag_5
                            });
                            break;
                        case 6:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 1560,
                                ViewImag = Imag_6
                            });
                            break;
                    }
                    countImag++;
                }
            }
        }

        public void OpenEvent(int order, int orderRo)
        {
            int id = Rooms.Where(x => x.order == orderRo).First().id;
            EventModel _event = Events.Where(x => x.order == order && x.roomId == id).First();
            //FormatText(_event.text);
            TextRoom = _event.text;
            HeadRoom = _event.name;
            AddViewImages(_event.imag);
            Sound = PathSound + _event.sound;
            Milsec = _event.Milsec;
            if (Milsec == 0)
            {
                VisibilityPlaySound = Visibility.Hidden;
            }
            else
            {
                VisibilityPlaySound = Visibility.Visible;
            }
            VisibilityEventList = Visibility.Hidden;
        }

        public void NextRoom()
        {
            VisibilityEventList = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            VisibilityDise = Visibility.Hidden;
            if (Rooms.Max(x => x.order) >= orderRoom + 1)
            {
                orderRoom++;
                OpenRoom(orderRoom);
            }
        }

        public void BackRoom()
        {
            VisibilityEventList = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            VisibilityDise = Visibility.Hidden;
            if (Rooms.Min(x => x.order) <= orderRoom - 1)
            {
                orderRoom--;
                OpenRoom(orderRoom);
            }
        }

        public void ViewEventList()
        {
            if (VisibilityEventList == Visibility.Hidden)
            {
                VisibilityEventList = Visibility.Visible;
            }
            else
            {
                VisibilityEventList = Visibility.Hidden;
            }
        }

        public void ViewHeroList()
        {
            if (VisiilityHeroList == Visibility.Hidden)
            {
                VisiilityHeroList = Visibility.Visible;
            }
            else
            {
                VisiilityHeroList = Visibility.Hidden;
            }
        }

        public void ViewNPCList()
        {
            if (VisibilityNPCList == Visibility.Hidden)
            {
                VisibilityNPCList = Visibility.Visible;
            }
            else
            {
                VisibilityNPCList = Visibility.Hidden;
            }
        }

        public void ViewDise()
        {
            if (VisibilityDise == Visibility.Hidden)
            {
                VisibilityDise = Visibility.Visible;
            }
            else
            {
                VisibilityDise = Visibility.Hidden;
            }
            CountDise = 1;
            SumDise = 0;
            BeforDise = 0;
            Dise = "";
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

        public void AddEventButton(int order, string name)
        {
            switch(order)
            {
                case 0:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_0
                    });
                    break;
                case 1:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_1
                    });
                    break;
                case 2:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_2
                    });
                    break;
                case 3:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_3
                    });
                    break;
                case 4:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_4
                    });
                    break;
                case 5:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_5
                    });
                    break;
                case 6:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_6
                    });
                    break;
                case 7:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_7
                    });
                    break;
                case 8:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_8
                    });
                    break;
                case 9:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_9
                    });
                    break;
                case 10:
                    StackPanelEvent.Add(new StackPanelEventModel()
                    {
                        NameEventBtn = name,
                        Event = Event_10
                    });
                    break;
            }
        }

        public void Update(object sender, DataGridRowEditEndingEventArgs e)
        {
            var rr = e.Row.Item;
            var r = e.GetType();
        }

        public void ViewNPC()
        {
            if (CurrentNPC != null)
            {
                AvaNPC = PathNPC + CurrentNPC.Imag;
                TextNPC = CurrentNPC.Attack + "" + CurrentNPC.Note + "\n\f" + CurrentNPC.HistoryText;
            };
        }

        public void ViewHero()
        {
            if (CurrentHero != null)
            {
                ListBoxItem.Clear();
                ListBoxItem.Add("Бонус мастерства = " + CurrentHero.SkillBonus);
                ListBoxItem.Add("");
                ListBoxItem.Add("Спасброски");
                ListBoxItem.Add("Сила = " + CurrentHero.PowerSave);
                ListBoxItem.Add("Ловкость = " + CurrentHero.DexteritySave);
                ListBoxItem.Add("Телосложение = " + CurrentHero.EnduranceSave);
                ListBoxItem.Add("Интелект = " + CurrentHero.IntelligenceSave);
                ListBoxItem.Add("Мудрость = " + CurrentHero.WisdomSave);
                ListBoxItem.Add("Харизма = " + CurrentHero.CharismaSave);
                ListBoxItem.Add("");
                ListBoxItem.Add("Навыки");
                ListBoxItem.Add("Акробатика(Лов) = " + CurrentHero.Acrobatics);
                ListBoxItem.Add("Анализ(Инт) = " + CurrentHero.Analysis);
                ListBoxItem.Add("Атлетика(Сил) = " + CurrentHero.Athletics);
                ListBoxItem.Add("Восприятие(Муд) = " + CurrentHero.Perception);
                ListBoxItem.Add("Выживание(Муд) = " + CurrentHero.Survival);
                ListBoxItem.Add("Выступление(Хар) = " + CurrentHero.Performance);
                ListBoxItem.Add("Запугивание(Хар) = " + CurrentHero.Intimidation);
                ListBoxItem.Add("История(Инт) = " + CurrentHero.History);
                ListBoxItem.Add("Ловкость рук(Лов) = " + CurrentHero.SleightOfHand);
                ListBoxItem.Add("Магия(Инт) = " + CurrentHero.Magic);
                ListBoxItem.Add("Медицина(Муд) = " + CurrentHero.Medicine);
                ListBoxItem.Add("Обман(Хар) = " + CurrentHero.Deception);
                ListBoxItem.Add("Природа(Инт) = " + CurrentHero.Nature);
                ListBoxItem.Add("Проницательность(Муд) = " + CurrentHero.Insight);
                ListBoxItem.Add("Религия(Инт) = " + CurrentHero.Religion);
                ListBoxItem.Add("Скрытность(Лов) = " + CurrentHero.Stealth);
                ListBoxItem.Add("Убеждение(Хар) = " + CurrentHero.Persuasion);
                ListBoxItem.Add("Уход за животными(Муд) = " + CurrentHero.AnimalCare);
                //AvaNPC = PathNPC + CurrentNPC.imag;
                //TextNPC = CurrentNPC.attack + "" + CurrentNPC.note;
            };
        }

        //public void FormatText(string _text)
        //{
        //    HtmlToDisplay = "<html><meta charset='UTF-8'><body style='display: flex; margin: 0; background: #1C1C25; color: #AAAAAA; font-size: 30px; font-family: Verdana;'>" + _text + " </body><html>";
        //}
        #endregion

        #region Команды

        public ICommand ComboOk { get; set; }
        public ICommand BackRoomBtn { get; set; }
        public ICommand NextRoomBtn { get; set; }
        public ICommand ViewEventBtn { get; set; }
        public ICommand ViewNPCBtn { get; set; }
        public ICommand ViewDiseBtn { get; set; }
        public ICommand ShowPreWindow { get; set; }
        public ICommand ShowBattleWindow { get; set; }
        public ICommand ViewLogoBtn { get; set; }
        public ICommand ShowNPCBtn { get; set; }
        public ICommand ShowEditorBtn { get; set; }
        public ICommand ShowHeroListBtn { get; set; }
        public ICommand D4 { get; set; }
        public ICommand D6 { get; set; }
        public ICommand D8 { get; set; }
        public ICommand D10 { get; set; }
        public ICommand D12 { get; set; }
        public ICommand D20 { get; set; }
        public ICommand D100 { get; set; }
        public ICommand Event_0 { get; set; }
        public ICommand Event_1 { get; set; }
        public ICommand Event_2 { get; set; }
        public ICommand Event_3 { get; set; }
        public ICommand Event_4 { get; set; }
        public ICommand Event_5 { get; set; }
        public ICommand Event_6 { get; set; }
        public ICommand Event_7 { get; set; }
        public ICommand Event_8 { get; set; }
        public ICommand Event_9 { get; set; }
        public ICommand Event_10 { get; set; }
        public ICommand Imag_0 { get; set; }
        public ICommand Imag_1 { get; set; }
        public ICommand Imag_2 { get; set; }
        public ICommand Imag_3 { get; set; }
        public ICommand Imag_4 { get; set; }
        public ICommand Imag_5 { get; set; }
        public ICommand Imag_6 { get; set; }
        public ICommand Push0Btn { get; set; }
        public ICommand Push1Btn { get; set; }
        public ICommand Push2Btn { get; set; }
        public ICommand Push3Btn { get; set; }
        public ICommand Push4Btn { get; set; }
        public ICommand Push5Btn { get; set; }
        public ICommand Push6Btn { get; set; }
        public ICommand Push7Btn { get; set; }
        public ICommand PlaySoundBtn { get; set; }

        #endregion

        #region Свойства

        public DispatcherTimer Timer = new DispatcherTimer();
        public Media media = new Media();

        List<RoomModel> Rooms = new List<RoomModel>();
        List<EventModel> Events = new List<EventModel>();
        List<BattleModel> NPCs = new List<BattleModel>();
        
        //public MainWindow MainWindow { get; set; }

        public PreViewModel PreVeiwWindow { get; set; }
        public BattleViewModel BattleVeiwWindow { get; set; }
        public EditorViewModel EditorVeiwWindow { get; set; }
        public int orderRoom = 1;
        public int BeforDise = 0;
        public int CountDise = 1;
        public int SumDise = 0;
        public int Duration = 0;
        public int SecTimer = 0;
        public int Milsec = 0;


        public string PathImag = "";
        public string PathNPC = "";
        public string PathSound = "";

        public bool PlaySound = false;

        private ObservableCollection<string> _listBoxItem;
        public ObservableCollection<string> ListBoxItem
        {
            get { return _listBoxItem; }
            set
            {
                _listBoxItem = value;

                RaisePropertyChanged(nameof(ListBoxItem));
            }
        }

        private ObservableCollection<StackPanelEventModel> _stackPanelEvent;
        public ObservableCollection<StackPanelEventModel> StackPanelEvent
        {
            get { return _stackPanelEvent; }
            set { Set(ref _stackPanelEvent, value); }
        }
        private ObservableCollection<StackPanelImagModel> _stackPanelImag;
        public ObservableCollection<StackPanelImagModel> StackPanelImag
        {
            get { return _stackPanelImag; }
            set { Set(ref _stackPanelImag, value); }
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

        private double _loadSoundRec;
        public double LoadSoundRec
        {
            get { return _loadSoundRec; }
            set
            {
                _loadSoundRec = value;

                RaisePropertyChanged(nameof(LoadSoundRec));
            }
        }

        private string _iconSound;
        public string IconSound
        {
            get { return _iconSound; }
            set
            {
                _iconSound = value;

                RaisePropertyChanged(nameof(IconSound));
            }
        }

        private string _sound;
        public string Sound
        {
            get { return _sound; }
            set
            {
                _sound = value;

                RaisePropertyChanged(nameof(Sound));
            }
        }

        private string _headRoom;
        public string HeadRoom
        {
            get { return _headRoom; }
            set
            {
                _headRoom = value;

                RaisePropertyChanged(nameof(HeadRoom));
            }
        }

        private string _textRoom;
        public string TextRoom
        {
            get { return _textRoom; }
            set
            {
                _textRoom = value;

                RaisePropertyChanged(nameof(TextRoom));
            }
        }

        private string _avaNPC;
        public string AvaNPC
        {
            get { return _avaNPC; }
            set
            {
                _avaNPC = value;

                RaisePropertyChanged(nameof(AvaNPC));
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

        private HistoryModel _selectItemHistory;
        public HistoryModel SelectItemHistory
        {
            get { return _selectItemHistory; }
            set
            {
                _selectItemHistory = value;

                RaisePropertyChanged(nameof(SelectItemHistory));
            }
        }

        private List<HistoryModel> _comboBoxHistorym;
        public List<HistoryModel> ComboBoxHistory
        {
            get { return _comboBoxHistorym; }
            set
            {
                _comboBoxHistorym = value;

                RaisePropertyChanged(nameof(ComboBoxHistory));
            }
        }

        private Visibility _visibilityDise;
        public Visibility VisibilityDise
        {
            get { return _visibilityDise; }
            set
            {
                _visibilityDise = value;

                RaisePropertyChanged(nameof(VisibilityDise));
            }
        }

        private Visibility _visibilityEventList;
        public Visibility VisibilityEventList
        {
            get { return _visibilityEventList; }
            set
            {
                _visibilityEventList = value;

                RaisePropertyChanged(nameof(VisibilityEventList));
            }
        }

        private Visibility _visibilityNPCList;
        public Visibility VisibilityNPCList
        {
            get { return _visibilityNPCList; }
            set
            {
                _visibilityNPCList = value;

                RaisePropertyChanged(nameof(VisibilityNPCList));
            }
        }

        private Visibility _visibilityPlaySound;
        public Visibility VisibilityPlaySound
        {
            get { return _visibilityPlaySound; }
            set
            {
                _visibilityPlaySound = value;

                RaisePropertyChanged(nameof(VisibilityPlaySound));
            }
        }

        private Visibility _visibilityCountEvent;
        public Visibility VisibilityCountEvent
        {
            get { return _visibilityCountEvent; }
            set
            {
                _visibilityCountEvent = value;

                RaisePropertyChanged(nameof(VisibilityCountEvent));
            }
        }

        private int _countEvent;
        public int CountEvent
        {
            get { return _countEvent; }
            set
            {
                _countEvent = value;

                RaisePropertyChanged(nameof(CountEvent));
            }
        }

        private Visibility _visibilityCountNPC;
        public Visibility VisibilityCountNPC
        {
            get { return _visibilityCountNPC; }
            set
            {
                _visibilityCountNPC = value;

                RaisePropertyChanged(nameof(VisibilityCountNPC));
            }
        }

        private Visibility _visiilityHeroList;
        public Visibility VisiilityHeroList
        {
            get { return _visiilityHeroList; }
            set
            {
                _visiilityHeroList = value;

                RaisePropertyChanged(nameof(VisiilityHeroList));
            }
        }

        private int _countNPC;
        public int CountNPC
        {
            get { return _countNPC; }
            set
            {
                _countNPC = value;

                RaisePropertyChanged(nameof(CountNPC));
            }
        }

        #endregion
    }
}
