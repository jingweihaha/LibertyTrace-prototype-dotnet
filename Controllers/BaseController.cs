using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibertyHealthcare.PAAPS.Core.Interfaces;
using LibertyHealthcare.PAAPS.Core.Domains;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibertyHealthcare.PAAPS.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        private readonly IMenuItemsService _menuItemsService;
        private readonly IUserCasesService _userCasesService;

        public BaseController()
        {

        }

        public BaseController(IMenuItemsService menuItemsService, IUserCasesService userCasesService)
        {
            _menuItemsService = menuItemsService;
            _userCasesService = userCasesService;            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            controller.ViewBag.MenuItems = _menuItemsService.LoadAllMenuItems();
        }

    }
}
