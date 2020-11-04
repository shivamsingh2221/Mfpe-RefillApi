using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RefillApi.Models
{
    public class RefillOrder
    {
       public string SubscriptionID { get; set; }
       public int RefillorderID { get; set; }

       public DateTime RefillDate { get; set; }
       
       public int QuantityStatus { get; set; }
        public Boolean Payment { get; set; }
    }
}
