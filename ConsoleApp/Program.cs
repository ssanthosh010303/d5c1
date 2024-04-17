/*
 * Author: Sakthi Santhosh
 * Created on: 15/04/2024
 *
 * Day-5 Challenge-1: CRUD Operations on Employee Model
 */
using EmployeeLibrary;

namespace Challenge1;

class Program
{
    static void Main()
    {
        EmployeeController employeeHandle = new(3);

        employeeHandle.CreateNewEmployee(1, 45, "Sakthi Santhosh", DateTime.Today, 25000);
        employeeHandle.CreateNewEmployee(2, 48, "Attack Helicopter", DateTime.Today, 550000);
        employeeHandle.PrintAllEmployees();

        employeeHandle.UpdateEmployee(2, 45, "Attack Helicopter", DateTime.Today, 850000);
        employeeHandle.DeleteEmployee(1);
        Console.WriteLine();
        employeeHandle.PrintAllEmployees();
    }
}
