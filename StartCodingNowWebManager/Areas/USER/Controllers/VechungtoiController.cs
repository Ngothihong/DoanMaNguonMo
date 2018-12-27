using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace StartCodingNowWebManager.Areas.USER.Controllers
{
    [Area("USER")]
    public class VechungtoiController : Controller
    {
        // GET: USER/Vechungtoi
        public ActionResult Index()
        {
            return View();
        }
    }
}