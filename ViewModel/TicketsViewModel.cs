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
    internal class TicketsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private EventRepository EventRepository { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<string> MyNames { get; private set; }

        private string _name;
        private string _type;
        private DateTime _date;
        private int _cost;
        private string _ticketVariant;
        private int _amount;
        private int _price;
        public Command ShowCommand { get; private set; }
        public Command TicketCommand { get; private set; }
        public Command CalculateCommand { get; private set; }

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged(); } }
        public DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged(); } }
        public int Cost { get { return _cost; } set { _cost = value; OnPropertyChanged(); } }

        public int Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(); } }
        public int Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }

        public string TicketVariant { get { return _ticketVariant; } set { _ticketVariant = value; OnPropertyChanged(); } }

        private Event dummy;
        public ObservableCollection<string> MyTicketTypes { get; private set; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public TicketsViewModel()
        {
            MyTicketTypes = new ObservableCollection<string>()
            {
                "Standard Ticket",
                "Family Ticket",
                "Student Ticket"
                
            };
            dummy=new Event();
            EventRepository = new EventRepository();
            Events = new ObservableCollection<Event>(EventRepository.eventsRepository);
            MyNames = new ObservableCollection<string>();
            for(int i = 0; i < Events.Count; i++)
            {
                
                    MyNames.Add(Events[i].Name);
                
            }
            ShowCommand = new Command(GiveInfo);
            TicketCommand = new Command(TicketType);
            CalculateCommand = new Command(Calc);
        }
        public void GiveInfo(object message)
        {
            for(int i=0;i<Events.Count;i++)
            {
                if(Events[i].Name == (string)message)
                {
                    dummy = Events[i];
                    Name = Events[i].Name;
                    Type = Events[i].Type;
                    Date = Events[i].Date;
                    break;
                }
            }
        }
        public void TicketType(object message)
        {
            if((string)message== "Standard Ticket")
            {
                Cost = dummy.Cost;
            }
            if ((string)message == "Family Ticket")
            {
                Cost = dummy.Cost+5;
            }
            if ((string)message == "Student Ticket")
            {
                Cost = dummy.Cost-5;
            }
            TicketVariant = (string)message;
        }
        public void Calc(object message)
        {
            Price = dummy.Cost * Amount;
        }
    }
}
