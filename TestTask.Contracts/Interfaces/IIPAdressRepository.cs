using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Contracts.DataContracts;

namespace TestTask.Contracts.Interfaces
{
    public interface IIPAdressRepository
    {
        IEnumerable<IPAdress> GetAll();

        IPAdress GetById(int id);

        void Add(IPAdress report);

        void Update(IPAdress reportWithChanges);

        void Delete(int id);
    }
}
