using System;
using System.Threading.Tasks;
using Stripe;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebApplication3.Data;
using WebApplication3.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication3
{
    public class MakePayment
    {
        public static async Task<dynamic> PayAsync(string cardNumber, int month, int year, string cvc, int value, IActionResult returnValue, EntityEntry databaseAdd)
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

                    return returnValue;
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
