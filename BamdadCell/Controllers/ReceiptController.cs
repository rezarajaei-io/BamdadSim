using Repository.DTO;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace BamdadCell.Controllers
{
    public class ReceiptController : Controller
    {

        public Repository.IServives.IUserService _userService;
        public Repository.IServives.IReceiptService _receiptService;
        public Repository.IServives.ISimService _simservice;
        public Repository.IServives.ISmsService _smsService;


        public ReceiptController(Repository.IServives.IReceiptService receiptservices, Repository.IServives.IUserService userservices, Repository.IServives.ISimService simservices, Repository.IServives.ISmsService smsServices)
        {
            _receiptService = receiptservices;
            _userService = userservices;
            _simservice = simservices;
            _smsService = smsServices;
        }
        // GET: Receipt
        public ActionResult Payment()
        {
            int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);

            var sims = _simservice.GetAllSimIdByPersonId(SenderAccountId);

            if (sims.Count > 0)
            {

                var allsender = _simservice.GetAllSimIdByPersonId(SenderAccountId);
                var Credit = _simservice.IsAllSimCredit(allsender);

                if (!Credit)
                {
                    var receiptlist = _receiptService.GetReceipt(SenderAccountId, allsender);
                    return View(receiptlist);
                }
                else
                {
                    return View("Receipttype");
                }
            }
            return View("NoSim");

        }

        [HttpPost]
        public ActionResult Payment(ShowReceiptViewModel srvm)
        {
            var simId = _userService.GetSimIdByNumber(srvm.SimCart);

            var jtime = Extentions.TimeConvertor.ToShamsi();
            var ptime = DateTime.ParseExact(jtime, "yyyy/MM/dd HH:mm:ss", CultureInfo.GetCultureInfo("fa-IR"));
            _smsService.UpdateBalanceById(simId, 0);
            _receiptService.PayReceipt(srvm.Price, simId, ptime);
            return (Redirect("/"));
        }

    }

}