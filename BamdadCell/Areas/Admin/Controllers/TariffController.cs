using Repository.DTO;
using System.Web.Mvc;

namespace BamdadCell.Areas.Admin.Controllers
{



    public class TariffController : Controller
    {

        private Repository.IServives.ICallService _callService;
        private Repository.IServives.ISmsService _smsService;

        public TariffController(Repository.IServives.ICallService callService, Repository.IServives.ISmsService smsService)
        {
            _callService = callService;
            _smsService = smsService;
        }
        // GET: Admin/Tariff
        public ActionResult Index()
        {
            ViewBag.calltariff = _callService.GetCallTariff();
            ViewBag.smstariff = _smsService.GetSmsTariff();
            return View();
        }
        [HttpPost]
        public ActionResult Index(TarrtifViewModel tvm)
        {

            _smsService.UpdateTariff(tvm.CallTariff, tvm.SmsTariff);

            return View("Home");
        }
    }
}