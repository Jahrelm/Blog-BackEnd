using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Management.Dtos
{
    public class CommentDto
    {
        public int Id {get; set;}
        public int? BlogPostId {get; set;}
        
        public string Content {get; set;} = string.Empty;

        public DateTime CreatedOn {get; set;} 

    }
}