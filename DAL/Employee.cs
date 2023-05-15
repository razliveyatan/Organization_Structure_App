namespace DAL;
public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Position { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;     
    public string Phone { get; set; } = String.Empty;

    public int? ManagerId { get; set; }
    public Employee Manager { get; set; }
    public ICollection<Employee> Employees { get; set; }

    public ICollection<Report> Reports { get; set; }

    public ICollection<CustomTask> CustomTasks { get; set; }

    public Employee()
    {
        Employees = new HashSet<Employee>();
        Reports = new HashSet<Report>();
        CustomTasks = new HashSet<CustomTask>();
    }


}
