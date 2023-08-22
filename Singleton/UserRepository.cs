using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    //  Singleton User Repository
    public class UserRepository
    {

        // it is containter that is basicaly store the details : instance is created or not;
        private static UserRepository _instance;

        private UserRepository() { }


        //get the Instance
        public static UserRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserRepository();
                    //for thread safty we are using Synchronization 
                    lock (_instance) ;
                }
                    

                return _instance;
            }
        }

        // details of subscriber setter method
        private List<string> subscribedUsers = new List<string> { "user1@example.com", "+1234567890" };


        //getter method of subcriber
        public List<string> GetSubscribedUsers()
        {
            return subscribedUsers;
        }
        public void SetSubscribedUsers(string data)
        {
            
            subscribedUsers.Add(data);
            Console.WriteLine("User are addes suscessfully");

        }

        public void UnSubscribedUsers(string data)
        {

            subscribedUsers.Remove(data);
            Console.WriteLine("User are removed ");

        }
    }

}
