using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RefillApi.Models
{
    public class RefillOrderLine
    {
        public string SubscriptionID { get; set; }
        public int RefillorderID { get; set; }

        public int QuantityStatus { get; set; }
        
        public string DrugsList { get; set;  }

    }
}
