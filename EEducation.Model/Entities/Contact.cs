using EEducation.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EEducation.Model.Entities
{
    public class Contact : CoreEntity
    {
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }


    }
}
