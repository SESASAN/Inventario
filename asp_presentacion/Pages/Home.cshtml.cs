using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ILogger<HomeModel> _logger;

        public HomeModel(ILogger<HomeModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
