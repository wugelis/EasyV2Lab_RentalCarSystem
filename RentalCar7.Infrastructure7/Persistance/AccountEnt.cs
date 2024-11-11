using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar7.Infrastructure7.Persistance
{
	public class AccountEnt
	{
		[Key]
		[Column(Order = 0)]
		public int Id {get; set;}
		public string UserID {get; set;}
		public string Password {get; set;}
		public string AID {get; set;}
		public string MobilePhone {get; set;}
		public string ChtName {get; set;}
	}

}
