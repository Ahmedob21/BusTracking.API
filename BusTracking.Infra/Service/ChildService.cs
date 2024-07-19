using BusTracking.Core.Data;
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

        public ChildService(IChildRepository childRepository)
        {
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

        public Task<List<Child>> GetAllChildren()
        {
            return _childRepository.GetAllChildren();
        }

        public Task<Child> GetChildById(int Childid)
        {
            return _childRepository.GetChildById(Childid);
        }

        public async Task UpdateChild(Child child)
        {
            await _childRepository.UpdateChild(child);
        }
    }
}
