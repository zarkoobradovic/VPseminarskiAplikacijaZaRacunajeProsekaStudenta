using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PredmetRepository
    {
        public List<Predmet> GetAllPredmet()
        {
            List<Predmet> results = new List<Predmet>();

            using (SqlConnection sqlConnection = new SqlConnection(Konstante.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Predmet";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Predmet p = new Predmet();
                    p.Id = sqlDataReader.GetInt32(0);
                    p.NazivPredmeta = sqlDataReader.GetString(1);
                    p.Godina = sqlDataReader.GetInt32(2);
                    p.Ocena = sqlDataReader.GetInt32(3);

                    results.Add(p);
                }
            }

            return results;
        }

        public int InsertPredmet(Predmet p)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Konstante.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText =
                    string.Format("INSERT INTO Predmet VALUES ('{0}', '{1}', '{2}')",
                     p.NazivPredmeta, p.Godina, p.Ocena);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();

            }
        }

        public int UpdatePredmet(Predmet p)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Konstante.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText =
                    string.Format($"UPDATE Predmet SET NazivPredmeta='{p.NazivPredmeta}', Godina='{p.Godina}', Ocena='{p.Ocena}' WHERE Id='{p.Id}' ");
                     

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();

            }
        }

        public int DeletePredmet(int Id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Konstante.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText =
                    string.Format( "DELETE FROM Predmet WHERE Id='{0}' ", Id);

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();

            }
        }

       

    }
}
