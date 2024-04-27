using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bancousmporres.Models;
using Bancousmporres.Data;

namespace Bancousmporres.Controllers
{

    public class CuentaController : Controller
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly ApplicationDbContext _context;

        public CuentaController(ILogger<CuentaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarMensaje(Cuenta objcuenta)
        {
            _logger.LogDebug("Ingreso a enviar mensaje");
            _context.Add(objcuenta);
            _context.SaveChanges();
            ViewData["Message"] = "Se registro el contacto";
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}