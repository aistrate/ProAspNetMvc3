using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FormsAuth.Infrastructure
{
    public class CustomRoleProvider : RoleProvider
    {
        private static Dictionary<string, string[]> rolesPerUser = new Dictionary<string, string[]>
        {
            { "tutu", new[] { "ApprovedUser", "CommentsModerator" } },
            { "adrian", new[] { "SiteAdministrator" } },
        };

        public override string[] GetRolesForUser(string username)
        {
            if (rolesPerUser.ContainsKey(username))
                return rolesPerUser[username];
            else
                throw new ApplicationException("User not found");
        }

        // Everything else is 'not implemented'
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
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

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}