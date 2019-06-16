using System.Data.Entity;

namespace BoubuWebApp.Models
{
    public class EmployeeContext : DbContext
    {
        // Samplesテーブルを定義する
        public DbSet<Employee> Employees { get; set; }
    }
}