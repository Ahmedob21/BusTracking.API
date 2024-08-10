using BusTracking.Core.Data;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageContentController : ControllerBase
    {
        private readonly IPageContentService _pageContentService;

        public PageContentController(IPageContentService pageContentService)
        {
            _pageContentService = pageContentService;
        }



        [HttpGet]
        public async Task<List<Pagecontent>> GetAllPagecontent()
        {
            return await _pageContentService.GetAllPagecontent();
        }

        [HttpGet("{Pagecontentid}")]
        public async Task<Pagecontent> GetPagecontentById(int Pagecontentid)
        {
            return await _pageContentService.GetPagecontentById(Pagecontentid);
        }

        [HttpGet]
        [Route("key/{key}")]
        public async Task<Pagecontent> GetcontentByKey(string key)
        {
            return await _pageContentService.GetcontentByKey(key);
        }

        [HttpPost]
        public async Task CreatePagecontent(Pagecontent pagecontent)
        {
            await _pageContentService.CreatePagecontent(pagecontent);
        }

        [HttpPut]
        public async Task UpdatePagecontent(Pagecontent pagecontent)
        {
            await _pageContentService.UpdatePagecontent(pagecontent);
        }

        [HttpDelete]
        public async Task DeletePagecontent(int Pagecontentid)
        {
            await _pageContentService.DeletePagecontent(Pagecontentid);
        }


    }
}
