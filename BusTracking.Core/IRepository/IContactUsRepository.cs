using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IContactUsRepository
    {

        Task CreateContactus(Contactu contactu);
        Task DeleteContactus(int contactusid);
        Task<List<Contactu>> GetAllContactus();
        Task<Contactu> GetContactusById(int contactusid);
       


    }
}
