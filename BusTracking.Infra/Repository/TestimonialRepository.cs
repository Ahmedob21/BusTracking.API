using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.ICommon;
using BusTracking.Core.IRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {

        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTestimonial(Testimonial testimonial)
        {
            var param = new DynamicParameters(); ;
            param.Add("c_MESSAGE", testimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_PUBLISHER_ID", testimonial.Publisher_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_STATUS", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("TESTIMONIAL_package.create_TESTIMONIAL", param, commandType: CommandType.StoredProcedure);

        }

        public async Task DeleteTestimonial(int testimonialid)
        {
            var param = new DynamicParameters();
            param.Add("d_TESTIMONIALID", testimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("TESTIMONIAL_package.delete_TESTIMONIAL", param, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<TestimonialModel>> GetAllTestimonial()
        {
            var result = await _dbContext.Connection.QueryAsync<TestimonialModel>("TESTIMONIAL_package.get_all_TESTIMONIAL", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public async Task<TestimonialModel> GetTestimonialById(int testimonialid)
        {
            var param = new DynamicParameters();
            param.Add("get_TESTIMONIALID", testimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<TestimonialModel>("TESTIMONIAL_package.get_TESTIMONIAL_by_id", param, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }

        public async Task UpdateTestimonial(Testimonial testimonial)
        {
            var param = new DynamicParameters();
            param.Add("u_TESTIMONIALID", testimonial.Testimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_MESSAGE", testimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_PUBLISHER_ID", testimonial.Publisher_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_STATUS", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("TESTIMONIAL_package.update_TESTIMONIAL", param, commandType: CommandType.StoredProcedure);

        }
    }
}
