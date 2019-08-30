using BoubuWebApp.Models;
using BoubuWebApp.Services;
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
        private  EmployeeService employeeServive;

        public EmployeeController()
        {
            employeeServive = new EmployeeService();
        }

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
        public IHttpActionResult GetEmployees([FromUri]SampleViewModel query, string sortColumn)
        {
            // Okの中に返す値を入れる
            // HTTPステータスコード200を返す
            // return Ok(employees);

            using (var db = new EmployeeContext())
            {
                var result = employeeServive.GetEmployees(query, sortColumn);

                return Ok(result);
            }
        }

        /// <summary>
        /// URLに書かれたIDを持つEmployeeを取得する
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("api/employees/{id}")]
        //public IHttpActionResult GetEmployee(int id)
        //{
        //   // Employee result = null;

        //    using (var db = new EmployeeContext())
        //    {
        //        var result = db.Employees.Where(x => x.Id == id).Select(x => new SampleViewModel()
        //        {
        //            Id = x.Id,
        //            Birth = x.Birth.ToString(),
        //            Name = x.Name,
        //            Test = "取得成功"
        //        });

        //        return Ok(result);
        //    }
        //}

        ///// <summary>
        ///// Bodyに定義したEmployeeを追加する
        ///// </summary>
        ///// <param name="vm">追加するEmployee情報</param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("api/employees/add")]
        //public IHttpActionResult AddEmployee(SampleViewModel vm)
        //{
        //    using (var db = new EmployeeContext())
        //    {
        //        var req = new Models.Employee()
        //        {
        //            Id = vm.Id,
        //            Name = vm.Name,
        //            Birth = DateTime.Parse(vm.Birth)
        //        };

        //        db.Employees.Add(req);

        //        db.SaveChanges();
        //    }

        //    // employeesリストに新しい情報を追加する
        //    // employees.Add(vm);
        //    return Ok();
        //}

        ///// <summary>
        ///// Bodyに定義した情報を更新する
        ///// </summary>
        ///// <param name="vm">更新するEmployee情報</param>
        ///// <returns></returns>
        //[HttpPut]
        //[Route("api/employees/update")]
        //public IHttpActionResult UpdateEmployee(SampleViewModel vm)
        //{
        //    using(var db = new EmployeeContext())
        //    {
        //        var update = db.Employees.Where(x => x.Id == vm.Id).First();

        //        update.Name = vm.Name;
        //        update.Birth = DateTime.Parse(vm.Birth);

        //        db.SaveChanges();
        //    }

        //    // Okの中に返す値を入れる
        //    // HTTPステータスコード200を返す
        //    return Ok();
        //}

        ///// <summary>
        ///// Bodyに定義した情報を削除する
        ///// </summary>
        ///// <param name="vm">削除するEmployee情報</param>
        ///// <returns></returns>
        //[HttpDelete]
        //[Route("api/employees/delete")]
        //public IHttpActionResult DeleteEmployee(Employee vm)
        //{
        //    using (var db = new EmployeeContext())
        //    {
        //        var delete = db.Employees.Where(x => x.Id == vm.Id).First();

        //        db.Employees.Remove(delete);

        //        db.SaveChanges();
        //    }

        //    // 一時保存用の変数を宣言しておく
        //    //Employee deleteItem = null;

        //    //// 引数のIDに一致したIDを持つEmployeeを探す
        //    //foreach (Employee employee in employees)
        //    //{
        //    //    if (employee.Id == vm.Id)
        //    //    {
        //    //        // 一致した場合そのIDを持つEmoloyeeを変数に保存する
        //    //        deleteItem = employee;
        //    //    }
        //    //}

        //    //// 該当のEmployee情報を削除する
        //    //employees.Remove(deleteItem);

        //    // Okの中に返す値を入れる
        //    // HTTPステータスコード200を返す
        //    return Ok();
        //}

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