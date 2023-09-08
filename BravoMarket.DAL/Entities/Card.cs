using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BravoMarket.DAL.Entities
{
    public class Card : TimeStample
    {
        public string HeadTitle { get; set; }
        public string HeadDescription { get; set; }

        public ICollection<CardType> CardTypes { get; set; }
        public ICollection<CardImage> CardImages { get; set; }
    }
}
