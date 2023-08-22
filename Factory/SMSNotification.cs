using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class SMSNotification : INotification
    {
        public void Send(string subject, string message)
        {
            // Implement sending SMS
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Sending SMS: Subject: {subject}, Message: {message}");
        }
    }
}
