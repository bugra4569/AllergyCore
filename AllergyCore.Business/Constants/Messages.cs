using AllergyCore.Entity.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllergyCore.Business.Constants
{
    public static class Messages
    {
        public static string FoodNameAlredyExist = "Yemek ismi daha önce kullanılmış";
        public static string FoodAdded = "Yemek Eklendi";
        public static string AllergyNameAlreadyExist = "Alerji ismi daha önce kullanılmış";
        public static string AllergyAdded = "Alerji Eklendi";
        public static string AllergyNotFound = "Alerji Bulunamadı";
        public static string AllergyDeleted = "Alerji Kaldırıldı.";
        public static string AllergyUpdated = "Alerji Güncellendi.";
        public static string MaterialAlreadyExistForSameFood = "Malzeme daha önce eklenmiş.";
        public static string IngredientAdded = "İçerik yemeğe eklendi.";
        public static string IngredientNotFound = "İçerik bulunamadı";
        public static string IngredientDeleted = "İçerik silindi.";
        public static string IngredientUpdated = "İçerik güncellendi.";
        public static string ModelNotValid = "Eksik ya da hatalı bilgi";
        public static string MaterialNotFound = "Malzeme kaydı bulunamadı";
        public static string MaterialNameAlreadyExist = "Aynı isimde malzeme sistemde kayıtlı";
        public static string MaterialAdded = "Malzeme eklendi";
        public static string MaterialUpdated = "Malzeme güncellendi.";
        public static string MaterialDeleted = "Malzeme silindi.";
        public static string FoodNotFound = "Yemek Bulunamadı.";
        public static string FoodDeleted = "Yemek Silindi.";
    }
}
