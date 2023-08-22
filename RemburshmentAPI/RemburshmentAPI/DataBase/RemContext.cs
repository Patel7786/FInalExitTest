using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemburshmentAPI.Model;

namespace RemburshmentAPI.DataBase
{
    public class RemContext : DbContext
    {


        public RemContext(DbContextOptions<RemContext> options) : base(options)
        {

        }

        public DbSet<SignUp> SignUp { get; set; }


        public DbSet<SignUpType> SignUpType { get; set; }


        public DbSet<DashBoard> Dashboard { get; set; }
        public DbSet<DashboardModel> DashboardModel { get; set; }
        public DbSet<Currencytype> CurrencyType { get; set; }
        public DbSet<Remburshmenttype> RemburshmentType { get; set; }
        public DbSet<RemburshmentAPI.Model.CurrencyTypeModel> CurrencyTypeModel { get; set; }
        public DbSet<RemburshmentAPI.Model.RemburshmentTypeMode> RemburshmentTypeMode { get; set; }

    }
}
