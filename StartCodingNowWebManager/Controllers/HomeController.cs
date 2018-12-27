using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StartCodingNowWebManager.Models;
using StartCodingNowWebManager.ApiCommunicationTools;
using StartCodingNowWebManager.ApiCommunicationModels.ThanhDatAPI;


namespace StartCodingNowWebManager.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            //OrdersModel n = new OrdersModel();
            //n.Idorders = 9;
            var data =  ApiClientFactory.ThanhDatInstance.GetAllOrders();            
           
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
