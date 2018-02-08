using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Contracts.DataContracts;
using TestTask.Contracts.Interfaces;
using TestTask.DAL.DataBase;

namespace TestTask.DAL.Repositories
{
    public class MainLogRepositories : IMainLogRepository
    {
        internal TestTaskContext db;
        internal DbSet<MainLog> dbSet;

        public MainLogRepositories(TestTaskContext db)
        {
            this.db = db;
            this.dbSet = db.Set<MainLog>();
        }

        public virtual IEnumerable<MainLog> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual MainLog GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(MainLog entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            MainLog entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(MainLog entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(MainLog entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
