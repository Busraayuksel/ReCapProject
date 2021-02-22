using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemoryCarDal
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ModelYear=2019, DailyPrice=500, Description="SKODA"},
                new Car{Id=2, BrandId=2, ModelYear=2017, DailyPrice=600, Description="FORD"},
                new Car{Id=3, BrandId=2, ModelYear=2018, DailyPrice=400, Description="FORD"},
                new Car{Id=4, BrandId=3, ModelYear=2015, DailyPrice=500, Description="OPEL"},
                new Car{Id=5, BrandId=4, ModelYear=2021, DailyPrice=1300, Description="RANGE ROVER"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Delete(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }
    }
}
