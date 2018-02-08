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
    class FilesRepositories : IFilesRepository
    {
        internal TestTaskContext db;
        internal DbSet<Files> dbSet;

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
            throw new NotImplementedException();
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
