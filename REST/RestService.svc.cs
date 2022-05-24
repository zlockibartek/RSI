using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace REST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class RestService : IRestService
    {
        private static List<Car> cars;

        public RestService()
        {
            cars = new List<Car>()
            {
                new Car(1, "Fiat Multipla", 10),
                new Car(2, "Ford Mustang", 250000),
                new Car(3, "Mini Cooper", 130000)
            };
        }

        public List<Car> getAllXml()
        {
            return cars;
        }

        public List<Car> getAllJson()
        {
            return getAllXml();
        }

        public Car getByIdXml(string identifier)
        {
            int id = int.Parse(identifier);

            bool exists = cars.Where(car => car.identifier == id).Select(car => car.identifier).Any();

            if (!exists)
            {
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            }

            return cars.Where(car => car.identifier == id).First();
        }

        public Car getByIdJson(string identifier)
        {
            return getByIdXml(identifier);
        }

        public string addXml(Car car)
        {
            if (car == null)
            {
                throw new WebFaultException<string>("409: Conflict", System.Net.HttpStatusCode.BadRequest);
            }

            bool exists = cars.Where(c => c.identifier == car.identifier).Any();

            if (exists)
            {
                throw new WebFaultException<string>("409: Conflict", System.Net.HttpStatusCode.Conflict);
            }

            cars.Add(car);
            return $"Added item with ID={car.identifier}";
        }

        public string addJson(Car car)
        {
            return addXml(car);
        }

        public string deleteXml(string identifier)
        {
            int id = int.Parse(identifier);

            bool exists = cars.Where(car => car.identifier == id).Select(car => car.identifier).Any();

            if (!exists)
            {
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            }

            Car carToRemove = cars.Where(car => car.identifier == id).First();

            cars.Remove(carToRemove);

            return $"Removed item with ID={identifier}";
        }

        public string deleteJson(string identifier)
        {
            return deleteXml(identifier);
        }
    }
}
