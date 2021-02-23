using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Task<IEnumerable<Employee>> GetById(int Id);
        int Create(SignUp signUp);
        int Update(SignUp signUp, int Id);
        int Delete(int Id);
    }
}