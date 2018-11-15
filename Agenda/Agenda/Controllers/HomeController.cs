﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            //ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            //ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        public IActionResult Editar()
        {
            //ViewData["Message"] = "Your contact page.";


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
