using System;
using System.Linq;
using System.Web.Mvc;

namespace BamdadCell.Areas.Admin.Controllers
{
    public class SimCardsController : Controller
    {

        public Repository.IServives.ISimService _simService;

        public SimCardsController(Repository.IServives.ISimService simService)
        {
            //_userService = new Repository.IServives.IUserService();
            _simService = simService;

        }
        public ActionResult Index()
        {
            var listSim = _simService.GetSims();

            return View(listSim);

        }
        public ActionResult Create(FormCollection collection)
        {


            ViewBag.Succsess = true;

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Repository.DTO.SimCardViewModel simvm, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var result = _simService.AddSim(simvm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Edit(Repository.DTO.SimCardViewModel sim)
        {
            var ss = _simService.GetSims().FirstOrDefault(s => s.Id == sim.Id);
            return View(ss);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Repository.DTO.SimCardViewModel sim, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                _simService.UpdateSim(sim);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _simService.DeleteSim(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}