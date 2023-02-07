using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using PrimeHomes.Models;
using PrimeHomes.ViewModels;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net.Mail;
using System.Threading.Tasks;


namespace PrimeHomes.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _emailSender;

        public ContactController(
            IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpPost]
        public async Task<ActionResult> SendEmail()
        {
            await _emailSender.SendEmailAsync("mustic11jobe@yahoo.com", "subject", "something");
            // email was sent, no exception
            return Ok();

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("INFO@PRIMEHOMES.AFRICA ");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;

                    smtp.Credentials = new System.Net.NetworkCredential
                    ("primehomes633@gmail.com", "nmlbrqxfipdsturc");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }




       


        //[HttpPost]
        // public ActionResult Contact()
        // {




        //     //string fromMail = "primehomes633@gmail.com";
        //     //string fromPassword = "nmlbrqxfipdsturc";

        //     //MailMessage message = new MailMessage();
        //     //message.From = new MailAddress(fromMail);
        //     //message.Subject = "Test Subject";
        //     //message.To.Add(new MailAddress("mustic11jobe@yahoo.com"));
        //     //message.Body = "<html><body> Test Body </body></html>";
        //     //message.IsBodyHtml = true;

        //     //var smtpClient = new SmtpClient("smtp.gmail.com")
        //     //{
        //     //    Port = 587,
        //     //    Credentials = new NetworkCredential(fromMail, fromPassword),
        //     //    EnableSsl = true,
        //     //};

        //     //smtpClient.Send(message);
        //     return View();
        // }



      
    
}
