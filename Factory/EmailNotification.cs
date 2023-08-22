using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class EmailNotification : INotification
    {
        public void Send(string subject, string message)
        {
            // Implement sending email
            Console.WriteLine($"Sending email: Subject: {subject}, Message: {message}");
        }
    }
}
