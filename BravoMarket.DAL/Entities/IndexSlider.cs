using System;
using System.Collections.Generic;

namespace BravoMarket.DAL.Entities
{
    public class IndexSlider : TimeStample
    {
        public string BackgroundColor { get; set; }
        public string InnerColor { get; set; }
        public string ButtonBg { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BigImageUrl { get; set; }
        public string LittleImageUrl { get; set; }
        public int DotId { get; set; }
        public SliderDot SliderDot { get; set; }
    }
}
