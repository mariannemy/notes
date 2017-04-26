using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.Web.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public List<Note> Notes { get; set; }
    }
}