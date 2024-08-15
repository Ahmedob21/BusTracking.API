using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
using BusTracking.Core.ICommon;
using BusTracking.Core.IRepository;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BusTracking.Infra.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public NotificationRepository(IDbContext dBContext, ModelContext modelContext)
        {
            _dbContext = dBContext;
            _modelContext = modelContext;
        }

        public async Task CreateNotification(Notification notification)
        {
            var param = new DynamicParameters();
            param.Add("c_MESSAGE", notification.Message, DbType.String, direction: ParameterDirection.Input);
            param.Add("c_PARENT_ID", notification.ParentId, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_TEACHER_ID", notification.TeacherId, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("NOTIFICATIONS_PACKAGE.create_NOTIFICATION", param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateNotification(Notification notification)
        {
            var param = new DynamicParameters();
            param.Add("u_NOTIFICATIONID", notification.Notificationid, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_MESSAGE", notification.Message, DbType.String, direction: ParameterDirection.Input);
            param.Add("u_PARENT_ID", notification.ParentId, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_TEACHER_ID", notification.TeacherId, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("NOTIFICATIONS_PACKAGE.update_NOTIFICATION", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteNotification(int notificationId)
        {
            var param = new DynamicParameters();
            param.Add("d_NOTIFICATIONID", notificationId, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.ExecuteAsync("NOTIFICATIONS_PACKAGE.delete_NOTIFICATION", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<Notification> GetNotificationById(int notificationId)
        {
            var param = new DynamicParameters();
            param.Add("get_NOTIFICATIONID", notificationId, DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<Notification>("NOTIFICATIONS_PACKAGE.get_NOTIFICATION_by_id", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<Notification>> GetAllNotifications()
        {
            var result = await _dbContext.Connection.QueryAsync<Notification>("NOTIFICATIONS_PACKAGE.get_all_NOTIFICATIONS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<Notification>> GetAllNotificationsByParentId(int parentid) 
        {
           var result= await _modelContext.Notifications.Where(x=>x.ParentId == parentid).ToListAsync();
            return result;
        }
    }

}
