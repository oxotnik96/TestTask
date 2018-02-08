using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Contracts.DataContracts;

namespace TestTask.DAL.DataBase
{
    public class TestTaskContext : DbContext
    {
        public TestTaskContext()
        : base("TestTaskContext")
        {
            System.Data.Entity.Database.SetInitializer<TestTaskContext>(new TestTaskInitializer());
            Database.Initialize(true);
        }

        public DbSet<Files> files { get; set; }
        public DbSet<IPAdress> ip_adress { get; set; }
        public DbSet<MainLog> mainlog { get; set; }
    }
}
