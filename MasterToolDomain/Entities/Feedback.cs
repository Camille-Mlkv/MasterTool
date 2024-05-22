using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Feedback
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public int Rate { get; set; }
        public string? Text { get; set; }
        public int OrderId { get; set; }
        public Feedback() { }
        public Feedback(string? clientName, int rate, string? text, int orderId)
        {
            ClientName = clientName;
            Rate = rate;
            Text = text;
            OrderId = orderId;
        }
    }
}
