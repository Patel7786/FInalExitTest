
using Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class SMSNotificationStrategy : INotificationChannelStrategy
    {
        public void Send(string subject, string message)
        {
            var smsNotification = new SMSNotification();
            smsNotification.Send(subject, message);
        }
    }
}
