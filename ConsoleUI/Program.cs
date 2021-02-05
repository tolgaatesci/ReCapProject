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
            Console.WriteLine("-----------------InMemoryCarDal------------------------");

            CarManager carManagerMemory = new CarManager(new InMemoryCarDal());
            foreach (var car in carManagerMemory.GetAll())
            {
                Console.WriteLine("Araçların açıklamaları" + " " + car.Description);
            }

            Console.WriteLine("-----------------InMemoryCarDal------------------------");

            ICarDal carDal = new InMemoryCarDal();
            carDal.Add(new Car { Id = 4, BrandId = 444, ColorId = 44, ModelYear = 2013, DailyPrice = 250, Description = "rty" });

            foreach (var car in carDal.GetAll())
            {
                Console.WriteLine("Bir araç klendikten sonra araçların açıklamaları" + " " + car.Description);
            }

            Console.WriteLine("------------------InMemoryCarDal-----------------------");

            carDal.Update(new Car { Id = 3, BrandId = 555, ColorId = 55, ModelYear = 2018, DailyPrice = 520, Description = "fgh" });

            carDal.Delete(new Car { Id = 2 });


            foreach (var car in carDal.GetAll())
            {
                Console.WriteLine("Bir araç eklenip bir araç silindikten sonra araçların açıklamaları" + " " + car.Description);
            }

            Console.WriteLine("-----------------------------------------");

            foreach (var car in carDal.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("----------------AvisContext-------------------------");

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarsByColorId(11))
            {
                Console.WriteLine("Renge göre araçların açıklamaları" + " " + car.Description);
            }

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("Markaya göre araçların model yılları" + " " + car.ModelYear);
            }

            Console.WriteLine("--------------------------------------------------");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t" + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Description);
            }

            Console.WriteLine("--------------------------------------------------");

            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Color color2 = new Color();
            //color2.ColorId = 18;
            //color2.ColorName = "Kırmızı";
            //color2.ColorType = "Rich";

            //Color color3 = new Color() { ColorId = 19, ColorName = "Siyah", ColorType = "Pastel" };
            //colorManager.Add(color2);
            //colorManager.Add(color3);

            colorManager.Add(new Color { ColorId = 18, ColorName = "Kırmızı", ColorType = "Rich" });
            colorManager.Add(new Color { ColorId = 19, ColorName = "Siyah", ColorType = "Pastel" });

            foreach (var color in colorManager.GetColorsByColorType("Rich"))
            {
                Console.WriteLine("Renk tipine göre renklerin isimleri" + " " + color.ColorName);
            }

        }
    }
}
