using EEducation.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Model.Entities
{
    public class Brand : CoreEntity
    {
        public string BrandName { get; set; }
        public string BrandLogo { get; set; }
    }
}
