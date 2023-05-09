using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Entities
{
    public class CarrierConfiguration:BaseEntity
    {

        public Carriers Carriers { get; set; }

        public int CarrierId { get; set; } 
        public int MaxDesi { get; set; }

        public int CarrierMaxDesi { get; set; }

        public int CarrierMinDesi { get; set; }

        public int CarrierCost { get; set; }
    }
}
