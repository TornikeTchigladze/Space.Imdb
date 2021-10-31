using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.Email
{
    public class EbMailConfig
    {
        public EmailAddress Sender { get; set; }
        public EmailAddress Receiver { get; set; }
        public EmailAddress ReceiverCC { get; set; }
    }
}
