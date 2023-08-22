using Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class EmailNotificationStrategy : INotificationChannelStrategy
    {
        public void Send(string subject, string message)
        {
            var emailNotification = new EmailNotification();
            emailNotification.Send(subject, message);
        }
    }
}
