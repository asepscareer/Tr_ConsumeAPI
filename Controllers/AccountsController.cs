using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Tr_ConsumeAPI.Controllers
{
    public class AccountsController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44340/API/")
        };
        // SignUp
        public ActionResult Create()
        {
            IEnumerable<SignUp> signUps = null;
            var responseTask = client.GetAsync("Accounts");
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
            HttpResponseMessage response = client.PostAsJsonAsync("SignUp", signUp).Result;
            return RedirectToAction("Index", "Employees");
        }

        // SignIn
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignIn signIn)
        {
            IEnumerable<Employee> employees = null;
            var responseTask = client.GetAsync("Employees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                readTask.Wait();
                employees = readTask.Result;
                try {
                    var id = employees.FirstOrDefault(
                        e => e.Email == signIn.Email
                        ).Id;
                    return RedirectToAction("Details/" + id.ToString(), "Employees");
                }
                catch {
                    return RedirectToAction("SignIn", "Accounts");
                }
                
            }
            return View();
        }
    }
}