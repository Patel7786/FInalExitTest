using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    //interface 
    public interface IUserRepositoryAdapter
    {
        
        List<string> GetSubscribedUsers();
    }
}
