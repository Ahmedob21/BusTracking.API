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
    public class UpdateProfileService : IUpdateProfileService
    {
        private readonly IUpdateProfileRepository _updateProfileRepository;

        public UpdateProfileService(IUpdateProfileRepository updateProfileRepository)
        {
            _updateProfileRepository = updateProfileRepository;
        }
        async Task IUpdateProfileService.UpdateProfile(UpdateProfile profile)
        {
            await _updateProfileRepository.UpdateProfile(profile);
        }
    }
}
