using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public  Role Role { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public User()
        {
            Messages = new List<Message>();
            Topics = new List<Topic>();
        }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
   
}