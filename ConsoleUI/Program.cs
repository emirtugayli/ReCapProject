using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReCap Homework - Emir TUGAYLI");
            Console.WriteLine("===== Rent A Car Demo=====");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("-Arabalar Listeleniyor-");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Description} Fiyati : {car.DailyPrice}");
            }
            Console.WriteLine("-Araba Silme Demosu-");
            Console.Write("Silmek istediginiz arabanin ID'sini giriniz : ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                carManager.Delete(id);
                Console.WriteLine($"#{id}'li araba basariyla sistemimizden silinmistir. Guncel araba listesini goruntelemek icin 1'e tiklayiniz.");
                int getAll = Convert.ToInt32(Console.ReadLine());
                if (getAll==1)
                {
                    foreach (var car in carManager.GetAll())
                    {
                        Console.WriteLine($"{car.Description} Fiyati : {car.DailyPrice}");
                    }
                }
                else
                {
                    Console.WriteLine("Hatali giris yaptiniz");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Hatali giris yaptiniz");
            }
            Console.WriteLine("-Araba Bulma Demosu-");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                var getCar = carManager.GetById(id);
                Console.WriteLine($"{getCar.Description} Fiyati:{getCar.DailyPrice}TL Uretim Yili : {getCar.ModelYear}");
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali giris yaptiniz");
            }
            
            
        }
    }
}
