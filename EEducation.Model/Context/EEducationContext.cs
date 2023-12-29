using EEducation.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Model.Context
{
    // EEducationContext veritabanını temsil eden sınıfımızdır
    public class EEducationContext : IdentityDbContext
    {
        public EEducationContext(DbContextOptions<EEducationContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        // Db'de oluşacak tabloların burada property olarak tanımlanması gerekiyor
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<About> Abouts { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
