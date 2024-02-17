using Repository.DTO;
using System;
using System.Collections.Generic;

namespace Repository.IServives
{
    public interface ICallService
    {
        int AddCall(CallsViewModel sim, int SenderId, int ReciverId);
        bool UpdateBalanceById(int Id, decimal newBalance);
        decimal GetCallTariff();
        decimal UpdateCallTariff();
        IEnumerable<CallsViewModel> ShowUserCallList(List<int> SenderAllSimId);

        #region admin 


        IEnumerable<AdminCallViewModel> GetAllCalls();

        void DeleteCall(int Id);
        void UpdateCalls(AdminCallViewModel cl);
        #endregion


    }
}
