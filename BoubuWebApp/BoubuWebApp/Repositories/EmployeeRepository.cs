using BoubuWebApp.Models;
using BoubuWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BoubuWebApp.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployees(SampleViewModel query, string sortColumn)
        {
            using (var dbContext = new EmployeeContext())
            {
                IOrderedQueryable<Employee> sorted = null;

                var result = dbContext.Employees
                                .Where(x => (string.IsNullOrEmpty(query.Name) ? true : query.Name.Equals(x.Name))
                                && (query.Id == null ? true : query.Id == x.Id));


                switch (sortColumn)
                {
                    case "name":
                        sorted = result.OrderBy(x => x.Name);
                        break;
                    case "-name":
                        sorted = result.OrderByDescending(x => x.Name);
                        break;
                    case "id":
                        sorted = result.OrderBy(x => x.Id);
                        break;
                    case "-id":
                        sorted = result.OrderByDescending(x => x.Id);
                        break;
                    case "birth":
                        sorted = result.OrderBy(x => x.Birth);
                        break;
                    case "-birth":
                        sorted = result.OrderByDescending(x => x.Birth);
                        break;
                    default:
                        sorted = result.OrderBy(x => x.Id);
                        break;
                }

                var response = sorted.ToList();

                return response;
            }
        }
    }
}