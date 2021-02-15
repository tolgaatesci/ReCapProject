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
            //InMemoryCarDalReadTest();
            //InMemoryCarDalAddTest();
            //InMemoryCarDalUpdateAndDeleteTest();
            //AvisContextCarManagerTest();
            //AvisContextColorManagerTest();
            //CarDetailsDto();
            //AvisContextBrandManagerAddTest();
            //AvisContextBrandManagerDeleteTest();
            //AvisContextColorManagerUpdateTest();
            //AvisContextUserManagerUpdateTest();
            //AvisContextCustomerManagerDeleteTest();
            //AvisContextRentalManagerListTest();
            AvisContextRentalManagerAddTest();
            //RentalDetailsDto();
            //AvisContextUserManagerAddTest();
            //AvisContextRentalManagerDeleteTest();
        }

        private static void AvisContextRentalManagerDeleteTest()
        {
            IRentalDal rentalDal = new EfRentalDal();
            RentalManager rentalManager = new RentalManager(rentalDal);
            rentalManager.Delete(new Rental { Id=9 });
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}", rental.CarId, rental.CustomerId, rental.Id, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void AvisContextUserManagerAddTest()
        {
            IUserDal userDal = new EfUserDal();
            UserManager userManager = new UserManager(userDal);
            userManager.Add(new User() { FirstName = "Tolga", LastName = "Burak", Email = "tolga@mynet.com", Password = 123456});
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}", user.Id, user.FirstName, user.LastName, user.Email, user.Password);
            }
        }
        private static void RentalDetailsDto()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();

            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("{0}\t {1}\t {2}", rental.CarName, rental.CustomerName, rental.RentDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void AvisContextRentalManagerAddTest()
        {
            IRentalDal rentalDal = new EfRentalDal();
            RentalManager rentalManager = new RentalManager(rentalDal);
            var result1 =rentalManager.Add(new Rental {CarId=5, RentDate = new DateTime(2021,1,21), ReturnDate = new DateTime(2021,2,14) });
            var result2 = rentalManager.GetAll();

            foreach (var rental in result2.Data)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}", rental.CarId, rental.CustomerId, rental.Id, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void AvisContextRentalManagerListTest()
        {
            IRentalDal rentalDal = new EfRentalDal();
            RentalManager rentalManager = new RentalManager(rentalDal);
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}", rental.CarId, rental.CustomerId, rental.Id, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void AvisContextCustomerManagerDeleteTest()
        {
            ICustomerDal customerDal = new EfCustomerDal();
            CustomerManager customerManager = new CustomerManager(customerDal);
            customerManager.Delete(new Customer { CustomerId = 3});
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CustomerId + customer.UserId + customer.CompanyName);
            }
        }

        private static void AvisContextUserManagerUpdateTest()
        {
            IUserDal userDal = new EfUserDal();
            UserManager userManager = new UserManager(userDal);
            userManager.Update(new User {  Id = 3, FirstName = "Can Bartu", LastName = "Küçükandonyadis", Email = "canbartu@yandex.com", Password = 789654123});
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.Id + user.FirstName + user.LastName + user.Email + user.Password);
            }
        }

        private static void AvisContextColorManagerUpdateTest()
        {
            IColorDal colorDal = new EfColorDal();
            ColorManager colorManager = new ColorManager(colorDal);
            colorManager.Update(new Color { ColorId = 17, ColorName = "Violet", ColorType = "Dark" });
            var result = colorManager.GetAll();
            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorId + color.ColorName + color.ColorType);
            }
        }

        private static void AvisContextBrandManagerDeleteTest()
        {
            IBrandDal brandDal = new EfBrandDal();
            BrandManager brandManager = new BrandManager(brandDal);
            brandManager.Delete(new Brand { BrandId = 5 });
            brandManager.Delete(new Brand { BrandId = 9 });
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine("Marka Id {0} \nMarka İsmi: {1} \nMarka İtibarı: {2}", brand.BrandId, brand.BrandName, brand.BrandReputation);
                Console.WriteLine("\n-----------------------------------------------\n");
            }
        }

        private static void AvisContextBrandManagerAddTest()
        {
            IBrandDal brandDal = new EfBrandDal();
            BrandManager brandManager = new BrandManager(brandDal);
            var result = brandManager.GetAll();
            Brand brand1 = new Brand();
            brand1.BrandReputation = 3;
            brand1.BrandName = "Peugeot";
            brandManager.Add(brand1);
            foreach (var brand in result.Data)
            {
                Console.WriteLine("Marka Id {0} \nMarka İsmi: {1} \nMarka İtibarı: {2}", brand.BrandId, brand.BrandName, brand.BrandReputation);
                Console.WriteLine("\n-----------------------------------------------\n");
            }
        }

        private static void CarDetailsDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} {1} {2} {3}", car.BrandName, car.CarName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void InMemoryCarDalUpdateAndDeleteTest()
        {
            Console.WriteLine("------------------InMemoryCarDal-----------------------");

            ICarDal carDal = new InMemoryCarDal();
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
        }

        private static void InMemoryCarDalReadTest()
        {
            Console.WriteLine("-----------------InMemoryCarDal------------------------");

            CarManager carManagerMemory = new CarManager(new InMemoryCarDal());
            var result = carManagerMemory.GetAll();
            foreach (var car in result.Data)
            {
                Console.WriteLine("Araçların açıklamaları" + " " + car.Description);
            }
        }

        private static void InMemoryCarDalAddTest()
        {
            Console.WriteLine("-----------------InMemoryCarDal------------------------");

            ICarDal carDal = new InMemoryCarDal();
            carDal.Add(new Car { Id = 4, BrandId = 444, ColorId = 44, ModelYear = 2013, DailyPrice = 250, Description = "rty" });

            foreach (var car in carDal.GetAll())
            {
                Console.WriteLine("Bir araç klendikten sonra araçların açıklamaları" + " " + car.Description);
            }
        }

        private static void AvisContextCarManagerTest()
        {
            Console.WriteLine("----------------AvisContext-------------------------");

            CarManager carManager = new CarManager(new EfCarDal());
            var result1 = carManager.GetCarsByColorId(11);
            var result2 = carManager.GetCarsByBrandId(2);
            var result3 = carManager.GetAll();
            var result4 = carManager.GetCarsByBrandId(3);

            foreach (var car in result1.Data)
            {
                Console.WriteLine("Renge göre araçların açıklamaları" + " " + car.Description);
            }

            foreach (var car in result2.Data)
            {
                Console.WriteLine("Markaya göre araçların model yılları" + " " + car.ModelYear);
            }

            Console.WriteLine("--------------------------------------------------");

            foreach (var car in result3.Data)
            {
                Console.WriteLine(car.Id + "\t" + car.BrandId + "\t" + car.ColorId + "\t" + car.ModelYear + "\t" + car.DailyPrice + "\t" + car.Description);
            }

            Console.WriteLine("--------------------------------------------------");

            carManager.Add(new Car { BrandId = 3, ColorId = 14, DailyPrice = 300, ModelYear = 2019, Description = "Kadjar" });

            Console.WriteLine("--------------------------------------------------");

            foreach (var car in result4.Data)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}\t {5}\t", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }
        }

        private static void AvisContextColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();

            //Color color2 = new Color();
            //color2.ColorId = 18;
            //color2.ColorName = "Kırmızı";
            //color2.ColorType = "Rich";

            //Color color3 = new Color() { ColorId = 19, ColorName = "Siyah", ColorType = "Pastel" };
            //colorManager.Delete(color2);
            //colorManager.Delete(color2);


            //colorManager.Add(new Color { ColorId = 19, ColorName = "Siyah", ColorType = "Pastel" });

            foreach (var color in result.Data)
            {
                Console.WriteLine("{0}\t {1}\t \t{2}", color.ColorId, color.ColorName, color.ColorType);
            }

            Console.WriteLine("--------------------------------------------------");
        }
    }
}
