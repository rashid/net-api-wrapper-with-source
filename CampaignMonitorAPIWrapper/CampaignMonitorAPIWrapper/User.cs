using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPIWrapper
{
    public class User
    {
        public static Result<List<CampaignMonitorAPI.Client>> GetClients(string apiKey)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetClients(apiKey);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.Client>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.Client>>(0, "Success", new List<CampaignMonitorAPI.Client>((IEnumerable<CampaignMonitorAPI.Client>)o));
        }

        public static Result<DateTime> GetSystemDate(string apiKey)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetSystemDate(apiKey);

            if (o is CampaignMonitorAPI.Result)
                return new Result<DateTime>((CampaignMonitorAPI.Result)o, DateTime.MinValue);
            else
                return new Result<DateTime>(0, "Success", Convert.ToDateTime(o));
        }
    }
}
