using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCar7.Infrastructure7.Persistance
{
	public class CarsEnt
	{
		public int Id {get; set;}
		public string Model {get; set;}
		public int cc {get; set;}
		public DateTime ManufacturingDate {get; set;}
		public string Type {get; set;}
	}

}
