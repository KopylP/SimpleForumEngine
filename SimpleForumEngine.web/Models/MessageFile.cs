using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models
{
    public class MessageFile
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public bool IsPhoto { get; set; }
        public string OriginalName { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
    }
}