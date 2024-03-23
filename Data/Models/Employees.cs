namespace Data.Models;

public class Employees : Base
{
    public string Name { get; set; }

    public int DivisionId { get; set; }
    public Division? Division { get; set; } = null;

    public string Departament { get; set; } = null;
}
