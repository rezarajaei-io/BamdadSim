using DataLayer.Models;
using Repository.DTO;
using Repository.IServives;

namespace Repository.Services
{
    public class RegisterServices : IRegisterService
    {
        public DataLayer.Models.BamdadSimEntities _dbContext;
        public RegisterServices(BamdadSimEntities context)
        {
            _dbContext = context;
        }
        public int AddUser(RegisterViewModel registerviewmodel)
        {

            Person person = new Person()
            {
                Name = registerviewmodel.Name,
                Gender = registerviewmodel.Gender,
                Balance = 10000,
                Address = registerviewmodel.Address
            };
            Account acc = new Account()
            {
                AccountId = person.PersonId,
                Email = registerviewmodel.Email,
                Password = registerviewmodel.Password,
                RoleId = 2
            };
            _dbContext.Person.Add(person);
            _dbContext.Account.Add(acc);
            _dbContext.SaveChanges();
            return person.PersonId;
        }
    }
}
