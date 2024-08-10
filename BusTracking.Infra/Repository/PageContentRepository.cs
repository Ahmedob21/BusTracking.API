using BusTracking.Core.Data;
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
    public class PageContentRepository : IPageContentRepository
    {
        private readonly IDbContext _dbContext;

        private readonly ModelContext _modelContext;
        public PageContentRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
        }


      

        public async Task CreatePagecontent(Pagecontent pagecontent)
        {
            var param = new DynamicParameters();
            param.Add("p_PAGENAME", pagecontent.Pagename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_CONTENTKEY", pagecontent.Contentkey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_CONTENTVALUE", pagecontent.Contentvalue, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("PAGECONTENT_PACKAGE.create_PAGECONTENT", param, commandType: CommandType.StoredProcedure);

        }

        public async Task DeletePagecontent(int Pagecontentid)
        {
            var param = new DynamicParameters();
            param.Add("p_PAGECONTENTID", Pagecontentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("PAGECONTENT_PACKAGE.delete_PAGECONTENT", param, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<Pagecontent>> GetAllPagecontent()
        {
            var result = await _dbContext.Connection.QueryAsync<Pagecontent>("PAGECONTENT_PACKAGE.get_all_PAGECONTENT", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public async Task<Pagecontent> GetPagecontentById(int Pagecontentid)
        {
            var param = new DynamicParameters();
            param.Add("get_PAGECONTENTID", Pagecontentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Pagecontent>("PAGECONTENT_PACKAGE.get_PAGECONTENT_by_id", param, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task<Pagecontent> GetcontentByKey(string key)
        {
           return  _modelContext.Pagecontents.Where(x=>x.Contentkey == key).SingleOrDefault();
        }

        public async Task UpdatePagecontent(Pagecontent pagecontent)
        {
            var param = new DynamicParameters();
            param.Add("p_PAGECONTENTID", pagecontent.Pagecontentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("p_PAGENAME", pagecontent.Pagename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_CONTENTKEY", pagecontent.Contentkey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("p_CONTENTVALUE", pagecontent.Contentvalue, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("PAGECONTENT_PACKAGE.Update_PageContent", param, commandType: CommandType.StoredProcedure);

        }
    }
}
