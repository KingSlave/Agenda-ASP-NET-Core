using System;
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
            List<Contacto> contactos = new List<Contacto>();

            contactos.Add(new Contacto("king.slave@gmail.com"));
            contactos.Add(new Contacto("itsh.sistemas@gmail.com"));
            contactos.Add(new Contacto("correo@gmail.com"));

            //ViewData["Message"] = "Your contact page.";

            return View(contactos);
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            Contacto c = new Contacto();
            c.email = id;

            return View(c);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
