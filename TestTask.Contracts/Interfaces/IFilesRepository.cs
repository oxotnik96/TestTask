using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Contracts.DataContracts;

namespace TestTask.Contracts.Interfaces
{
    public interface IFilesRepository
    {
        IEnumerable<Files> GetAll();

        Files GetById(int id);

        void Add(Files report);

        void Update(Files reportWithChanges);

        void Delete(int id);
    }
}
