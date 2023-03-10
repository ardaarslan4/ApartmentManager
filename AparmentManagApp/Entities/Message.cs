using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManager.Entities
{
    public class Message
    {
        [Key]
        public int ID { get; set; }
        public string ReceiverMail { get; set; }

        public string SenderMail { get; set; }
       
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
