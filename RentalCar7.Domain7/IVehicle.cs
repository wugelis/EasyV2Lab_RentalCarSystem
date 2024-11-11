using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar7.Domain7
{
    /// <summary>
    /// 車輛介面
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// 計算車輛租金
        /// </summary>
        /// <param name="daysRented"></param>
        /// <returns></returns>
        int CalculateRentalCost(int daysRented);
        /// <summary>
        /// 選擇租車時間
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        TimeSpan ChoiseRentalTime(DateTime start, DateTime end);
        /// <summary>
        /// 取得車輛類型
        /// </summary>
        /// <returns></returns>
        VehicleType GetVehicleType();
        /// <summary>
        /// 車種
        /// </summary>
        ModelType Model { get; set; }
        /// <summary>
        /// 排氣量
        /// </summary>
        string CC { get; set; }
        string ModelName { get; set; }
    }
    /// <summary>
    /// 車輛類型
    /// </summary>
    public enum VehicleType { Car, RV, RacingCar }
    /// <summary>
    /// 車輛型號
    /// </summary>
    public enum ModelType { Toyota = 100, Lexus = 150, Ford = 120, BMW = 200 }
}


