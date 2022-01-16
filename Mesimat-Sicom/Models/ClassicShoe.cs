using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mesimat_Sicom.Models
{
    public class ClassicShoe
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Gender { get; set; }
        public bool IsInStock { get; set; }
        public bool HasHeel { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
    }
}