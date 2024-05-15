using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Service
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public double Tarif {  get; set; }

        public Service() { }
        public Service(string? serviceName, double tarif)
        {
            ServiceName = serviceName;
            Tarif = tarif;
        }
    }
}
