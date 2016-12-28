using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMasterDetailsEntry.Models; 

namespace MVCMasterDetailsEntry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Post action for Save data to database
        [HttpPost]
        public JsonResult SaveOrder(OrderVM O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MasterEntities dc = new MasterEntities())
                {
                    Order order = new Order { OrderNo = O.OrderNo, OrderDate = O.OrderDate, Description = O.Description };
                    foreach (var i in O.OrderDetails)
                    {
                        //
                        // i.TotalAmount = 
                        order.OrderDetails.Add(i);
                    }
                    dc.Orders.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
            }
        }
}