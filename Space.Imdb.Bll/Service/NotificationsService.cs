using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Space.Imdb.Bll.Contracts.Interfaces.Service;
using Space.Imdb.Bll.Contracts.Models.Email;
using Space.Imdb.DB.Contracts.Entities;
using Space.Imdb.Infrastructure.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Imdb.Bll.Service
{
    public class NotificationsService : INotificationsService
    {
        private readonly ILogger<NotificationsService> _logger;
        private readonly IImdbUnitOfWork _uow;
        private readonly IEmailSenderService _emailSenderService;
        private readonly EbMailConfig _ebMailConfig;

        public NotificationsService
        (
            ILogger<NotificationsService> logger,
            IImdbUnitOfWork uow,
            IOptions<EbMailConfig> ebMailConfigOptions,
            IEmailSenderService emailSenderService)
        {
            _logger = logger;
            _uow = uow;
            _ebMailConfig = ebMailConfigOptions.Value;
            _emailSenderService = emailSenderService;
        }


        public Task Send()
        {
            var currentDate = DateTime.UtcNow.AddHours(4);
            var UsersWatchedList = _uow.WatchListRepository.Filter(u => u.IsWatched == false, includ => includ.Movie, includ => includ.Users, includ => includ.Movie.Posters, includ => includ.Movie.Wikipedia,include=>include.Notifications).ToList()
                                                           .Where(n => n.Notifications.Count == 0 || (n.Notifications.OrderByDescending(d => d.CreateDate).FirstOrDefault() != null && currentDate.Subtract(n.Notifications.OrderByDescending(d => d.CreateDate).FirstOrDefault().CreateDate).Days / (365.25 / 12) > 1))
                                                           .GroupBy(u => u.UserId)
                                                           .Select(grp => grp.OrderByDescending(m => m.Movie.ImDbRating).Take(1).FirstOrDefault());

            foreach (var movies in UsersWatchedList)
            {
                try
                {
                    StringBuilder bodyText = new StringBuilder();
                    bodyText.Append($"Movie Name : {movies.Movie.Title}");
                    bodyText.AppendLine($"IMDB Raiting : {movies.Movie.ImDbRating}");
                    bodyText.AppendLine($"Posters:");
                    foreach (var poster in movies.Movie.Posters)
                    {
                        bodyText.AppendLine(poster.Link);
                    }
                    bodyText.AppendLine($"Short Wiki : {movies.Movie.Wikipedia.PlainText}");
                    
                    /*კონგიგრუაცია შეგიძლია შეცვალოთ config იდან*/
                    try
                    {
                        _emailSenderService.SendEmail(new Email()
                        {
                            To = _ebMailConfig.Sender,
                            From = _ebMailConfig.Receiver,
                            Body = bodyText.ToString(),
                            Subject = "Imdb WatchList Notification"
                        });
                    }
                    catch (Exception ex)
                    {

                        _logger.LogError(ex.Message, ex);
                    }

                    Notifications notification = new Notifications() { WatchListId = movies.Id };
                    _uow.NotificationsRepository.Create(notification);
                    _uow.Save();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                }
            }

            return Task.CompletedTask;
        }
    }
}
