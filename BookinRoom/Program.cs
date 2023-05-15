// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace BookingRoom;

public class Program
{
    private static readonly string connectionString =
        "Data Source=LAPTOP-FTO3M4EL;Database=booking_room;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static void Main()
    {
        int pilihCrud;
        int pilihDB;

        do
        {
            Menu.MenuPilih();
            Console.Write("Pilihan: ");
            pilihCrud = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

            Menu.MenuDatabase();
            Console.Write("Pilihan: ");
            pilihDB = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

        } while (pilihDB == 4);

        Status status = new Check();

        // -------------------------------------------------------------- CRUD University

        var university = new University();

        if (pilihCrud == 1 && pilihDB == 1) //GetUniversities
        {
            var results = University.GetUniversities();
            Console.WriteLine("==================================");
            Console.WriteLine("          Universities            ");
            Console.WriteLine("----------------------------------");
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Name: " + result.Name + "\n");
            }
            Console.WriteLine("----------------------------------\n");

        }
        else if (pilihCrud == 2 && pilihDB == 1) //GetUniversitiesById
        {
            Console.WriteLine("----------------------------------\n");
            Console.Write("Pilih ID: ");
            university.Id = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

            var results = University.GetUniversitiesById(university);
            Console.WriteLine("==================================");
            Console.WriteLine("          Universities            ");
            Console.WriteLine("----------------------------------");
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Name: " + result.Name);
            }
            Console.WriteLine("----------------------------------\n");

        }
        else if (pilihCrud == 3 && pilihDB == 1) //InsertUniversity
        {
            Console.WriteLine("----------------------------------\n");
            Console.Write("Masukkan Nama Universitas: ");
            university.Name = Console.ReadLine();
            Console.WriteLine("\n");

            var result = University.InsertUniversity(university);
            status.CheckStatus(result);

        }
        else if (pilihCrud == 4 && pilihDB == 1) //UpdateUniversity
        {
            Console.WriteLine("----------------------------------\n");
            Console.Write("Pilih ID: ");
            university.Id = Convert.ToInt16(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Masukkan Perubahan Nama Universitas: ");
            university.Name = Console.ReadLine();
            Console.WriteLine("\n");

            var result = University.UpdateUniversity(university);
            status.CheckStatus(result);

        }
        else if (pilihCrud == 5 && pilihDB == 1) // DeleteUniversity
        {
            Console.WriteLine("----------------------------------\n");
            Console.Write("Pilih ID: ");
            university.Id = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

            var result = University.DeleteUniversity(university);
            status.CheckStatus(result);
        }

        // -------------------------------------------------------------- CRUD Education
        var education = new Education();

        if (pilihCrud == 1 && pilihDB == 2) //GetEducation
        {
            var results = Education.GetEducation();
            Console.WriteLine("==================================");
            Console.WriteLine("             Education            ");
            Console.WriteLine("----------------------------------");
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Major: " + result.Major);
                Console.WriteLine("Degree: " + result.Degree);
                Console.WriteLine("GPA: " + result.GPA);
                Console.WriteLine("University_Id: " + result.UniversityId + "\n");
            }
            Console.WriteLine("----------------------------------\n");

        }
        else if (pilihCrud == 2 && pilihDB == 2) //GetEducationById
        {
            Console.WriteLine("----------------------------------\n");
            Console.Write("Pilih ID: ");
            education.Id = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

            var results = Education.GetEducationById(education);
            Console.WriteLine("==================================");
            Console.WriteLine("             Education            ");
            Console.WriteLine("----------------------------------");
            foreach (var result in results)
            {
                Console.WriteLine("Id: " + result.Id);
                Console.WriteLine("Major: " + result.Major);
                Console.WriteLine("Degree: " + result.Degree);
                Console.WriteLine("GPA: " + result.GPA);
                Console.WriteLine("University_Id: " + result.UniversityId);
            }
            Console.WriteLine("----------------------------------\n");

        }
        else if (pilihCrud == 3 && pilihDB == 2) //InsertEducation
        {
            Console.WriteLine("----------------------------------\n");
            Console.Write("Masukkan Nama Major: ");
            education.Major = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Masukkan Nama Degree: ");
            education.Degree = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Masukkan Nama GPA: ");
            education.GPA = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Pilih University ID: ");
            education.UniversityId = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

            var result = Education.InsertEducation(education);
            status.CheckStatus(result);

        }
        else if (pilihCrud == 4 && pilihDB == 2) //UpdateEducation
        {
            Console.WriteLine("----------------------------------\n");
            Console.Write("Pilih ID: ");
            education.Id = Convert.ToInt16(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Masukkan Perubahan Nama Major: ");
            education.Major = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Masukkan Perubahan Nama Degree: ");
            education.Degree = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Masukkan Perubahan Nama GPA: ");
            education.GPA = Console.ReadLine();
            Console.Write("\n");
            Console.Write("Masukkan Perubahan University ID: ");
            education.UniversityId = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

            var result = Education.UpdateEducation(education);
            status.CheckStatus(result);

        }
        else if (pilihCrud == 5 && pilihDB == 2) // DeleteEducation
        {
            Console.WriteLine("----------------------------------\n");
            Console.Write("Pilih ID: ");
            education.Id = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

            var result = Education.DeleteEducation(education);
            status.CheckStatus(result);
        }
        if (pilihCrud == 3 && pilihDB == 3)
        {
            InsertAll();
        }
    }

    public static void InsertAll()
    {
        Status status = new Check();

        var university = new University();
        Console.WriteLine("---------University---------\n");
        Console.Write("Masukkan Nama Universitas: ");
        university.Name = Console.ReadLine();
        Console.WriteLine("\n");

        var resultUniversity = University.InsertUniversity(university);
        status.CheckStatus(resultUniversity);
        Console.WriteLine("\n");


        var education = new Education();
        var pembedaUni = 1;
        Console.WriteLine("--------Education---------\n");
        Console.Write("Masukkan Nama Major: ");
        education.Major = Console.ReadLine();
        Console.Write("\n");
        Console.Write("Masukkan Nama Degree: ");
        education.Degree = Console.ReadLine();
        Console.Write("\n");
        Console.Write("Masukkan Nama GPA: ");
        education.GPA = Console.ReadLine();
        Console.Write("\n");
        education.UniversityId = GetLastEduUnivID(pembedaUni);
        Console.WriteLine("Universitas ID: " + education.UniversityId + "\n");

        var resultEducation = Education.InsertEducation(education);
        status.CheckStatus(resultEducation);
        Console.WriteLine("\n");


        var employee = new Employee();
        Console.WriteLine("--------Employee---------\n");
        Console.Write("Masukkan NIK: ");
        employee.NIK = Console.ReadLine();
        Console.Write("\n");
        Console.Write("Masukkan Nama Depan: ");
        employee.FirstName = Console.ReadLine();
        Console.Write("\n");
        Console.Write("Masukkan Nama Belakang: ");
        employee.LastName = Console.ReadLine();
        Console.Write("\n");
        Console.Write("Masukkan Tanggal Lahir: ");
        employee.Birthdate = Convert.ToDateTime(Console.ReadLine());
        Console.Write("\n");
        Console.Write("Masukkan Jenis Kelamin: ");
        employee.Gender = Console.ReadLine();
        Console.Write("\n");
        Console.Write("Masuukkan Tanggal Masuk: ");
        employee.HiringDate = Convert.ToDateTime(Console.ReadLine());
        Console.Write("\n");
        Console.Write("Masukkan Email: ");
        employee.Email = Console.ReadLine();
        Console.Write("\n");
        Console.Write("Masukkan Nomor Telepon: ");
        employee.PhoneNumber = Console.ReadLine();
        Console.Write("\n");
        Console.Write("Masukkan Department ID: ");
        employee.DepartmentId = Console.ReadLine();
        Console.WriteLine("\n");

        var resultEmployee = Employee.InsertEmployee(employee);
        status.CheckStatus(resultEmployee);
        Console.WriteLine("\n");


        var profiling = new Profiling();
        var pembedaEdu = 2;
        Console.WriteLine("--------Profiling---------\n");
        profiling.EmployeeId = GetLastEmpID(employee.NIK);
        Console.WriteLine("Employee ID: "+profiling.EmployeeId + "\n");
        profiling.EducationId = GetLastEduUnivID(pembedaEdu);
        Console.WriteLine("Education ID: " + profiling.EducationId);
        Console.WriteLine("\n");

        var resultProfiling = Profiling.InsertProfiling(profiling);
        status.CheckStatus(resultProfiling);
        Console.WriteLine("\n");
    }


    public static string GetLastEmpID(string NIK)
    {
        using var connection = new SqlConnection(connectionString);
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


    public static int GetLastEduUnivID(int pembeda)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        if (pembeda == 1)
        {
            // Command melakukan select
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_universities ORDER BY id DESC;", connection);

            // Menjalankan select dan mencari ID terakhir
            int lastInsertedId = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return lastInsertedId;
        }
        else
        {
            // Command melakukan select
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_educations ORDER BY id DESC;", connection);

            // Menjalankan select dan mencari ID terakhir
            int lastInsertedId = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return lastInsertedId;
        }
    }
}

//Abstract check status
public abstract class Status
{
    public abstract void CheckStatus(int result);
}