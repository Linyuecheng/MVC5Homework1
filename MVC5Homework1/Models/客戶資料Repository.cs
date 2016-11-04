using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Homework1.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Find(int Id)
        {
            return this.All().FirstOrDefault(c => c.Id == Id);
        }

        public override void Delete(客戶資料 customerData)
        {
            customerData.Is刪除 = true;
        }

    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}