using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public interface INotificationChannelStrategy
    {
        void Send(string subject, string message);
    }
}
