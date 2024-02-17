using System;
using System.Linq;
using System.Web.Mvc;

namespace BamdadCell.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        public Repository.IServives.IUserService _userService;

        public UsersController(Repository.IServives.IUserService userService)
        {
            //_userService = new Repository.IServives.IUserService();
            _userService = userService;

        }
        // GET: Users
        public ActionResult Index()
        {
            var listUsers = _userService.GetUsers();

            return View(listUsers);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create(FormCollection collection)
        {


            ViewBag.Succsess = true;

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Repository.DTO.UsersViewModel user, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var result = _userService.AddUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(Repository.DTO.UsersViewModel user, FormCollection collection)
        {
            var ss = _userService.GetUsers().FirstOrDefault(s => s.Id == user.Id);
            return View(ss);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Repository.DTO.UsersViewModel user)
        {
            try
            {
                // TODO: Add update logic here
                _userService.UpdateUser(user);
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
                _userService.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
