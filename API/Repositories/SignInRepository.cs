using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace API.Repositories
{
    public class SignInRepository
    {
        // SignIn
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        public IHttpActionResult Post(SignIn signIn)
        {
            if (signIn.Email == null || signIn.Password == null)
            {
                return BadRequest("- Tidak boleh kosong");
            }
            employeeRepository.Create(signIn);
            return Ok("Data sudah masuk!");
        }
    }
}