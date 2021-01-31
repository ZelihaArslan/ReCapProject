using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
             new Car{CarId=1, BrandId =243, ColorId=2344, ModelYear=1994, DailyPrice=1000, Description="Mercedes"},
             new Car{CarId=2, BrandId =468, ColorId=8575, ModelYear=1996, DailyPrice=400, Description="Fiat"},
             new Car{CarId=3, BrandId =145, ColorId=6456, ModelYear=1988, DailyPrice=300, Description="Honda"},
             new Car{CarId=4, BrandId =532, ColorId=5756, ModelYear=1964, DailyPrice=1200, Description="Jeep"},
             new Car{CarId=5, BrandId =654, ColorId=3346, ModelYear=2020, DailyPrice=900, Description="volswagen"},
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {

           Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.BrandId == id).ToList();
        }

        public void Update(Car car)
        {
            //arabanın id sine sahip ürünü listeden bul ve güncelle
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
        
        
    }
}
