using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Dtos
{
    public class OrderPlusCarrierInformation
    {
        public string CarrierName { get; set; }

        public bool CarrierIsActive { get; set; }
        public int CarrierId { get; set; }

        public int OrderDesi { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal OrderCarrierCost { get; set; }

    }
}
