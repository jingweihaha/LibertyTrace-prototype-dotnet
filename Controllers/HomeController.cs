using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibertyHealthcare.PAAPS.Core.Interfaces;
using LibertyHealthcare.PAAPS.Core.Models;
using AutoMapper;

namespace LibertyHealthcare.PAAPS.Web.Controllers
{ 
    public class HomeController : BaseController
    {
          
        private readonly IUserCasesService _userCasesService;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public HomeController(IUsersService usersService, IUserCasesService userCasesService, IMapper mapper):base(usersService, userCasesService, mapper)
        {
            _usersService = usersService;
            _userCasesService = userCasesService;
            _mapper = mapper;
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
