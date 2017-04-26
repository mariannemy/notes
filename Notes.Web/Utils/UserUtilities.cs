using Notes.Web.Models;
using System;
using System.Linq;
using System.Web;


namespace Notes.Web.Utils
{
    public class UserUtilities
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpContextBase _httpContext;

        public UserUtilities(ApplicationDbContext dbContext, HttpContextBase httpContext)
        {
            _context = dbContext;
            _httpContext = httpContext;
        }

        public User CheckCookieAndGetUserFromDatabase(string cookieValue)
        {
            Guid cookieValueGuid;

            if (!Guid.TryParse(cookieValue, out cookieValueGuid))
            {
                return null;
            }

            return _context.Users.SingleOrDefault(m => m.UserId == cookieValueGuid);
        }

        public User GetExistingUser()
        {  
            var cookieRequest = _httpContext.Request.Cookies[Constants.CoockieName];

            if (cookieRequest != null)
            {
                if (CheckCookieAndGetUserFromDatabase(cookieRequest.Value) != null)
                {
                    return CheckCookieAndGetUserFromDatabase(cookieRequest.Value);
                }
            }

            var cookieResponse = _httpContext.Request.Cookies.Get(Constants.CoockieName);

            if (cookieResponse != null)
            {
                if (CheckCookieAndGetUserFromDatabase(cookieResponse.Value) != null)
                {
                    return CheckCookieAndGetUserFromDatabase(cookieResponse.Value);
                }
            }
            return null;
        }
    }
}
