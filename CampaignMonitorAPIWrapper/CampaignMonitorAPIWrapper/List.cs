using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPIWrapper
{
    public class List
    {
        public static Result<string> Create(string apiKey, string clientID, string title, string unsubscribePage, bool confirmOptIn, string confirmationSuccessPage)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.CreateList(apiKey, clientID, title, unsubscribePage, confirmOptIn, confirmationSuccessPage);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<string> Update(string apiKey, string listID, string title, string unsubscribePage, bool confirmOptIn, string confirmationSuccessPage)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.UpdateList(apiKey, listID, title, unsubscribePage, confirmOptIn, confirmationSuccessPage);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<CampaignMonitorAPI.ListDetail> GetDetail(string apiKey, string listID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetListDetail(apiKey, listID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<CampaignMonitorAPI.ListDetail>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<CampaignMonitorAPI.ListDetail>(0, "Success", (CampaignMonitorAPI.ListDetail)(o));
        }

        public static Result<string> Delete(string apiKey, string listID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.DeleteList(apiKey, listID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<List<CampaignMonitorAPI.ListCustomField>> GetCustomFields(string apiKey, string listID)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.GetListCustomFields(apiKey, listID);

            if (o is CampaignMonitorAPI.Result)
                return new Result<List<CampaignMonitorAPI.ListCustomField>>((CampaignMonitorAPI.Result)o, null);
            else
                return new Result<List<CampaignMonitorAPI.ListCustomField>>(0, "Success", new List<CampaignMonitorAPI.ListCustomField>((IEnumerable<CampaignMonitorAPI.ListCustomField>)o));
        }

        public static Result<string> CreateCustomField(string apiKey, string listID, string fieldName, CampaignMonitorAPIWrapper.CampaignMonitorAPI.SubscriberFieldDataType dataType, string options)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.CreateListCustomField(apiKey, listID, fieldName, dataType, options);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }

        public static Result<string> DeleteCustomField(string apiKey, string listID, string key)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            object o = _api.DeleteListCustomField(apiKey, listID, key);

            if (o is CampaignMonitorAPI.Result)
                return new Result<string>((CampaignMonitorAPI.Result)o, "");
            else
                return new Result<string>(0, "Success", Convert.ToString(o));
        }
    }
}
