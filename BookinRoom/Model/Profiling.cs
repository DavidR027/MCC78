using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BasicConnection.Context;

namespace BookingRoom.Model
{
    public class Profiling
    {

        public string EmployeeId { get; set; }
        public int EducationId { get; set; }


        public List<Profiling> GetProfilings()
        {
            var profilings = new List<Profiling>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_profilings";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var profiling = new Profiling();
                        profiling.EmployeeId = reader.GetGuid(0).ToString();
                        profiling.EducationId = reader.GetInt32(1);

                        profilings.Add(profiling);
                    }

                    return profilings;
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
            return new List<Profiling>();
        }


        // INSERT : Profiling
        public int InsertProfiling(Profiling profiling)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan insert
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_tr_profilings(employee_id, education_id) VALUES (@employeeid, @educationid)";
                command.Transaction = transaction;

                // Membuat parameter
                var EmpID = new SqlParameter();
                EmpID.ParameterName = "@employeeid";
                EmpID.SqlDbType = SqlDbType.VarChar;
                EmpID.Size = 100;
                EmpID.Value = profiling.EmployeeId;

                var EduID = new SqlParameter();
                EduID.ParameterName = "@educationid";
                EduID.SqlDbType = SqlDbType.Int;
                EduID.Value = profiling.EducationId;

                // Menambahkan parameter ke command
                command.Parameters.Add(EmpID);
                command.Parameters.Add(EduID);

                // Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;

            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}
