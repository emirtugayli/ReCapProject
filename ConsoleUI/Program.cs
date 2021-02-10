using System;
using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Collections.Generic;

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
            Start(carManager, brandManager, colorManager, carList, brandList, colorList);

            //Use for start
            //Start(carManager, brandManager, colorManager, carList, brandList, colorList);


            //Screens
            //UserScreen(carManager, brandManager, carList, brandList);
            //AdminScreen(carManager, brandManager, colorManager, carList, brandList, colorList, result, adminPass);


            //Services

            //Car CRUD Operations
            //AddCarTest(carManager, carList);
            //UpdateCarDemo(carManager, brandManager, carList);
            //DeleteCarDemo(carManager);
            //FindCarByBrandTest(carManager, brandManager, brandList);
            //GetListOfCarsTest(brandManager, carList);

            //Brand CRUD Operations 
            //AddBrandDemo(brandManager, brandList);
            //GetListOfBrand(brandManager);
            //DeleteBrandDemo(brandManager);
            //UpdateBrandDemo(brandManager);

            //Color CRUD Operations
            //AddColorTest(ColorManager colorManager);
            //GetColorList(colorList);
            //UpdateColorTest(colorManager, colorList);
            //DeleteColorTest(colorManager, colorList);

        }

        //Methods
        private static void Start(CarManager carManager, BrandManager brandManager, ColorManager colorManager, List<Car> carList, List<Brand> brandList, List<Color> colorList)
        {
            Console.WriteLine("ReCap Homework - Emir TUGAYLI \n \n");
            Console.WriteLine("===== Rent A Car Demo=====");
            try
            {
                Console.WriteLine("Adminseniz 'admin' Usersaniz 'user' yaziniz");
                var result = Console.ReadLine();
                var adminPass = "password123";
                AdminScreen(carManager, brandManager, colorManager, carList, brandList, colorList, result, adminPass);
            }
            catch (Exception)
            {

                Console.WriteLine("Hatali giris yaptiniz!");
            }
        }

        private static void AdminScreen(CarManager carManager, BrandManager brandManager, ColorManager colorManager, List<Car> carList, List<Brand> brandList, List<Color> colorList, string result, string adminPass)
        {
            if (result == "admin")
            {
                Console.Write("Sifrenizi yaziniz :");
                var tempPass = Console.ReadLine();
                if (tempPass == adminPass)
                {

                    try
                    {
                        Console.WriteLine("Islem yapmak istediginiz objeyi seciniz \n 1- Araba   2-Marka   3-Renk");
                        Console.Write("Islemin idsini giriniz : ");
                        var decide = Convert.ToInt32(Console.ReadLine());
                        if (decide == 1)
                        {
                            try
                            {
                                Console.WriteLine("Islemler : \n1-Ekle \n2-Sil \n3-Guncelle");
                                var operation = Convert.ToInt32(Console.ReadLine());
                                if (operation == 1)
                                {
                                    AddCarTest(carManager, carList);
                                }
                                else if (operation == 2)
                                {
                                    DeleteCarDemo(carManager);
                                }
                                else
                                {
                                    UpdateCarDemo(carManager, brandManager, carList);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Bu id'de bir islem yok!");
                            }

                        }
                        else if (decide == 2)
                        {
                            try
                            {
                                Console.WriteLine("Islemler : \n1-Ekle \n2-Sil \n3-Guncelle");
                                var operation = Convert.ToInt32(Console.ReadLine());
                                if (operation == 1)
                                {
                                    AddBrandDemo(brandManager, brandList);

                                }

                                else if (operation == 2)
                                {
                                    DeleteBrandDemo(brandManager);
                                }
                                else
                                {
                                    UpdateBrandDemo(brandManager);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Bu id'de bir islem yok!");
                            }
                        }
                        else if (decide == 3)
                        {
                            try
                            {
                                Console.WriteLine("Islemler : \n1-Ekle \n2-Sil \n3-Guncelle");
                                var operation = Convert.ToInt32(Console.ReadLine());
                                if (operation == 1)
                                {
                                    AddColorTest(colorManager);
                                }

                                else if (operation == 2)
                                {
                                    DeleteColorTest(colorManager, colorList);
                                }
                                else
                                {
                                    UpdateColorTest(colorManager, colorList);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Bu id'de bir islem yok!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bu id'de bir obje yok!");
                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception("Hatali id girisi");
                    }

                }
                else
                {
                    throw new Exception("Sifreniz yanlis!");
                    Console.Write("User olarak devam etmek ister misiniz ? E/H");
                    var question = Console.ReadLine();
                    if (question == "E")
                    {
                        UserScreen(carManager, brandManager, carList, brandList);
                    }
                    else if (question == "H")
                    {
                        Console.WriteLine("Uygulama kapatiliyor.");
                        Environment.Exit(0);
                    }

                }
            }
            else if (result == "user")
            {
                UserScreen(carManager, brandManager, carList, brandList);
            }
        }

        private static void UpdateColorTest(ColorManager colorManager, List<Color> colorList)
        {
            Console.WriteLine("-Renk guncelleme demosu-");
            GetColorList(colorList);
            try
            {
                Console.WriteLine("Guncellemek istediginiz arabanin idsini giriniz : ");
                var colorId = Convert.ToInt32(Console.ReadLine());
                var updatedColor = colorManager.GetColorById(colorId);
                try
                {
                    Console.Write("Yeni ismi giriniz :");
                    var tempColorName = Console.ReadLine();
                    updatedColor.Name = tempColorName;
                    colorManager.Update(updatedColor);
                }
                catch (Exception)
                {

                    throw new Exception("Yanlis giris!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Bu id'de bir renk yok.");
            }
        }

        private static void DeleteColorTest(ColorManager colorManager, List<Color> colorList)
        {
            Console.WriteLine("-Renk Silme Demosu-");
            GetColorList(colorList);
            Console.Write("Silmek istediginiz markanin ID'sini giriniz : ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                colorManager.Delete(colorManager.GetColorById(id));
                Console.WriteLine("Basariyla silindi!");
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali giris yaptiniz");
            }
        }

        private static void GetColorList(List<Color> colorList)
        {
            Console.WriteLine("-Renkler Listeleniyor-");
            foreach (var color in colorList)
            {
                Console.WriteLine($"#{color.Id} / {color.Name}");
            }
        }

        private static void UpdateBrandDemo(BrandManager brandManager)
        {
            Console.WriteLine("-Marka guncelleme demosu-");
            GetListOfBrand(brandManager);
            try
            {
                Console.WriteLine("Guncellemek istediginiz arabanin idsini giriniz : ");
                var brandId = Convert.ToInt32(Console.ReadLine());
                var updatedBrand = brandManager.GetBrandById(brandId);
                try
                {
                    Console.Write("Yeni ismi giriniz :");
                    var tempBrandName = Console.ReadLine();
                    updatedBrand.Name = tempBrandName;
                    brandManager.Update(updatedBrand);
                }
                catch (Exception)
                {

                    throw new Exception("Yanlis giris!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Bu id'de bir marka yok.");
            }
        }

        private static void DeleteBrandDemo(BrandManager brandManager)
        {
            Console.WriteLine("-Marka Silme Demosu-");
            GetListOfBrand(brandManager);
            Console.Write("Silmek istediginiz markanin ID'sini giriniz : ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                brandManager.Delete(brandManager.GetBrandById(id));
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali giris yaptiniz");
            }
        }

        private static void GetListOfBrand(BrandManager brandManager)
        {
            Console.WriteLine("-Markalar Listeleniyor-");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"#{brand.Id} / {brand.Name}");
            }
        }

        private static void AddBrandDemo(BrandManager brandManager, List<Brand> brandList)
        {
            Console.WriteLine("-Marka ekleme demosu-");
            try
            {
                foreach (var brand in brandList)
                {
                    Console.WriteLine($"#{brand.Id} - {brand.Name} ");
                }
                Console.Write("Kac tane marka eklemek istiyorsunuz :");
                var counter = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < counter; i++)
                {

                    Console.Write("Girmek istediginiz markanin ismini yaziniz : ");
                    var tempName = Console.ReadLine();
                    Brand tempBrand = new Brand { };
                    tempBrand.Name = tempName;
                    brandManager.Add(tempBrand);
                    Console.WriteLine($"Istenen marka basariyla sisteme eklendi! #{tempBrand.Id}");
                }
            }
            catch
            {
                Console.WriteLine("Islem hatali!");
            }
        }

        private static void UpdateCarDemo(CarManager carManager, BrandManager brandManager, List<Car> carList)
        {
            GetListOfCarsTest(brandManager, carList);
            try
            {
                Console.WriteLine("Guncellemek istediginiz arabanin idsini giriniz : ");
                var carId = Convert.ToInt32(Console.ReadLine());
                var updatedCar = carManager.GetById(carId);
                try
                {
                    Console.Write("Arabanin yeni ismini yaziniz : ");
                    var tempName = Console.ReadLine();
                    Console.Write("Arabanin yeni renk idsini yaziniz : ");
                    var tempColorId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Arabanin yeni model yilini yaziniz : ");
                    var tempModelYear = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Arabanin yeni gunluk fiyatini yaziniz : ");
                    var tempDailyPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Arabanin yeni aciklamasini (max 20 karakter) yaziniz : ");
                    var tempDescription = Console.ReadLine();

                    updatedCar.Name = tempName;
                    updatedCar.ColorId = tempColorId;
                    updatedCar.ModelYear = tempModelYear;
                    updatedCar.DailyPrice = tempDailyPrice;
                    updatedCar.Description = tempDescription;
                    carManager.Update(updatedCar);
                    Console.WriteLine("Urun basariyla guncellenmistir!");
                }
                catch (Exception)
                {

                    throw new Exception("Yanlis giris!");
                }

            }
            catch (Exception)
            {
                throw new Exception("Bu id'de bir araba yok.");
            }
        }

        private static void UserScreen(CarManager carManager, BrandManager brandManager, List<Car> carList, List<Brand> brandList)
        {
            Console.WriteLine("Sisteme hosgeldiniz !");
            Console.WriteLine("Islemler ; \n 1-Arabalari listele \n 2-Istenen markalarin arabalarini bul");
            Console.Write("Yapmak istediginiz islemin numarasini yaziniz : ");
            var operation = Convert.ToInt32(Console.ReadLine());
            if (operation == 1)
            {
                GetListOfCarsTest(brandManager, carList);
            }
            else if (operation == 2)
            {
                FindCarByBrandTest(carManager, brandManager, brandList);
            }
            else
            {
                throw new Exception("Hatali islem girdiniz , Lutfen tekrar deneyiniz.");
            }
        }

        private static void GetListOfCarsTest(BrandManager brandManager, List<Car> carList)
        {
            Console.WriteLine("-Arabalar Listeleniyor-");
            foreach (var item in carList)
            {
                //iDTO kullanmadim daha onceki versiyon bu. 
                var brand = brandManager.GetBrandById(item.BrandId);
                Console.WriteLine($"#{item.Id} - {brand.Name} {item.Name} fiyati : {item.DailyPrice}");
            }
        }

        private static void DeleteCarDemo(CarManager carManager)
        {
            Console.WriteLine("-Araba Silme Demosu-");
            Console.Write("Silmek istediginiz arabanin ID'sini giriniz : ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                carManager.Delete(carManager.GetById(id));
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali giris yaptiniz");
            }
        }

        private static void AddCarTest(CarManager carManager, List<Car> carList)
        {
            Console.WriteLine("-Araba ekleme demosu-");
            try
            {
                foreach (var car in carList)
                {
                    Console.WriteLine($"#{car.Id} - {car.Name} Fiyati : {car.DailyPrice}");
                }
                Console.Write("Kac tane araba eklemek istiyorsunuz :");
                var counter = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < counter; i++)
                {

                    Console.Write("Girmek istediginiz arabanin ismini yaziniz : ");
                    var tempName = Console.ReadLine();
                    Console.Write("Girmek istediginiz arabanin marka idsini yaziniz : ");
                    var tempBranId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Girmek istediginiz arabanin renk idsini yaziniz : ");
                    var tempColorId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Girmek istediginiz arabanin model yilini yaziniz : ");
                    var tempModelYear = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Girmek istediginiz arabanin gunluk fiyatini yaziniz : ");
                    var tempDailyPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Girmek istediginiz arabaya kisa bir aciklama (max 20 karakter) yaziniz : ");
                    var tempDescription = Console.ReadLine();

                    Car tempCar = new Car { };
                    tempCar.Name = tempName;
                    tempCar.BrandId = tempBranId;
                    tempCar.ColorId = tempColorId;
                    tempCar.ModelYear = tempModelYear;
                    tempCar.DailyPrice = tempDailyPrice;
                    tempCar.Description = tempDescription;
                    carManager.Add(tempCar);
                    Console.WriteLine($"Istenen araba basariyla sisteme eklendi! #{tempCar.Id}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Islem hatali!");
            }
        }

        private static void AddColorTest(ColorManager colorManager)
        {
            Console.WriteLine("-Renk Ekleme Demosu-");
            try
            {
                Console.Write("Girmek istediginiz rengin ismini yaziniz :");
                var colorName = Console.ReadLine();
                Color tempColor = new Color { Name = colorName };
                colorManager.Add(tempColor);
                Console.WriteLine($"Istenen renk basariyla db'ye eklenmistir #{tempColor.Id}");
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali giris yaptiniz");
            }
        }

        private static void FindCarByBrandTest(CarManager carManager, BrandManager brandManager, List<Brand> brandList)
        {
            Console.WriteLine("-Markaya gore araba bulma demosu-");
            try
            {
                Console.WriteLine("Marka listesi \n -----------");
                foreach (var item in brandList)
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
                    Console.WriteLine($"------------- \n {brand.Name} {item.Name} \n Gunluk Fiyati : {item.DailyPrice} \n Model Yili : {item.ModelYear} \n -------------");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali giris yaptiniz");
            }
        }
    }
}
