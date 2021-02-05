using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal()); 
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //Console.WriteLine("-----------------------------------------");

            //ICarDal carDal = new InMemoryCarDal();
            //carDal.Add(new Car { Id = 4, BrandId = 444, ColorId = 44, ModelYear = 2013, DailyPrice = 250, Description = "rty" });

            //foreach (var car in carDal.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //Console.WriteLine("-----------------------------------------");

            //carDal.Update(new Car { Id = 3, BrandId = 555, ColorId = 55, ModelYear = 2018, DailyPrice = 520, Description = "fgh" });

            //carDal.Delete(new Car { Id = 2 });


            //foreach (var car in carDal.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            //Console.WriteLine("-----------------------------------------");

            //foreach (var car in carDal.GetAllById(1))
            //{
            //    Console.WriteLine(car.Description);
            //}

            //Console.WriteLine("-----------------------------------------");

            CarManager carManager = new CarManager(new EfCarDal()); 
            foreach (var car in carManager.GetCarsByColorId(11))
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
