﻿using API.Models;
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
        public ActionResult Create()
        {
            IEnumerable<SignIn> signIns = null;
            var responseTask = client.GetAsync("Accounts");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SignIn>>();
                readTask.Wait();
                signIns = readTask.Result;
            }
            return View(signIns);
        }

        [HttpPost]
        public ActionResult Create(SignIn signIn)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Accounts", signIn).Result;
            return RedirectToAction("Index");
        }

        /*public ActionResult Edit(int Id)
        {
            IEnumerable<SignIn> signIns = null;
            var responseTask = client.GetAsync("Employees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SignIn>>();
                readTask.Wait();
                signIns = readTask.Result;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SignIn signIn)
        {
            var put = client.PutAsJsonAsync<SignIn>("Accounts/" + signIn.Email, signIn);
            put.Wait();
            return RedirectToAction("Index");
        }*/
    }
}