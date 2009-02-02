using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPIWrapper
{
    public class Client
    {
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
    }
}
