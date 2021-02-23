using API.Models;
using API.Repositories.Interface;
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
    public class EmployeeRepository : IEmployeeRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        // Create
        public int Create(SignUp signUp)
        {
            var spName = "SP_InsertEmployee";
            parameters.Add("@Name", signUp.Name);
            parameters.Add("@Email", signUp.Email);
            parameters.Add("@PhoneNumber", signUp.PhoneNumber);
            parameters.Add("@JoinDate", signUp.JoinDate);
            parameters.Add("@Salary", signUp.Salary);
            parameters.Add("@Password", signUp.Password);

            var Create = connection.Execute(spName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return Create;
        }
        // Delete
        public int Delete(int Id)
        {
            var spName = "SP_DeleteEmployee";
            parameters.Add("@Id", Id);
            var Delete = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return Delete;

        }
        // Get All
        public IEnumerable<Employee> Get()
        {
            var spName = "SP_GetEmployee";
            var Get = connection.Query<Employee>(spName, commandType: CommandType.StoredProcedure);
            return Get;
        }
        // Update

        public int Update(SignUp signUp, int Id)
        {
            var spName = "SP_UpdateEmployee";
            parameters.Add("@Id", Id);
            parameters.Add("@Name", signUp.Name);
            parameters.Add("@Email", signUp.Email);
            parameters.Add("@Password", signUp.Password);
            parameters.Add("@PhoneNumber", signUp.PhoneNumber);
            parameters.Add("@JoinDate", signUp.JoinDate);
            parameters.Add("@Salary", signUp.Salary);
            parameters.Add("@Password", signUp.Password);
            var Update = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
        // Get by Id
        public async Task<IEnumerable<Employee>> GetById(int Id)
        {
            var spName = "SP_GetEmployeeById";
            parameters.Add("@Id", Id);
            var Get = await connection.QueryAsync<Employee>(spName, parameters, commandType: CommandType.StoredProcedure);
            return Get;
        }
        // End
    }
}