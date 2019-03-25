using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message
    {
        public int? IDUser { get; set; }

        public int? IDFriend { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid message length")]
        public string MessageValue { get; set; }

        public DateTime MessageDate { get; set; }
    }
}
