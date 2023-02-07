
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using SendGrid;
using SendGrid.Helpers;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace PrimeHomes
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //SendEmail().Wait();

           

            CreateHostBuilder(args).Build().Run();
            

           
        }
        //static async Task SendEmail()
        //{
        //    var apiKey = "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";
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("primehomes633@gmail.com", "Prime");
        //    var subject = "Sending with SendGrid is Fun";
        //    var to = new EmailAddress("mustic11jobe@yahoo.com", "Example User");
        //    var plainTextContent = "and easy to do anywhere, even with C#";
        //    var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg);
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
