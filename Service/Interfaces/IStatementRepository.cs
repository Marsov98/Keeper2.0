using Data.Models;

namespace Service.Interfaces;

public interface IStatementRepository
{
    List<Employees> GetEmployees();
    List<Division> GetDivision();
    List<Statement> GetStatement();
    Statement CreateIndivid(Statement Statement);
    Statement CreateGroup(List<Statement> Statement);
    int GetNextApplicationNumber();
}
