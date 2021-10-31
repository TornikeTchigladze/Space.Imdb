using Quartz;
using Space.Imdb.Bll.Contracts.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Space.Imdb.Bll.Jobs
{
    [DisallowConcurrentExecution]
    public class NotificationJob : IJob
    {
        private readonly INotificationsService _notificationsService;

        public NotificationJob(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _notificationsService.Send();

            return Task.CompletedTask;
        }
    }
}
