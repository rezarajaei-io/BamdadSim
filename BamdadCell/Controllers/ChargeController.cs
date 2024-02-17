using Repository.DTO;
using System.Web.Mvc;
using Repository.Services;
using DataLayer;
using DataLayer.Models;

namespace BamdadCell.Controllers
{
    public class ChargeController : Controller
    {

        public Repository.IServives.IChargeService _chargeservice;
        public Repository.IServives.ISimService _simservice;
        public Repository.IServives.IUserService _userService;
        public Repository.IServives.ISmsService _smsService;


        public ChargeController(Repository.IServives.IChargeService chargesimservices, Repository.IServives.ISimService simservices, Repository.IServives.IUserService userservices, Repository.IServives.ISmsService smsservice)
        {
            _chargeservice = chargesimservices;
            _simservice = simservices;
            _userService = userservices;
            _smsService = smsservice;

        }
        // GET: Charge
        [Authorize]
        public ActionResult BuyCharge()
        {

            int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);

            var sims = _simservice.GetAllSimIdByPersonId(SenderAccountId);

            if (sims.Count > 0)
            {

                var sendersimId = _simservice.GetSimIdByPersonId(SenderAccountId);
                var Credit = _simservice.IsSimCredit(sendersimId);


                //ViewBag.ChargeInfo = _chargeservice.ShowCharges();
                BamdadSimEntities context = new BamdadSimEntities();
                GenericRepository<DataLayer.Models.Charge, Repository.DTO.ShowChargesVIewModel> repo = new GenericRepository<DataLayer.Models.Charge, Repository.DTO.ShowChargesVIewModel>(context);
                //ViewBag.ChargeInfo = repo.GetById(2);
                ViewBag.ChargeInfo = _chargeservice.ShowCharges();
                //ViewBag.ChargeInfo = repo.ShowGrid();
                if (Credit)
                {
                    ViewBag.SenderNumbers = _simservice.GetSenderNumbers(SenderAccountId);

                    return View();
                }
                else
                {
                    return View("Credit");
                }
            }

            return View("NoSim");

        }

        [HttpPost]
        public ActionResult BuyCharge(ShowChargesVIewModel scvm)
        {
            int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);
            //// Person Id => Sim Id
            ///
            var sendersimId = int.Parse(Request.Form["SenderNumbers"]);

            //  var sendersimId = _simservice.GetSimIdByPersonId(SenderAccountId);

            var Balance = _simservice.GetSimBalance(sendersimId);
            var chargeId = int.Parse(Request.Form["ChargeInfo"]);
            var chargeprice = _chargeservice.GetChargePriceByChargeId(chargeId);
            var newBalance = Balance += chargeprice;


            _smsService.UpdateBalanceById(sendersimId, newBalance);
            _chargeservice.UpdateChargeStatus(chargeId);
            _chargeservice.ChargeSim(sendersimId, chargeId);
            return (Redirect("/"));
        }
    }
}