using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mesimat_Sicom.Models
{
    public class SportShoe
    {
        public SportShoe(int id, string companyName, string modelName, int size, int price)
        {
            Id = id;
            CompanyName = companyName;
            ModelName = modelName;
            Size = size;
            Price = price;
        }
        public SportShoe()
        {

        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ModelName { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
    }
}