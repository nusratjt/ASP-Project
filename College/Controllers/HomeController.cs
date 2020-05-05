using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using College.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace College.Controllers
{
    public class HomeController : Controller

    {
        public ViewResult Index()
        {
            return View("Home");
        }
    }
}
