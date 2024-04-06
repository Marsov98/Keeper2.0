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

        public Users SignUp(Users user)
        {
            user.Password = UserExtension.HashPassword(user.Password); // Используйте имя класса для вызова статического метода
            user.RoleId = 1;

            _db.Users.Add(user);
            _db.SaveChanges(); // Используйте асинхронный метод для сохранения изменений

            return user;
        }

        public Users GetUser(int id)
        {
            return _db.Users.Find(id);
        }

        public List<Users> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public void Remove(int id)
        {
            Users user = GetUser(id);

            _db.Users.Remove(user);
            _db.SaveChangesAsync();
        }

        public Users Auth(Users InputAuth)
        {
            InputAuth.Password = UserExtension.HashPassword(InputAuth.Password);

            var User = _db.Users.Where(u => u.Login == InputAuth.Login && u.Password == InputAuth.Password).FirstOrDefault<Users>();
            User.Role = _db.Role.Where(p => p.Id == User.RoleId).FirstOrDefault();
            return User;
        }

        public Employees CreateEmployees(Employees employees)
        {
            employees.Division = _db.Division.Where(p => p.Id == employees.DivisionId).FirstOrDefault();
            _db.Employees.Add(employees);
            _db.SaveChanges(); // Используйте асинхронный метод для сохранения изменений

            return employees;
        }

        public Division CreateDivision(Division division)
        {
            _db.Division.Add(division);
            _db.SaveChanges(); // Используйте асинхронный метод для сохранения изменений

            return division; ;
        }

        public Users GetUserByPassport(string passport)
        {
            return _db.Users.Where(p => p.Passport == passport).FirstOrDefault();
        }

        public void BlackList(string passport)
        {
            var User = GetUserByPassport(passport);
            if (User.BlFirst == true) 
            {
                User.BlFirst = false;
            }
            else {
                User.BlLast = false;
            }
            _db.Attach(User).State = EntityState.Modified;
            _db.SaveChanges();
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
