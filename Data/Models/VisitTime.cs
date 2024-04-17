namespace Data.Models;

public class VisitTime : Base
{
    public DateTime TimeIn { get; set; }
    public DateTime TimeOut { get; set; }
    public DateTime TimeStart { get; set; }
    public DateTime TimeEnd { get; set; }
}
