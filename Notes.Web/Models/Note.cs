using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.Web.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } 
    }
}