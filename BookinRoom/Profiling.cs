using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookingRoom
{
    public class Profiling
    {
        private static readonly string connectionString =
       "Data Source=LAPTOP-FTO3M4EL;Database=booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public string EmployeeId { get; set; }
        public int EducationId { get; set; }


        // INSERT : Profiling
        public static int InsertProfiling(Profiling profiling)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
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
