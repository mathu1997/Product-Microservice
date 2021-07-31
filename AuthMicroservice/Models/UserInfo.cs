using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuthMicroservice.Models
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
