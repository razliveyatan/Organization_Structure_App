namespace DAL.Types;
public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;


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
