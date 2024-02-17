using DataLayer.Models;
using Repository.IServives;
using System.Linq;

namespace Repository.Services
{
    public class LoginServices : ILoginService
    {

        public DataLayer.Models.BamdadSimEntities _dbContext;
        public LoginServices(BamdadSimEntities context)
        {
            _dbContext = context;
        }
        public bool IsExistUser(string Email)
        {
            return _dbContext.Account.Any(u => u.Email == Email);


        }
    }
}
