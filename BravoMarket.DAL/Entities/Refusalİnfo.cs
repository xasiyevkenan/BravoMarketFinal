using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoMarket.DAL.Entities
{
    public class Refusalİnfo : TimeStample
    {
        public string Information { get; set; }
        public int RefusalId { get; set; }

        public Refusal Refusal { get; set; }
    }
}
