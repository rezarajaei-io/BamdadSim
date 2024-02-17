using Repository.DTO;
using System.Web.Mvc;

namespace BamdadCell.Controllers
{
    public class SimController : Controller
    {

        private Repository.IServives.ISimService _simService;
        private Repository.IServives.IUserService _userService;
        public SimController(Repository.IServives.ISimService sim, Repository.IServives.IUserService userService)
        {
            _simService = sim;
            _userService = userService;

        }
        // GET: Sim
        public ActionResult BuySim()
        {
            var allnoOwnersimid = _simService.GetAllNoOwnerSimIds();
            var receiptlist = _simService.GetBuySimCardsList(allnoOwnersimid);
            return View(receiptlist);

        }

        [HttpPost]
        public ActionResult BuySim(BuySimViewModel bsvm)
        {
            int userPersonId = _userService.GetUserIdByEmail(User.Identity.Name);
            var simid = _simService.GetSimIdByNumber(bsvm.SimNumber);

            _simService.BuySim(simid, userPersonId);
            return Redirect("/");
        }



    }
}