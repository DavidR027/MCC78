using BookingRoom.View;
using BookingRoom.Model;
using BookingRoom;
using static BasicConnection.Controller.CombineController;

namespace BasicConnection.Controller;

public class CombineController
{
    private Employee _employee = new Employee();
    private Education _education = new Education();
    private University _university = new University();
    private Profiling _profiling = new Profiling();
    private Menu _menu = new Menu();


    public void InsertAll()
    {
        var view = new EmployeeView();
        view.Input("---------University---------\n");
        view.Input("Masukkan Nama Universitas: ");
        _university.Name = Console.ReadLine();
        view.Input("\n");

        var resultUniversity = _university.InsertUniversity(_university);
        _menu.getStatus(resultUniversity);
        view.Input("\n");


        view.Input("--------Education---------\n");
        view.Input("Masukkan Nama Major: ");
        _education.Major = Console.ReadLine();
        view.InputPlus("Masukkan Nama Degree: ");
        _education.Degree = Console.ReadLine();
        view.InputPlus("Masukkan Nama GPA: ");
        _education.GPA = Console.ReadLine();
        _education.UniversityId = _university.GetLastUniversityID();
        view.InputPlus("Universitas ID: " + _education.UniversityId + "\n");
        view.Input("\n");
        var resultEducation = _education.InsertEducation(_education);
        _menu.getStatus(resultEducation);
        view.Input("\n");


        view.Input("--------Employee---------\n");
        view.Input("Masukkan NIK: ");
        _employee.NIK = Console.ReadLine();
        view.InputPlus("Masukkan Nama Depan: ");
        _employee.FirstName = Console.ReadLine();
        view.InputPlus("Masukkan Nama Belakang: ");
        _employee.LastName = Console.ReadLine();
        view.InputPlus("Masukkan Tanggal Lahir: ");
        _employee.Birthdate = Convert.ToDateTime(Console.ReadLine());
        view.InputPlus("Masukkan Jenis Kelamin: ");
        _employee.Gender = Console.ReadLine();
        view.InputPlus("Masuukkan Tanggal Masuk: ");
        _employee.HiringDate = Convert.ToDateTime(Console.ReadLine());
        view.InputPlus("Masukkan Email: ");
        _employee.Email = Console.ReadLine();
        view.InputPlus("Masukkan Nomor Telepon: ");
        _employee.PhoneNumber = Console.ReadLine();
        view.InputPlus("Masukkan Department ID: ");
        _employee.DepartmentId = Console.ReadLine();
        view.Input("\n");

        var resultEmployee = _employee.InsertEmployee(_employee);
        _menu.getStatus(resultEmployee);
        view.Input("\n");


        view.Input("--------Profiling---------\n");
        _profiling.EmployeeId = _employee.GetLastEmpID(_employee.NIK);
        view.Input("Employee ID: " + _profiling.EmployeeId + "\n");
        view.Input("\n");
        _profiling.EducationId = _education.GetLastEducationID();
        view.Input("Education ID: " + _profiling.EducationId + "\n");
        view.Input("\n");

        var resultProfiling = _profiling.InsertProfiling(_profiling);
        _menu.getStatus(resultProfiling);
        view.Input("\n");
    }

    public void GetCombineTable()
    {
        var view = new EmployeeView();
        Employee employee = new Employee();
        var result = employee.checkAll();
        view.Combine(result);
    }

}