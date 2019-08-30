using BoubuWebApp.Models;
using BoubuWebApp.Repositories;
using BoubuWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoubuWebApp.Common;

namespace BoubuWebApp.Services
{
    public class EmployeeService
    {
        private EmployeeRepository employeeRepository;

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        public ResponseViewModel<SampleViewModel> GetEmployees(SampleViewModel query, string sortColumn)
        {
            try
            {
                var list = employeeRepository.GetEmployees(query, sortColumn);

                var response = list.Select(x => new SampleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Birth = x.Birth
                }).ToList();

                var result = new ResponseViewModel<SampleViewModel>()
                {
                    ResponseObj = response,
                    Count = list.Count(),
                    ResultFlg = true,
                    Message = Consts.SuccessMessage
                };

                return result;
            }
            catch (Exception e)
            {
                var result = new ResponseViewModel<SampleViewModel>()
                {
                    ResultFlg = false,
                    Message = Consts.FailureMessage + e.StackTrace
                };

                return result;

            }
        }
    }
}