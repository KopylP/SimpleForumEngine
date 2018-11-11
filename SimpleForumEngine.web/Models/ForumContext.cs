using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models
{
    public class ForumContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<CommonInformation> CommonInformations { get; set; }
        public DbSet<MessageFile> MessageFiles { get; set; }
    }
}