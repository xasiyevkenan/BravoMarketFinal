using System;
using System.Collections.Generic;

namespace BravoMarket.DAL.Entities
{
    public class SpecialOffer : TimeStample
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string ButtonInner { get; set; }
        public string ButtonBg { get; set; }
        public string InnerColor { get; set; }
    }
}
