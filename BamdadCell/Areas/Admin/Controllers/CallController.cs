using System;
using System.Linq;
using System.Web.Mvc;

namespace BamdadCell.Areas.Admin.Controllers
{
    public class CallController : Controller
    {
        Repository.IServives.ICallService _callService;

        public CallController(Repository.IServives.ICallService callservice)
        {
            _callService = callservice;
        }
        // GET: Admin/Call
        public ActionResult Index()
        {
            var callist = _callService.GetAllCalls();

            return View(callist);
        }




        // GET: Users/Edit/5
        public ActionResult Edit(Repository.DTO.AdminCallViewModel call, FormCollection collection)
        {
            var ss = _callService.GetAllCalls().FirstOrDefault(s => s.Id == call.Id);
            return View(ss);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Repository.DTO.AdminCallViewModel cl)
        {
            try
            {
                // TODO: Add update logic here
                _callService.UpdateCalls(cl);
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
                _callService.DeleteCall(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}