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
    public class PageContentService : IPageContentService
    {
        private readonly IPageContentRepository _PageContentRepository;

        public PageContentService(IPageContentRepository pageContentRepository)
        {
            _PageContentRepository = pageContentRepository;
        }

        public async Task CreatePagecontent(Pagecontent pagecontent)
        {
            await _PageContentRepository.CreatePagecontent(pagecontent);
        }

        public async Task DeletePagecontent(int Pagecontentid)
        {
            await _PageContentRepository.DeletePagecontent(Pagecontentid);
        }

        public async Task<List<Pagecontent>> GetAllPagecontent()
        {
           return await _PageContentRepository.GetAllPagecontent();
        }

        public async Task<Pagecontent> GetPagecontentById(int Pagecontentid)
        {
           return await _PageContentRepository.GetPagecontentById(Pagecontentid);
        }

        public async Task UpdatePagecontent(Pagecontent pagecontent)
        {
            await _PageContentRepository.UpdatePagecontent(pagecontent);
        }

        public Task<Pagecontent> GetcontentByKey(string key)
        {
            return _PageContentRepository.GetcontentByKey(key);
        }
    }
}
