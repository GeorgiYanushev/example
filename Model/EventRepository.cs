using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Zoo.Model
{
    internal class EventRepository
    {
        public List<Event> eventsRepository { get; set; }

        public EventRepository()
        {
            eventsRepository = GetEvents();
        }
        public string conString = "Data Source=DESKTOP-LT3U7Q6\\MSSQLSERVER01;Initial Catalog=ZooDB;Integrated Security=True";
        public List<Event> GetEvents()
        {
            List<Event> ListOfEvents = new List<Event>();

            SqlConnection SqlCon= new SqlConnection(conString);
            {
                if(SqlCon==null)
                {
                    throw new Exception("Connection String is Null");
                }
                SqlCon.Open();
                DataTable dataTable = new DataTable();
                SqlCommand query=new SqlCommand("SELECT * from tblEvents ORDER BY Date", SqlCon);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    Event dummy = new Event();
                    dummy.Id=(int)row["EventID"];
                    dummy.Name=(string)row["Name"];
                    dummy.Date = (DateTime)row["Date"];
                    dummy.Cost = (int)row["Cost"];
                    dummy.Type = (string)row["Type"];
                    ListOfEvents.Add(dummy);

                }
                return ListOfEvents;
            }
        }

    }
}
