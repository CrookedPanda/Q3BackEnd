using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineMonitoring.Controllers
{
    public class MachineController : Controller
    {
        Imachine_monitoring_poortenLogic _logic;
        public MachineController(Imachine_monitoring_poortenLogic logic)
        {
            _logic = logic;
        }

        // GET: MachineController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MachineController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MachineController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MachineController/Create
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

        // GET: MachineController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MachineController/Edit/5
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

        // GET: MachineController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MachineController/Delete/5
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
