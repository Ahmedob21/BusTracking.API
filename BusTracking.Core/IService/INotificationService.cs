using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;

namespace BusTracking.Core.IService
{
    public interface INotificationService
    {
        Task CreateNotification(Notification notification);
        Task UpdateNotification(Notification notification);
        Task DeleteNotification(int notificationId);
        Task<Notification> GetNotificationById(int notificationId);
        Task<List<Notification>> GetAllNotifications();
        Task<List<Notification>> GetAllNotificationsByParentId(int parentid);
        
    }
}
