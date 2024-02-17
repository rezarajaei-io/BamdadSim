using DataLayer.Models;
using Repository.DTO;
using Repository.IServives;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;


namespace Repository.UserServices
{
    public class UserServices : IUserService
    {
        public BamdadSimEntities _dbContext;

        public UserServices(BamdadSimEntities context)
        {
            _dbContext = context;
        }

        public int AddUser(UsersViewModel user)
        {
            Person person = new Person()
            {
                Name = user.Name,
                Gender = user.Gender,
                Balance = user.balance,
                Address = user.Address
            };
            _dbContext.Person.Add(person);
            _dbContext.SaveChanges();
            return person.PersonId;

        }

        public void DeleteUser(int Id)
        {
            var p = _dbContext.Person.Find(Id);
            _dbContext.Person.Remove(p);
            _dbContext.SaveChanges();
        }


        public Task<int> GetUserCount()
        {
            throw new NotImplementedException();
        }

        public int GetUserIdByEmail(string email)
        {
            return _dbContext.Account.SingleOrDefault(e => e.Email == email).AccountId;

        }

        public int GetSimIdByNumber(string number)
        {
            return _dbContext.Simcard.SingleOrDefault(e => e.Number == number).SimId;

        }

        public IEnumerable<UsersViewModel> GetUsers()
        {
            var showuser = _dbContext.Person.Select(p => new DTO.UsersViewModel()
            {
                Id = p.PersonId,
                Name = p.Name,
                Gender = (bool)p.Gender,
                balance = (decimal)p.Balance,
                Address = p.Address
            });
            return showuser;
        }

        public UsersViewModel GetUsersById(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UsersViewModel user)
        {
            var p = _dbContext.Person.Find(user.Id);
            p.Name = user.Name;
            p.Gender = user.Gender;
            p.Balance = user.balance;
            p.Address = user.Address;

            _dbContext.SaveChanges();
        }

        public IEnumerable<ShowAccountViewModel> GetAccounts()
        {
            var showaccounts = _dbContext.Account.Select(a => new DTO.ShowAccountViewModel()
            {
                Id = a.AccountId,
                Email = a.Email,
                Password = a.Password,
                RoleId = (int)a.RoleId
            });
            return showaccounts;
        }

        public void UpdateAccount(ShowAccountViewModel acc)
        {
            var a = _dbContext.Account.Find(acc.Id);
            a.Email = acc.Email;
            a.Password = acc.Password;
            a.RoleId = acc.RoleId;

            _dbContext.SaveChanges();
        }

        public void DeleteAccount(int Id)
        {
            var p = _dbContext.Account.Find(Id);
            _dbContext.Account.Remove(p);
            _dbContext.SaveChanges();
        }

        public int AddAccount(ShowAccountViewModel useraccount)
        {
            Account acc = new Account()
            {
                AccountId = useraccount.Id,
                Email = useraccount.Email,
                Password = useraccount.Password,
                RoleId = useraccount.RoleId
            };
            _dbContext.Account.Add(acc);
            _dbContext.SaveChanges();
            return acc.AccountId;
        }

        public IEnumerable<RoleViewModel> GetRoles()
        {
            var showroles = _dbContext.Role.Select(p => new DTO.RoleViewModel()
            {
                RoleId = p.RoleId,
                RoleName = p.RoleName
            });
            return showroles;
        }

        public int AddRoles(RoleViewModel role)
        {
            Role rol = new Role()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };
            _dbContext.Role.Add(rol);
            _dbContext.SaveChanges();
            return rol.RoleId;
        }

        public void DeleteRoles(int Id)
        {
            var p = _dbContext.Role.Find(Id);
            _dbContext.Role.Remove(p);
            _dbContext.SaveChanges();
        }

        public void UpdateRoles(RoleViewModel role)
        {
            var p = _dbContext.Role.Find(role.RoleId);
            p.RoleId = role.RoleId;
            p.RoleName = role.RoleName;

            _dbContext.SaveChanges();
        }

        public int GetRoleIdByPersonId(int Id)
        {

            return (int)_dbContext.Account.FirstOrDefault(r => r.AccountId == Id).RoleId;

        }
        /// <summary>
        /// در اینجا رول شخص با با ایمیل دریافت میشود و در قسمت بعد آن را در مموری کش میکنیم
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetRoleNameByEmail(string username)
        {

            string key = "rolecaching_" + username;
            ObjectCache cache = MemoryCache.Default;

            if (!cache.Contains(key))
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1);

                var account = _dbContext.Account
                    .Where(e => e.Email == username)
                    .Include(r => r.Role)
                    .FirstOrDefault();

                if (account != null && account.Role != null)
                {
                    cache.Add(key, account.Role.RoleName, policy);
                }
            }

            return cache.Get(key) as string;
        }



        public decimal GetUserBalanceById(int Id)
        {
            return (decimal)_dbContext.Person.SingleOrDefault(i => i.PersonId == Id).Balance;
        }



        public void SaveDb()
        {
            _dbContext.SaveChanges();
        }
    }
}
