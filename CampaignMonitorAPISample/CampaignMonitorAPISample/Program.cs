using System;
using System.Collections.Generic;
using System.Text;

using CampaignMonitorAPIWrapper;

namespace CampaignMonitorAPISample
{
    class Program
    {
        string apiKey = "1679b865f887884e4c3917bf73e92c2f";
        string listID = "aabd28c266ba32e4d7d91b4a4c47deb1";
        string emailAddress = "jasonh+1@freshview.com";

        static void Main(string[] args)
        {
            #region Subscriber. operations
            //Subscriber.Add();
            //Subscriber.AddWithCustomFields();
            //Subscriber.Unsubscribe();
            #endregion

            #region Subscribers. operations
            //Subscribers.GetActive();
            //Subscribers.GetBounced();
            //Subscribers.GetUnsubscribed();
            //Subscribers.GetIsSubscribed();
            //Subscribers.GetSingleSubscriber();
            #endregion

            #region Campaign. operations
            //Campaign.Create();
            Campaign.Send();
            //Campaign.GetSummary();
            //Campaign.GetLists();
            //Campaign.GetOpens();
            //Campaign.GetBounces();
            //Campaign.GetSubscriberClicks();
            //Campaign.GetUnsubscribes();
            #endregion

            #region Client. operations
            //Client.GetCampaigns();
            //Client.GetLists();
            //Client.GetSegments();
            #endregion

            #region User. operations
            //User.GetClients();
            //User.GetSystemDate();
            #endregion
        }

        
    }
}
