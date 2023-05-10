using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaCase.Core.Entities
{
    public class Orders:BaseEntity
    {
        public Carriers Carriers { get; set; }

        public int CarrierId { get; set; }

        public int OrderDesi { get; set; }//13 mesela 

        public DateTime OrderDate { get; set; }= DateTime.Now;  

        public decimal OrderCarrierCost { get; set; }
    }
}
