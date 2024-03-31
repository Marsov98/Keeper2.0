using Data;
using Data.Models;
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
            throw new NotImplementedException();
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
            for(int i = 0; i <Count;i++)
            {
                Employees[i].Division = Divis[Employees[i].DivisionId-1];
            }
            return Employees;
        }

        public int GetNextApplicationNumber()
        {
            throw new NotImplementedException();
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

