using System;
using System.Collections.Generic;
using System.Text;

using CampaignMonitorAPIWrapper;

namespace CampaignMonitorAPISample
{
    class Program
    {
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
