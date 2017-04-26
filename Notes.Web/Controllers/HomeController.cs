using System;
using System.Web;
using System.Web.Mvc;
using Notes.Web.Models;
using Notes.Web.ViewModels;
using Notes.Web.Utils;

namespace Notes.Web.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Home
        public ActionResult Index()
        {
            var userUtilities = new UserUtilities(_context, HttpContext);

            var user = userUtilities.GetExistingUser();

            if (user == null)
            {
                Guid newCustomerGuid = Guid.NewGuid();
                user = CreateCustomer(newCustomerGuid);
                SetCookie(newCustomerGuid);
            }

            return View(user);
        }

        public ActionResult AddNote()
        {
            var noteViewModel = new NoteViewModel();

            return View(noteViewModel);
        }

        [HttpPost]
        public ActionResult AddNote(NoteViewModel note)
        {
            var userUtilities = new UserUtilities(_context, HttpContext);

            var user = userUtilities.GetExistingUser();

            var newNote = new Note();
            newNote.Text = note.Text;
            newNote.UserId = user.UserId;

            _context.Notes.Add(newNote);

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public void SetCookie(Guid userIdGuid)
        {
            HttpCookie aCookie = new HttpCookie(Constants.CoockieName); 
            aCookie.Value = userIdGuid.ToString();
            aCookie.Expires = DateTime.Now.AddDays(365 * 3);
            Response.Cookies.Add(aCookie);
        }

        public User CreateCustomer(Guid userIdGuid)
        {
            var user = new User();

            user.UserId = userIdGuid;
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                }                
            }

            base.Dispose(disposing);
        }
    }
}
