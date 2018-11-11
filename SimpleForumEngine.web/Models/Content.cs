using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models
{
    public abstract class Content
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set;}
    }
}