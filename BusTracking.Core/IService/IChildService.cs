using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface IChildService
    {
        Task<List<ChidrenResult>> GetAllChildren();
        Task<List<ChidrenResult>> GetChildrenByParentId(int parentid);
        Task<ChidrenResult> GetChildById(int Childid);
        Task CreateChild(Child child);
        Task UpdateChild(Child child);
        Task DeleteChild(int Childid);
        Task<List<Child>> SearchChildrenByName(string name);
        Task<List<ChidrenResult>> GetChildrenByDriverId(int driverId);
        Task<IEnumerable<PresentChildren>> GetTripChildren(decimal teacherId);
    }
}
