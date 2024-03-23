using System.Data;

namespace Data.Models;

public class Users : Base
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Name { get; set; } = null!;
    public string? Passport { get; set; } = null!;
    public bool? BlFirst { get; set; }
    public bool? BlLast { get; set; }

    public int? RoleId { get; set; }
    public Role? Role { get; set; }

}
