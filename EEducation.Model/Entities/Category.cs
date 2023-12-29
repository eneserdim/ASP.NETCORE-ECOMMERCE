using EEducation.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Model.Entities
{
    // Dbdeki kategorileri içerisinde tutacak Categories tablosunu temsil eden sınıf
    public class Category : CoreEntity
    {
        public string CategoryName { get; set; }

        public string CategoryImage {  get; set; }

        public string CategoryIcon { get; set; }

        // Product sınıfla(tablosuyla) bağlantı yapıyoruz
        public ICollection<Product> Product { get; set; }
    }
}
