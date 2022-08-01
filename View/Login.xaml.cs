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
using System.Data;
using System.Data.SqlClient;


namespace Zoo.View
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=DESKTOP-LT3U7Q6\\MSSQLSERVER01;Initial Catalog=ZooDB;Integrated Security=True";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           SqlConnection SqlCon= new SqlConnection(conString);
            try
            {
                if(SqlCon.State==ConnectionState.Closed)
                    SqlCon.Open();
                String query = "SELECT COUNT(1) FROM tblUser WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd=new SqlCommand(query,SqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                int count=Convert.ToInt32(sqlCmd.ExecuteScalar());
                if(count==1)
                {
                    Menu dashbord = new Menu();
                    dashbord.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("username or password is incorrect");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SqlCon.Close();
            }
        }
    }
}
