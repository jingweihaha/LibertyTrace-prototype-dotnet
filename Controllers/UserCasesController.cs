using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibertyTrace_prototype_dotnet.Controllers
{
    public class UserCasesController : Controller
    {
        // GET: UserCasesController
        public ActionResult Index()
        {
            return View();
        }

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
