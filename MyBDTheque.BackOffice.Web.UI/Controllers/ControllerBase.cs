using Microsoft.AspNetCore.Mvc;
using MyBDTheque.Core.Data;

namespace MyBDTheque.BackOffice.Web.UI.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly DefaultContext _context = null;
        public ControllerBase(DefaultContext context)
        {
            _context = context;
        }
    }
}
