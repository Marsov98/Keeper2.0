using Data.Models;

namespace Service.Interfaces;

public interface IUserRepository
{
    Users SignUp(Users user);

    Employees CreateEmployees(Employees employees);

    Division CreateDivision(Division division);

    Users Auth(Users user);

    List<Users> GetAllUsers();

    void Remove(int id);

    Users GetUser(int id);
}
