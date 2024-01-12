using DnV.Models;
using DnV.Views;
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
    public class EditorViewModel : ViewModelBase
    {
        #region Конструктор

        public EditorViewModel()
        {
            Update();
            NewHistorySaveBtn = new RelayCommand(() => NewHistorySave());
            HistorySaveBtn = new RelayCommand(() => HistorySave());
            ComboOk = new RelayCommand(() => LoadHystory());
            VisibilityCountEvent = Visibility.Hidden;
            VisibilityCountNPC = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            VisibilityNPCEditor = Visibility.Hidden;
            VisibilityDise = Visibility.Hidden;
            VisibilityHistoryEditor = Visibility.Hidden;
            VisibilityRoomEditor = Visibility.Hidden;
            VisibilityEventEditor = Visibility.Hidden;
            VisibilityHeroEditor = Visibility.Hidden;
            VisiilityNPCInRoomEditor = Visibility.Hidden;
            NewHistoryBtn = new RelayCommand(() => NewHistory());
            SaveRoomBtn = new RelayCommand(() => SaveRoom());
            CloseRoomBtn = new RelayCommand(() => CloseRoom());
            NewRoomBtn = new RelayCommand(() => NewRoom());
            NewEventBtn = new RelayCommand(() => NewEvent());
            StackPanelEvent = new ObservableCollection<StackPanelEventModel>();
            StackPanelImag = new ObservableCollection<StackPanelImagModel>();
            BackRoomBtn = new RelayCommand(() => BackRoom());
            NextRoomBtn = new RelayCommand(() => NextRoom());
            SaveEventBtn = new RelayCommand(() => SaveEvent());
            ViewEventBtn = new RelayCommand(() => ViewEventList());
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
            SaveHeroBtn = new RelayCommand(() => SavePerson());
            ShowListHeroBtn = new RelayCommand(() => ShowListHero(0));
            ShowListNPCBtn = new RelayCommand(() => ShowListHero(1));
            NewHeroBtn = new RelayCommand(() => NewHero());
            ShowListNPCInRoomBtn = new RelayCommand(() => ShowListNPCInRoom());
            SaveNPCBtn = new RelayCommand(() => SaveNPC());
            NewNPCBtn = new RelayCommand(() => NewNPC());
            ViewNPCBtn = new RelayCommand(() => ViewNPCList());
            ColorRedBtn = new RelayCommand(() => ColoredText(1));
            ColorGreenBtn = new RelayCommand(() => ColoredText(2));
            ColorYellowBtn = new RelayCommand(() => ColoredText(3));
        }

        #endregion

        #region Методы

        public void ColoredText(int color)
        {
            switch (color)
            {
                case 1:
                    TextRoom += "<p><span style='color: #FF0000;'></span></p>";
                    break;
                case 2:
                    TextRoom += "<p><span style='color: #00FF00;'></span></p>";
                    break;
                case 3:
                    TextRoom += "<p><span style='color: #FFFF00;'></span></p>";
                    break;
            }
            
        }

        public void SaveNPC()
        {
            BattleModel Person = new BattleModel();
            Person.Id = Convert.ToInt32(IdNPC);
            Person.NPCId = SelectItemNPC.Id;
            Person.RoomId = SelectItemRoom.id;
            Person.Name = NameNPC;
            Person.Imag = ImagNPC;
            if (DefenceNPC != "")
            {
                Person.Defence = Convert.ToInt32(DefenceNPC);
            }
            if (HealthNPC != "")
            {
                Person.Health = Convert.ToInt32(HealthNPC);
            }
            
            Person.Note = NoteNPC;
            Person.HistoryText = HistoryNPC;
            Processor.SetNPCInRoom(Person);
        }

        public void NewNPC()
        {
            IdNPC = "0";
            SelectItemNPC = null;
            SelectItemRoom = null;
            NameNPC = "";
            ImagNPC = "";
            DefenceNPC = "";
            HealthNPC = "";
            NoteNPC = "";
            HistoryNPC = "";
        }

        public void ShowListNPCInRoom()
        {
            VisibilityRoomEditor = Visibility.Hidden;
            VisibilityEventEditor = Visibility.Hidden;
            VisibilityHistoryEditor = Visibility.Hidden;
            VisibilityHeroEditor = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            if (SelectItemHistory is null)
            {
                MessageBox.Show("Выбери историю!");
            }
            else
            {
                if (VisiilityNPCInRoomEditor == Visibility.Hidden)
                {
                    ComboBoxNPC = Processor.GetNPCComboBox();
                    ComboBoxRoom = Processor.GetRoom(SelectItemHistory.Id);
                    NPCListTable = new ObservableCollection<BattleModel>(Processor.GetNPC(SelectItemHistory.Id));
                    VisiilityNPCInRoomEditor = Visibility.Visible;
                    IdNPC = "0";
                    NameNPC = "";
                    ImagNPC = "";
                    DefenceNPC = "";
                    HealthNPC = "";
                    NoteNPC = "";
                    HistoryNPC = "";
                }
                else
                {
                    VisiilityNPCInRoomEditor = Visibility.Hidden;
                }
            }
        }

        public void NewHero()
        {
            
            IdHero = "0";
            //HistoryId = CurrentHero.HistoryId
            NameHero = "Имя героя";
            NameUserHero = "Имя игрока";
            ImagHero = "Картинка";
            SpeciesHero = "Раса";
            ClassHero = "Класс";
            NoteHero = "Заметки";
            DefenceHero = "0";
            HealthHero = "0";
            PowerHero = "0";
            PowerModHero = "0";
            PowerSave = "0";
            DexterityHero = "0";
            DexterityModHero = "0";
            DexteritySave = "0";
            EnduranceHero = "0";
            EnduranceModHero = "0";
            EnduranceSave = "0";
            IntelligenceHero = "0";
            IntelligenceModHero = "0";
            IntelligenceSave = "0";
            WisdomHero = "0";
            WisdomModHero = "0";
            WisdomSave = "0";
            CharismaHero = "0";
            CharismaModHero = "0";
            CharismaSave = "0";
            PassivWisdomHero = "0";
            SkillBonusHero = "0";
            Acrobatics = "0";
            Analysis = "0";
            Athletics = "0";
            Perception = "0";
            Survival = "0";
            Performance = "0";
            Intimidation = "0";
            History = "0";
            SleightOfHand = "0";
            Magic = "0";
            Medicine = "0";
            Deception = "0";
            Nature = "0";
            Insight = "0";
            Religion = "0";
            Stealth = "0";
            Persuasion = "0";
            AnimalCare = "0";
            AttackHero = "";
        }

        public void ShowListHero(int isNPC)
        {
            VisibilityHistoryEditor = Visibility.Hidden;
            VisibilityEventEditor = Visibility.Hidden;
            VisibilityRoomEditor = Visibility.Hidden;
            VisiilityNPCInRoomEditor = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            IsNPCFlag = isNPC;
            if (VisibilityHeroEditor == Visibility.Hidden)
            {
                if (isNPC == 0)
                {
                    AttackHero = "";
                    HeroTable = new ObservableCollection<BattleModel>(Processor.GetHero());
                }
                else
                {
                    AttackHero = "";
                    HeroTable = new ObservableCollection<BattleModel>(Processor.GetNPCEditor());
                }
                VisibilityHeroEditor = Visibility.Visible;
            }
            else
            {
                VisibilityHeroEditor = Visibility.Hidden;
            }
        }

        public void ViewHero()
        {
            IdHero = CurrentHero.Id.ToString();
            if (CurrentHero.IsNPC == 0)
            {
                SelectItemHistoryPerson = ComboBoxHistory.Where(x => x.Id == CurrentHero.HistoryId).First();
            }
            NameHero = CurrentHero.Name;
            NameUserHero = CurrentHero.NameUser;
            ImagHero = CurrentHero.Imag;
            SpeciesHero = CurrentHero.Species;
            ClassHero = CurrentHero.ClassPerson;
            NoteHero = CurrentHero.Note;
            DefenceHero = CurrentHero.Defence.ToString();
            HealthHero = CurrentHero.Health.ToString();
            PowerHero = CurrentHero.Power.ToString();
            PowerModHero = CurrentHero.PowerMod.ToString();
            PowerSave = CurrentHero.PowerSave.ToString();
            DexterityHero = CurrentHero.Dexterity.ToString();
            DexterityModHero = CurrentHero.DexterityMod.ToString();
            DexteritySave = CurrentHero.DexteritySave.ToString();
            EnduranceHero = CurrentHero.Endurance.ToString();
            EnduranceModHero = CurrentHero.EnduranceMod.ToString();
            EnduranceSave = CurrentHero.EnduranceSave.ToString();
            IntelligenceHero = CurrentHero.Intelligence.ToString();
            IntelligenceModHero = CurrentHero.IntelligenceMod.ToString();
            IntelligenceSave = CurrentHero.IntelligenceSave.ToString();
            WisdomHero = CurrentHero.Wisdom.ToString();
            WisdomModHero = CurrentHero.WisdomMod.ToString();
            WisdomSave = CurrentHero.WisdomSave.ToString();
            CharismaHero = CurrentHero.Charisma.ToString();
            CharismaModHero = CurrentHero.CharismaMod.ToString();
            CharismaSave = CurrentHero.CharismaSave.ToString();
            PassivWisdomHero = CurrentHero.PassivWisdom.ToString();
            SkillBonusHero = CurrentHero.SkillBonus.ToString();
            Acrobatics = CurrentHero.Acrobatics.ToString();
            Analysis = CurrentHero.Analysis.ToString();
            Athletics = CurrentHero.Athletics.ToString();
            Perception = CurrentHero.Perception.ToString();
            Survival = CurrentHero.Survival.ToString();
            Performance = CurrentHero.Performance.ToString();
            Intimidation = CurrentHero.Intimidation.ToString();
            History = CurrentHero.History.ToString();
            SleightOfHand = CurrentHero.SleightOfHand.ToString();
            Magic = CurrentHero.Magic.ToString();
            Medicine = CurrentHero.Medicine.ToString();
            Deception = CurrentHero.Deception.ToString();
            Nature = CurrentHero.Nature.ToString();
            Insight = CurrentHero.Insight.ToString();
            Religion = CurrentHero.Religion.ToString();
            Stealth = CurrentHero.Stealth.ToString();
            Persuasion = CurrentHero.Persuasion.ToString();
            AnimalCare = CurrentHero.AnimalCare.ToString();
            if (CurrentHero.IsNPC == 0)
            {
                AttackHero = "";
            }
            else
            {
                AttackHero = CurrentHero.Attack.ToString();
            }
            
        }

        public void SavePerson()
        {
            BattleModel Person = new BattleModel();
            Person.Id = Convert.ToInt32(IdHero);
            if (IsNPCFlag == 0)
            {
                Person.HistoryId = SelectItemHistoryPerson.Id;
            }
            Person.Name = NameHero;
            Person.NameUser = NameUserHero;
            Person.Imag = ImagHero;
            Person.Species = SpeciesHero;
            Person.ClassPerson = ClassHero;
            Person.Note = NoteHero;
            Person.Defence = Convert.ToInt32(DefenceHero);
            Person.Health = Convert.ToInt32(HealthHero);
            Person.Power = Convert.ToInt32(PowerHero);
            Person.PowerMod = Convert.ToInt32(PowerModHero);
            Person.PowerSave = Convert.ToInt32(PowerSave);
            Person.Dexterity = Convert.ToInt32(DexterityHero);
            Person.DexterityMod = Convert.ToInt32(DexterityModHero);
            Person.DexteritySave = Convert.ToInt32(DexteritySave);
            Person.Endurance = Convert.ToInt32(EnduranceHero);
            Person.EnduranceMod = Convert.ToInt32(EnduranceModHero);
            Person.EnduranceSave = Convert.ToInt32(EnduranceSave);
            Person.Intelligence = Convert.ToInt32(IntelligenceHero);
            Person.IntelligenceMod = Convert.ToInt32(IntelligenceModHero);
            Person.IntelligenceSave = Convert.ToInt32(IntelligenceSave);
            Person.Wisdom = Convert.ToInt32(WisdomHero);
            Person.WisdomMod = Convert.ToInt32(WisdomModHero);
            Person.WisdomSave = Convert.ToInt32(WisdomSave);
            Person.Charisma = Convert.ToInt32(CharismaHero);
            Person.CharismaMod = Convert.ToInt32(CharismaModHero);
            Person.CharismaSave = Convert.ToInt32(CharismaSave);
            Person.PassivWisdom = Convert.ToInt32(PassivWisdomHero);
            Person.SkillBonus = Convert.ToInt32(SkillBonusHero);
            Person.Acrobatics = Convert.ToInt32(Acrobatics);
            Person.Analysis = Convert.ToInt32(Analysis);
            Person.Athletics = Convert.ToInt32(Athletics);
            Person.Perception = Convert.ToInt32(Perception);
            Person.Survival = Convert.ToInt32(Survival);
            Person.Performance = Convert.ToInt32(Performance);
            Person.Intimidation = Convert.ToInt32(Intimidation);
            Person.History = Convert.ToInt32(History);
            Person.SleightOfHand = Convert.ToInt32(SleightOfHand);
            Person.Magic = Convert.ToInt32(Magic);
            Person.Medicine = Convert.ToInt32(Medicine);
            Person.Deception = Convert.ToInt32(Deception);
            Person.Nature = Convert.ToInt32(Nature);
            Person.Insight = Convert.ToInt32(Insight);
            Person.Religion = Convert.ToInt32(Religion);
            Person.Stealth = Convert.ToInt32(Stealth);
            Person.Persuasion = Convert.ToInt32(Persuasion);
            Person.AnimalCare = Convert.ToInt32(AnimalCare);
            Person.Attack = AttackHero;
            Person.IsNPC = IsNPCFlag;
            Processor.SetPerson(Person);
        }

        public void LoadHystory()
        {
            NewRoomFlag = false;
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
                PathImag = AppDomain.CurrentDomain.BaseDirectory + "Media\\History_" + SelectItemHistory.Id + "\\Images\\";
                PathNPC = AppDomain.CurrentDomain.BaseDirectory + "Media\\NPC\\";
                if (Rooms.Count() != 0)
                {
                    orderRoom = 1;
                    OpenRoom(orderRoom);
                }
            }
        }

        public void NewRoom()
        {
            NewRoomFlag = true;
            HeadRoom = "Новая комната";
            ImagRoom = "";
            TextRoom = "";
            IdRoom = 0;
            VisibilityHistoryEditor = Visibility.Hidden;
            VisibilityEventEditor = Visibility.Hidden;
            VisibilityHeroEditor = Visibility.Hidden;
            VisiilityNPCInRoomEditor = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            if (VisibilityRoomEditor == Visibility.Hidden)
            {
                VisibilityRoomEditor = Visibility.Visible;
            }
            else
            {
                VisibilityRoomEditor = Visibility.Hidden;
            }
        }
        public void NewEvent()
        {
            VisibilityRoomEditor = Visibility.Hidden;
            NewEventFlag = true;
            HeadEvent = "Новая событие";
            ImagEvent = "";
            TextEvent = "";
            IdEvent = 0;
            IdRoomEvent = IdRoom.ToString();
            VisibilityRoomEditor = Visibility.Hidden;
            VisibilityHistoryEditor = Visibility.Hidden;
            VisibilityHeroEditor = Visibility.Hidden;
            VisiilityNPCInRoomEditor = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            if (VisibilityEventEditor == Visibility.Hidden)
            {
                VisibilityEventEditor = Visibility.Visible;
            }
            else
            {
                VisibilityEventEditor = Visibility.Hidden;
            }
        }

        public void SaveEvent()
        {
            if (NewEventFlag)
            {
                
                if (Events.Where(x => x.roomId == IdRoom).Count() == 0)
                {
                    orderEvent = 1;
                }
                else
                {
                    orderEvent = Events.Where(x => x.roomId == IdRoom).Max(x => x.order) + 1;
                }
            }
            Processor.SetEvent(HeadEvent, orderEvent, IdRoom, SoundEvent, ImagEvent, TextEvent, IdEvent);
            //Processor.SetRoom(HeadRoom, orderRoom, SelectItemHistory.Id, SoundRoom, ImagRoom, TextRoom, IdRoom);
            UpdateEvent();
        }

        public void SaveRoom()
        {
            if (NewRoomFlag)
            {
                if (Rooms.Count() == 0)
                {
                    orderRoom = 1;
                }
                else
                {
                    orderRoom = Rooms.Max(x => x.order) + 1;
                }
            }
            Processor.SetRoom(HeadRoom, orderRoom, SelectItemHistory.Id, SoundRoom, ImagRoom, TextRoom, IdRoom);
            UpdateRoom();
        }
        public void UpdateRoom()
        {
            Rooms = Processor.GetRoom(SelectItemHistory.Id);
        }
        public void UpdateEvent()
        {
            Events = Processor.GetEvent(SelectItemHistory.Id);
        }
        public void CloseRoom()
        {
            NewRoomFlag = false;
            HeadRoom = "Отмена";
            ImagRoom = "";
            TextRoom = "";
        }

        public void OpenEvent(int order, int orderRo)
        {
            
            int id = Rooms.Where(x => x.order == orderRo).First().id;
            
            EventModel _event = Events.Where(x => x.order == order && x.roomId == id).First();
            NewEventFlag = false;
            IdEvent = _event.id;
            IdRoomEvent = _event.roomId.ToString();
            SoundEvent = _event.sound;
            ImagEvent = _event.imag;
            TextEvent = _event.text;
            HeadEvent = _event.name;
            orderEvent = _event.order;
            AddViewImages(_event.imag);

            VisibilityRoomEditor = Visibility.Hidden;
            VisibilityEventEditor = Visibility.Visible;
            VisiilityNPCInRoomEditor = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
        }

        public void OpenRoom(int order)
        {
            VisibilityRoomEditor = Visibility.Hidden;
            VisibilityEventEditor = Visibility.Hidden;
            VisibilityHeroEditor = Visibility.Hidden;
            VisiilityNPCInRoomEditor = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            NewRoomFlag = false;
            RoomModel _room = Rooms.Where(x => x.order == order).First();
            IdRoom = _room.id;
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
            TextRoom = _room.text;
            HeadRoom = _room.name;
            ImagRoom = _room.imag;
            SoundRoom = _room.sound;
            CountEvent = _events.Count();  
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
            VisibilityRoomEditor = Visibility.Visible;
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
                            });
                            break;
                        case 1:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 260,
                            });
                            break;
                        case 2:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 520,
                            });
                            break;
                        case 3:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 780,
                            });
                            break;
                        case 4:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 1040,
                            });
                            break;
                        case 5:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 1300,
                            });
                            break;
                        case 6:
                            StackPanelImag.Add(new StackPanelImagModel()
                            {
                                SourceImag = PathImag + img,
                                X = 1560,
                            });
                            break;
                    }
                    countImag++;
                }
            }
        }
        public void AddEventButton(int order, string name)
        {
            switch (order)
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

        public void NewHistorySave()
        {
            int _id = Convert.ToInt32(Id);
            int _visibility = Convert.ToInt32(VisibilityHistory);
            Processor.SetHistory(_id, Name, _visibility, Imag, 0);
            Update();
        }
        public void HistorySave()
        {
            int _id = Convert.ToInt32(Id);
            int _visibility = Convert.ToInt32(VisibilityHistory);
            Processor.SetHistory(_id, Name, _visibility, Imag, 1);
            Update();
        }

        public void Update()
        {
            List<HistoryModel> _history = Processor.GetHistory(0);
            ComboBoxHistory = _history;
            HistoryTable = new ObservableCollection<HistoryModel>(_history);
            int _count = _history.Count() + 1;
            Id = _count.ToString();
            Name = "";
            Imag = "new.png";
            VisibilityHistory = "0";
        }

        public void ShowEditorWindowVM()
        {
            ev = new EditorView(this);
            ev.Show();
        }

        public void ViewHistory()
        {
            Id = CurrentHistory.Id.ToString();
            Name = CurrentHistory.Name.ToString();
            Imag = CurrentHistory.Imag.ToString();
            VisibilityHistory = CurrentHistory.VisibilityHistory.ToString();
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
                TextNPC = CurrentNPC.Attack + "" + CurrentNPC.Note;
            };
        }
        public void ViewNPCEditor()
        {
            if (CurrentNPCList != null)
            {
                //AvaNPC = PathNPC + CurrentNPC.Imag;
                SelectItemNPC = ComboBoxNPC.Where(x => x.Id == CurrentNPCList.NPCId).First();
                SelectItemRoom = ComboBoxRoom.Where(x => x.id == CurrentNPCList.RoomId).First();
                IdNPC = CurrentNPCList.Id.ToString();
                NameNPC = CurrentNPCList.Name;
                ImagNPC = CurrentNPCList.Imag;
                DefenceNPC = CurrentNPCList.Defence.ToString();
                HealthNPC = CurrentNPCList.Health.ToString();
                NoteNPC = CurrentNPCList.Note;
                HistoryNPC = CurrentNPCList.HistoryText;
            };
        }

        public void NextRoom()
        {
            if (Rooms.Max(x => x.order) >= orderRoom + 1)
            {
                orderRoom++;
                OpenRoom(orderRoom);
            }
        }
        
        public void BackRoom()
        {
            if (Rooms.Min(x => x.order) <= orderRoom - 1)
            {
                orderRoom--;
                OpenRoom(orderRoom);
            }
        }

        public void NewHistory()
        {
            VisibilityRoomEditor = Visibility.Hidden;
            VisibilityEventEditor = Visibility.Hidden;
            VisibilityHeroEditor = Visibility.Hidden;
            VisiilityNPCInRoomEditor = Visibility.Hidden;
            VisibilityNPCList = Visibility.Hidden;
            VisibilityEventList = Visibility.Hidden;
            if (VisibilityHistoryEditor == Visibility.Hidden)
            {
                VisibilityHistoryEditor = Visibility.Visible;
            }
            else
            {
                VisibilityHistoryEditor = Visibility.Hidden;
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

        public void ViewNPCPageEditor()
        {
            if (VisibilityNPCEditor == Visibility.Hidden)
            {
                VisibilityNPCEditor = Visibility.Visible;
            }
            else
            {
                VisibilityNPCEditor = Visibility.Hidden;
            }
        }

        #endregion

        #region Свойства

        public int IsNPCFlag = 0;
        public int orderEvent = 1;
        public int IdRoom = 0;
        public int IdEvent = 0;
        public bool NewRoomFlag = false;
        public bool NewEventFlag = false;
        public int orderRoom = 0;
        public string PathImag = "";
        public string PathNPC = "";
        List<RoomModel> Rooms = new List<RoomModel>();
        List<EventModel> Events = new List<EventModel>();
        List<BattleModel> NPCs = new List<BattleModel>();

        public EditorViewModel EditorViewWindow { get; set; }
        
        public EditorView ev { get; set; }

        private List<RoomModel> _comboBoxRoom;
        public List<RoomModel> ComboBoxRoom
        {
            get { return _comboBoxRoom; }
            set
            {
                _comboBoxRoom = value;

                RaisePropertyChanged(nameof(ComboBoxRoom));
            }
        }

        private List<HistoryModel> _comboBoxHistory;
        public List<HistoryModel> ComboBoxHistory
        {
            get { return _comboBoxHistory; }
            set
            {
                _comboBoxHistory = value;

                RaisePropertyChanged(nameof(ComboBoxHistory));
            }
        }
        private List<NPCComboBoxModel> _comboBoxNPC;
        public List<NPCComboBoxModel> ComboBoxNPC
        {
            get { return _comboBoxNPC; }
            set
            {
                _comboBoxNPC = value;

                RaisePropertyChanged(nameof(ComboBoxNPC));
            }
        }
        private ObservableCollection<HistoryModel> _historyTable;
        public ObservableCollection<HistoryModel> HistoryTable
        {
            get { return _historyTable; }
            set
            {
                _historyTable = value;

                RaisePropertyChanged(nameof(HistoryTable));
            }
        }

        private HistoryModel _currentHistory;
        public HistoryModel CurrentHistory
        {
            get { return _currentHistory; }
            set
            {
                _currentHistory = value;
                ViewHistory();
            }
        }

        private RoomModel _selectItemRoom;
        public RoomModel SelectItemRoom
        {
            get { return _selectItemRoom; }
            set
            {
                _selectItemRoom = value;

                RaisePropertyChanged(nameof(SelectItemRoom));
            }
        }

        private NPCComboBoxModel _selectItemNPC;
        public NPCComboBoxModel SelectItemNPC
        {
            get { return _selectItemNPC; }
            set
            {
                _selectItemNPC = value;

                RaisePropertyChanged(nameof(SelectItemNPC));
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

        private HistoryModel _selectItemHistoryPerson;
        public HistoryModel SelectItemHistoryPerson
        {
            get { return _selectItemHistoryPerson; }
            set
            {
                _selectItemHistoryPerson = value;

                RaisePropertyChanged(nameof(SelectItemHistoryPerson));
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

        private ObservableCollection<BattleModel> _nPCListTable;
        public ObservableCollection<BattleModel> NPCListTable
        {
            get { return _nPCListTable; }
            set
            {
                _nPCListTable = value;

                RaisePropertyChanged(nameof(NPCListTable));
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

        private Visibility _visibilityNPCEditor;
        public Visibility VisibilityNPCEditor
        {
            get { return _visibilityNPCEditor; }
            set
            {
                _visibilityNPCEditor = value;

                RaisePropertyChanged(nameof(VisibilityNPCEditor));
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

        private Visibility _VisibilityHistoryEditor;
        public Visibility VisibilityHistoryEditor
        {
            get { return _VisibilityHistoryEditor; }
            set
            {
                _VisibilityHistoryEditor = value;

                RaisePropertyChanged(nameof(VisibilityHistoryEditor));
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

        private Visibility _visibilityRoomEditor;
        public Visibility VisibilityRoomEditor
        {
            get { return _visibilityRoomEditor; }
            set
            {
                _visibilityRoomEditor = value;

                RaisePropertyChanged(nameof(VisibilityRoomEditor));
            }
        }
        private Visibility _visibilityEventEditor;
        public Visibility VisibilityEventEditor
        {
            get { return _visibilityEventEditor; }
            set
            {
                _visibilityEventEditor = value;

                RaisePropertyChanged(nameof(VisibilityEventEditor));
            }
        }

        private Visibility _visibilityHeroEditor;
        public Visibility VisibilityHeroEditor
        {
            get { return _visibilityHeroEditor; }
            set
            {
                _visibilityHeroEditor = value;

                RaisePropertyChanged(nameof(VisibilityHeroEditor));
            }
        }

        private Visibility _visiilityNPCInRoomEditor;
        public Visibility VisiilityNPCInRoomEditor
        {
            get { return _visiilityNPCInRoomEditor; }
            set
            {
                _visiilityNPCInRoomEditor = value;

                RaisePropertyChanged(nameof(VisiilityNPCInRoomEditor));
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
        private BattleModel _currentNPCList;
        public BattleModel CurrentNPCList
        {
            get { return _currentNPCList; }
            set
            {
                _currentNPCList = value;
                ViewNPCPageEditor();
            }
        }

        private string _soundRoom;
        public string SoundRoom
        {
            get { return _soundRoom; }
            set
            {
                _soundRoom = value;

                RaisePropertyChanged(nameof(SoundRoom));
            }
        }

        private string _imagRoom;
        public string ImagRoom
        {
            get { return _imagRoom; }
            set
            {
                _imagRoom = value;

                RaisePropertyChanged(nameof(ImagRoom));
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

        private string _soundEvent;
        public string SoundEvent
        {
            get { return _soundEvent; }
            set
            {
                _soundEvent = value;

                RaisePropertyChanged(nameof(SoundEvent));
            }
        }

        private string _imagEvent;
        public string ImagEvent
        {
            get { return _imagEvent; }
            set
            {
                _imagEvent = value;

                RaisePropertyChanged(nameof(ImagEvent));
            }
        }

        private string _headEvent;
        public string HeadEvent
        {
            get { return _headEvent; }
            set
            {
                _headEvent = value;

                RaisePropertyChanged(nameof(HeadEvent));
            }
        }

        private string _textEvent;
        public string TextEvent
        {
            get { return _textEvent; }
            set
            {
                _textEvent = value;

                RaisePropertyChanged(nameof(TextEvent));
            }
        }

        private string _idRoomEvent;
        public string IdRoomEvent
        {
            get { return _idRoomEvent; }
            set
            {
                _idRoomEvent = value;

                RaisePropertyChanged(nameof(IdRoomEvent));
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

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
        
                RaisePropertyChanged(nameof(Id));
            }
        }
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
        
                RaisePropertyChanged(nameof(Name));
            }
        }
        
        private string _visibilityHistory;
        public string VisibilityHistory
        {
            get { return _visibilityHistory; }
            set
            {
                _visibilityHistory = value;
        
                RaisePropertyChanged(nameof(VisibilityHistory));
            }
        }
        
        private string _imag;
        public string Imag
        {
            get { return _imag; }
            set
            {
                _imag = value;
        
                RaisePropertyChanged(nameof(Imag));
            }
        }
        //-----------------------------------------------------------
        private string _idHero;
        public string IdHero
        {
            get { return _idHero; }
            set
            {
                _idHero = value;

                RaisePropertyChanged(nameof(IdHero));
            }
        }
        private string _nameHero;
        public string NameHero
        {
            get { return _nameHero; }
            set
            {
                _nameHero = value;

                RaisePropertyChanged(nameof(NameHero));
            }
        }
        private string _nameUserHero;
        public string NameUserHero
        {
            get { return _nameUserHero; }
            set
            {
                _nameUserHero = value;

                RaisePropertyChanged(nameof(NameUserHero));
            }
        }
        private string _imagHero;
        public string ImagHero
        {
            get { return _imagHero; }
            set
            {
                _imagHero = value;

                RaisePropertyChanged(nameof(ImagHero));
            }
        }
        private string _speciesHero;
        public string SpeciesHero
        {
            get { return _speciesHero; }
            set
            {
                _speciesHero = value;

                RaisePropertyChanged(nameof(SpeciesHero));
            }
        }
        private string _classHero;
        public string ClassHero
        {
            get { return _classHero; }
            set
            {
                _classHero = value;

                RaisePropertyChanged(nameof(ClassHero));
            }
        }
        private string _noteHero;
        public string NoteHero
        {
            get { return _noteHero; }
            set
            {
                _noteHero = value;

                RaisePropertyChanged(nameof(NoteHero));
            }
        }
        //--------------------------------------------------------------------------
        private string _defenceHero;
        public string DefenceHero
        {
            get { return _defenceHero; }
            set
            {
                _defenceHero = value;

                RaisePropertyChanged(nameof(DefenceHero));
            }
        }
        private string _healthHero;
        public string HealthHero
        {
            get { return _healthHero; }
            set
            {
                _healthHero = value;

                RaisePropertyChanged(nameof(HealthHero));
            }
        }
        private string _powerHero;
        public string PowerHero
        {
            get { return _powerHero; }
            set
            {
                _powerHero = value;

                RaisePropertyChanged(nameof(PowerHero));
            }
        }
        private string _powerModHero;
        public string PowerModHero
        {
            get { return _powerModHero; }
            set
            {
                _powerModHero = value;

                RaisePropertyChanged(nameof(PowerModHero));
            }
        }
        private string _dexterityHero;
        public string DexterityHero
        {
            get { return _dexterityHero; }
            set
            {
                _dexterityHero = value;

                RaisePropertyChanged(nameof(DexterityHero));
            }
        }
        private string _dexterityModHero;
        public string DexterityModHero
        {
            get { return _dexterityModHero; }
            set
            {
                _dexterityModHero = value;

                RaisePropertyChanged(nameof(DexterityModHero));
            }
        }
        private string _enduranceHero;
        public string EnduranceHero
        {
            get { return _enduranceHero; }
            set
            {
                _enduranceHero = value;

                RaisePropertyChanged(nameof(EnduranceHero));
            }
        }
        private string _enduranceModHero;
        public string EnduranceModHero
        {
            get { return _enduranceModHero; }
            set
            {
                _enduranceModHero = value;

                RaisePropertyChanged(nameof(EnduranceModHero));
            }
        }
        private string _intelligenceHero;
        public string IntelligenceHero
        {
            get { return _intelligenceHero; }
            set
            {
                _intelligenceHero = value;

                RaisePropertyChanged(nameof(IntelligenceHero));
            }
        }
        private string _intelligenceModHero;
        public string IntelligenceModHero
        {
            get { return _intelligenceModHero; }
            set
            {
                _intelligenceModHero = value;

                RaisePropertyChanged(nameof(IntelligenceModHero));
            }
        }
        private string _wisdomHero;
        public string WisdomHero
        {
            get { return _wisdomHero; }
            set
            {
                _wisdomHero = value;

                RaisePropertyChanged(nameof(WisdomHero));
            }
        }
        private string _wisdomModHero;
        public string WisdomModHero
        {
            get { return _wisdomModHero; }
            set
            {
                _wisdomModHero = value;

                RaisePropertyChanged(nameof(WisdomModHero));
            }
        }
        private string _charismaHero;
        public string CharismaHero
        {
            get { return _charismaHero; }
            set
            {
                _charismaHero = value;

                RaisePropertyChanged(nameof(CharismaHero));
            }
        }
        private string _charismaModHero;
        public string CharismaModHero
        {
            get { return _charismaModHero; }
            set
            {
                _charismaModHero = value;

                RaisePropertyChanged(nameof(CharismaModHero));
            }
        }
        private string _passivWisdomHero;
        public string PassivWisdomHero
        {
            get { return _passivWisdomHero; }
            set
            {
                _passivWisdomHero = value;

                RaisePropertyChanged(nameof(PassivWisdomHero));
            }
        }
        //--------------------------------------------------------------------------
        private string _skillBonusHero;
        public string SkillBonusHero
        {
            get { return _skillBonusHero; }
            set
            {
                _skillBonusHero = value;

                RaisePropertyChanged(nameof(SkillBonusHero));
            }
        }
        private string _powerSave;
        public string PowerSave
        {
            get { return _powerSave; }
            set
            {
                _powerSave = value;

                RaisePropertyChanged(nameof(PowerSave));
            }
        }
        private string _dexteritySave;
        public string DexteritySave
        {
            get { return _dexteritySave; }
            set
            {
                _dexteritySave = value;

                RaisePropertyChanged(nameof(DexteritySave));
            }
        }
        private string _enduranceSave;
        public string EnduranceSave
        {
            get { return _enduranceSave; }
            set
            {
                _enduranceSave = value;

                RaisePropertyChanged(nameof(EnduranceSave));
            }
        }
        private string _intelligenceSave;
        public string IntelligenceSave
        {
            get { return _intelligenceSave; }
            set
            {
                _intelligenceSave = value;

                RaisePropertyChanged(nameof(IntelligenceSave));
            }
        }
        private string _wisdomSave;
        public string WisdomSave
        {
            get { return _wisdomSave; }
            set
            {
                _wisdomSave = value;

                RaisePropertyChanged(nameof(WisdomSave));
            }
        }
        private string _charismaSave;
        public string CharismaSave
        {
            get { return _charismaSave; }
            set
            {
                _charismaSave = value;

                RaisePropertyChanged(nameof(CharismaSave));
            }
        }
        private string _acrobatics;
        public string Acrobatics
        {
            get { return _acrobatics; }
            set
            {
                _acrobatics = value;

                RaisePropertyChanged(nameof(Acrobatics));
            }
        }
        private string _analysis;
        public string Analysis
        {
            get { return _analysis; }
            set
            {
                _analysis = value;

                RaisePropertyChanged(nameof(Analysis));
            }
        }
        private string _athletics;
        public string Athletics
        {
            get { return _athletics; }
            set
            {
                _athletics = value;

                RaisePropertyChanged(nameof(Athletics));
            }
        }
        private string _perception;
        public string Perception
        {
            get { return _perception; }
            set
            {
                _perception = value;

                RaisePropertyChanged(nameof(Perception));
            }
        }
        private string _survival;
        public string Survival
        {
            get { return _survival; }
            set
            {
                _survival = value;

                RaisePropertyChanged(nameof(Survival));
            }
        }
        private string _performance;
        public string Performance
        {
            get { return _performance; }
            set
            {
                _performance = value;

                RaisePropertyChanged(nameof(Performance));
            }
        }
        private string _intimidation;
        public string Intimidation
        {
            get { return _intimidation; }
            set
            {
                _intimidation = value;

                RaisePropertyChanged(nameof(Intimidation));
            }
        }
        private string _history;
        public string History
        {
            get { return _history; }
            set
            {
                _history = value;

                RaisePropertyChanged(nameof(History));
            }
        }
        private string _sleightOfHand;
        public string SleightOfHand
        {
            get { return _sleightOfHand; }
            set
            {
                _sleightOfHand = value;

                RaisePropertyChanged(nameof(SleightOfHand));
            }
        }
        private string _magic;
        public string Magic
        {
            get { return _magic; }
            set
            {
                _magic = value;

                RaisePropertyChanged(nameof(Magic));
            }
        }
        private string _medicine;
        public string Medicine
        {
            get { return _medicine; }
            set
            {
                _medicine = value;

                RaisePropertyChanged(nameof(Medicine));
            }
        }
        private string _deception;
        public string Deception
        {
            get { return _deception; }
            set
            {
                _deception = value;

                RaisePropertyChanged(nameof(Deception));
            }
        }
        private string _nature;
        public string Nature
        {
            get { return _nature; }
            set
            {
                _nature = value;

                RaisePropertyChanged(nameof(Nature));
            }
        }
        private string _insight;
        public string Insight
        {
            get { return _insight; }
            set
            {
                _insight = value;

                RaisePropertyChanged(nameof(Insight));
            }
        }
        private string _religion;
        public string Religion
        {
            get { return _religion; }
            set
            {
                _religion = value;

                RaisePropertyChanged(nameof(Religion));
            }
        }
        private string _stealth;
        public string Stealth
        {
            get { return _stealth; }
            set
            {
                _stealth = value;

                RaisePropertyChanged(nameof(Stealth));
            }
        }
        private string _persuasion;
        public string Persuasion
        {
            get { return _persuasion; }
            set
            {
                _persuasion = value;

                RaisePropertyChanged(nameof(Persuasion));
            }
        }
        private string _animalCare;
        public string AnimalCare
        {
            get { return _animalCare; }
            set
            {
                _animalCare = value;

                RaisePropertyChanged(nameof(AnimalCare));
            }
        }
        private string _attackHero;
        public string AttackHero
        {
            get { return _attackHero; }
            set
            {
                _attackHero = value;

                RaisePropertyChanged(nameof(AttackHero));
            }
        }
        //---------------------------------------------------------
        private string _idNPC;
        public string IdNPC
        {
            get { return _idNPC; }
            set
            {
                _idNPC = value;

                RaisePropertyChanged(nameof(IdNPC));
            }
        }
        private string _nameNPC;
        public string NameNPC
        {
            get { return _nameNPC; }
            set
            {
                _nameNPC = value;

                RaisePropertyChanged(nameof(NameNPC));
            }
        }
        private string _defenceNPC;
        public string DefenceNPC
        {
            get { return _defenceNPC; }
            set
            {
                _defenceNPC = value;

                RaisePropertyChanged(nameof(DefenceNPC));
            }
        }
        private string _imagNPC;
        public string ImagNPC
        {
            get { return _imagNPC; }
            set
            {
                _imagNPC = value;

                RaisePropertyChanged(nameof(ImagNPC));
            }
        }
        private string _healthNPC;
        public string HealthNPC
        {
            get { return _healthNPC; }
            set
            {
                _healthNPC = value;

                RaisePropertyChanged(nameof(HealthNPC));
            }
        }
        private string _noteNPC;
        public string NoteNPC
        {
            get { return _noteNPC; }
            set
            {
                _noteNPC = value;

                RaisePropertyChanged(nameof(NoteNPC));
            }
        }
        private string _historyNPC;
        public string HistoryNPC
        {
            get { return _historyNPC; }
            set
            {
                _historyNPC = value;

                RaisePropertyChanged(nameof(HistoryNPC));
            }
        }
        #endregion

        #region Команды

        public ICommand NewHistorySaveBtn { get; set; }
        public ICommand HistorySaveBtn { get; set; }
        public ICommand ComboOk { get; set; }
        public ICommand NewHistoryBtn { get; set; }
        public ICommand CloseRoomBtn { get; set; }
        public ICommand SaveRoomBtn { get; set; }
        public ICommand NewRoomBtn { get; set; }
        public ICommand BackRoomBtn { get; set; }
        public ICommand NextRoomBtn { get; set; }
        public ICommand NewEventBtn { get; set; }
        public ICommand SaveEventBtn { get; set; }
        public ICommand ViewEventBtn { get; set; }
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
        public ICommand SaveHeroBtn { get; set; }
        public ICommand ShowListHeroBtn { get; set; }
        public ICommand NewHeroBtn { get; set; }
        public ICommand ShowListNPCBtn { get; set; }
        public ICommand ShowListNPCInRoomBtn { get; set; }
        public ICommand SaveNPCBtn { get; set; }
        public ICommand NewNPCBtn { get; set; }
        public ICommand ViewNPCBtn { get; set; }
        public ICommand ColorYellowBtn { get; set; }
        public ICommand ColorGreenBtn { get; set; }
        public ICommand ColorRedBtn { get; set; }

        #endregion

    }
}
