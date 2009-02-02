using System;
using System.Collections.Generic;
using System.Text;

using CampaignMonitorAPIWrapper;

namespace CampaignMonitorAPISample
{
    public class Subscribers
    {
        internal static void GetActive()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string listID = "xxxxxxxxxxxxListIDxxxxxxxxxxxxxx";
            DateTime addedAfter = new DateTime(2009, 1, 1);

            var result = CampaignMonitorAPIWrapper.Subscribers.GetActive(apiKey, listID, addedAfter);

            if (result.Code != 0)
                Console.WriteLine("Error on getting active subscribers : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("No active subscribers in this list");
            else
                foreach (var subscriber in result.ReturnObject)
                {
                    Console.WriteLine("Email : " + subscriber.EmailAddress);
                    Console.WriteLine("Name : " + subscriber.Name);
                    Console.WriteLine("Date Added : " + subscriber.Date);
                    Console.WriteLine("Custom Fields");

                    foreach (var customField in subscriber.CustomFields)
                    {
                        Console.WriteLine(customField.Key + " : " + customField.Value);
                    }

                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetBounced()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string listID = "xxxxxxxxxxxxListIDxxxxxxxxxxxxxx";
            DateTime bouncedAfter = new DateTime(2009, 1, 1);

            var result = CampaignMonitorAPIWrapper.Subscribers.GetBounced(apiKey, listID, bouncedAfter);

            if (result.Code != 0)
                Console.WriteLine("Error on getting bounced subscribers : " + result.Code.ToString() + " - " + result.Message);
            else if(result.ReturnObject.Count == 0)
                Console.WriteLine("No bounced subscribers in this list");
            else
                foreach (var subscriber in result.ReturnObject)
                {
                    Console.WriteLine("Email : " + subscriber.EmailAddress);
                    Console.WriteLine("Name : " + subscriber.Name);
                    Console.WriteLine("Date Added : " + subscriber.Date);
                    Console.WriteLine("Custom Fields");

                    foreach (var customField in subscriber.CustomFields)
                    {
                        Console.WriteLine(customField.Key + " : " + customField.Value);
                    }

                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetUnsubscribed()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string listID = "xxxxxxxxxxxxListIDxxxxxxxxxxxxxx";
            DateTime unsubscribedAfter = new DateTime(2009, 1, 1);

            var result = CampaignMonitorAPIWrapper.Subscribers.GetUnsubscribed(apiKey, listID, unsubscribedAfter);

            if (result.Code != 0)
                Console.WriteLine("Error on getting unsubscribed subscribers : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("No unsubscribed subscribers in this list");
            else
                foreach (var subscriber in result.ReturnObject)
                {
                    Console.WriteLine("Email : " + subscriber.EmailAddress);
                    Console.WriteLine("Name : " + subscriber.Name);
                    Console.WriteLine("Date Added : " + subscriber.Date);
                    Console.WriteLine("Custom Fields");

                    foreach (var customField in subscriber.CustomFields)
                    {
                        Console.WriteLine(customField.Key + " : " + customField.Value);
                    }

                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetIsSubscribed()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string listID = "xxxxxxxxxxxxListIDxxxxxxxxxxxxxx";
            string emailAddress = "sample@notarealdomain.com";

            var result = CampaignMonitorAPIWrapper.Subscribers.GetIsSubscribed(apiKey, listID, emailAddress);

            if (result.Code != 0)
                Console.WriteLine("Error on getting IsSusbcribed : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject == true)
                Console.WriteLine("Subscriber is subscribed");
            else
                Console.WriteLine("Subscriber is not subscribed");
        }

        internal static void GetSingleSubscriber()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string listID = "xxxxxxxxxxxxListIDxxxxxxxxxxxxxx";
            string emailAddress = "sample@notarealdomain.com";

            var result = CampaignMonitorAPIWrapper.Subscribers.GetSingleSubscriber(apiKey, listID, emailAddress);

            if (result.Code != 0)
                Console.WriteLine("Error on getting subscriber : " + result.Code.ToString() + " - " + result.Message);
            else
            {
                var subscriber = result.ReturnObject;

                Console.WriteLine("Email : " + subscriber.EmailAddress);
                Console.WriteLine("Name : " + subscriber.Name);
                Console.WriteLine("State : " + subscriber.State);
                Console.WriteLine("Date Added : " + subscriber.Date);
                Console.WriteLine("Custom Fields");

                foreach (var customField in subscriber.CustomFields)
                {
                    Console.WriteLine(customField.Key + " : " + customField.Value);
                }
            }
        }
    }
}
