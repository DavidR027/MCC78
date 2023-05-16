using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicConnection.Context;
using BookingRoom.View;

namespace BookingRoom.Model
{
    public class Employee
    {
        private Education _education = new Education();
        private University _university = new University();
        private Profiling _profiling = new Profiling();
        private Menu _menu = new Menu();
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


        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var employee = new Employee();
                        employee.Id = reader.GetGuid(0).ToString();
                        employee.NIK = reader.GetString(1);
                        employee.FirstName = reader.GetString(2);
                        employee.LastName = reader.GetString(3);
                        employee.Birthdate = reader.GetDateTime(4);
                        employee.Gender = reader.GetString(5);
                        employee.HiringDate = reader.GetDateTime(6);
                        employee.Email = reader.GetString(7);
                        employee.PhoneNumber = reader.GetString(8);
                        employee.DepartmentId = reader.GetString(9);

                        employees.Add(employee);
                    }

                    return employees;
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
            return new List<Employee>();
        }


        // INSERT : Employee
        public int InsertEmployee(Employee employee)
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

        public string GetLastEmpID(string NIK)
        {
            using var connection = MyConnection.Get();
            connection.Open();

            // Command melakukan select
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_employees WHERE NIK = (@nik);", connection);

            // Membuat parameter
            var Nik = new SqlParameter();
            Nik.ParameterName = "@nik";
            Nik.SqlDbType = SqlDbType.Char;
            Nik.Size = 6;
            Nik.Value = NIK;

            command.Parameters.Add(Nik);

            // Menjalankan select dan mencari ID terakhir
            string lastInsertedId = Convert.ToString(command.ExecuteScalar());

            connection.Close();

            return lastInsertedId;

        }

        public List<CombineTable> checkAll()
        {
            var getInfo = from emp in GetEmployees()
                          join pro in _profiling.GetProfilings() on emp.Id equals pro.EmployeeId
                          join edu in _education.GetEducation() on pro.EducationId equals edu.Id
                          join uni in _university.GetUniversities() on edu.UniversityId equals
                          uni.Id
                          select new CombineTable
                          {
                              NIK = emp.NIK,
                              FirstName = emp.FirstName,
                              LastName = emp.LastName,
                              Birthdate = emp.Birthdate,
                              Gender = emp.Gender,
                              HiringDate = emp.HiringDate,
                              Email = emp.Email,
                              PhoneNumber = emp.PhoneNumber,
                              Major = edu.Major,
                              Degree = edu.Degree,
                              GPA = edu.GPA,
                              Name = uni.Name
                          };
            return getInfo.ToList();

        }

    }
}
