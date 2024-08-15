using System.ComponentModel.DataAnnotations;
using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
       // [CheckClaims("RoleId","1")]
        public async Task<List<ChidrenResult>> GetAllChildren()
        {
            return await _childService.GetAllChildren();
        }
        [HttpGet]        //succesfully working
        [Route("GetChildrenByParentId/{Parentid}")]
        public async Task<List<ChidrenResult>> GetChildrenByParentId(int parentid)
        {
            return await _childService.GetChildrenByParentId(parentid);
        }

        [HttpPost]             //succesfully working
        [Authorize]
        [CheckClaims("RoleId", "1")]
        public async Task CreateChild(Child child)
        {
            await _childService.CreateChild(child);
        }


        [HttpGet("{Childid}")]        //succesfully working
        public async Task<ChidrenResult> GetChildById(int Childid)
        {
            return await _childService.GetChildById(Childid);
        }

        [HttpDelete]  //succesfully working
        [Route("delete/{Childid}")]
        [Authorize]
        [CheckClaims("RoleId", "1")]
        public async Task DeleteChild(int Childid)
        {
            await _childService.DeleteChild(Childid);
        }


        [HttpPut]             //succesfully working
        [Authorize]
        [CheckClaims("RoleId", "1")]
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

        [HttpGet]                //successfully working
        [Route("GetChildrenByDriverId/{driverid}")]
        public Task<List<ChidrenResult>> GetChildrenByDriverId(int driverid)
        {
            return  _childService.GetChildrenByDriverId(driverid);
        }


        [HttpGet]
        [Route("GetTripChildren/{teacherid}")]
        public async Task<IEnumerable<PresentChildren>> GetTripChildren(decimal teacherId)
        {
           return await _childService.GetTripChildren(teacherId);
        }
    }
}
