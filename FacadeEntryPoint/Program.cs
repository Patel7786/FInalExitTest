using Adapter;
using Factory;
using Strategy;
using System;
using System.Text.RegularExpressions;

namespace FacadeEntryPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a facade for the notification system. this is Entry Point of the System.
            var userRepository = new UserRepositoryAdapter();
            var notificationSystem = new NotificationSystem(userRepository);

            // Read arguments from the command line
           
            Boolean flag = true;
            while (flag)
            {
                Console.WriteLine("***-------------Please Select the Notification System-----------------***");
                Console.WriteLine("1.Email");
                Console.WriteLine("2.SMS");
                Console.WriteLine("3.Add");
                Console.WriteLine("4.Delete");
                Console.WriteLine("5.Stop");
                Console.WriteLine("------------------------------------------------");
                string channelArg = Console.ReadLine().Trim().ToLower();

                if (channelArg == "1" || channelArg == "email" || channelArg == "2" || channelArg == "sms")
                {

                    Console.WriteLine("***-------------Please Provide Subject---------------------***");
                    Console.WriteLine("---------------------------------------------------------------------------------------->");
                    string subject = Console.ReadLine();
                    Console.WriteLine("***-------------Please Provide Body---------------------***");
                    string message = Console.ReadLine();

                    Console.WriteLine("---------------------------------------------------------------------------------------->");
                    var strategy = GetNotificationStrategy(channelArg);
                    notificationSystem.SendNotification(channelArg, subject, message);

                    Console.WriteLine("Notification sent successfully!");
                }
                else if (channelArg == "3" || channelArg == "add")
                {
                    Console.WriteLine("--------------Adding User----------------");
                    Console.WriteLine("Please select option for Adding User by ");
                    Console.WriteLine("1. Email");
                    Console.WriteLine("2. SMS");
                    string e=Console.ReadLine().Trim().ToLower();
                    if(e=="1" || e=="email")
                    {
                        Console.WriteLine("Please Provide Email id of the User : for Addition ");
                        string d = Console.ReadLine();
                        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

                        if (Regex.IsMatch(d, regex, RegexOptions.IgnoreCase))
                            new UserRepositoryAdapter().SetSubscribedUsers(d);
                        else
                        {
                            Console.WriteLine("please provide valid Email ID");
                        }
                    }
                    else if(e=="2" || e=="sms")
                    {
                        Console.WriteLine("Please Provide Phone No. of the User : for Addition  ");
                        string d = Console.ReadLine();
                        string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
                        if(Regex.IsMatch(d, motif, RegexOptions.IgnoreCase))
                            new UserRepositoryAdapter().SetSubscribedUsers(d);
                        else
                        {
                            Console.WriteLine("Please provide Valid Phone No.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("*** No other Way to Add user please select from Above ***");
                    }
                    
                }
                else if (channelArg == "4" || channelArg == "delete")
                {
                    Console.WriteLine("--------------Deleting User----------------");
                    Console.WriteLine("Please select option for Deletion of User by ");
                    Console.WriteLine("1. Email");
                    Console.WriteLine("2. SMS");
                    string e = Console.ReadLine().Trim().ToLower();
                    if (e == "1" || e == "email")
                    {
                        Console.WriteLine("Please Provide Email id of the User : for Deletion ");
                        string d = Console.ReadLine();
                        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

                        if (Regex.IsMatch(d, regex, RegexOptions.IgnoreCase))
                            new UserRepositoryAdapter().UnSubscribedUsers(d);
                        else
                        {
                            Console.WriteLine("please provide valid Email ID");
                        }
                    }
                    else if (e == "2" || e == "sms")
                    {
                        Console.WriteLine("Please Provide Phone No. of the User : for Deletion ");
                        string d = Console.ReadLine();
                        
                        string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
                        if (Regex.IsMatch(d, motif, RegexOptions.IgnoreCase))
                            new UserRepositoryAdapter().UnSubscribedUsers(d);
                        else
                            Console.WriteLine("Please Provide Valid Phone No.");
                    }
                    else
                    {
                        Console.WriteLine("*** No other Way to Add user please select from Above ***");
                    }
                }
                else if (channelArg == "5" || channelArg == "stop")
                {
                    flag = false;
                }

                else
                {
                    Console.WriteLine("Invalid notification channel.");
                }

                // Parse the channel argument from SMS and Email
            }
                
        }

        private static INotificationChannelStrategy GetNotificationStrategy(string channel)
        {
            if (channel=="1" || channel=="email" )
            {
                return new EmailNotificationStrategy();
            }
            else if(channel == "2" || channel == "sms")
            {
                return new SMSNotificationStrategy();
            }
            Console.WriteLine($"Channel {channel} not supported.");
            return null;

        }
    }

}
