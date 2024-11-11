using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar7.Infrastructure7.Persistance
{
	public class RentalCarsEnt
	{
		[Key]
		[Column(Order = 0)]
		public int Id {get; set;}
		public string CarType {get; set;}
		public DateTime RentalStartTime {get; set;}
		public DateTime RentalEndTime {get; set;}
		public int AccountID {get; set;}
	}

}
