/*
 * Author: Sakthi Santhosh
 * Created on: 15/04/2024
 */
namespace EmployeeLibrary;

public class EmployeeModel
{
    private byte _age;
    private uint _id;
    private string? _name;
    private DateTime _dateOfBirth;
    private uint _salary;

    public uint Id
    {
        get { return _id; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Id), "ID must be greater than zero.");
            _id = value;
        }
    }

    public byte Age
    {
        get { return _age; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Age), "Age must be greater than zero.");
            _age = value;
        }
    }

    public string? Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Name cannot be null or empty.", nameof(Name));
            _name = value;
        }
    }

    public DateTime DateOfBirth
    {
        get { return _dateOfBirth; }
        set
        {
            if (value > DateTime.Today)
                throw new ArgumentException("Date of birth must be in the past.", nameof(DateOfBirth));
            _dateOfBirth = value;
        }
    }

    public uint Salary
    {
        get { return _salary; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Salary), "Salary cannot be less than zero.");
            _salary = value;
        }
    }

    public EmployeeModel(uint id, byte age, string name, DateTime dateOfBirth, uint salary = 0)
    {
        Id = id;
        Age = age;
        Name = name;
        DateOfBirth = dateOfBirth;
        Salary = salary;
    }
}

public class EmployeeController(uint size)
{
    private readonly uint _size = size;
    private EmployeeModel?[] _employees = new EmployeeModel[size];

    private void _AddEmployee(EmployeeModel newEmployee)
    {
        for (int index = 0; index < _size; index++)
        {
            if (_employees[index] == null)
            {
                _employees[index] = newEmployee;
                return;
            }
        }
        throw new InvalidOperationException("No more space to add employees.");
    }

    public void CreateNewEmployee(uint id, byte age, string name, DateTime dateOfBirth, uint salary = 0)
    {
        EmployeeModel newEmployee = new EmployeeModel(id, age, name, dateOfBirth, salary);
        _AddEmployee(newEmployee);
    }

    public void CreateMultipleNewEmployees(params EmployeeModel[] newEmployees)
    {
        foreach (EmployeeModel employee in newEmployees)
        {
            _AddEmployee(employee);
        }
    }

    public EmployeeModel? SearchEmployee(uint id)
    {
        foreach (EmployeeModel? employee in _employees)
        {
            if (employee != null && employee.Id == id)
            {
                return employee;
            }
        }
        return null;
    }

    public static void PrintEmployee(EmployeeModel employee)
    {
        Console.WriteLine("Employee Details");
        Console.WriteLine("  ID:            " + employee.Id);
        Console.WriteLine("  Name:          " + employee.Name);
        Console.WriteLine("  Age:           " + employee.Age);
        Console.WriteLine("  Date of birth: " + employee.DateOfBirth);
        Console.WriteLine("  Salary:        " + employee.Salary);
        Console.WriteLine();
    }

    public void PrintEmployee(uint id)
    {
        EmployeeModel? employee = SearchEmployee(id);
        if (employee != null)
            PrintEmployee(employee);
        else
            Console.WriteLine("Error: Employee not found.");
    }

    public void PrintAllEmployees()
    {
        foreach (EmployeeModel? employee in _employees) {
            if (employee != null) PrintEmployee(employee);
        }
    }

    public void DeleteEmployee(uint id)
    {
        EmployeeModel? employee = SearchEmployee(id);
        if (employee != null)
        {
            for (int index = 0; index < _size; index++)
            {
                if (_employees[index] != null && _employees[index].Id == id)
                {
                    _employees[index] = null;
                    Console.WriteLine("Info: Employee deleted successfully.");
                    return;
                }
            }
        }
        Console.WriteLine("Error: Employee not found.");
    }

    public void UpdateEmployee(uint id, byte age, string name, DateTime dateOfBirth, uint salary)
    {
        EmployeeModel? employee = SearchEmployee(id);
        if (employee != null)
        {
            employee.Age = age;
            employee.Name = name;
            employee.DateOfBirth = dateOfBirth;
            employee.Salary = salary;
            Console.WriteLine("Info: Employee updated successfully.");
        }
        else
        {
            Console.WriteLine("Error: Employee not found.");
        }
    }
}
