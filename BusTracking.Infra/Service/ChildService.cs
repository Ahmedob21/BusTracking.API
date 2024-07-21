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

        public Task<List<ChidrenResult>> GetAllChildren()
        {
            return _childRepository.GetAllChildren();
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
    }
}
