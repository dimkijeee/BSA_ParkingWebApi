using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking;

namespace ParkingWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Car")]
    public class CarController : Controller
    {
        // GET: api/Car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return Parking.Parking.Instance.Cars;
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return Parking.Parking.Instance.Cars.FirstOrDefault((x) => x.Id == id);
        }
        
        // POST: api/Car
        [HttpPost]
        public Car Post(int balance, CarType typeOfCar)
        {
            Car car = new Car(balance, typeOfCar);
            Parking.Parking.Instance.AddCar(car);
            return car;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            Car temp;
            temp = Parking.Parking.Instance.Cars.FirstOrDefault((x) => x.Id == id);
            if (temp == null)
                return temp;
            else
            {
                Parking.Parking.Instance.TakeCar(id);
                return temp;
            }
        }
    }
}
