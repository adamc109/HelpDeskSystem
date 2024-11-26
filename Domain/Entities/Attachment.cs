using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attachment
    {

        public int AttachmentId { get; set; }
        public int Filename { get; set; }
        public string ServerFileName { get; set; }
        public int FileSize { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(Ticket))]

        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }

        [ForeignKey(nameof(Disscusion))]
        public int? DiscussionId { get; set; }
        public Disscusion Disscusion { get; set; }
    }
}
