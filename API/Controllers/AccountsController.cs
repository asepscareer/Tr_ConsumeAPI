using API.Models;
using API.Repositories;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AccountsController : ApiController
    {
        AccountRepository accountRepository = new AccountRepository();
        public IHttpActionResult Post(SignUp signUp)
        {
            if (signUp.Name == null || signUp.Email == null || signUp.Password == null || signUp.PhoneNumber == null)
            {
                return BadRequest("Tidak boleh kosong");
            }
            accountRepository.Create(signUp);
            return Ok("Data sudah masuk!");
        }
    }
}