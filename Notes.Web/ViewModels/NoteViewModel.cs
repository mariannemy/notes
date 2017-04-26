using System.Web.Mvc;

namespace Notes.Web.ViewModels
{
    public class NoteViewModel
    {
        public int NoteId { get; set; }

        [AllowHtml]
        public string Text { get; set; }
    }
}