using System;
using System.Collections.Generic;

namespace BravoMarket.DAL.Entities
{
    public class İndicator : TimeStample
    {
        public string Count { get; set; }
        public string Title { get; set; }
        public string IconUrl { get; set; }
    }
}
