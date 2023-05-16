using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicConnection.Context;

namespace BookingRoom.Model
{
    public class Education
    {

        public int Id { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public int UniversityId { get; set; }


        // --------------------------------------------------------------------------------- Database Education

        // GET : Education
        public List<Education> GetEducation()
        {
            var educations = new List<Education>();
            using var connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var education = new Education();
                        education.Id = reader.GetInt32(0);
                        education.Major = reader.GetString(1);
                        education.Degree = reader.GetString(2);
                        education.GPA = reader.GetString(3);
                        education.UniversityId = reader.GetInt32(4);

                        educations.Add(education);
                    }

                    return educations;
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
            return new List<Education>();
        }

        // GET : Education(5)
        public Education GetEducationById(Education education)
        {
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations WHERE Id = (@id)";
                command.Transaction = transaction;
             

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@Id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = education.Id;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        education.Id = reader.GetInt32(0);
                        education.Major = reader.GetString(1);
                        education.Degree = reader.GetString(2);
                        education.GPA = reader.GetString(3);
                        education.UniversityId = reader.GetInt32(4);

                    }

                    return education;
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
            return new Education();
        }

        // INSERT : Education
        public int InsertEducation(Education education)
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
                command.CommandText = "INSERT INTO tb_m_educations(major, degree, gpa, university_id) VALUES (@major, @degree, @gpa, @universityid)";
                command.Transaction = transaction;

                // Membuat parameter
                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.SqlDbType = SqlDbType.VarChar;
                pMajor.Size = 50;
                pMajor.Value = education.Major;

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@degree";
                pDegree.SqlDbType = SqlDbType.VarChar;
                pDegree.Size = 10;
                pDegree.Value = education.Degree;

                var pGpa = new SqlParameter();
                pGpa.ParameterName = "@gpa";
                pGpa.SqlDbType = SqlDbType.VarChar;
                pGpa.Size = 5;
                pGpa.Value = education.GPA;

                var pUID = new SqlParameter();
                pUID.ParameterName = "@universityid";
                pUID.SqlDbType = SqlDbType.Int;
                pUID.Value = education.UniversityId;

                // Menambahkan parameter ke command
                command.Parameters.Add(pMajor);
                command.Parameters.Add(pDegree);
                command.Parameters.Add(pGpa);
                command.Parameters.Add(pUID);

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

        // UPDATE : Education(obj)
        public int UpdateEducation(Education education)
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
                command.CommandText = "UPDATE tb_m_educations SET Major = (@major), Degree = (@degree), gpa = (@gpa), university_id = (@universityid) WHERE Id = (@id)";
                command.Transaction = transaction;

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = education.Id;

                var pMajor = new SqlParameter();
                pMajor.ParameterName = "@major";
                pMajor.SqlDbType = SqlDbType.VarChar;
                pMajor.Size = 50;
                pMajor.Value = education.Major;

                var pDegree = new SqlParameter();
                pDegree.ParameterName = "@degree";
                pDegree.SqlDbType = SqlDbType.VarChar;
                pDegree.Size = 10;
                pDegree.Value = education.Degree;

                var pGpa = new SqlParameter();
                pGpa.ParameterName = "@gpa";
                pGpa.SqlDbType = SqlDbType.VarChar;
                pGpa.Size = 5;
                pGpa.Value = education.GPA;

                var pUID = new SqlParameter();
                pUID.ParameterName = "@universityid";
                pUID.SqlDbType = SqlDbType.Int;
                pUID.Value = education.UniversityId;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);
                command.Parameters.Add(pMajor);
                command.Parameters.Add(pDegree);
                command.Parameters.Add(pGpa);
                command.Parameters.Add(pUID);

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

        // DELETE : Education(5)
        public int DeleteEducation(Education education)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                // Command melakukan delete
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_educations WHERE Id = (@id)";
                command.Transaction = transaction;

                // Membuat parameter
                var pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = SqlDbType.Int;
                pId.Value = education.Id;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);

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

        public int GetLastEducationID()
        {
            using var connection = MyConnection.Get();
            connection.Open();

                // Command melakukan select
                SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_educations ORDER BY id DESC;", connection);

                // Menjalankan select dan mencari ID terakhir
                int lastInsertedId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();

                return lastInsertedId;
            
        }

    }
}
