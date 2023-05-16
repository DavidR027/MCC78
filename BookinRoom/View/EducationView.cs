using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoom.Model;

namespace BookingRoom.View;

public class EducationView
{
    public void Header()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("            Educations            ");
        Console.WriteLine("----------------------------------");
    }

    public void Footer()
    {
        Console.WriteLine("----------------------------------\n");
    }

    public void Output(Education education)
    {
        Console.WriteLine("Id: " + education.Id);
        Console.WriteLine("Major: " + education.Major);
        Console.WriteLine("Degree: " + education.Degree);
        Console.WriteLine("GPA: " + education.GPA);
        Console.WriteLine("University_Id: " + education.UniversityId + "\n");
    }

    public void Output(string message)
    {
        Console.WriteLine(message);
    }

    public void Input(string message)
    {
        Console.Write(message);
    }

    public void InputPlus(string message)
    {
        Console.Write("\n");
        Console.Write(message);
    }
}