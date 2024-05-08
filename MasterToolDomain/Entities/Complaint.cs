using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class Complaint
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Category { get; set; } //compplaint/suggestion
        public string? Text { get; set; }
        public string? ClientName { get; set; }
        public Complaint() { }
        public Complaint(string category, string text,string clientName)
        {
            Category = category;
            Text = text;
            ClientName = clientName;
        }

    }
}
