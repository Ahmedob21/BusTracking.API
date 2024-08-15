using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;
        private readonly ModelContext _modelContext;
        public ChildService(IChildRepository childRepository, ModelContext modelContext)
        {
            _modelContext = modelContext;
            _childRepository = childRepository;
        }

        public async Task CreateChild(Child child)
        {
            await _childRepository.CreateChild(child);
        }

        public async Task DeleteChild(int Childid)
        {
            await _childRepository.DeleteChild(Childid);
        }

        public Task<List<ChidrenResult>> GetAllChildren()
        {
            return _childRepository.GetAllChildren();
        }
        public Task<List<ChidrenResult>> GetChildrenByParentId(int parentid)
        {
            return _childRepository.GetChildrenByParentId(parentid);
        }

        public Task<ChidrenResult> GetChildById(int Childid)
        {
            return _childRepository.GetChildById(Childid);
        }

        public async Task UpdateChild(Child child)
        {
            await _childRepository.UpdateChild(child);
        }


        public Task<List<Child>> SearchChildrenByName(string name)
        {
            return _childRepository.SearchChildrenByName(name);
        }

        public  Task<List<ChidrenResult>> GetChildrenByDriverId(int driverid)
        {
            return  _childRepository.GetChildrenByDriverId(driverid);
        }

        public Task<IEnumerable<PresentChildren>> GetTripChildren(decimal teacherId)
        {
            return _childRepository.GetTripChildren(teacherId);
        }

    }
}
