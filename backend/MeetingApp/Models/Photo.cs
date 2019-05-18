using System;

namespace MeetingApp.Models
{
    public class Photo
    {
        public int id { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }

    }
}