using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Order
    {
        private int Id { get; set; }
        private DateTime Date { get; set; }
        private Request? BaseRequest { get; set; }
        private int MasterId { get; set; }
        private string? Status { get; set; }
        private double Price { get; set; }
        private Dictionary<Detail, int>? Details { get; set; }
        private Dictionary<Material,double>? Materials { get; set; }
    }
}
