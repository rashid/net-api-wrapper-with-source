using System;
using System.Collections.Generic;
using System.Text;
using CampaignMonitorAPIWrapper;

namespace CampaignMonitorAPISample
{
    public class Subscriber
    {
        internal static void Add()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string listID = "xxxxxxxxxxxxListIDxxxxxxxxxxxxxx";
            string emailAddress = "sample@notarealdomain.com";
            string name = "Sample Subscriber";

            var result = CampaignMonitorAPIWrapper.Subscriber.Add(apiKey, listID, emailAddress, name);

            if (result.Code != 0)
                Console.WriteLine("Error on adding subscriber : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("Subscriber added successfully");
        }

        internal static void AddWithCustomFields()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string listID = "xxxxxxxxxxxxListIDxxxxxxxxxxxxxx";
            string emailAddress = "sample@notarealdomain.com";
            string name = "Sample Subscriber";

            List<CustomField> customFields = new List<CustomField>();

            //adding a text custom field
            customFields.Add(new CustomField("Dog", "Fido"));

            //adding a multi-option, multi select
            customFields.Add(new CustomField("Interests", "Basketball"));
            customFields.Add(new CustomField("Interests", "Xbox"));

            var result = CampaignMonitorAPIWrapper.Subscriber.AddWithCustomFields(apiKey, listID, emailAddress, name, customFields);

            if (result.Code != 0)
                Console.WriteLine("Error on adding subscriber : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("Subscriber added successfully");
        }

        internal static void Unsubscribe()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string listID = "xxxxxxxxxxxxListIDxxxxxxxxxxxxxx";
            string emailAddress = "sample@notarealdomain.com";

            var result = CampaignMonitorAPIWrapper.Subscriber.Unsubscribe(apiKey, listID, emailAddress);

            if (result.Code != 0)
                Console.WriteLine("Error on unsubscription : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("Subscriber unsubscribed successfully");
        }
    }
}
