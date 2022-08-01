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

namespace Zoo.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Events e1 = new Events();
        Animals a1 = new Animals();
        Tickets t1= new Tickets();
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MainMenu.Content = a1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            MainMenu.Content = e1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = t1;

        }
    }
}
