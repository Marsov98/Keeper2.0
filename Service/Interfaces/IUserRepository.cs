using Data.Models;

namespace Service.Interfaces;

public interface IUserRepository
{
    Task Create(Users user);

    IAsyncEnumerable<Users> GetAll();

    Task Remove(int id);

    Task<Users> Get(int id);
}
