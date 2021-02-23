using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.Repositories.Interfaces;
using API.ViewModels;
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
        // SignUp
        public int Create(SignUp signUp)
        {
            var SP_Con = "SP_InsertEmployee";
            parameters.Add("@Name", signUp.Name);
            parameters.Add("@Email", signUp.Email);
            parameters.Add("@PhoneNumber", signUp.PhoneNumber);
            parameters.Add("@JoinDate", signUp.JoinDate);
            parameters.Add("@Salary", signUp.Salary);
            parameters.Add("@Password", signUp.Password);

            var Create = connection.Execute(SP_Con, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return Create;
        }
    }
}