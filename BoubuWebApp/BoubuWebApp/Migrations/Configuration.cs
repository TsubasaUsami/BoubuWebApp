namespace BoubuWebApp.Migrations
{
    using BoubuWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BoubuWebApp.Models.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BoubuWebApp.Models.EmployeeContext context)
        {
            // Samplesテーブルに2つのレコードを追加または更新する
            context.Employees.AddOrUpdate(
            p => p.Id,
            new Employee { Name = "陳さん", Birth = DateTime.Parse("1995/04/28") },
            new Employee { Name = "カント", Birth = DateTime.Parse("1995/04/29") },
            new Employee { Name = "地味師", Birth = DateTime.Parse("1995/04/30") }
            );
        }
    }
}
