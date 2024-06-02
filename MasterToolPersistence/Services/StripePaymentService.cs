using Stripe;
using System.Threading.Tasks;

namespace MasterToolPersistence.Services
{
    public class StripePaymentService : IPaymentService
    {
        public StripePaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51PJZMMRtVjU5VEaRQaATLuxqMi7RFyiFGNUmcqijsQh1034xCXd8tfM0nenZVsRsYcbbSMwZVJ4BK3Cf6CEof6HX008zwqdB26"; 
        }

        public async Task<string> CreateAndConfirmPaymentIntent(string paymentMethodId, long amount, string currency)
        {
            try
            {
                var paymentIntentService = new PaymentIntentService();
                var paymentIntentOptions = new PaymentIntentCreateOptions
                {
                    Amount = amount, 
                    Currency = currency, 
                    PaymentMethod = paymentMethodId,
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                    {
                        Enabled = true,
                        AllowRedirects = "never",
                    },
                };

                var paymentIntent = await paymentIntentService.CreateAsync(paymentIntentOptions);

                if (paymentIntent.Status == "requires_confirmation")
                {
                    var confirmOptions = new PaymentIntentConfirmOptions
                    {
                        PaymentMethod = paymentMethodId,
                    };
                    paymentIntent = await paymentIntentService.ConfirmAsync(paymentIntent.Id, confirmOptions);
                }

                return paymentIntent.Status;
            }
            catch (StripeException ex)
            {
                throw new Exception($"Stripe Error: {ex.StripeError.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
