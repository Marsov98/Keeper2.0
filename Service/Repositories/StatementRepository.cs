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
        public StatementRepository(KeeperContext db)
        {
            _db = db;
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
    }
}

