using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPIWrapper
{
    public class Campaign
    {
        public static Result<string> Create(string apiKey, string clientID, string campaignName, string campaignSubject, string fromName, string fromEmailAddress, string replyToEmailAddress, string htmlContentURL, string textContentURL, List<string> listIDs, List<ListSegment> listSegments)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.CreateCampaign(apiKey, clientID, campaignName, campaignSubject, fromName, fromEmailAddress, replyToEmailAddress, htmlContentURL, textContentURL, listIDs.ToArray(), listSegments.ConvertAll<CampaignMonitorAPI.List>(
                delegate(ListSegment segment)
            {
                CampaignMonitorAPI.List apiSegment = new CampaignMonitorAPI.List();
                apiSegment.ListID = segment.ListID;
                apiSegment.Name = segment.SegmentName;

                return apiSegment;
            }).ToArray());

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<string> Send(string apiKey, string campaignID, string confirmationEmailAddress, DateTime sendDate)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.SendCampaign(apiKey, campaignID, confirmationEmailAddress, sendDate.ToString("yyyy-MM-dd HH:mm:ss"));

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<List<CampaignMonitorAPI.SubscriberBounce>> GetBounces(string apiKey, string campaignID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetCampaignBounces(apiKey, campaignID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.SubscriberBounce>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.SubscriberBounce>>(0, "Success", new List<CampaignMonitorAPI.SubscriberBounce>((IEnumerable<CampaignMonitorAPI.SubscriberBounce>)o));
        }

        public static Result<List<CampaignMonitorAPI.SubscriberOpen>> GetOpens(string apiKey, string campaignID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetCampaignOpens(apiKey, campaignID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.SubscriberOpen>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.SubscriberOpen>>(0, "Success", new List<CampaignMonitorAPI.SubscriberOpen>((IEnumerable<CampaignMonitorAPI.SubscriberOpen>)o));
        }

        public static Result<List<CampaignMonitorAPI.SubscriberClick>> GetSubscriberClicks(string apiKey, string campaignID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetSubscriberClicks(apiKey, campaignID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.SubscriberClick>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.SubscriberClick>>(0, "Success", new List<CampaignMonitorAPI.SubscriberClick>((IEnumerable<CampaignMonitorAPI.SubscriberClick>)o));
        }

        public static Result<List<CampaignMonitorAPI.SubscriberUnsubscribe>> GetUnsubscribes(string apiKey, string campaignID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetCampaignUnsubscribes(apiKey, campaignID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.SubscriberUnsubscribe>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.SubscriberUnsubscribe>>(0, "Success", new List<CampaignMonitorAPI.SubscriberUnsubscribe>((IEnumerable<CampaignMonitorAPI.SubscriberUnsubscribe>)o));
        }

        public static Result<CampaignMonitorAPI.CampaignSummary> GetSummary(string apiKey, string campaignID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetCampaignSummary(apiKey, campaignID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<CampaignMonitorAPI.CampaignSummary>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<CampaignMonitorAPI.CampaignSummary>(0, "Success", (CampaignMonitorAPI.CampaignSummary)o);
        }

        public static Result<List<CampaignMonitorAPI.List>> GetLists(string apiKey, string campaignID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetCampaignLists(apiKey, campaignID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.List>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.List>>(0, "Success", new List<CampaignMonitorAPI.List>((IEnumerable<CampaignMonitorAPI.List>)o));
        }
    }
}
