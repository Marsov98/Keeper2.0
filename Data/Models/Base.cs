using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Base
{
    [Key]
    public int Id { get; set; }
}
