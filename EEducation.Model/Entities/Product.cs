using EEducation.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Model.Entities
{
    // Dbdeki ürünleri içerisinde tutacak Products tablosunu temsil eden sınıf
    public class Product : CoreEntity
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageName { get; set; }

        public bool IsStock { get; set; }

        // Alttaki property yazımı ile ürünler tablosu ile kategori tablosunu birbirine bağladık. CategoryId propertysi ise bu bağlantıdan meydana foreign key bilgisidir.
        public int CategoryId { get; set; } // Foreing Key
        public Category Category { get; set; } // Bağlantı propertyisi
    }
}
