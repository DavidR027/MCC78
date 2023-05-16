using BookingRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.View;

public class UniversityView
{
    public void Header()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("          Universities            ");
        Console.WriteLine("----------------------------------");
    }

    public void Footer() 
    {
        Console.WriteLine("----------------------------------\n");
    }

    public void Output(University university)
    {
        Console.WriteLine("Id: " + university.Id);
        Console.WriteLine("Name: " + university.Name + "\n");
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
