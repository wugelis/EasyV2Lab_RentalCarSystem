using RentalCar7.Application7.port.Out;
using RentalCar7.Domain7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar7.Infrastructure7.Persistance
{
    public class RentalCarRepository : IRentalCarRepository
    {
        private static List<IVehicle> _vehicles = new List<IVehicle>(
            new IVehicle[]
            {
                new Car(ModelType.Ford) { CC = "1.8", ModelName = nameof(ModelType.Ford) },
                new RV(ModelType.BMW) { CC = "3.5", ModelName = nameof(ModelType.BMW)},
                new Car(ModelType.Lexus) { CC = "2.0", ModelName = nameof(ModelType.Lexus) },
            });
        public RentalCarRepository() 
        { 
        }
        public bool AddCar(IVehicle car)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVehicle> GetAllCars()
        {
            return _vehicles;
        }

        public bool RemoveCar(IVehicle car)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCar(IVehicle car)
        {
            throw new NotImplementedException();
        }
    }
}
