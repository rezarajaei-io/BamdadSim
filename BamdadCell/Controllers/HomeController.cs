using Repository.DTO;
using System;
using System.Web.Mvc;

namespace BamdadCell.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {


        public Repository.IServives.ISimService _simService;
        public Repository.IServives.IUserService _userService;
        public Repository.IServives.ISmsService _smsService;
        public Repository.IServives.ICallService _callService;


        public HomeController(Repository.IServives.ISimService simService, Repository.IServives.IUserService userService, Repository.IServives.ISmsService smsService, Repository.IServives.ICallService callService)
        {
            _simService = simService;
            _userService = userService;
            _smsService = smsService;
            _callService = callService;
        }
        public ActionResult Index()
        {
            int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);
            //// Person Id => Sim Id
            // var SenderId = _simService.GetSimIdByPersonId(SenderAccountId);

            var allsenderId = _simService.GetAllSimIdByPersonId(SenderAccountId);


            var SmsList = _smsService.ShowUserSmsList(allsenderId);



            return View(SmsList);
        }

        public ActionResult Sms()
        {
            int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);
            var sims = _simService.GetAllSimIdByPersonId(SenderAccountId);
            if (sims.Count > 0)
            {
                ViewBag.SenderNumbers = _simService.GetSenderNumbers(SenderAccountId);
                ViewBag.ReciverNumbers = _simService.GetReciverNumbers(SenderAccountId);
                return View();
            }

            return View("NoSim");


        }
        [HttpPost]
        public ActionResult Sms(SmsViewModel smsvm)
        {

            int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);
            var sims = _simService.GetAllSimIdByPersonId(SenderAccountId);
            if (sims.Count > 0)
            {

                var reciversimId = int.Parse(Request.Form["ReciverNumbers"]);
                var reciversimnumber = _simService.GetSimNumberIdBySimId(reciversimId);
                if (_simService.IsExistSim(reciversimnumber))
                {

                    var SenderId = int.Parse(Request.Form["SenderNumbers"]);
                    var ReciverSimId = int.Parse(Request.Form["ReciverNumbers"]);
                    
                    
                    var Credit = _simService.IsSimCredit(SenderId);
                    var Balance = _simService.GetSimBalance(SenderId);
                    var tarrif = _smsService.GetSmsTariff();

                    if (_simService.IsSimActive(SenderId))
                    {
                        if (Credit)
                        {
                            if (Balance >= 0)
                            {
                                var newBalance = Balance -= tarrif;
                                _smsService.UpdateBalanceById(SenderId, newBalance);
                                _smsService.AddSms(smsvm, SenderId, ReciverSimId);
                            }
                            else
                            {
                                return View("NoBalance");
                            }
                        }
                        else
                        {
                            if (Balance >= -20000)
                            {
                                var reBalance = Balance -= tarrif;
                                _smsService.UpdateBalanceById(SenderId, reBalance);
                                _smsService.AddSms(smsvm, SenderId, ReciverSimId);
                            }
                            else
                            {
                                return View("NoCredit");
                            }
                        }

                    }

                    else
                    {
                        return View("BlockSim");
                    }
                    return Redirect("/");



                }
                else
                {

                    return View();
                }
                return View();
            }
            else
            {
                return View("NoSim");
            }
        }







        public ActionResult ShowCalls()
        {
            int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);

            var sims = _simService.GetAllSimIdByPersonId(SenderAccountId);
            if (sims.Count > 0)
            {


                ViewBag.SenderNumbers = _simService.GetSenderNumbers(SenderAccountId);
                //// Person Id => Sim Id
                var SenderId = _simService.GetSimIdByPersonId(SenderAccountId);

                var allSimId = _simService.GetAllSimIdByPersonId(SenderAccountId);

                var callList = _callService.ShowUserCallList(allSimId);
                return View(callList);

            }

            return View("NoSim");

        }

        public ActionResult Call()
        {
            int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);

            var sims = _simService.GetAllSimIdByPersonId(SenderAccountId);
            if (sims.Count > 0)
            {


                ViewBag.SenderNumbers = _simService.GetSenderNumbers(SenderAccountId);
                ViewBag.ReciverNumbers = _simService.GetReciverNumbers(SenderAccountId);


                return View();
            }

            return View("NoSim");



        }

        [HttpPost]
        public ActionResult Call(CallsViewModel callvm)
        {
            // var ReciverrId = int.Parse(Request.Form["ReciverNumbers"]);
            var reciversimId = int.Parse(Request.Form["ReciverNumbers"]);
            var reciversimnumber = _simService.GetSimNumberIdBySimId(reciversimId);
            if (_simService.IsExistSim(reciversimnumber))
            {

                int SenderAccountId = _userService.GetUserIdByEmail(User.Identity.Name);
                //// Person Id => Sim Id
                //var SenderId = _simService.GetSimIdByPersonId(SenderAccountId);
                var SenderId = int.Parse(Request.Form["SenderNumbers"]);



                var ReciverSimId = int.Parse(Request.Form["ReciverNumbers"]);
                var Duration = callvm.CallDuration;

                string nowtime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
                var time = DateTime.Parse(nowtime);

                var Credit = _simService.IsSimCredit(SenderId);
                var Balance = _simService.GetSimBalance(SenderId);
                var tarrif = _callService.GetCallTariff();
                if (_simService.IsSimActive(SenderId))
                {
                    if (Credit)
                    {
                        if (Balance >= 0)
                        {
                            var newBalance = Balance -= (tarrif * Duration);
                            _callService.UpdateBalanceById(SenderId, newBalance);
                            _callService.AddCall(callvm, SenderId, ReciverSimId);

                        }
                        else
                        {
                            return View("NoBalance");
                        }
                    }
                    else
                    {
                        if (Balance >= -20000)
                        {
                            var reBalance = Balance -= (tarrif * Duration);


                            _smsService.UpdateBalanceById(SenderId, reBalance);
                            _callService.AddCall(callvm, SenderId, ReciverSimId);


                        }
                        else
                        {
                            return View("NoCredit");
                        }
                    }

                }

                else
                {
                    return View("BlockSim");
                }
                return Redirect("/Home/ShowCalls");



            }
            else
            {
                ModelState.AddModelError("Reciver", "Number Is Not Exist");

                return View();
            }
            return View();
        }



    }
}