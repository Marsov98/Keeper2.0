using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Data;

public class KeeperContext : DbContext
{
    public DbSet<Division> Division { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Statement> Statement { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<BusyTime> BusyTime { get; set; }
    public DbSet<VisitTime> VisitTime { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Keeper;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}
