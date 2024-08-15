using BusTracking.Core.Data;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<List<Notification>> GetAllNotifications()
        {
            return await _notificationService.GetAllNotifications();
        }

        [HttpGet]
        [Route("ByParentId/{parentid}")]
        public async Task<List<Notification>> GetAllNotificationsByParentId(int parentid)
        {
            return await _notificationService.GetAllNotificationsByParentId(parentid);
        }

        [HttpGet("{notificationId}")]
        public async Task<Notification> GetNotificationById(int notificationId)
        {
            return await _notificationService.GetNotificationById(notificationId);
        }

        [HttpPost]
        public async Task CreateNotification(Notification notification)
        {
            await _notificationService.CreateNotification(notification);
        }

        [HttpPut]
        public async Task UpdateNotification(Notification notification)
        {
            await _notificationService.UpdateNotification(notification);
        }

        [HttpDelete("{notificationId}")]
        public async Task DeleteNotification(int notificationId)
        {
            await _notificationService.DeleteNotification(notificationId);
        }
    }

}
