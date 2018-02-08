using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Contracts.DataContracts;

namespace TestTask.Contracts.Interfaces
{
    public interface IMainLogRepository
    {
        IEnumerable<MainLog> GetAll();

        MainLog GetById(int id);

        void Add(MainLog report);

        void Update(MainLog reportWithChanges);

        void Delete(int id);
    }
}
