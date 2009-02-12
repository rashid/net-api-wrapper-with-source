using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPIWrapper
{
    public class Client
    {
        public static Result<string> Create(string apiKey, string companyName, string contactName, string emailAddress, string country, string timezone)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.CreateClient(apiKey, companyName, contactName, emailAddress, country, timezone);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<string> UpdateBasics(string apiKey, string clientID, string companyName, string contactName, string emailAddress, string country, string timezone)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.UpdateClientBasics(apiKey, clientID, companyName, contactName, emailAddress, country, timezone);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<string> UpdateAccessAndBilling(string apiKey, string clientID, int accessLevel, string username, string password, string billingType, string currency, string deliveryFee, string costPerRecipient, string designAndSpamTestFee)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.UpdateClientAccessAndBilling(apiKey, clientID, accessLevel, username, password, billingType, currency, deliveryFee, costPerRecipient, designAndSpamTestFee);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

		public static Result<CampaignMonitorAPI.ClientDetail> GetDetail(string apiKey, string clientID)
		{
			CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

			object o = _api.GetClientDetail(apiKey, clientID);

			if (o is CampaignMonitorAPI.Result)
				return new Result<CampaignMonitorAPI.ClientDetail>((CampaignMonitorAPI.Result)o, null);
			else
				return new Result<CampaignMonitorAPI.ClientDetail>(0, "Success", (CampaignMonitorAPI.ClientDetail)o);
		}

        public static Result<string> Delete(string apiKey, string clientID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.DeleteClient(apiKey, clientID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<List<CampaignMonitorAPI.Campaign>> GetCampaigns(string apiKey, string clientID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetClientCampaigns(apiKey, clientID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.Campaign>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.Campaign>>(0, "Success", new List<CampaignMonitorAPI.Campaign>((IEnumerable<CampaignMonitorAPI.Campaign>)o));
        }

        public static Result<List<CampaignMonitorAPI.List>> GetLists(string apiKey, string clientID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetClientLists(apiKey, clientID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.List>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.List>>(0, "Success", new List<CampaignMonitorAPI.List>((IEnumerable<CampaignMonitorAPI.List>)o));
        }

        public static Result<List<ListSegment>> GetSegments(string apiKey, string clientID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetClientSegments(apiKey, clientID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<ListSegment>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<ListSegment>>(0, "Success", new List<CampaignMonitorAPI.List>((IEnumerable<CampaignMonitorAPI.List>)o).ConvertAll<ListSegment>(
                    delegate(CampaignMonitorAPI.List apiSegment)
                    {
                        return new ListSegment(apiSegment.ListID, apiSegment.Name);
                    }));
        }

        public static Result<List<CampaignMonitorAPI.Subscriber>> GetSuppressionList(string apiKey, string clientID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetClientSuppressionList(apiKey, clientID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.Subscriber>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.Subscriber>>(0, "Success", new List<CampaignMonitorAPI.Subscriber>((IEnumerable<CampaignMonitorAPI.Subscriber>)o));
        }
    }
}
