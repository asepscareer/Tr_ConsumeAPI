using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class SignInsController : ApiController
    {
        SignInRepository signInRepository = new SignInRepository();
        // SignIn
        public async Task<IHttpActionResult> Post(SignIn signIn)
        {
            var SignIn = await signInRepository.Post(signIn);
            if (SignIn != null)
            {
                if (SignIn.Count() == 0)
                {
                    return Content(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
                }
                return Ok(SignIn);
            }
            return Content(HttpStatusCode.BadRequest, "Terjadi Kesalahan");
        }
    }
}
