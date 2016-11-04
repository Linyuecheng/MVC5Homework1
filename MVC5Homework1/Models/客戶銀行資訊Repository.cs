using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Homework1.Models
{
    public class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
    {
        public 客戶銀行資訊 Find(int id)
        {
            return this.All().FirstOrDefault(cb => cb.Id == id);
        }

        public override void Delete(客戶銀行資訊 customerBankInfo)
        {
            customerBankInfo.Is刪除 = true;
        }
    }

    public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}