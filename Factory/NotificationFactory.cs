using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{


    //create Enumerator of NotificationChannel in which We have Email, SMS
    public enum NotificationChannel
    {
        Email,
        SMS
    }

    //create factory in which we can hide the complexity of system and return object.
    public static class NotificationFactory
    {
        public static INotification CreateNotification(string channel)
        {
            switch (channel)
            {
                case "email":
                    return new EmailNotification();
                case "1":
                    return new EmailNotification();
                case "2":
                    return new SMSNotification();
                case "sms":
                    return new SMSNotification();
                default:
                    throw new NotSupportedException($"Channel {channel} not supported. Please provide valid communication channel");
            }
        }
    }
}
