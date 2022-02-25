using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_MVC.Controllers
{
    public class HelloworldController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello World ！");
        }
    }
}
