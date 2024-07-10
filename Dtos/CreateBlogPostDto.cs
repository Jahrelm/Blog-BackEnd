using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Management.Dtos
{
    public class CreateBlogPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
    }
}