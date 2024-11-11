//using Domain.Lab120240821;
using RentalCar7.Domain7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar7.Application7.port.In
{
    /// <summary>
    /// RentalCar 租車服務的主要 UseCase Services
    /// </summary>
    public interface IRentalCarUseCase
    {
        /// <summary>
        /// 進行車輛租用作業
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        bool ToRentCar(IVehicle car);
        /// <summary>
        /// 取得所有車輛
        /// </summary>
        /// <returns></returns>
        IEnumerable<IVehicle> GetAllCars();
    }
}

