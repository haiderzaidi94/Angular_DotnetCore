using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingApp.Models;

namespace MeetingApp.DTOs
{
    public class UserForDetailsDTO
    {
        public int id { get; set; }
        public string Name { get; set; }

        public string gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
