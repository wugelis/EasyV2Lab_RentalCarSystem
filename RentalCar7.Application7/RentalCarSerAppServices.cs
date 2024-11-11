using RentalCar7.Application7.port.In;
using RentalCar7.Application7.port.Out;
using RentalCar7.Domain7;
//using Domain.Lab120240821;

namespace RentalCar7.Application7
{
    /// <summary>
    /// 
    /// </summary>
    public class RentalCarSerAppServices
    {
        private readonly IRentalCarRepository _rentalCarRepository;
        private readonly IRentalCarUseCase _rentalCarUseCase;

        public RentalCarSerAppServices(IRentalCarRepository rentalCarRepository, IRentalCarUseCase rentalCarUseCase)
        {
            _rentalCarRepository = rentalCarRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IVehicle>? GetAllCars()
        {
            return _rentalCarUseCase.GetAllCars();
        }

        public bool ToRentCar(IVehicle car)
        {
            Car mycar = new Car(car.Model) { CC = car.CC };

            return _rentalCarRepository.AddCar(car);
        }
    }
}

