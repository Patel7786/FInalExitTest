using Adapter;
using Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeEntryPoint
{
    //  Facade for Notification System
    public class NotificationSystem
    {
        private readonly IUserRepositoryAdapter user;

        public NotificationSystem(IUserRepositoryAdapter userRepository)
        {
            
            user = userRepository;
        }

        public void SendNotification(string channel, string subject, string message)
        {
            //get the list of Subscriber by using adpter design pattern
            var users = user.GetSubscribedUsers();

            //use the factory design pattern 
            var notification = NotificationFactory.CreateNotification(channel);

            foreach (var user in users)
            {
                // Send notifications to only subscribed users ----------------
                notification.Send(subject, message);
            }
        }
    }

}
