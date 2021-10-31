using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Bll.Contracts.Models.Email
{
    public class Email
    {
        public string Subject { get; set; }
        public EmailAddress To { get; set; }
        public EmailAddress From { get; set; }
        public string Body { get; set; }
    }
}
