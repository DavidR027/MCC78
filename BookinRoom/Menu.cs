using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom;

public class Menu
{
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
            Console.WriteLine("6. Exit");
            Console.WriteLine("------------------------------\n");
        }

        public static void MenuDatabase()
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("                 Pilih Database                  ");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.WriteLine("3. Employee (Hanya bisa melakukan Insert dan juga akan");
            Console.WriteLine("   menambah dalam Profiling, Education, dan University)");
            Console.WriteLine("4. Back");
            Console.WriteLine("5. Exit");
            Console.WriteLine("-------------------------------------------------\n");
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