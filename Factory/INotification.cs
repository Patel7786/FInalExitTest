using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    //create INotification Interface 
    public interface INotification
    {
        void Send(string subject, string message);
    }
}
