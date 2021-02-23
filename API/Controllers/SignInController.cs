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
    public class SignInController : ApiController
    {
        SignInRepository signInRepository = new SignInRepository();
        public IHttpActionResult Post(SignIn signIn)
        {
            if (signIn != null)
            {
                signInRepository.Create(signIn);
                return Ok("Successfully!");
            } else
            {
                return BadRequest("Failed!");
            }
        }
    }
}