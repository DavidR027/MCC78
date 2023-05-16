using BookingRoom.View;
using BookingRoom.Model;
using BookingRoom;
using static BasicConnection.Controller.EmployeeController;

namespace BasicConnection.Controller;

public class EmployeeController
{
    private Employee _employee = new Employee();

    public void GetAll()
    {
        var results = _employee.GetEmployees();
        var view = new EmployeeView();
        view.Header();
        foreach (var result in results)
        {
            view.Output(result);
        }
        view.Footer();
    }
}
