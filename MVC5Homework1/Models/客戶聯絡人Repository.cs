using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Homework1.Models
{
    public class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
    {
        public 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public override void Delete(客戶聯絡人 customerContact)
        {
            customerContact.Is刪除 = true;
        }
    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}