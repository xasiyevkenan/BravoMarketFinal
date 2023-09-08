﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoMarket.DAL.Entities
{
    public class LeftNavigation : TimeStample
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int HeaderId { get; set; }

        public Header Header { get; set; }
    }
}
