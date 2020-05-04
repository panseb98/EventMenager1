using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Authorization;
using WebAPI.Models.Events;

namespace WebAPI.Services.Interfaces
{
    public interface INotifyciationService
    {
        Task NotifyNewReceiptItem(List<User> participants, Event mainEvent, int changerId);
        Task GetNotifications(List<User> participants, Event mainEvent, int changerId);
    }
}
