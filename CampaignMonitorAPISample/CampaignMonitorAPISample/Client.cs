using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPISample
{
    public class Client
    {
        internal static void Create()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Client.Create(apiKey, "New Client", "My Name", "email@address.com", "Australia", "(GMT+10:00) Canberra, Melbourne, Sydney");

            if (result.Code != 0)
                Console.WriteLine("Error creating new client : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("The new client was successfully created. It's ID is " + result.ReturnObject);
        }

        internal static void UpdateBasics()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Client.UpdateBasics(apiKey, clientID, "New Client", "My Name", "email@address.com", "Australia", "(GMT+10:00) Canberra, Melbourne, Sydney");

            if (result.Code != 0)
                Console.WriteLine("Error updating existing client : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("The client was successfully updated.");
        }

        internal static void UpdateAccessAndBilling()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Client.UpdateAccessAndBilling(apiKey, clientID, 15, "clientusername", "pword", "UserPaysOnClientsBehalf", "", "", "", "");

            if (result.Code != 0)
                Console.WriteLine("Error updating existing client : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("The client was successfully updated.");
        }

		internal static void GetDetail()
		{
			string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
			string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";

			var result = CampaignMonitorAPIWrapper.Client.GetDetail(apiKey, clientID);

			if (result.Code != 0)
				Console.WriteLine("Error getting client detail : " + result.Code.ToString() + " - " + result.Message);
			else
			{
				Console.WriteLine("ClientID : " + result.ReturnObject.BasicDetails.ClientID);
				Console.WriteLine("Company Name : " + result.ReturnObject.BasicDetails.CompanyName);
				Console.WriteLine("Contact Name : " + result.ReturnObject.BasicDetails.ContactName);
				Console.WriteLine("Country : " + result.ReturnObject.BasicDetails.Country);
				Console.WriteLine("Email Address : " + result.ReturnObject.BasicDetails.EmailAddress);
				Console.WriteLine("Timezone : " + result.ReturnObject.BasicDetails.Timezone);

				Console.WriteLine("Access Level : " + result.ReturnObject.AccessAndBilling.AccessLevel);

				// other results only relevant if the client has access
				if (result.ReturnObject.AccessAndBilling.AccessLevel != 0)
				{
					Console.WriteLine("Username : " + result.ReturnObject.AccessAndBilling.Username);
					Console.WriteLine("Password : " + result.ReturnObject.AccessAndBilling.Password);

					// bitwise AND operation to see if the client has Create/Send access
					// billing details only relevant in that case
					if ((result.ReturnObject.AccessAndBilling.AccessLevel & 4) != 0)
					{
						Console.WriteLine("Billing Type : " + result.ReturnObject.AccessAndBilling.BillingType);
						
						// currency string only populated it the client is paying for themselves
						if (result.ReturnObject.AccessAndBilling.BillingType != "UserPaysOnClientsBehalf")
						{
							Console.WriteLine("Currency : " + result.ReturnObject.AccessAndBilling.Currency);
						}

						// Campaign and test rates only of interest if there is a markup involved
						if (result.ReturnObject.AccessAndBilling.BillingType == "ClientPaysWithMarkup")
						{
							Console.WriteLine("Delivery Fee : " + result.ReturnObject.AccessAndBilling.DeliveryFee);
							Console.WriteLine("Cost per recipient : " + result.ReturnObject.AccessAndBilling.DeliveryFee);
							Console.WriteLine("Design and spam test fee : " + result.ReturnObject.AccessAndBilling.DesignAndSpamTestFee);
						}
					}
				}
			}
		}

        internal static void Delete()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Client.Delete(apiKey, clientID);

            if (result.Code != 0)
                Console.WriteLine("Error deleting existing client : " + result.Code.ToString() + " - " + result.Message);
            else
                Console.WriteLine("The client was successfully deleted.");
        }

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

        internal static void GetSuppressionList()
        {
            string apiKey = "xxxxxxxxxxxxApiKeyxxxxxxxxxxxxxx";
            string clientID = "xxxxxxxxxxxClientIDxxxxxxxxxxxxx";

            var result = CampaignMonitorAPIWrapper.Client.GetSuppressionList(apiKey, clientID);

            if (result.Code != 0)
                Console.WriteLine("Error getting client suppression list : " + result.Code.ToString() + " - " + result.Message);
            else if (result.ReturnObject.Count == 0)
                Console.WriteLine("There are no email addresses in the suppression list for this client");
            else
                foreach (var subscriber in result.ReturnObject)
                {
                    Console.WriteLine("Subscriber Email Address : " + subscriber.EmailAddress);
                    Console.WriteLine("Subscriber Name : " + subscriber.Name);
                    Console.WriteLine("Subscriber State : " + subscriber.State);


                    Console.WriteLine("---------------------------------------");
                }
        }
    }
}
