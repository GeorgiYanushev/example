using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zoo.Model;
using System.Runtime.CompilerServices;

namespace Zoo.ViewModel
{
    public class AnimalsViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<string> MySpecies { get; private set; }
        public ObservableCollection<string> ListBoxMessages { get; private set; }
        public ObservableCollection<Animal> Animals { get; set; }
        public ObservableCollection<Animal> Test { get; set; }
        private AnimalRepository AnimalRepository { get; set; }
        public Command ShowCommand { get; private set; }

        public Command TextBoxCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;


        private string _name;
        private string _age;
        private string _species;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        public string Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }
        public string Species
        {
            get { return _species; }
            set
            {
                _species = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public AnimalsViewModel()
        {
            Test = new ObservableCollection<Animal>();
            MySpecies = new ObservableCollection<string>();
            AnimalRepository = new AnimalRepository();
            Animals = new ObservableCollection<Animal>(AnimalRepository.animalsRepository);
            MySpecies.Add(Animals[0].Species);
            for (int i = 1; i < Animals.Count - 1; i++)
                if (Animals[i].Species != Animals[i - 1].Species)
                {
                    MySpecies.Add(Animals[i].Species);
                }
            MySpecies.Add("");
           ShowCommand = new Command(FilterAnimals);
           TextBoxCommand = new Command(GiveInfo);
        }


       
        public void FilterAnimals(object message)
        {
            Test.Clear();
            if (message == null || (string)message =="")
            {
                for (int i = 0; i < Animals.Count; i++)
                {
                    Test.Add(Animals[i]);
                }
            }
            else
            {
                for (int i = 0; i < Animals.Count; i++)
                {
                    if (Animals[i].Species == (string)message)
                        Test.Add(Animals[i]);
                }
            }
        }
        public void GiveInfo(object message)
        {
            Animal dummy = (Animal)message;
            Name = dummy.Name;
            Age = dummy.Age.ToString();
            Species = dummy.Species;
        }


    }
}
