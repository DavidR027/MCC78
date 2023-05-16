using BookingRoom.View;
using BookingRoom.Model;
using BookingRoom;
using static BasicConnection.Controller.UniversityController;
using static BookingRoom.View.Menu;

namespace BasicConnection.Controller;

public class UniversityController
{
    private University _university = new University();
    private Menu _menu = new Menu();
    private UniversityView view = new UniversityView();

    public void GetAll()
    {
        var results = _university.GetUniversities();
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
        _university.Id = Convert.ToInt16(Console.ReadLine());
        view.Input("\n");

        var result = _university.GetUniversitiesById(_university);
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
        view.Input("Masukkan Nama Universitas: ");
        _university.Name = Console.ReadLine();
        view.Input("\n");

        var result = _university.InsertUniversity(_university);
        _menu.getStatus(result);
    }

    public void Update()
    {
        view.Footer();
        view.Input("Pilih ID: ");
        _university.Id = Convert.ToInt16(Console.ReadLine());
        view.InputPlus("Masukkan Perubahan Nama Universitas: ");
        _university.Name = Console.ReadLine();
        view.Input("\n");

        var result = _university.UpdateUniversity(_university);
        _menu.getStatus(result);
    }

    public void Delete()
    {
        view.Footer();
        view.Input("Pilih ID: ");
        _university.Id = Convert.ToInt16(Console.ReadLine());
        view.Input("\n");

        var result = _university.DeleteUniversity(_university);
        _menu.getStatus(result);
    }

}
