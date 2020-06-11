using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class QueueOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QueueOrderNumber { get; set; }
        public int ServiceQueueNumber { get; set; }
        public string CustomerId { get; set; }
        public int CustomerNumber { get; set; }
        public string Status { get; set; }
    }
}