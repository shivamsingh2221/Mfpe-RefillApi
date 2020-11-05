using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            new RefillOrder{ Id =2, RefillDate = Convert.ToDateTime("2020-11-24 12:12:00 PM"),DrugQuantity = 10, RefillDelivered=true,Payment=true, SubscriptionId=1},
            new RefillOrder{ Id =3, RefillDate = Convert.ToDateTime("2020-11-24 12:12:00 PM"),DrugQuantity = 10, RefillDelivered=false,Payment=false, SubscriptionId=1}
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
            // drugId and Location is taken from subscription service with the help of MemberId
            
           int DrugId=2;
           string Location="Haldwani";
           RefillOrder result=new RefillOrder();
          
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject("hello"), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync("https://localhost:44329/api/DrugsApi/getDispatchableDrugStock/" + DrugId + "/" + Location, content).Result)
                {

                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest();
                    }

                    var data = response.Content.ReadAsStringAsync().Result;

                    var check = JsonConvert.DeserializeObject<bool>(data);

                    if (check)
                    {
                        result.Id=9;
                        result.RefillDate= DateTime.Now;
                        result.DrugQuantity = 10;
                        result.RefillDelivered=false;
                        result.Payment=false;
                        result.SubscriptionId=SubscriptionId;
                    }
                    
                    return Ok(result);
                }
            }
        }
    }
}
