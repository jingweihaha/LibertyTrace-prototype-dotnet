using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibertyTrace_prototype_dotnet.Models;
using LibertyHealthcare.PAAPS.Core.Interfaces;

namespace LibertyHealthcare.PAAPS.Web.Controllers
{ 
    public class HomeController : BaseController
    {
    
        private readonly IUserCasesService _userCasesService;
        private readonly IMenuItemsService _menuItemsService;
        public HomeController(IUserCasesService userCasesService, IMenuItemsService menuItemsService):base(menuItemsService, userCasesService)
        {
            _menuItemsService = menuItemsService;
            _userCasesService = userCasesService;
        }

        public IActionResult Index()
        {
            var MenuItems = ViewBag.MenuItems;
            return View();
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
