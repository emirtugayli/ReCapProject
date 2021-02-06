using System;
using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var carList = carManager.GetAll();
            var brandList = brandManager.GetAll();
            var colorList = colorManager.GetAll();
            Console.WriteLine("ReCap Homework - Emir TUGAYLI \n \n");
            Console.WriteLine("===== Rent A Car Demo=====");
            Console.WriteLine("-Arabalar Listeleniyor-");
            foreach (var item in carList)
            {
                Console.WriteLine($"{item.Description} fiyati : {item.DailyPrice}");
            }
            Console.WriteLine("-Araba Silme Demosu-");
            Console.Write("Silmek istediginiz arabanin ID'sini giriniz : ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                carManager.Delete(carManager.GetCarById(id));
            }
            catch (Exception)
            {

                Console.WriteLine("Hatali giris yaptiniz");
            }
            Console.WriteLine("-Markaya gore araba bulma demosu-");
            try
            {
                Console.WriteLine("Marka listesi \n -----------");
                foreach (var item in brandManager.GetAll())
                {
                    Console.WriteLine($"#{item.Id} - {item.Name}");
                }
                Console.Write("Bulmak istediginiz markanin idsini yaziniz :");
                int brandId = Convert.ToInt32(Console.ReadLine());
                var brandListId = carManager.GetCarsByBrandId(brandId);
                var brand = brandManager.GetBrandById(brandId);
                Console.WriteLine($"{brand.Name} markasinin arabalari listeleniyor...");
                foreach (var item in brandListId)
                {
                    Console.WriteLine($"------------- \n {item.Description} \n Gunluk Fiyati : {item.DailyPrice} \n Model Yili : {item.ModelYear} \n -------------");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali giris yaptiniz");
            }
            Console.WriteLine("-Renk Ekleme Demosu-");
            try
            {
                Console.Write("Girmek istediginiz rengin ismini yaziniz :");
                var colorName = Console.ReadLine();
                Color tempColor = new Color { Name = colorName };
                colorManager.Add(tempColor);
                Console.WriteLine("Istenen renk basariyla db'ye eklenmistir");
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali giris yaptiniz");
            }
            
        }
    }
}
