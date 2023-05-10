using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Entities
{
    public class CarrierReports:BaseEntity
    {
        public Carriers Carrier { get; set; }
        public int CarrierId { get; set; }
        public int Cost { get; set; }
        public DateTime CarrierReportDate { get; set; }
    }
}
