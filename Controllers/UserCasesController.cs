using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using LibertyHealthcare.PAAPS.Core.Interfaces;
using LibertyHealthcare.PAAPS.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LibertyHealthcare.PAAPS.Web.Controllers
    
{
    public class UserCasesController : BaseController
    {
        private readonly IUserCasesService _userCasesService;
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        static List<UserCaseViewModel> UserCasesList = new List<UserCaseViewModel>();

        public UserCasesController(IUsersService usersService,IUserCasesService userCasesService, IMapper mapper):base(usersService, userCasesService, mapper)
        {
            _usersService = usersService;
            _userCasesService = userCasesService;
            _mapper = mapper;

            
        }

        // GET: UserCasesController
        public async Task<ActionResult> Index()
        {
            ViewBag.Status = new string[] {"Active", "Close" };
            ViewBag.Users = await _usersService.LoadAllAsync();
            ViewBag.Category = new string[] {"Priority", "Non-Priority"};
            var source = await _userCasesService.LoadAllAsync();
            _mapper.Map(source, UserCasesList);
            ViewBag.AllCases = UserCasesList;

            return View("AllCases");
        }

        //public async Task<ActionResult> AllCasesAsync()
        //{
        //    List<UserCaseViewModel> UserCasesList = new List<UserCaseViewModel>();
        //    var source = await _userCasesService.LoadAllAsync();
        //    _mapper.Map(source, UserCasesList);
        //    ViewBag.AllCases = UserCasesList;
        //    ViewBag.Status = new string[] {"Active", "Close" };
        //    ViewBag.Users = await _usersService.LoadAllAsync(); 
        //    return View("AllCases");
        //}

        [Route("/UserCases/Search")]
        public async Task<ActionResult> Search(UserCaseViewModel userCaseViewModel)
        {
            var res = new List<UserCaseViewModel>(UserCasesList);
            string SAMSID = userCaseViewModel.SAMSID;
            string[] supervisorSearch = userCaseViewModel.SupervisorSearch;
            string[] createdBySearch = userCaseViewModel.CreatedBySearch;
            string[] caseStatusSearch = userCaseViewModel.CaseStatusSearch;
            string[] assignedToSearch = userCaseViewModel.AssignedToSearch;
            string[] categorySearch = userCaseViewModel.CategorySearch;

            dynamic source = null;

            if(string.IsNullOrEmpty(SAMSID) && (supervisorSearch==null ) && (createdBySearch==null) &&
                (caseStatusSearch==null) && (assignedToSearch == null) && (categorySearch == null))
            {
                
            }
            else
            {
                source = await _userCasesService.FindCasesAsync(x => (assignedToSearch == null || assignedToSearch.Contains(x.AssignedTo))
                        && (SAMSID == null || x.Samsid.Contains(SAMSID))
                        && (supervisorSearch == null || supervisorSearch.Contains(x.Supervisor))
                        && ((createdBySearch == null || createdBySearch.Contains(x.CreatedBy)))
                        && ((caseStatusSearch == null || caseStatusSearch.Contains(x.CaseStatus)))
                        && ((categorySearch == null || categorySearch.Contains(x.Category))));

            }

            //var source = await _userCasesService.LoadAllAsync();
            _mapper.Map(source, res);

            ViewBag.Status = new string[] {"Active", "Closed" };
            ViewBag.Users = await _usersService.LoadAllAsync();
            ViewBag.Category = new string[] {"Priority", "Non-Priority"};
            ViewBag.AllCases = res;
            return View("AllCases");
        }

        //[Route("/UserCases/FindCases")]
        //public async Task<ActionResult> FindCases(string str)
        //{
        //    List<UserCaseViewModel> UserCasesList = new List<UserCaseViewModel>();
        //    var source = await _userCasesService.LoadAllAsync();
        //    _mapper.Map(source, UserCasesList);
        //    ViewBag.AllCases = UserCasesList;
        //    ViewBag.Status = new string[] {"Active", "Close" };
        //    ViewBag.Users = await _usersService.LoadAllAsync(); 
        //    return View("AllCases");
        //}

        //public async Task<ActionResult> FindACaseAsync()
        //{
        //    //List<UserCaseViewModel> UserCasesList = new List<UserCaseViewModel>();
        //    var userCase = new UserCaseViewModel();
        //    var source = await _userCasesService.FindACaseAsync();
        //    _mapper.Map(source, userCase);
        //    //ViewBag.AllCases = userCase;
        //    //return View("AllCases");
        //    return new JsonResult(userCase);
        //}

        // GET: UserCasesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserCasesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCasesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserCasesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserCasesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserCasesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserCasesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
