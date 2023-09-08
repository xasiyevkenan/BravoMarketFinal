using System;
using System.Collections.Generic;
using System.Linq;

namespace BravoMarket.DAL.Entities
{
    public class ClientFAQTitle : TimeStample
    {
        public string Question { get; set; }
        public int ClientFAQId { get; set; }

        public ClientFAQ ClientFAQ { get; set; }

        public ICollection<ClientFAQAnswer> Answers { get; set; }
    }
}
