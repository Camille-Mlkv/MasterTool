using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Detail
    {
        private int Id {  get; set; }
        private string? Name { get; set; }
        private string? Manufacturer { get; set; }
        private double Price { get; set; }
        private int Amount { get; set; }
    }
}
