using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models
{
    public class MessageAuthor
    {
        public String Content { get; set; }
        public String Author { get; set; }
        public int TopicId { get; set; }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
        public IEnumerable<HttpPostedFileBase> Photos { get; set; }
        public MessageAuthor()
        {
            Files = new List<HttpPostedFileBase>();
            Photos = new List<HttpPostedFileBase>();
        }
    }
}