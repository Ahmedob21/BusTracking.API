using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using BusTracking.Infra.Repository;

namespace BusTracking.Infra.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task CreateNotification(Notification notification)
        {
           await _notificationRepository.CreateNotification(notification);
        }

        public async Task DeleteNotification(int notificationId)
        {
           await _notificationRepository.DeleteNotification(notificationId);
        }

        public async Task<List<Notification>> GetAllNotifications()
        {
            return await _notificationRepository.GetAllNotifications();
        }

        public Task<Notification> GetNotificationById(int notificationId)
        {
            return _notificationRepository.GetNotificationById(notificationId);
        }

        public async Task UpdateNotification(Notification notification)
        {
            await _notificationRepository.UpdateNotification(notification);
        }
        public async Task<List<Notification>> GetAllNotificationsByParentId(int parentid)
        {
            return await _notificationRepository.GetAllNotificationsByParentId(parentid);
        }
    }

}
