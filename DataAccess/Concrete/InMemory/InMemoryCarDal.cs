using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            Car car1 = new Car() { };
            car1.Id = 1;
            car1.ColorId = 11;
            car1.BrandId = 111;
            car1.DailyPrice = 300;
            car1.ModelYear = 2005;
            car1.Description = "abc";

            Car car2 = new Car() { };
            car2.Id = 2;
            car2.ColorId = 22;
            car2.BrandId = 222;
            car2.DailyPrice = 400;
            car2.ModelYear = 2009;
            car2.Description = "qwe";

            Car car3 = new Car() { };
            car3.Id = 3;
            car3.ColorId = 33;
            car3.BrandId = 333;
            car3.DailyPrice = 600;
            car3.ModelYear = 2015;
            car3.Description = "zxc";

            _cars = new List<Car> { };
            _cars.Add(car1);
            _cars.Add(car2);
            _cars.Add(car3);
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id); 

            _cars.Remove(carToDelete); 
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
