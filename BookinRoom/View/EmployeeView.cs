using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoom.Model;

namespace BookingRoom.View;

public class EmployeeView
{
    public void Header()
    {
        Console.WriteLine("===================================================");
        Console.WriteLine("                     Employees                     ");
        Console.WriteLine("---------------------------------------------------");
    }

    public void Footer()
    {
        Console.WriteLine("---------------------------------------------------\n");
    }

    public void Output(Employee employee)
    {
        Console.WriteLine("Id: " + employee.Id);
        Console.WriteLine("NIK: " + employee.NIK);
        Console.WriteLine("First Name: " + employee.FirstName);
        Console.WriteLine("Last Name: " + employee.LastName);
        Console.WriteLine("Birthdate: " + employee.Birthdate);
        Console.WriteLine("Gender: " + employee.Gender);
        Console.WriteLine("Hiring Date: " + employee.HiringDate);
        Console.WriteLine("Email: " + employee.Email);
        Console.WriteLine("Phone Number: " + employee.PhoneNumber);
        Console.WriteLine("Department ID: " + employee.DepartmentId + "\n");
    }

    public void Combine(List<CombineTable> Combine)
    {
        foreach (var showAll in Combine)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("NIK: " + showAll.NIK + "\n" +
                "Full Name: " + showAll.FirstName + " " + showAll.LastName + "\n" +
                "Birthdate: " + showAll.Birthdate + "\n" +
                "Gender: " + showAll.Gender + "\n" +
                "Hiring Date: " + showAll.HiringDate + "\n" +
                "Email: " + showAll.Email + "\n" +
                "Phone Number: " + showAll.PhoneNumber + "\n" +
                "Major: " + showAll.Major + "\n" +
                "Degree: " + showAll.Degree + "\n" +
                "GPA: " + showAll.GPA + "\n" +
                "University Name: " + showAll.Name);
            Console.WriteLine("-----------------------------------------------\n");
        }
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