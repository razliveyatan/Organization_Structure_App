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
    public string ManagerFullName { get; set; } = string.Empty; 

    public bool IsManager { get; set; } = false;
    

    //public Manager Manager { get; set; }

    public ICollection<Report>? Reports { get; set; }

    public ICollection<CustomTask>? CustomTasks { get; set; }
    


}
