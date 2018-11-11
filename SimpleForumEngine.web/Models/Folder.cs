using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models
{
    public class Folder : Content
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public bool CanCreateTopic { get; set; }
        public int? ParentId { get; set; }
        public Folder Parent { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Folder> Children { get; set; }
        public Folder()
        {
            Topics = new List<Topic>();
            Children = new List<Folder>();
        }
    }
}