using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KeeperContext _db;
        public UserRepository(KeeperContext db)
        {
            _db = db;
        }

        public async Task Create(Users user)
        {
            user.Password = UserExtension.HashPassword(user.Password); // Используйте имя класса для вызова статического метода

            _db.Users.Add(user);
            await _db.SaveChangesAsync(); // Используйте асинхронный метод для сохранения изменений
        }

        public async Task<Users> Get(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async IAsyncEnumerable<Users> GetAll()
        {
            var allUsers = await _db.Users.ToListAsync();
            foreach (var user in allUsers)
            {
                yield return user;
            }
        }

        public async Task Remove(int id)
        {
            var user = await _db.Users.FindAsync(id);

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }


    }

    public class UserExtension
    {
        public static string HashPassword(string password)
        {
            // Реализация хеширования пароля с использованием MD5
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Конвертируем байты обратно в строку
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
