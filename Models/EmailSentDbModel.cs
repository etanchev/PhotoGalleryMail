using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryMail.Models
{
    public class EmailSentDbModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // <summary>
        // The Domain Keys Identified Email code for the email
        // </summary>
        /// 

        public DateTime DateTime { get; set; }

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

       
    }
}
