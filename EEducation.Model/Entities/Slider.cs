using EEducation.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Model.Entities
{
    public class Slider : CoreEntity
    {
        public string SliderImage { get; set; }
        public string SliderTitle { get; set; }
        public string SliderDescription { get; set; }
        public string ButtonName { get; set; }
        public string ButtonUrl { get; set; }
    }
}
