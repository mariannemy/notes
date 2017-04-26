using Notes.Web.Models;
using Notes.Web.Utils;
using Notes.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Notes.Web.Controllers.Api
{
    [RoutePrefix("api/note")]
    public class NoteController : ApiController
    {
        private ApplicationDbContext _context;

        public NoteController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Note
        //Get/api/note
        [HttpGet]
        [Route("")]
        public IEnumerable<NoteViewModel> Note()
        {
            var wrappedContext = new HttpContextWrapper(HttpContext.Current);
            var userutilities = new UserUtilities(_context, wrappedContext);

            var user = userutilities.GetExistingUser();

            var notes = _context.Notes.Where(c => c.UserId == user.UserId).ToList();

            List<NoteViewModel> noteViewModelList = new List<NoteViewModel>();
            foreach (Note noteElement in notes)
            {
                var noteViewModel = new NoteViewModel()
                {
                    NoteId = noteElement.NoteId,
                    Text = noteElement.Text
                };
                noteViewModelList.Add(noteViewModel);
            }

            return noteViewModelList;
        }

        //DELETE/api/note/5

        [Route("{noteId}")]
        [HttpDelete]
        public IHttpActionResult DeleteNote(int noteId)
        {
            var note = _context.Notes.SingleOrDefault(c => c.NoteId == noteId);

            if (note == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();

            return Ok();
        }

        [Route("{noteId}")]
        //PUT /api/note/5
        [HttpPut]
        public IHttpActionResult ChangeNote(int noteId, [FromBody] UpdateNoteViewModel updatedNote)
        {
            var note = _context.Notes.SingleOrDefault(c => c.NoteId == noteId);

            if (note == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            note.Text = updatedNote.Text;
            _context.SaveChanges();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}