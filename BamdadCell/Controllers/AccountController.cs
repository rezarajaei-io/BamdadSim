using Repository.DTO;
using System.Web.Mvc;
using System.Web.Security;

namespace BamdadCell.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        public Repository.IServives.ILoginService _loginService;
        public Repository.IServives.IRegisterService _registerService;

        public Repository.IServives.IUserService _userServices;


        public AccountController(Repository.IServives.ILoginService loginService, Repository.IServives.IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (_loginService.IsExistUser(login.Email))
            {
                FormsAuthentication.SetAuthCookie(login.Email, login.RememberMe);
                //var Id = _userServices.GetUserIdByEmail(login.Email);
                var logstring = $"- User =>{login.Email} Logged In";
                Extentions.Logger.Logg(logstring);

                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("Email", "نام کاربری یا کلمه عبور اشتباه است");
            }




            return View(login);
        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerVM)
        {
            var log = _loginService.IsExistUser(registerVM.Email);
            if (_loginService.IsExistUser(registerVM.Email))
            {
                ModelState.AddModelError("Email", "این کاربر قبلا ثبت نام کرده است");
                return View();
            }
            else
            {
                _registerService.AddUser(registerVM);
                return Redirect("/");

            }

            //return View(registerVM);
            return Redirect("/");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var logstring = $"- User =>{User.Identity.Name} Logged out";
            Extentions.Logger.Logg(logstring);
            return Redirect("/");
        }
    }
}