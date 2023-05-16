using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicConnection.Context;

namespace BookingRoom.Model;
    public class CombineTable
    {

        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public string Name { get; set; }

    public List<CombineTable> GetTables()
    {
        var tables = new List<CombineTable>();
        using var connection = MyConnection.Get();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM tb_m_employees emp JOIN tb_tr_profilings pro ON emp.id = pro.employee_id JOIN tb_m_educations edu ON pro.education_id = edu.id JOIN tb_m_universities uni ON edu.university_id = uni.id";

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var table = new CombineTable();
                    table.NIK = reader.GetString(0);
                    table.FirstName = reader.GetString(1);
                    table.LastName = reader.GetString(2);
                    table.Birthdate = reader.GetDateTime(3);
                    table.Gender = reader.GetString(4);
                    table.HiringDate = reader.GetDateTime(5);
                    table.Email = reader.GetString(6);
                    table.PhoneNumber = reader.GetString(7);
                    table.Major = reader.GetString(8);
                    table.Degree = reader.GetString(9);
                    table.GPA = reader.GetString(10);
                    table.Name = reader.GetString(11);

                    tables.Add(table);
                }

                return tables;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return new List<CombineTable>();
    }

}


