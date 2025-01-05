using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Models
{
    internal class Drug
    {
        private static int id;
        public int Id { get; set; }
        public string Name { get; set; }
        public string DrugType { get; set; }

        public int Price { get; set; }
        public int Count { get; set; }

        public Drug(string name, string drugType, int price)
        {
            id++;
            Id = id;
            Name = name;
            DrugType = drugType;
            Price = price;
        }
        public override string ToString()
        {
            return $"ID: {Id} Dərman adı : {Name}  Tipi : {DrugType} Qiymət : {Price}";
        }

    }
}
