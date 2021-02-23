using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Repositories
{
    public class SignInRepository : IsignInRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

        public int Create(SignIn signIn)
        {
            var spName = "SP_SignIn";
            parameters.Add("@Email", signIn.Email);
            parameters.Add("@Password", signIn.Password);

            var Create = connection.Execute(spName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return Create;
        }
    }
}