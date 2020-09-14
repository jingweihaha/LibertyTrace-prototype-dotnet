using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibertyHealthcare.PAAPS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using AutoMapper;

namespace LibertyHealthcare.PAAPS.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        public BaseController()
        {

        }

        public BaseController(IUsersService usersService,IUserCasesService userCasesService, IMapper mapper)
        {
                     
        }

        

    }
}
