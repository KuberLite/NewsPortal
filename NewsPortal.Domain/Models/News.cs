using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPortal.Domain.Models
{
    public class News
    {
        [Key]
        [Column(Order=1)]
        public string Title { get; set; }

        public string Link { get; set; }

        public string Guid { get; set; }

        public string Description { get; set; }

        [Key]
        [Column(Order=2)]
        public DateTime PubDate { get; set; }

        public string Creator { get; set; }
    }
}
