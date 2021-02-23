using API.Models;
using API.Repositories;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        // Create
        public IHttpActionResult Post(SignUp signUp)
        {
            if (signUp.Name == null || signUp.Email == null || signUp.Password == null || signUp.PhoneNumber == null)
            {
                return BadRequest("Tidak boleh kosong");
            }
            employeeRepository.Create(signUp);
            return Ok("Data sudah masuk!");
        }
        // Delete
        public IHttpActionResult Delete(int Id)
        {
            var result = employeeRepository.Delete(Id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok("Berhasil Delete");
        }
        public IHttpActionResult Put(SignUp signUp, int Id)
        {
            var result = employeeRepository.Update(signUp, Id);
            if (result == 0)
            {
                return Content(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
            }
            return Ok();
        }
        public IHttpActionResult Get()
        {
            var result = employeeRepository.Get();
            if (result == null)
            {
                return Content(HttpStatusCode.BadRequest, "Terjadi Kesalahan");
            }
            return Ok(result);
        }
        public async Task<IHttpActionResult> GetById(int id)
        {
            var result = await employeeRepository.GetById(id);
            if (result != null)
            {
                if (result.Count() == 0)
                {
                    return Content(HttpStatusCode.NotFound, "Data Tidak Ditemukan");
                }
                return Ok(result);
            }
            return Content(HttpStatusCode.BadRequest, "Terjadi Kesalahan");
        }
    }
}
