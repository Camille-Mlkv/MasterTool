using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class OrderDetail
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DetailId { get; set; }
        public int Amount { get; set; }
        public OrderDetail() { }
        public OrderDetail(int orderId, int detailId,int amount)
        {
            OrderId = orderId;
            DetailId=detailId;
            Amount = amount;
        }
    }
}
