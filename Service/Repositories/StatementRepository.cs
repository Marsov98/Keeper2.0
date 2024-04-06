using Data;
using Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Service.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        private readonly KeeperContext _db;
        private readonly IUserRepository _user;
        public StatementRepository(KeeperContext db, IUserRepository user)
        {
            _db = db;
            _user = user;
        }

        public void CreateGroup(List<Statement> Statement)
        {
            if (Statement != null)
            {
                int applicationNumber = GetNextApplicationNumber();
                foreach (var user in Statement)
                {
                    user.ApplicationNumber = applicationNumber;

                    _db.Statement.Add(user);
                }
                _db.SaveChanges();
            }
        }

        public void CreateIndivid(Statement Statement)
        {
            _db.Statement.Add(Statement);
            _db.SaveChanges();
        }

        public List<Division> GetDivision()
        {
            return _db.Division.ToList();
        }

        public List<Employees> GetEmployees()
        {
            List<Division> Divis = GetDivision();
            List<Employees> Employees = _db.Employees.ToList();
            int Count = Employees.Count();
            for (int i = 0; i < Count; i++)
            {
                Employees[i].Division = Divis[Employees[i].DivisionId - 1];
            }
            return Employees;
        }

        public List<Statement> GetGroup(int Id)
        {
            var Statement = _db.Statement.Where(u => u.ApplicationNumber == Id).ToList();
            List<Employees> Employees = GetEmployees();
            int Count = Statement.Count();
            for (int i = 0; i < Count; i++)
            {
                Statement[i].Employees = Employees[Statement[i].EmployeeId - 1];
            }
            return Statement;
        }

        public Statement GetIndivid(int Id)
        {
            var Statement = _db.Statement.Where(u => u.Id == Id).FirstOrDefault();
            List<Employees> Employees = GetEmployees();

            Statement.Employees = Employees[Statement.EmployeeId - 1];

            return Statement;
        }

        public int GetNextApplicationNumber()
        {
            var NextApplicationNumber = _db.Statement.Max(u => u.ApplicationNumber) + 1;
            return (int)NextApplicationNumber;
        }


        public List<Statement> GetStatement()
        {
            var Statement = _db.Statement.ToList();
            List<Employees> Employees = GetEmployees();
            int Count = Statement.Count();
            for (int i = 0; i < Count; i++)
            {
                Statement[i].Employees = Employees[Statement[i].EmployeeId - 1];
            }
            return Statement;
        }

        public void UpdateGroup(List<Statement> statements)
        {
            foreach (var statement in statements)
            {
                statement.Employees = null;
                // Теперь прикрепляем и обновляем сущность
                _db.Attach(statement);
                _db.Entry(statement).State = EntityState.Modified;
            }
            _db.SaveChanges();
        }

        public void UpdateIndivid(Statement Statement)
        {
            throw new NotImplementedException();
        }
    }
}

