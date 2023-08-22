using Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    public class UserRepositoryAdapter : IUserRepositoryAdapter
    {
        //using Adapter design pattern we get Subscriber which is in UserRepository , that is present in singleton design pattern. And that is work of adpater
        public List<string> GetSubscribedUsers()
        {
            return UserRepository.Instance.GetSubscribedUsers();
        }

        // using for setting the new Subscriber
        public void SetSubscribedUsers(string data)
        {
             UserRepository.Instance.SetSubscribedUsers( data);
        }


        //using for removing any user from subscriber List
        public void UnSubscribedUsers(string data)
        {
            if (UserRepository.Instance.GetSubscribedUsers().Contains(data))
            {
                UserRepository.Instance.UnSubscribedUsers(data);
            }
            else
            {
                Console.WriteLine("User Not Exist");
            }
        }
    }
}
