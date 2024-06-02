using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Date { get; set; }
        public int BaseRequestId { get; set; }
        public int MasterId { get; set; }
        public int ClientId { get; set; }
        public bool IsReady { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }
        public bool IsTaken { get; set; }
        public bool IsRefusedByMaster { get; set; }

        public Order() { }

        public Order(string date, int baseRequestId,int masterId,int clientId, bool isReady, double price,bool isPaid,bool isTaken,bool isRefusedByMaster)
        {
            Date = date;
            MasterId = masterId;
            ClientId = clientId;
            IsReady = isReady;
            Price = price;
            BaseRequestId = baseRequestId;
            IsPaid = isPaid;
            IsTaken = isTaken;
            IsRefusedByMaster = isRefusedByMaster;
        }
    }
}
