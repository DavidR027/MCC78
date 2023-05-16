using BasicConnection.Controller;
using BookingRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.View;

public class Menu
{

    private static UniversityController universityController = new();
    private static EducationController educationController = new();
    private static EmployeeController employeeController = new();
    private static CombineController allController = new();

    public void getStatus(int result)
    {
        Status status = new Check();
        status.CheckStatus(result);
    }

    //Abstract check status
    public abstract class Status
    {
        public abstract void CheckStatus(int result);
    }

    public static void MenuPilih()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("          Menu CRUD           ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1. View All Data");
        Console.WriteLine("2. View Data by ID");
        Console.WriteLine("3. Insert Data");
        Console.WriteLine("4. Update Data");
        Console.WriteLine("5. Delete Data");
        Console.WriteLine("6. LINQ");
        Console.WriteLine("------------------------------\n");
    }

    public static void MenuDatabase()
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("                 Pilih Database                  ");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("1. University");
        Console.WriteLine("2. Education");
        Console.WriteLine("3. Employee (Hanya bisa View All dan melakukan Insert yang");
        Console.WriteLine("   akan menambah dalam Profiling, Education, dan University)");
        Console.WriteLine("4. Back");
        Console.WriteLine("5. Exit");
        Console.WriteLine("-------------------------------------------------\n");
    }

    public static void RunProgram()
    {
        int pilihCrud;
        int pilihDB;

        do //Mengulang jika saat menu kedua pilih back
        {
            MenuPilih();
            Console.Write("Pilihan: ");
            pilihCrud = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

            MenuDatabase();
            Console.Write("Pilihan: ");
            pilihDB = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\n");

        } while (pilihDB == 4);

        var profiling = new Profiling();

        // -------------------------------------------------------------- CRUD University

        if (pilihCrud == 1 && pilihDB == 1) //GetUniversities
        {
            universityController.GetAll();
        }
        else if (pilihCrud == 2 && pilihDB == 1) //GetUniversitiesById
        {
            universityController.GetAllbyID();
        }
        else if (pilihCrud == 3 && pilihDB == 1) //InsertUniversity
        {
            universityController.Insert();
        }
        else if (pilihCrud == 4 && pilihDB == 1) //UpdateUniversity
        {
            universityController.Update();
        }
        else if (pilihCrud == 5 && pilihDB == 1) // DeleteUniversity
        {
            universityController.Delete();
        }

        // -------------------------------------------------------------- CRUD Education

        if (pilihCrud == 1 && pilihDB == 2) //GetEducation
        {
            educationController.GetAll();
        }
        else if (pilihCrud == 2 && pilihDB == 2) //GetEducationById
        {
            educationController.GetAllbyID();
        }
        else if (pilihCrud == 3 && pilihDB == 2) //InsertEducation
        {
            educationController.Insert();
        }
        else if (pilihCrud == 4 && pilihDB == 2) //UpdateEducation
        {
            educationController.Update();
        }
        else if (pilihCrud == 5 && pilihDB == 2) // DeleteEducation
        {
            educationController.Delete();
        }

        // -------------------------------------------------------------- Employee

        if (pilihCrud == 1 && pilihDB == 3)
        {
            employeeController.GetAll();
        }
        else if (pilihCrud == 3 && pilihDB == 3)
        {
            allController.InsertAll();
        }
        else if (pilihCrud == 6 && pilihDB == 3)
        {
            allController.GetCombineTable();
        }
    }


    public class Check : Status
    {
        public override void CheckStatus(int result)
        {
            if (result > 0)
            {
                Console.WriteLine("Process success.");
            }
            else
            {
                Console.WriteLine("Process failed.");
            }
        }
    }
}