using decoderslash_erp.Data;
using decoderslash_erp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace decoderslash_erp.Controllers
{
    public class ProjectManagerController : Controller
    {
        private readonly decoderslash_erpContext _context;
        private readonly IAdminRepo _repo;
        public ProjectManagerController(decoderslash_erpContext context, IAdminRepo repo)
        {
            _context = context;
            _repo = repo;
        }
    }
}
