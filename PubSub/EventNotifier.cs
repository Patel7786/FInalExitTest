using System;
using System.Collections.Generic;
using System.Text;

namespace PubSub
{
    public class EventNotifier
    {
        public delegate void NotificationHandler(object sender, string message);
        public event NotificationHandler OnNotification;

        //use for notify the subcriber 
        public void NotifySubscribers(string message)
        {
            OnNotification?.Invoke(this, message);
        }
    }
}
