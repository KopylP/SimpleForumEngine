using SimpleForumEngine.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SimpleForumEngine.web.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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

        public override string[] GetRolesForUser(string username)
        {
            using (ForumContext db = new ForumContext())
            {
                User user = db.Users.FirstOrDefault(n => n.Email == username);
                if(user != null)
                {
                    var role = db.Roles.Find(user.RoleId);
                    if (role != null)
                        return new string[] { role.Name };
                }
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool isInRole = false;
            using (ForumContext db = new ForumContext())
            {
                User user = db.Users.FirstOrDefault(n => n.Email == username);
                if (user != null)
                {
                    var role = db.Roles.Find(user.RoleId);
                    if (role != null && role.Name == roleName)
                        isInRole = true;
                }
            }
            return isInRole;
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