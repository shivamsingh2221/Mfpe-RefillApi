using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefillApi.Models;

namespace RefillApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RefillOrdersController : ControllerBase
    {     
        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RefillOrdersController));
        private List<RefillOrder> refill= new List<RefillOrder>()
        {
            new RefillOrder{ Id =1, RefillDate = Convert.ToDateTime("2020-11-24 12:12:00 PM"),DrugQuantity = 10, RefillDelivered=true,Payment=true, SubscriptionId=1},
            new RefillOrder{ Id =1, RefillDate = Convert.ToDateTime("2020-11-24 12:12:00 PM"),DrugQuantity = 10, RefillDelivered=true,Payment=true, SubscriptionId=1},
            new RefillOrder{ Id =1, RefillDate = Convert.ToDateTime("2020-11-24 12:12:00 PM"),DrugQuantity = 10, RefillDelivered=false,Payment=false, SubscriptionId=1}
        };
 
       [HttpGet("{id}")]
        public IActionResult RefillStatus(int id)
        {
            var result = refill.Last( x => (x.SubscriptionId == id) && (x.RefillDelivered) && (x.Payment) );       
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult RefillDues(int id)
        {
            var result = refill.Count( x => (x.SubscriptionId == id) && (!x.RefillDelivered) && (!x.Payment) );  
            return Ok(result);
        }
        
        [HttpPost("{PolicyId}/{MemberId}/{SubscriptionId}")]
        public IActionResult AdhocRefill([FromRoute]int PolicyId,int MemberId,int SubscriptionId)
        {
           int DrugId=2;
           string Location="Haldwani";
           RefillOrder result=new RefillOrder();
           
           // call drug microservice
           var check=true;
           
           return Ok(result);
        }
    }
}
