using BookingRoom.View;
using BookingRoom.Model;
using BookingRoom;
using static BasicConnection.Controller.EducationController;

namespace BasicConnection.Controller;

public class EducationController
{
    private Education _education = new Education();
    private Menu _menu = new Menu();
    private EducationView view = new EducationView();   

    public void GetAll()
    {
        var results = _education.GetEducation();
        view.Header();
        foreach (var result in results)
        {
            view.Output(result);
        }
        view.Footer();
    }

    public void GetAllbyID()
    {
        view.Footer();
        view.Input("Pilih ID: ");
        _education.Id = Convert.ToInt16(Console.ReadLine());
        view.Input("\n");

        var result = _education.GetEducationById(_education);
        view.Header();
        if (result == null)
        {
            view.Output("Data Tidak Ditemukan");
        }
        else
        {
            view.Output(result);
        }
        view.Footer();
    }

    public void Insert()
    {
        view.Footer();
        view.Input("Masukkan Nama Major: ");
        _education.Major = Console.ReadLine();
        view.InputPlus("Masukkan Nama Degree: ");
        _education.Degree = Console.ReadLine();
        view.InputPlus("Masukkan Nama GPA: ");
        _education.GPA = Console.ReadLine();
        view.InputPlus("Pilih University ID: ");
        _education.UniversityId = Convert.ToInt16(Console.ReadLine());
        view.Input("\n");

        var result = _education.InsertEducation(_education);
        _menu.getStatus(result);
    }

    public void Update()
    {
        view.Footer();
        view.Input("Pilih ID: ");
        _education.Id = Convert.ToInt16(Console.ReadLine());
        view.InputPlus("Masukkan Perubahan Nama Major: ");
        _education.Major = Console.ReadLine();
        view.InputPlus("Masukkan Perubahan Nama Degree: ");
        _education.Degree = Console.ReadLine();
        view.InputPlus("Masukkan Perubahan Nama GPA: ");
        _education.GPA = Console.ReadLine();
        view.InputPlus("Masukkan Perubahan University ID: ");
        _education.UniversityId = Convert.ToInt16(Console.ReadLine());
        view.Input("\n");

        var result = _education.UpdateEducation(_education);
        _menu.getStatus(result);
    }

    public void Delete()
    {
        view.Footer();
        view.Input("Pilih ID: ");
        _education.Id = Convert.ToInt16(Console.ReadLine());
        view.Input("\n");

        var result = _education.DeleteEducation(_education);
        _menu.getStatus(result);
    }

}
