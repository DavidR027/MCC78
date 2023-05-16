// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using BasicConnection.Controller;
using BookingRoom.Model;
using BookingRoom.View;

namespace BookingRoom;

public class Program
{

    public static void Main()
    {
        Menu.RunProgram();
    }
}