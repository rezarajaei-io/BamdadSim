using System;
using System.Linq;
using System.Web.Mvc;

namespace BamdadCell.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {

        Repository.IServives.IUserService _userService;
        public RoleController(Repository.IServives.IUserService userService)
        {
            _userService = userService;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            var roleslist = _userService.GetRoles();

            return View(roleslist);
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
        public ActionResult Create(Repository.DTO.RoleViewModel role, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var result = _userService.AddRoles(role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(Repository.DTO.RoleViewModel role, FormCollection collection)
        {
            var ss = _userService.GetRoles().FirstOrDefault(s => s.RoleId == role.RoleId);
            return View(ss);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Repository.DTO.RoleViewModel role)
        {
            try
            {
                // TODO: Add update logic here
                _userService.UpdateRoles(role);
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
                _userService.DeleteRoles(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}