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
    public class FilesRepositories : IFilesRepository
    {
        internal TestTaskContext db;
        internal DbSet<Files> dbSet;

        public FilesRepositories(TestTaskContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Files>();
        }

        public void Add(Files report)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Files> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }

        public Files GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Files reportWithChanges)
        {
            throw new NotImplementedException();
        }
    }
}
