using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Homework1.Models
{   
	public  class vw_CustomerInfoRepository : EFRepository<vw_CustomerInfo>, Ivw_CustomerInfoRepository
	{

	}

	public  interface Ivw_CustomerInfoRepository : IRepository<vw_CustomerInfo>
	{

	}
}