using Data.Models;


public class Statement : Base
{
    public int ApplicationNumber { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public string FirstName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Number { get; set; }
    public string Email { get; set; }
    public string Organization { get; set; }
    public string Note { get; set; }
    public DateTime Birthday { get; set; }
    public string Passport { get; set; }
    public byte[]? Pdf { get; set; }
    public byte[]? Photo { get; set; }
    public string Target { get; set; }

    public int EmployeeId { get; set; }
    public Employees? Employees { get; set; }

    public string? Status { get; set; }
    public bool? blackList { get; set; }

    public int? VisitTimeId { get; set; } = null;
    public VisitTime? VisitTime { get; set; }
}

