using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPIWrapper
{
    public class Subscriber
    {
        public static Result<int> Add(string apiKey, string listID, string emailAddress, string name)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            return new Result<int>(_api.AddSubscriber(apiKey, listID, emailAddress, name), 0);
        }

        public static Result<int> AddAndResubscribe(string apiKey, string listID, string emailAddress, string name)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            return new Result<int>(_api.AddAndResubscribe(apiKey, listID, emailAddress, name), 0);
        }

        public static Result<int> AddAndResubscribeWithCustomFields(string apiKey, string listID, string emailAddress, string name, List<CustomField> customFields)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            CampaignMonitorAPI.SubscriberCustomField[] customFieldArray = customFields.ConvertAll(
                new Converter<CustomField, CampaignMonitorAPI.SubscriberCustomField>(WrapperCustomToApiCustom)).ToArray();

            return new Result<int>(_api.AddAndResubscribeWithCustomFields(apiKey, listID, emailAddress, name, customFieldArray), 0);
        }

        public static Result<int> AddWithCustomFields(string apiKey, string listID, string emailAddress, string name, List<CustomField> customFields)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            CampaignMonitorAPI.SubscriberCustomField[] customFieldArray = customFields.ConvertAll<CampaignMonitorAPI.SubscriberCustomField>(
                new Converter<CustomField, CampaignMonitorAPI.SubscriberCustomField>(WrapperCustomToApiCustom)).ToArray();         

            return new Result<int>(_api.AddSubscriberWithCustomFields(apiKey, listID, emailAddress, name, customFieldArray), 0);
        }

        public static Result<int> Unsubscribe(string apiKey, string listID, string emailAddress)
        {
            CampaignMonitorAPIWrapper.CampaignMonitorAPI.api _api = new CampaignMonitorAPI.api();

            return new Result<int>(_api.Unsubscribe(apiKey, listID, emailAddress), 0);
        }

        public static CampaignMonitorAPI.SubscriberCustomField WrapperCustomToApiCustom(CustomField field)
        {
            CampaignMonitorAPI.SubscriberCustomField apiField = new CampaignMonitorAPI.SubscriberCustomField();
            apiField.Key = field.Key;
            apiField.Value = field.Value;

            return apiField;
        }
    }
}
