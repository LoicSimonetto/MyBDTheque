using Microsoft.AspNetCore.Mvc;
using MyBDTheque.Core.Data;

namespace MyBDTheque.BackOffice.Web.UI.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly DefaultContext _context = null;
        protected readonly IConfiguration _configuration = null;
        public ControllerBase(DefaultContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
    }
}
