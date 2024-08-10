using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface IPageContentService
    {
        Task<List<Pagecontent>> GetAllPagecontent();
        Task<Pagecontent> GetPagecontentById(int Pagecontentid);
        Task CreatePagecontent(Pagecontent pagecontent);
        Task UpdatePagecontent(Pagecontent pagecontent);
        Task DeletePagecontent(int Pagecontentid);
        Task<Pagecontent> GetcontentByKey(string key);
    }
}
