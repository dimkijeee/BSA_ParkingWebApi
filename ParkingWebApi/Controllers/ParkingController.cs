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
    [Route("api/Parking")]
    public class ParkingController : Controller
    {
        // GET: api/Parking
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return Parking.Parking.Instance.Transactions;
        }

        // GET: api/Parking/FreePlaces
        [HttpGet]
        [Route("FreePlaces")]
        public int GetFreePlaces()
        {
            return Parking.Parking.Instance.CountOfFreePlaces();
        }

        // GET: api/Parking/OccupiedPlaces
        [HttpGet]
        [Route("OccupiedPlaces")]
        public int GetOccupiedPlaces()
        {
            return Parking.Parking.Instance.CountOfOccupiedPlaces();
        }
    }
}
