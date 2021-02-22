using API.Models;
using API.Repositories.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        // Create
        public int Create(Account account)
        {
            var SP_Con = "SP_InsertAccount";
            parameters.Add("@Name", account.Password);
            var Create = connection.Execute(SP_Con, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return Create;
        }
        // Delete
        public int Delete(int Id)
        {
            var SP_Net = "SP_DeleteAccount";
            parameters.Add("@Id", Id);
            var Delete = connection.Execute(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Delete;

        }
        // Get All
        public IEnumerable<Account> Get()
        {
            var SP_Net = "SP_GetSupplier";
            var Get = connection.Query<Account>(SP_Net, commandType: CommandType.StoredProcedure);
            return Get;
        }
        // Update

        public int Update(Account account, int Id)
        {
            var SP_Net = "SP_UpdateSupplier";
            parameters.Add("@Id", Id);
            parameters.Add("@Password", account.Password);
            var Update = connection.Execute(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
        // Get by Id
        public async Task<IEnumerable<Account>> GetById(int Id)
        {
            var SP_Net = "SP_GetSupplierById";
            parameters.Add("@Id", Id);
            var Get = await connection.QueryAsync<Account>(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Get;
        }
        // End
    }
}