using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bancousmporres.Models;
using Bancousmporres.Data;
using Microsoft.AspNetCore.Identity;

namespace Bancousmporres.Controllers
{

    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;

        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ILogger<CatalogoController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(string? searchString)
        {
            var productos = from o in _context.DataCuenta select o;
            return View(productos.ToList());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}