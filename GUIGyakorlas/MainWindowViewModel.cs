using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUIGyakorlas
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Hero> heroes { get; set; }
        public ObservableCollection<Hero> team { get; set; }

        public ICommand AddToTeam { get; set; }
        public ICommand RemoveFromTeam { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand NewHero { get; set; }

        ILogic logic;

        public double AvgSpeed { get { return logic.AvgSpeed; } }
        public double AvgPower { get { return logic.AvgPower; } }

        private Hero selectedHeroFromHeroes;

        public Hero SelectedHeroFromHeroes
        {
            get { return selectedHeroFromHeroes; }
            set 
            { 
                SetProperty(ref selectedHeroFromHeroes, value);
                (AddToTeam as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Hero selectedHeroFromTeam;

        public Hero SelectedHeroFromTeam
        {
            get { return selectedHeroFromTeam; }
            set 
            { 
                SetProperty(ref selectedHeroFromTeam, value);
                (RemoveFromTeam as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public MainWindowViewModel(ILogic l)
        {
            heroes = new ObservableCollection<Hero>();
            team = new ObservableCollection<Hero>();
            heroes = JsonConvert.DeserializeObject<ObservableCollection<Hero>>(File.ReadAllText("heroes.json"));
            team = JsonConvert.DeserializeObject<ObservableCollection<Hero>>(File.ReadAllText("team.json"));
            logic = l;

            logic.SetUpCollections(heroes, team);

            AddToTeam = new RelayCommand(
                () => logic.AddHero(SelectedHeroFromHeroes.GetCopy()),
                () => SelectedHeroFromHeroes != null
                );

            RemoveFromTeam = new RelayCommand(
                () => logic.RemoveHero(SelectedHeroFromTeam),
                () => SelectedHeroFromTeam != null
                );

            NewHero = new RelayCommand(
                ()=> logic.NewHero()
                );

            SaveCommand = new RelayCommand(
                ()=> logic.WriteOutCollections()
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "heroinfo",(recipient,msg)=> 
            {
                OnPropertyChanged("AvgPower");
                OnPropertyChanged("AvgSpeed");
            });

        }

        public MainWindowViewModel() : this(IsDesignMode ? null : Ioc.Default.GetService<ILogic>())
        {

        }

        public static bool IsDesignMode
        {
            get 
            {
                var property = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(property, typeof(FrameworkElement)).Metadata.DefaultValue;
            }

        }

    }
}
