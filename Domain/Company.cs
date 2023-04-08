using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Company : BaseEntityWithId
    {
        public string CompanyName {get;set;}
        public string Address {get;set;}
        public string Number {get;set;}
        public string Distric {get;set;}
        public string City { get; set; }
        public string State {get;set;}
        public string UF { get;set;}
    }
}
