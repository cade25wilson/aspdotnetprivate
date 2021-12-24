using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;

namespace WebApplication3
{
    public class MakePayment
    {
        public static async Task<dynamic> PayAsync(string cardNumber, int month, int year, string cvc, int value)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51K9w2vKwDH39ZurYkBSBD4b1FwAES3Pxq95gxxxbEQUJgSpBr19mYAeJrju0mmwykCA6BE9wZHDg0VYZX8SNPjEc00sFsc2LMW";

                var optionsToken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardNumber,
                        ExpMonth = month,
                        ExpYear = year,
                        Cvc = cvc
                    }
                };

                var serviceToken = new TokenService();
                Token stripeToken = await serviceToken.CreateAsync(optionsToken);

                var options = new ChargeCreateOptions
                {
                    Amount = value,
                    Currency = "usd",
                    Description = "Test",
                    Source = stripeToken.Id
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }
    }
}
