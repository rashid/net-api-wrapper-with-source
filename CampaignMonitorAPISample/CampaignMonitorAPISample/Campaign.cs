using System;
using System.Collections.Generic;
using System.Text;

using CampaignMonitorAPIWrapper;

namespace CampaignMonitorAPISample
{
    public class Campaign
    {
        internal static void Create()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";            

            List<string> lists = new List<string>();
            lists.Add("xxxxxxxxxxxxListIDxxxxxxxxxxxxxx");
            lists.Add("xxxxxxxxxxxxListIDxxxxxxxxxxxxxx");

            List<ListSegment> listSegments = new List<ListSegment>();
            listSegments.Add(new ListSegment("xxxxxxxListIDOfSegmentxxxxxxx", "Segment Name"));
            listSegments.Add(new ListSegment("xxxxxxxListIDOfSegmentxxxxxxx", "Segment Name"));

            var result = CampaignMonitorAPIWrapper.Campaign.Create(apiKey, clientID, "Test Campaign Name", "Test Campaign Subject", "John Doe", "johndoe@notarealdomain.com", "johndoe@notarealdomain.com", "http://www.notarealdomain.com/campaigns/htmlversion.html", "http://www.notarealdomain.com/campaigns/textversion.html", lists, listSegments);

            if (result.Code != 0)
                Console.WriteLine("Error creating campaign : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("CampaignID : " + result.ReturnObject);
        }

        internal static void Send()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string campaignID = "xxxxxxxxxxCampaignIDxxxxxxxxxxxx";
            string confirmationEmailAddress = "sample@notarealdomain.com";
            DateTime sendDate = DateTime.Now;

            var result = CampaignMonitorAPIWrapper.Campaign.Send(apiKey, campaignID, confirmationEmailAddress, sendDate);

            if (result.Code != 0)
                Console.WriteLine("Error sending campaign : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("Sent CampaignID : " + result.ReturnObject);
        }

        internal static void GetLists()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string campaignID = "xxxxxxxxxxCampaignIDxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Campaign.GetLists(apiKey, campaignID);

            if (result.Code != 0)
                Console.WriteLine("Error getting campaign lists : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no lists set for this campaign");
            else
                foreach (var list in result.ReturnObject)
                {
                    Console.WriteLine("ListID : " + list.ListID);
                    Console.WriteLine("List Name : " + list.Name);

                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetSummary()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string campaignID = "xxxxxxxxxxCampaignIDxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Campaign.GetSummary(apiKey, campaignID);

            if (result.Code != 0)
                Console.WriteLine("Error getting campaign summary : " + result.Code.ToString() + " - " + result.Message);
            else
            {
                var campaign = result.ReturnObject;

                Console.WriteLine("Bounced : " + campaign.Bounced.ToString());
                Console.WriteLine("Clicks : " + campaign.Clicks.ToString());
                Console.WriteLine("Recipients : " + campaign.Recipients.ToString());
                Console.WriteLine("Total Opened : " + campaign.TotalOpened.ToString());
                Console.WriteLine("Unsubscribed : " + campaign.Unsubscribed.ToString());
            }
        }

        internal static void GetOpens()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string campaignID = "xxxxxxxxxxCampaignIDxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Campaign.GetOpens(apiKey, campaignID);

            if (result.Code != 0)
                Console.WriteLine("Error getting campaign opens : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no opens for this campaign");
            else
                foreach (var open in result.ReturnObject)
                {
                    Console.WriteLine("Email Address : " + open.EmailAddress);
                    Console.WriteLine("Number of Opens : " + open.NumberOfOpens);
                    Console.WriteLine("ListID : " + open.ListID);

                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetBounces()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string campaignID = "xxxxxxxxxxCampaignIDxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Campaign.GetBounces(apiKey, campaignID);

            if (result.Code != 0)
                Console.WriteLine("Error getting campaign bounces : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no bounces for this campaign");
            else
                foreach (var bounce in result.ReturnObject)
                {
                    Console.WriteLine("Email Address : " + bounce.EmailAddress);
                    Console.WriteLine("Bounce Type : " + bounce.BounceType);
                    Console.WriteLine("ListID : " + bounce.ListID);

                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetSubscriberClicks()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string campaignID = "xxxxxxxxxxCampaignIDxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Campaign.GetSubscriberClicks(apiKey, campaignID);

            if (result.Code != 0)
                Console.WriteLine("Error getting campaign clicks : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no link clicks for this campaign");
            else
                foreach (var subscriberClick in result.ReturnObject)
                {
                    Console.WriteLine("Email Address : " + subscriberClick.EmailAddress);
                    Console.WriteLine("ListID : " + subscriberClick.ListID);
                    Console.WriteLine("Links Clicked");
                    foreach (var link in subscriberClick.ClickedLinks)
                    {
                        Console.WriteLine(link.Clicks + " - " + link.Link);
                    }

                    Console.WriteLine("---------------------------------------");
                }
        }

        internal static void GetUnsubscribes()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string campaignID = "xxxxxxxxxxCampaignIDxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Campaign.GetUnsubscribes(apiKey, campaignID);

            if (result.Code != 0)
                Console.WriteLine("Error getting campaign unsubscriptions : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no unsubscriptions for this campaign");
            else
                foreach (var unsubscribe in result.ReturnObject)
                {
                    Console.WriteLine("Email Address : " + unsubscribe.EmailAddress);
                    Console.WriteLine("ListID : " + unsubscribe.ListID);

                    Console.WriteLine("---------------------------------------");
                }
        }
    }
}
