using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class BankCard
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? CardNumber { get; set; }
        public string? CvCode { get; set; }
        public string? ExpiryDate { get; set; }
        public BankCard() { }
        public BankCard(int clientId, string? cardNumber, string? cvCode, string? expiryDate)
        {
            ClientId = clientId;
            CardNumber = cardNumber;
            CvCode = cvCode;
            ExpiryDate = expiryDate;
        }
    }
}
