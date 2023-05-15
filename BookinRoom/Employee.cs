using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom
{
    public class Employee
    {
        private static readonly string connectionString =
       "Data Source=LAPTOP-FTO3M4EL;Database=booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public string Id { get; set; }
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentId { get; set; }


        // INSERT : Employee
        public static int InsertEmployee(Employee employee)
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
                command.CommandText = "INSERT INTO tb_m_employees(nik, first_name, last_name, birthdate, gender, hiring_date, email, phone_number, department_id) VALUES (@nik, @firstname, @lastname, @birthdate, @gender, @hiringdate, @email, @phonenumber, @departmentid)";
                command.Transaction = transaction;

                // Membuat parameter
                var Nik = new SqlParameter();
                Nik.ParameterName = "@nik";
                Nik.SqlDbType = SqlDbType.Char;
                Nik.Size = 6;
                Nik.Value = employee.NIK;

                var FName = new SqlParameter();
                FName.ParameterName = "@firstname";
                FName.SqlDbType = SqlDbType.VarChar;
                FName.Size = 50;
                FName.Value = employee.FirstName;

                var LName = new SqlParameter();
                LName.ParameterName = "@lastname";
                LName.SqlDbType = SqlDbType.VarChar;
                LName.Size = 50;
                LName.Value = employee.LastName;

                var Birthdate = new SqlParameter();
                Birthdate.ParameterName = "@birthdate";
                Birthdate.SqlDbType = SqlDbType.DateTime;
                Birthdate.Value = employee.Birthdate;

                var Gender = new SqlParameter();
                Gender.ParameterName = "@gender";
                Gender.SqlDbType = SqlDbType.VarChar;
                Gender.Size = 10;
                Gender.Value = employee.Gender;

                var Hiringdate = new SqlParameter();
                Hiringdate.ParameterName = "@hiringdate";
                Hiringdate.SqlDbType = SqlDbType.DateTime;
                Hiringdate.Value = employee.HiringDate;

                var Email = new SqlParameter();
                Email.ParameterName = "@email";
                Email.SqlDbType = SqlDbType.VarChar;
                Email.Size = 50;
                Email.Value = employee.Email;

                var Phone = new SqlParameter();
                Phone.ParameterName = "@phonenumber";
                Phone.SqlDbType = SqlDbType.VarChar;
                Phone.Size = 20;
                Phone.Value = employee.PhoneNumber;

                var DeptID = new SqlParameter();
                DeptID.ParameterName = "@departmentid";
                DeptID.SqlDbType = SqlDbType.Char;
                DeptID.Size = 4;
                DeptID.Value = employee.DepartmentId;

                // Menambahkan parameter ke command
                command.Parameters.Add(Nik);
                command.Parameters.Add(FName);
                command.Parameters.Add(LName);
                command.Parameters.Add(Birthdate);
                command.Parameters.Add(Gender);
                command.Parameters.Add(Hiringdate);
                command.Parameters.Add(Email);
                command.Parameters.Add(Phone);
                command.Parameters.Add(DeptID);


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
