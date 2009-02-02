using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPISample
{
    public class Client
    {
        internal static void GetCampaigns()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Client.GetCampaigns(apiKey, clientID);

            if (result.Code != 0)
                Console.WriteLine("Error getting client campaigns : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no campaigns for this client");
            else
                foreach (var campaign in result.ReturnObject)
                {
                    Console.WriteLine("CampaignID : " + campaign.CampaignID);
                    Console.WriteLine("Subject : " + campaign.Subject);
                    Console.WriteLine("Sent Date : " + campaign.SentDate);
                    Console.WriteLine("Total Recipients : " + campaign.TotalRecipients);

                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetLists()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Client.GetLists(apiKey, clientID);

            if (result.Code != 0)
                Console.WriteLine("Error getting client lists : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no lists for this client");
            else
                foreach (var list in result.ReturnObject)
                {
                    Console.WriteLine("ListID : " + list.ListID);
                    Console.WriteLine("List Name : " + list.Name);
                    
                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetSegments()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Client.GetSegments(apiKey, clientID);

            if (result.Code != 0)
                Console.WriteLine("Error getting client segments : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no segments for this client");
            else
                foreach (var segment in result.ReturnObject)
                {
                    Console.WriteLine("Segment Name : " + segment.SegmentName);
                    Console.WriteLine("Segment ListID : " + segment.ListID);
                    

                    Console.WriteLine("---------------------------------------");
                }
        }
    }
}
