using EEducation.Core.Entity;
using EEducation.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Model.Entities
{
    public class OurTeam : CoreEntity
    {
        public string FullName { get; set; }
        public  string PersonalImage { get; set; }
        public string PersonalTitle { get; set; }
    }
}
