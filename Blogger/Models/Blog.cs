using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
    public class Blog
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; }

        [Required, StringLength(50)]
        public string DateTime { get; set; }

        [Required, StringLength(50)]
        public string Author { get; set; }

        [Required, StringLength(50)]
        public string Tags { get; set; }

        [Required]
        public string Body { get; set; }
    }
}