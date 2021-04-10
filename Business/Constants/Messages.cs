using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba adı geçersiz";
        public static string CarListed = "Arabalar Listelendi";
        public static string CarUpdate = "Araba Güncellendi";
        public static string CarDelete = "Araba Kayıdı Silindi";

        public static string CarImageListed = "Araba resimleri listelendi";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string FailAddedImageLimit = "Resim limitine erişildi";

        public static string BrandAdded = "Marka eklendi.";
        public static string BrandNameInvalid = "Marka adı geçersiz";
        public static string BrandListed = "Markalar Listelendi";

        public static string ColorListed = "Colors Listelendi";
        public static string ColorAdded = "Color eklendi.";
        public static string ColorNameInvalid = "Color adı geçersiz";
        
        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalRentDateInvalid = "Kiralama tarihi geçersiz";
        public static string RentalReturnDateInvalid = "Kiralama dönüş tarihi geçersiz";
        public static string RentalUndeliveredCar = "Araç henüz teslim edilmedi.";
        public static string RentalListed = "Kiralamalar listelendi";
        public static string RentalUpdated = "Kiralama güncellendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerCompanyNameInvalid = "Müşteri firma ismi geçersiz";
        public static string CustomerListed = "Müşteri listelendi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        public static string UserListed = "Users Listelendi";
        public static string UserAdded = "User eklendi.";
        public static string UserInvalid = "User adı geçersiz";

        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ImageDelete = "Sistem Bakımda";
        public static string ImageUpdate = "Sistem Bakımda";
        public static string CarImagesCount = "Sistem Bakımda";
        public static string ImageAdded = "Sistem Bakımda";

        public static string CarImageLimitExceeded = "Car Image Limit Exceeded!";


        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string CustomerDelete { get; internal set; }
        public static string CustomerUpdate { get; internal set; }
        public static string RentalDelete { get; internal set; }
        public static string RentalUpdate { get; internal set; }
        public static string UserDelete { get; internal set; }
        public static string UserUpdate { get; internal set; }
      
    }
}
