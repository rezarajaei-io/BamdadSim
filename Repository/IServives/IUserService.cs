using Repository.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IServives
{
    public interface IUserService
    {
        IEnumerable<UsersViewModel> GetUsers();
        IEnumerable<ShowAccountViewModel> GetAccounts();

        UsersViewModel GetUsersById(int Id);
        int GetUserIdByEmail(string email);
        int GetSimIdByNumber(string number);


        void UpdateUser(UsersViewModel user);
        void UpdateAccount(ShowAccountViewModel acc);
        void DeleteUser(int Id);
        void DeleteAccount(int Id);
        int AddUser(UsersViewModel user);
        int AddAccount(ShowAccountViewModel user);

        IEnumerable<RoleViewModel> GetRoles();
        int AddRoles(RoleViewModel role);

        void DeleteRoles(int Id);
        void UpdateRoles(RoleViewModel role);

        int GetRoleIdByPersonId(int Id);

        string GetRoleNameByEmail(string username);
        decimal GetUserBalanceById(int Id);
       
       
        Task<int> GetUserCount();
        void SaveDb();

    }
}