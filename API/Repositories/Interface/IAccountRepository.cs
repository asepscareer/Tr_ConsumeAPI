using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IAccountRepository
    {
        int Create(SignIn signIn);
        int Update(SignIn signIn, int Id);
    }
}
