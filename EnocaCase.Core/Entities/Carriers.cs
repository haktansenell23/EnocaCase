using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Entities
{
    public class Carriers:BaseEntity
    {

        public string CarrierName { get; set; }

        public bool CarrierIsActive { get; set; }

        public int CarrierPlusDesiCost { get; set; }

        public List< CarrierConfiguration> CarrierConfigurations { get; set; }

        public List <Orders> Orders { get; set; }

    }
}
