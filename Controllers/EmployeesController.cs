using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Tr_ConsumeAPI.Controllers
{
    public class EmployeesController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44340/API/")
        };
        // GET: Employee
        public ActionResult Index()
        {

            IEnumerable<Employee> itemList = null;
            var responseTask = client.GetAsync("Employees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                itemList = readTask.Result;
            }
            return View(itemList);
        }

        // CREATE : Employee
        public ActionResult Create()
        {
            IEnumerable<SignUp> signUps = null;
            var responseTask = client.GetAsync("Items");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SignUp>>();
                readTask.Wait();
                signUps = readTask.Result;
            }
            return View(signUps);
        }

        [HttpPost]
        public ActionResult Create(SignUp signUp)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Employees", signUp).Result;
            return RedirectToAction("Index");
        }
        // EDIT : Employee
        public ActionResult Edit(int Id)
        {
            IEnumerable<SignUp> signUps = null;
            var responseTask = client.GetAsync("Employees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SignUp>>();
                readTask.Wait();
                signUps = readTask.Result;
            }
            return View(signUps.FirstOrDefault(s=> s.Id == Id));
        }

        [HttpPost]
        public ActionResult Edit(SignUp signUp)
        {
            var put = client.PutAsJsonAsync<SignUp>("Employees/" + signUp.Id, signUp);
            put.Wait();
            return RedirectToAction("Index");
        }
        // DELETE : Employee
        public ActionResult Delete(int Id)
        {
            IEnumerable<Employee> employees = null;
            var responseTask = client.GetAsync("Employees/" + Id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                employees = readTask.Result;
            }
            return View(employees.FirstOrDefault(s => s.Id == Id));
        }

        [HttpPost]
        public ActionResult Delete(Employee employee, int Id)
        {

            var delete = client.DeleteAsync("Employees/" + Id.ToString());
            delete.Wait();
            var result = delete.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        // DETAILS : Employee
        public ActionResult Details(int Id)
        {
            IEnumerable<Employee> employees = null;
            var responseTask = client.GetAsync("Employees/" + Id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                employees = readTask.Result;
            }
            return View(employees.FirstOrDefault(s => s.Id == Id));
        }
    }
}