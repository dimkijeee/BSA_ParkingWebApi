using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking;
using System.IO;

namespace ParkingWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        // GET: api/Transaction
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> list = new List<string>();
            using (var streamReader = new StreamReader(Settings.pathToFile))
            {
                string transaction = streamReader.ReadLine();
                while (transaction != null)
                {
                    list.Add(transaction);
                    transaction = streamReader.ReadLine();
                }
            }
            return list;
        }

        // GET: api/Transaction/TransactionsForTheLastMinute
        [HttpGet]
        [Route("TransactionsForTheLastMinute")]
        public IEnumerable<Transaction> GetTransactionsForTheLastMinute()
        {
            return Parking.Parking.Instance.Transactions;
        }

        [HttpGet("{id}")]
        //[Route("TransactionsForTheLastMinuteByCar")]
        public IEnumerable<Transaction> GetTransactionsForTheLastMinuteByCar(int id)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach(var ta in Parking.Parking.Instance.Transactions)
            {
                if(ta.CarId==id)
                {
                    transactions.Add(ta);
                }
            }
            return transactions;
        }

        // PUT: api/Transaction/5
        [HttpPut("{id}")]
        public void RefillBalance(int id, int value)
        {
            Car temp = new Car();
            foreach(var car in Parking.Parking.Instance.Cars)
            {
                if(car.Id==id)
                {
                    Parking.Parking.Instance.RefillBalance(id, value);
                    temp = car;
                }
            }
        }
    }
}
