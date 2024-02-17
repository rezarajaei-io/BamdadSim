using System;
using System.Linq;
using System.Web.Mvc;

namespace BamdadCell.Areas.Admin.Controllers
{
    public class SmsController : Controller
    {
        public Repository.IServives.ISmsService _smsService;

        public SmsController(Repository.IServives.ISmsService smsService)
        {
            //_userService = new Repository.IServives.IUserService();
            _smsService = smsService;

        }
        // GET: Admin/Sms
        public ActionResult Index()
        {
            var listUsers = _smsService.GetAllSms();

            return View(listUsers);
        }




        // GET: Users/Edit/5
        public ActionResult Edit(Repository.DTO.AdminSmsViewModel sms, FormCollection collection)
        {
            var ss = _smsService.GetAllSms().FirstOrDefault(s => s.Id == sms.Id);
            return View(ss);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Repository.DTO.AdminSmsViewModel sms)
        {
            try
            {
                // TODO: Add update logic here
                _smsService.UpdateSms(sms);
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
                _smsService.DeleteSms(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}