using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Detail
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public Detail() { }
        public Detail(string? name, string? manufacturer, double price, int amount)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            Amount = amount;
        }
    }
}
