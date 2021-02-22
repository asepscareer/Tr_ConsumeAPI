using API.Models;
using API.Repositories;
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
        public IHttpActionResult Post(SignIn signIn)
        {
            if (signIn.Email == null || signIn.Password == null)
            {
                return BadRequest("Tidak boleh kosong");
            }
            accountRepository.Create(signIn);
            return Ok("Berhasil Masuk");
        }
        public IHttpActionResult Put(SignIn signIn, int Id)
        {
            var put = accountRepository.Update(signIn, Id);
            if (put == 0)
            {
                return Content(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
            }
            return Ok();
        }

    }
}
