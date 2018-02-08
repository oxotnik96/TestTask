using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Contracts.DataContracts;
using TestTask.DAL.DataBase;

namespace WindowsFormsApp2
{
    class DataBase
    {
        private TestTaskContext db;

        public void AddIPAdress(IPAdress ip)
        {
            db = new TestTaskContext();
            db.ip_adress.Add(ip);
            db.SaveChanges();
        }

        public void AddFiles(Files fl)
        {
            db = new TestTaskContext();
            db.files.Add(fl);
            db.SaveChanges();
        }

        public void AddMainLog(MainLog ml)
        {
            db = new TestTaskContext();
            db.mainlog.Add(ml);
            db.SaveChanges();
        }

        public void UpdateFiles(Files fl)
        {
            db = new TestTaskContext();
            var finfo = fl.Mainlog.Where(x => x.IdFiles == fl.ID_of_file);
            db.files.Remove(fl);
            db.SaveChanges();
            fl.Mainlog = finfo.ToList();
            db.files.Add(fl);
            db.SaveChanges();
        }

        public void UpdateIP(IPAdress ip)
        {
            db = new TestTaskContext();
            var ipinfo = ip.Mainlog.Where(x => x.IdAdress == ip.ID_IP);
            db.ip_adress.Remove(ip);
            db.SaveChanges();
            ip.Mainlog = ipinfo.ToList();
            db.ip_adress.Add(ip);
            db.SaveChanges();
        }

        public Files GetFiles(int size, string title, string way)
        {
            db = new TestTaskContext();
            Files files = new Files();
            files = db.files.First(x => ((x.Size == size) && (x.Title == title) && (x.Way == way)));
            return files;
        }

        public IPAdress GetIP(string IP, string name)
        {
            db = new TestTaskContext();
            IPAdress ipadress = new IPAdress();
            ipadress = db.ip_adress.First(x => ((x.IP == IP) && (x.Name_of_company == name)));
            return ipadress;
        }
    }
}
