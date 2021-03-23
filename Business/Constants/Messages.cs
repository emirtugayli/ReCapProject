using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerDeleted = "Müşteri silindi";

        public static string RentalAdded = "Araç kiralama işlemi başarıyla eklendi";
        public static string RentalUpdated = "Araç kiralama işlemi başarıyla güncellendi";
        public static string RentalDeleted = "Araç kiralama işlemi başarıyla silindi";
        public static string ErrorRent = "Araç kiralama işlemi başarısız";


        public static string CarNameInvalid = "Araba ismi geçersiz";

        public static string CarListed = "Arabalar Listelendi";
        public static string BrandListed = "Markalar Listelendi";
        public static string ColorListed = "Renkler Listelendi";
        public static string UserListed = "Kullanıcılar Listelendi";
        public static string RentalListed = "Araç kiralama işlemi başarıyla Listelendi";
        public static string CustomerListed = "Müşteriler Listelendi";

        public static string CarImageAdded = "Araba resmi basariyla eklendi" ;
        public static string CarImageListed = "Araba resimleri basariyla listelendi " ;
        public static string CarImageDeleted = "Araba resmi basariyla silindi" ;
        public static string CarImageUpdated = "Araba resmi basariyla guncellendi";
        public static string ImageCapacityForACarReached = "Bir arabanin max 5 resmi olabilir";

        public static string AuthorizationDenied="Bunu yapabilmek icin yetkiniz yok";
        public static string UserRegistered = "Kayit olundu.";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Sifre yanlis";
        public static string SuccessfulLogin = "Giris basarili";
        public static string UserAlreadyExists = "Boyle bir kullanici zaten var";
        public static string AccessTokenCreated = "Token olusturuldu";
    }
}

