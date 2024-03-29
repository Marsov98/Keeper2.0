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

        public Statement CreateGroup(List<Statement> Statement)
        {
            throw new NotImplementedException();
        }

        public Statement CreateIndivid(Statement Statement)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}

