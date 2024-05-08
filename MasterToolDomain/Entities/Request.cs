using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Request
    {
        [PrimaryKey,AutoIncrement]
        private int Id {  get; set; }
        public string? Service {  get; set; }
        public string? ItemType { get; set; }
        public string? Problem { get; set; }
        public string? UsageTime { get; set; }
        public string? Manufacturer { get; set; }
        public int ClientId { get; set; }
        public bool IsApproved { get; set; }

        public Request() { }
        public Request(string service,string itemType,string problem, string usageTime,string manufacturer,int clientid,bool isApproved)
        {
            Service = service;
            ItemType = itemType;
            Problem = problem;
            UsageTime = usageTime;
            Manufacturer = manufacturer;
            ClientId = clientid;
            IsApproved = isApproved;
        }
    }
}
