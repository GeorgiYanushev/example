using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Model
{
    public class AnimalRepository
    {
        public List<Animal> animalsRepository { get; set; }

        public AnimalRepository()
        {
            animalsRepository = GetAnimals();
        }
        public string conString = "Data Source=DESKTOP-LT3U7Q6\\MSSQLSERVER01;Initial Catalog=ZooDB;Integrated Security=True";
        public List<Animal> GetAnimals()
        {
            List<Animal> listOfAnimals = new List<Animal>();

            SqlConnection SqlCon = new SqlConnection(conString);
            {
                if(SqlCon==null)
                {
                    throw new Exception("Connection String is Null");
                }
                SqlCon.Open();
                DataTable dataTable= new DataTable();
                SqlCommand query=new SqlCommand("SELECT * from tblAnimals ORDER BY Species", SqlCon);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                sqlDataAdapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    Animal animal = new Animal();
                    animal.Id = (int)row["AnimalID"];
                    animal.Name = (string)row["Name"];
                    animal.Age = (int)row["Age"];
                    animal.Species = (string)row["Species"];
                    listOfAnimals.Add(animal);
                }
                return listOfAnimals;
            }
        }
    }
}
