using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        [StringLength(10,MinimumLength = 4,ErrorMessage = "Username must be of 5 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Username must be of 5 characters")]
        public string Password { get; set; }
    }
}
