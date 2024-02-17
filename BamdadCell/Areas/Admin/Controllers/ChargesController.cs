using System;
using System.Linq;
using System.Web.Mvc;
using DataLayer.Models;
using Repository.Services;

namespace BamdadCell.Areas.Admin.Controllers
{
    public class ChargesController : Controller
    {
        Repository.IServives.IChargeService _chargeServices;
        public ChargesController(Repository.IServives.IChargeService chargeservices)
        {
            _chargeServices = chargeservices;
        }
        // GET: Admin/Charges
        public ActionResult Index()
        {
            BamdadSimEntities context = new BamdadSimEntities();
            //var charglist = _chargeServices.GetCharges();
            GenericRepository<DataLayer.Models.Charge, Repository.DTO.ShowChargesVIewModel> repo = new GenericRepository<DataLayer.Models.Charge, Repository.DTO.ShowChargesVIewModel>(context);

            var chargelist = repo.ShowGrid();
            return View(chargelist);
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
        public ActionResult Create(Repository.DTO.ShowChargesVIewModel charge, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //var result = _chargeServices.AddCharge(charge);

                BamdadSimEntities context = new BamdadSimEntities();
                //var charglist = _chargeServices.GetCharges();
                GenericRepository<DataLayer.Models.Charge, Repository.DTO.ShowChargesVIewModel> repo = new GenericRepository<DataLayer.Models.Charge, Repository.DTO.ShowChargesVIewModel>(context);

                repo.Add(charge);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(Repository.DTO.UsersViewModel charge, FormCollection collection)
        {
            var ss = _chargeServices.GetCharges().FirstOrDefault(s => s.ChargeId == charge.Id);
            return View(ss);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Repository.DTO.ShowChargesVIewModel charge)
        {
            try
            {
                // TODO: Add update logic here
                _chargeServices.UpdateCharge(charge);
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
                _chargeServices.DeleteCharge(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
