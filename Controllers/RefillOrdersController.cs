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
        public static List<RefillOrder> refillorders = new List<RefillOrder>()
        {
            new RefillOrder()
            {
                SubscriptionID ="F1",
                RefillorderID =101,
                //RefillDate = Convert.ToDateTime("2020-12-12 12:10:00.0000000"),
                RefillDate =new DateTime(2020,12,12),
                QuantityStatus = 10,
                Payment=true
            },
             new RefillOrder()
             {
                  SubscriptionID ="F2",
                RefillorderID =102,
               // RefillDate = Convert.ToDateTime("2020-10-3 12:10:00.0000000"),
                RefillDate =new DateTime(2020,10,12),
                QuantityStatus = 5,
                 Payment = true
             },

              new RefillOrder()
             {
                  SubscriptionID ="F2",
                RefillorderID =102,
               // RefillDate = Convert.ToDateTime("2020-10-3 12:10:00.0000000"),
                RefillDate =new DateTime(2020,10,12),
                QuantityStatus = 10000,
              Payment = false
                }
        };
        [HttpGet]
        public List<RefillOrder> GetRefillOrders()
        {
            return refillorders;
        }



        public static List<RefillOrderLine> refillorderlines = new List<RefillOrderLine>()
            {
             new RefillOrderLine()
             {
                    SubscriptionID = "F1",
                    RefillorderID = 101,
                    DrugsList = "A , B ,C",
                    QuantityStatus = 10
            }
           };

        [HttpGet]
        public List<RefillOrderLine> GetRefillOrderLines()
        {


            return refillorderlines;
        }





       [HttpGet("{id}")]
        public RefillOrder viewRefillStatus(string id)
        {


            /* RefillOrder order = (from p in refillorders
                                  where p.SubscriptionID.Contains(id)
                                   select p).ToList();*/

            //var order = RefillOrder

          /*  RefillOrder order = Models.RefillOrder
                                      .where(a => a.SubscriptionID.Contains(id));*/


            var result = refillorders.Last(x->(x.SubscriptionId==id ) && ()

            return order;
            // return _item.Get(id);
        }



        

        [HttpGet("{dt}")]
        public RefillOrder GetByName(DateTime dt)
        {

            RefillOrder order = (from p in refillorders
                                           where p.RefillDate <= dt
                                           select p).FirstOrDefault();
            return order;


            //return _item.Get(dt);
        }
        






    }
}
