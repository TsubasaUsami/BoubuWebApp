using BoubuWebApp.Models;
using BoubuWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoubuWebApp.Controllers
{
    /// <summary>
    /// コントローラー
    /// </summary>
    public class EmployeeController : ApiController
    {
        // Employeeテーブルの初期化
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "陳さん"
            },
            new Employee()
            {
                Id = 2,
                Name = "カント"
            },
            new Employee()
            {
                Id = 3,
                Name = "ji～～～～～mi"
            }
        };


        /// <summary>
        /// Employeeリストの一覧を返す
        /// </summary>
        /// <returns>HTTPステータスコード200とEmployeeリスト</returns>
        [HttpGet]
        [Route("api/employees")]
        public IHttpActionResult GetEmployees()
        {
            // Okの中に返す値を入れる
            // HTTPステータスコード200を返す
            // return Ok(employees);

            using (var db = new EmployeeContext())
            {
                var result = db.Employees.Select(x => new SampleViewModel
                {
                    Id = x.Id,
                    Birth = x.Birth,
                    Name = x.Name,
                    Test = "取得成功"
                }).ToList();

                return Ok(result);
            }
        }

        /// <summary>
        /// URLに書かれたIDを持つEmployeeを取得する
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/employees/{id}")]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee result = null;

            // 引数のIDに一致したIDを持つEmployeeを探す
            foreach (Employee employee in employees)
            {
                if (employee.Id == id)
                {
                    // 一致した場合resultを更新する
                    result = employee;
                }
            }

            // Okの中に返す値を入れる
            // HTTPステータスコード200を返す
            return Ok(result);
        }

        /// <summary>
        /// Bodyに定義したEmployeeを追加する
        /// </summary>
        /// <param name="vm">追加するEmployee情報</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/employees/add")]
        public IHttpActionResult AddEmployee(Employee vm)
        {
            // employeesリストに新しい情報を追加する
            employees.Add(vm);
            return Ok();
        }

        /// <summary>
        /// Bodyに定義した情報を更新する
        /// </summary>
        /// <param name="vm">更新するEmployee情報</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/employees/update")]
        public IHttpActionResult UpdateEmployee(Employee vm)
        {
            // 引数のIDに一致したIDを持つEmployeeを探す
            foreach (Employee employee in employees)
            {
                if (employee.Id == vm.Id)
                {
                    // 一致した場合Employee情報のNameを更新する
                    employee.Name = vm.Name;
                }

                if (employee.Name == vm.Name)
                {
                    employee.Id = vm.Id;
                }
            }

            // Okの中に返す値を入れる
            // HTTPステータスコード200を返す
            return Ok();
        }

        /// <summary>
        /// Bodyに定義した情報を削除する
        /// </summary>
        /// <param name="vm">削除するEmployee情報</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/employees/delete")]
        public IHttpActionResult DeleteEmployee(Employee vm)
        {
            // 一時保存用の変数を宣言しておく
            Employee deleteItem = null;

            // 引数のIDに一致したIDを持つEmployeeを探す
            foreach (Employee employee in employees)
            {
                if (employee.Id == vm.Id)
                {
                    // 一致した場合そのIDを持つEmoloyeeを変数に保存する
                    deleteItem = employee;
                }
            }

            // 該当のEmployee情報を削除する
            employees.Remove(deleteItem);

            // Okの中に返す値を入れる
            // HTTPステータスコード200を返す
            return Ok();
        }

    }

    /// <summary>
    /// Employeeクラス
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// 社員情報のID
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
    }
}