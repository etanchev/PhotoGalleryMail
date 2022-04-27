using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryMail.Models
{
    public class MailSendModel
    {
        [Required]
        [EmailAddress]
        public string To { get; set; }
        
        public string  Subject { get; set; }

        public string  Body { get; set; }

        public string Attachments { get; set; }
    }
}
