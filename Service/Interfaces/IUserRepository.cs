using Data.Models;

namespace Service.Interfaces;

public interface IUserRepository
{
    Users SignUp(Users user);

    Users Auth(Users user);

    List<Users> GetAllUsers();

    void Remove(int id);

    Users GetUser(int id);
}
