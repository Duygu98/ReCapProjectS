﻿using Entities.Concrete;
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


        public static string BrandAdded = "Marka eklendi.";
        public static string BrandNameInvalid = "Marka adı geçersiz";
        public static string BrandListed = "Markalar Listelendi";

        public static string ColorListed = "Colors Listelendi";
        public static string ColorAdded = "Color eklendi.";
        public static string ColorNameInvalid = "Color adı geçersiz";

        public static string RentalListed = "Rentals Listelendi";
        public static string RentalAdded = "Rental eklendi.";
        public static string RentalNameInvalid = "Rental adı geçersiz";

        public static string CustomerListed = "Customers Listelendi";
        public static string CustomerAdded = "Customer eklendi.";
        public static string CustomerInvalid = "Customer adı geçersiz";

        public static string UserListed = "Users Listelendi";
        public static string UserAdded = "User eklendi.";
        public static string UserInvalid = "User adı geçersiz";

        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CustomerDelete { get; internal set; }
        public static string CustomerUpdate { get; internal set; }
        public static string RentalDelete { get; internal set; }
        public static string RentalUpdate { get; internal set; }
        public static string UserDelete { get; internal set; }
        public static string UserUpdate { get; internal set; }
      
    }
}