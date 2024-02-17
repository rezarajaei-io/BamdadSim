using System;
using System.Linq;
using System.Web.Mvc;

namespace BamdadCell.Areas.Admin.Controllers
{
    public class AdminAccountController : Controller
    {
        Repository.IServives.IUserService _userService;

        public AdminAccountController(Repository.IServives.IUserService userService)
        {
            _userService = userService;
        }
        // GET: Admin/Account
        public ActionResult Index()
        {
            var accountslist = _userService.GetAccounts();

            return View(accountslist);
        }

        // GET: Users/Details/5


        // GET: Users/Create
        public ActionResult Create(FormCollection collection)
        {


            ViewBag.Succsess = true;

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Repository.DTO.ShowAccountViewModel acc, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var result = _userService.AddAccount(acc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(Repository.DTO.ShowAccountViewModel acc, FormCollection collection)
        {
            var ss = _userService.GetAccounts().FirstOrDefault(s => s.Id == acc.Id);
            return View(ss);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Repository.DTO.ShowAccountViewModel acc)
        {
            try
            {
                // TODO: Add update logic here
                _userService.UpdateAccount(acc);
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
                _userService.DeleteAccount(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}