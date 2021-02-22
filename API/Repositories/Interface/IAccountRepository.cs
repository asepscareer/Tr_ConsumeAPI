using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    interface IAccountRepository
    {
        IEnumerable<Account> Get();
        Task<IEnumerable<Account>> GetById(int Id);
        int Create(Account account);
        int Update(Account account, int Id);
        int Delete(int Id);
    }
}
