using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildService _childService;

        public ChildrenController(IChildService childService)
        {
            _childService = childService;
        }
        [HttpGet]               //succesfully working
        public async Task<List<ChidrenResult>> GetAllChildren()
        {
            return await _childService.GetAllChildren();
        }

        [HttpPost]             //succesfully working
        public async Task CreateChild(Child child)
        {
            await _childService.CreateChild(child);
        }


        [HttpGet("{Childid}")]        //succesfully working
        public async Task<ChidrenResult> GetChildById(int Childid)
        {
            return await _childService.GetChildById(Childid);
        }

        [HttpDelete("{Childid}")]  //succesfully working
        public async Task DeleteChild(int Childid)
        {
            await _childService.DeleteChild(Childid);
        }


        [HttpPut]             //succesfully working
        public async Task UpdateChild([FromBody] Child child)
        {
            await _childService.UpdateChild(child);
        }



        [HttpGet]                //successfully working
        [Route("SearchByName/{name}")]
        public Task<List<Child>> SearchChildrenByName(string name)
        {
            return _childService.SearchChildrenByName(name);
        }
    }
}
