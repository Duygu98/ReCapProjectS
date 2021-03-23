using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;


namespace ConsolePrj
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarText();
            //CarText1();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var kira = 0;
            // Müşteri Ekleme
            Customer customer1 = new Customer();
            customer1.CustomerId =5;
            customer1.UserId = 3;
            customer1.CompanyName = "Sirket5";

            Customer customer2 = new Customer();
            customer1.CustomerId = 5;
            customer1.UserId = 3;
            customer1.CompanyName = "Sirket5";

            Customer customer3 = new Customer();
            customer1.CustomerId = 5;
            customer1.UserId = 3;
            customer1.CompanyName = "Sirket5";

            Customer customer4 = new Customer();
            customer1.CustomerId = 5;
            customer1.UserId = 3;
            customer1.CompanyName = "Sirket5";

            customerManager.Add(customer1);
            customerManager.Add(customer2);
            customerManager.Add(customer3);
            customerManager.Add(customer4);

            if (kira==0)
            {
                Rental rental = new Rental();
                rental.Id = 5;
                rental.CustomerId = 3;
                rental.CarId = 2;
                rental.RentDate = "12/02/2021";
                rental.ReturnDate = "12/03/2021";
                if (rental.ReturnDate!=null)
                {
                    Console.WriteLine("Bu işlemi yapmazsınız.");
                }
                else
                {
                    rentalManager.Add(rental);

                }


            }






        }

        private static void CarText1()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine("Car Name : " + car.CarName + "\t Brand Name :" + car.BrandName +
            //                    "\t Color Name :  " + car.ColorName + "\t DailyPrice : " + car.DailyPrice);
            //}
        }

        private static void CarText()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("Hangi işlemi yapmak istersiniz? \n 1- Araba Listeleme  \n 2- Marka Listeleme  \n 3- Renk Listeleme  \n 2- Ekleme \n 3-Cıkıs");
            var cevap = Convert.ToInt32(Console.ReadLine());
            var baslangic = 0;
            switch (cevap)
            {
                case 1:
                    Console.WriteLine("------------------------------------------------Arabalar Listesi---------------------------------------------");
                    foreach (var car in carManager.GetAll().Data)
                    {
                        Console.WriteLine("CarId: {0}, CarName: {1}, BrandId: {2}, ColorId: {3}, DailyPrice: {4}, ModelYear: {5}, Description: {6}",
                            car.Id, car.CarName, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
                    }
                    break;

                case 2:
                    Console.WriteLine("------------------------------------------------Markaya Göre Listeleme---------------------------------------------");
                    Console.WriteLine("Hangi BrandId araba arıyorsunuz.");
                    baslangic = Convert.ToInt32(Console.ReadLine());
                    foreach (var car in carManager.GetCarsByBrandId(baslangic).Data)
                    {

                        Console.WriteLine("CarId: {0}, CarName: {1}, BrandId: {2}, ColorId: {3}, DailyPrice: {4}, ModelYear: {5}, Description: {6}",
                           car.Id, car.CarName, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
                    }


                    break;
                case 3:
                    Console.WriteLine("------------------------------------------------Renge Göre Listeleme---------------------------------------------");
                    Console.WriteLine("Hangi ColorId araba arıyorsunuz.");
                    baslangic = Convert.ToInt32(Console.ReadLine());
                    foreach (var car in carManager.GetCarsByColorId(baslangic).Data)
                    {

                        Console.WriteLine("CarId: {0}, CarName: {1}, BrandId: {2}, ColorId: {3}, DailyPrice: {4}, ModelYear: {5}, Description: {6}",
                           car.Id, car.CarName, car.BrandId, car.ColorId, car.DailyPrice, car.ModelYear, car.Description);
                    }


                    break;

                case 4:
                    Console.WriteLine("------------------------------------------------Ekleme İşlemi---------------------------------------------");
                    Car car1 = new Car();
                    Console.WriteLine("Car Id: ");
                    car1.Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Car Name: ");
                    car1.CarName = Console.ReadLine();
                    Console.WriteLine("Brand Id: ");
                    car1.BrandId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Color Id: ");
                    car1.ColorId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Daily Price: ");
                    car1.DailyPrice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Model Year: ");
                    car1.ModelYear = Console.ReadLine();
                    Console.WriteLine("Description: ");
                    car1.Description = Console.ReadLine();
                    carManager.Add(car1);

                    break;
                default:
                    break;
            }
        }
    }
}
