using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Profile;

namespace FormsAuth.Infrastructure
{
    public class CustomProfileProvider : ProfileProvider
    {
        private Dictionary<string, Dictionary<string, object>> repository = new Dictionary<string, Dictionary<string, object>>();

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            string userName = (string)context["UserName"];

            var propertyValues = collection.Cast<SettingsProperty>()
                                           .Select(p => new SettingsPropertyValue(p))
                                           .ToArray();

            if (repository.ContainsKey(userName))
            {
                var userProperties = repository[userName];

                foreach (var pv in propertyValues)
                    pv.PropertyValue = userProperties[pv.Name];
            }

            var result = new SettingsPropertyValueCollection();
            foreach (var pv in propertyValues)
                result.Add(pv);

            return result;
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            string userName = (string)context["UserName"];

            if (!string.IsNullOrEmpty(userName))
                repository[userName] = collection.Cast<SettingsPropertyValue>()
                                                 .ToDictionary(pv => pv.Name, pv => pv.PropertyValue);
        }

        // Everything else is 'not implemented'
        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}