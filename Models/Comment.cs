using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Management.Models
{
    public class Comment
    {
        
        public int Id {get; set;}
        public int? BlogPostId {get; set;}
        
        public string Content {get; set;} = string.Empty;

        public DateTime CreatedOn {get; set;} = DateTime.Now;

        public BlogPost? BlogPost {get; set;}

        public int? ParentCommentId {get; set;}
        
        public Comment? ParentComment {get; set;}

        public ICollection<Comment> Replies {get; set;} = new List<Comment>();
    }
}