using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Management.Dtos
{
    public class CreateCommentDto
    {
           public string Content {get; set;} = string.Empty;

           public int? ParentCommentId {get; set;}

           public DateTime CreatedOn {get; set;} = DateTime.Now;
    }
}