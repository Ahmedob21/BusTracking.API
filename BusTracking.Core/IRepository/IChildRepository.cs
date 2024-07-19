using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IChildRepository
    {
        Task<List<Child>> GetAllChildren();
        Task<Child> GetChildById(int Childid);
        Task CreateChild(Child child);
        Task UpdateChild(Child child);
        Task DeleteChild(int Childid);
    }
}
