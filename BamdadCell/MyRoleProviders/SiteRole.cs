using Repository.IServives;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BamdadCell.MyRoleProviders
{
    public class SiteRole : AuthorizeAttribute
    {
        private string _roles;
        private IUserService _userServices { get { return DependencyResolver.Current.GetService(typeof(IUserService)) as IUserService; } }
       
        public SiteRole(string Roles)
        {
            _roles = Roles;
        }


      
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var role = _userServices.GetRoleNameByEmail(httpContext.User.Identity.Name);

            if (role == _roles)
            {
                return true;
            }

            return false;
        }
    }
}