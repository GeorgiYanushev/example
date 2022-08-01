using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zoo.Model;

namespace Zoo.ViewModel
{
    internal class EventsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private EventRepository EventRepository { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<Event> Test { get; set; }
        public ObservableCollection<DateTime> MyDates { get; private set; }
        public ObservableCollection<string> MyTypes { get; private set; }

        public Command ShowCommand { get; private set; }
        public Command ShowCommand2 { get; private set; }
        public Command TextBoxCommand { get; private set; }


        private string _name;
        private string _type;
        private DateTime _date;
        private int _cost;

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged(); } }
        public DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged(); } }
        public int Cost { get { return _cost; } set { _cost = value; OnPropertyChanged(); } }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public EventsViewModel()
        {
            Test = new ObservableCollection<Event>();
            EventRepository = new EventRepository();
            MyTypes= new ObservableCollection<string>();    
            MyDates= new ObservableCollection<DateTime>();
            Events= new ObservableCollection<Event>(EventRepository.eventsRepository);
            MyDates.Add(Events[0].Date);
            MyTypes.Add(Events[0].Type);
            for (int i=1;i<Events.Count-1;i++)
            {
                if (Events[i].Date!= Events[i-1].Date)
                {
                    MyDates.Add(Events[i].Date);
                }
                if (Events[i].Type != Events[i - 1].Type)
                {
                    MyTypes.Add(Events[i].Type);
                }
                ShowCommand = new Command(FilterByType);
                ShowCommand2 = new Command(FilterByDate);
                TextBoxCommand = new Command(GiveInfo);
               
            }

        }
        public void FilterByType(object message)
        {
            Test.Clear();
            if (message == null )
            {
                for (int i = 0; i < Events.Count; i++)
                {
                    Test.Add(Events[i]);
                }
            }
            else
            {
                for (int i = 0; i < Events.Count; i++)
                {
                    if (Events[i].Type == (string)message)
                        Test.Add(Events[i]);
                }
            }
        }
        public void FilterByDate(object message)
        {
            Test.Clear();
            if (message == null)
            {
                for (int i = 0; i < Events.Count; i++)
                {
                    Test.Add(Events[i]);
                }
            }
            else
            {
                for (int i = 0; i < Events.Count; i++)
                {
                    if (Events[i].Date == (DateTime)message)
                        Test.Add(Events[i]);
                }
            }
        }
        public void GiveInfo(object message)
        {
            Event dummy = (Event)message;
            Name = dummy.Name;
            Cost = dummy.Cost;
            Type = dummy.Type;
            Date = dummy.Date;
        }
    }
}
