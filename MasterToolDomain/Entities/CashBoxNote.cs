using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class CashBoxNote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool IsIncome { get; set; }
        public string? Info { get; set; }
        public string? Date { get; set; }
        public double Sum { get; set; }
        public CashBoxNote() { }

        public CashBoxNote(bool isIncome, string? info,string? date,double sum) 
        { 
            IsIncome = isIncome;
            Info = info;
            Date = date;
            Sum = sum;
        }
    }
}
