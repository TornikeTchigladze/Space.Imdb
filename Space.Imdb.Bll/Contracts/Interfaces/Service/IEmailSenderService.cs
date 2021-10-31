using Space.Imdb.Bll.Contracts.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Interfaces.Service
{
    public interface IEmailSenderService
    {
        void SendEmail(Email email);
    }
}
