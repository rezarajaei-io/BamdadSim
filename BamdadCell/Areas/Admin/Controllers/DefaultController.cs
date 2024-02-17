using BamdadCell.MyRoleProviders;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BamdadCell.Areas.Admin.Controllers
{

    public class DefaultController : Controller
    {


        Repository.IServives.ISimService _simService;
        Repository.IServives.IUserService _userService;


        public DefaultController(Repository.IServives.ISimService simService, Repository.IServives.IUserService userService)
        {
            _simService = simService;
            _userService = userService;


        }

        public DefaultController()
        {

        }
        // GET: Admin/Default

        [SiteRole("Admin")]
        public ActionResult Index()
        {
            var simslist = _simService.GetSims();
            return View(simslist);
        }


        public ActionResult Create()
        {
            var SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);
            ViewBag.Owners = _simService.GetSimcartOwnerByPersonId(SenderAccountId);


            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Repository.DTO.SimCardViewModel sim, FormCollection collection)
        {
            try
            {
                var Owners = int.Parse(Request.Form["Owners"]);
                sim.PersonId = Owners;
                var result = _simService.AddSim(sim);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(Repository.DTO.SimCardViewModel sim, FormCollection collection)
        {
            var ss = _simService.GetSims().FirstOrDefault(s => s.Id == sim.Id);
            return View(ss);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Repository.DTO.SimCardViewModel sim)
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