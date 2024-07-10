using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Blog_Management.Models
{
    public class BlogPost
    {   
        public int Id {get; set;}

        [Required]
        public string Title {get; set;} = string.Empty;
 
        [Required]
        public string Content {get; set;} = string.Empty;

        public string Category {get; set;} = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

       public List<Comment> Comments {get; set;} = new List<Comment>();
    }
}