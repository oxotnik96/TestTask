using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Contracts.DataContracts;
using TestTask.DAL.DataBase;

namespace TestTask.WinForm
{
    class DataBase
    {
        private TestTaskContext db;
        
        public void AddDB(string IP, string name)
        {
            db = new TestTaskContext();
            
            IPAdress ipadress = new IPAdress();
            
            ipadress.IP = IP;
            ipadress.Name_of_company = name;
            ipadress.Mainlog = null;
            db.ip_adress.Add(ipadress);
            db.SaveChanges();
        }
    }
}
