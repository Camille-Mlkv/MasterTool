using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolDomain.Entities
{
    public class CreditCard
    {
        private int Number {  get; set; }
        private int CVV {  get; set; }
        private DateTime ExpiryDate {  get; set; }
    }
}
