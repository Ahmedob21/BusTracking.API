using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface IChildService
    {
        Task<List<Child>> GetAllChildren();
        Task<Child> GetChildById(int Childid);
        Task CreateChild(Child child);
        Task UpdateChild(Child child);
        Task DeleteChild(int Childid);
        Task<List<Child>> SearchChildrenByName(string name);
    }
}
