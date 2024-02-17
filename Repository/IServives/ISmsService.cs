using Repository.DTO;
using System;
using System.Collections.Generic;

namespace Repository.IServives
{
    public interface ISmsService
    {



        int AddSms(SmsViewModel sim, int SenderId, int ReciverId);

        bool UpdateBalanceById(int Id, decimal newBalance);

        decimal GetSmsTariff();
        void UpdateTariff(decimal calltarrif, decimal smstarrif);
        IEnumerable<SmsViewModel> ShowUserSmsList(List<int> SenderAllSimId);



        #region admin 


        IEnumerable<AdminSmsViewModel> GetAllSms();

        void DeleteSms(int Id);
        void UpdateSms(AdminSmsViewModel sm);
        #endregion


    }
}
