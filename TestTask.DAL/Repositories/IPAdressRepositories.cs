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
    public class IPAdressRepositories : IIPAdressRepository
    {
        internal TestTaskContext db;
        internal DbSet<IPAdress> dbSet;

        public IPAdressRepositories(TestTaskContext db)
        {
            this.db = db;
            this.dbSet = db.Set<IPAdress>();
        }

        public virtual IEnumerable<IPAdress> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }
        public virtual IPAdress GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(IPAdress entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            IPAdress entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(IPAdress entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(IPAdress entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
