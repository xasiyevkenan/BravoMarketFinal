using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoMarket.DAL.Entities
{
    public class Header : TimeStample
    {
        public string Number { get; set; }
        public string LogoUrl { get; set; }

        public ICollection<LeftNavigation> LeftNavigations { get; set; }
        public ICollection<RightNavigation> RightNavigations { get; set; }
    }
}
