using EEducation.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Model.Entities
{
    public class About : CoreEntity
    {
        public string AboutTitle { get; set; }
        public string AboutDescription { get; set; }
        public string AboutPhoto { get; set; }
    }
}
