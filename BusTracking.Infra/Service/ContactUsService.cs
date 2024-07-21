
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
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;
        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public async Task CreateContactus(Contactu contactu)
        {
            await _contactUsRepository.CreateContactus(contactu);
        }

        public async Task DeleteContactus(int contactusid)
        {
            await _contactUsRepository.DeleteContactus(contactusid);
        }

        public async Task<List<Contactu>> GetAllContactus()
        {
          return  await _contactUsRepository.GetAllContactus();
        }

        public async Task<Contactu> GetContactusById(int contactusid)
        {
            return await _contactUsRepository.GetContactusById(contactusid);
        }
    }
}
