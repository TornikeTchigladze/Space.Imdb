using System;
using System.Collections.Generic;
using System.Text;

namespace Space.Imdb.Infrastructure.Contracts.Models.Config
{
    public class SmtpConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
