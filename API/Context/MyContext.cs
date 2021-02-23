using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("Tr_ConsumeAPI") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<API.ViewModels.SignUp> SignUps { get; set; }
    }
}