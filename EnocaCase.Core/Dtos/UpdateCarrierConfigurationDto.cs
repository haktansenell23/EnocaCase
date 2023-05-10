using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Dtos
{
    public class UpdateCarrierConfigurationDto
    {


        public int Id { get; set; }
        public int CarrierId { get; set; }

        public int CarrierMaxDesi { get; set; }

        public int CarrierMinDesi { get; set; }

        public int CarrierCost { get; set; }



    }
}
