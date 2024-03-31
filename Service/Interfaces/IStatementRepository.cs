using Data.Models;

namespace Service.Interfaces;

public interface IStatementRepository
{
    List<Employees> GetEmployees();
    List<Division> GetDivision();
    List<Statement> GetStatement();
    void CreateIndivid(Statement Statement);
    void CreateGroup(List<Statement> Statement);
    int GetNextApplicationNumber();
}
