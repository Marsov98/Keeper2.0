using Data.Models;

namespace Service.Interfaces;

public interface IStatementRepository
{
    List<Employees> GetEmployees();
    List<Division> GetDivision();
    List<Statement> GetStatement();
    Statement GetIndivid(int Id);
    List<Statement> GetGroup(int Id);
    void CreateIndivid(Statement Statement);
    void CreateGroup(List<Statement> Statement);
    int GetNextApplicationNumber();
    Task<int> CreateVisitTimeAsync(VisitTime VisitTime);
    void UpdateVisitTime(VisitTime UpdateVisitTime);
    VisitTime GetVisitTimeById(int? Id);
    void UpdateIndivid(Statement Statement);
    void UpdateGroup(List<Statement> Statement);
    List<BusyTime> GetBusyTime();
    void UpdateBusyTime(BusyTime busyTime);

}
