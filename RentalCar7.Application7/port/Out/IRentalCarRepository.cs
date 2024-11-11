//using Domain.Lab120240821;
using RentalCar7.Domain7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar7.Application7.port.Out
{
    public interface IRentalCarRepository
    {
        bool AddCar(IVehicle car);
        bool RemoveCar(IVehicle car);
        bool UpdateCar(IVehicle car);
        IEnumerable<IVehicle> GetAllCars();
    }
}

