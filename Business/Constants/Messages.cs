﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    { 
        //değişkenimiz pascalcase olarak yazıldı çünkü erişim belirteci public.
        public static string ProductAdded = "Ürün eklendi";  
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductsListed = "Sistem bakımda";
        public static string MaintenanceTime = "Ürünler listelendi";
    }
}