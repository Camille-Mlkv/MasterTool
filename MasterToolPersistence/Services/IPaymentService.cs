using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterToolPersistence.Services
{
    public interface IPaymentService
    {
        Task<string> CreateAndConfirmPaymentIntent(string paymentMethodId, long amount, string currency);
    }
}
