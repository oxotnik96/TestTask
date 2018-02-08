using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestTask.DAL.DataBase
{
    class TestTaskInitializer : DropCreateDatabaseIfModelChanges<TestTaskContext>
    {
        protected override void Seed(TestTaskContext context)
        {
            base.Seed(context);
        }
    }
}
