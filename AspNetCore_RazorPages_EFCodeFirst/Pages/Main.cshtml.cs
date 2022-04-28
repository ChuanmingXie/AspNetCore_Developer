using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspNetCore_RazorPages_EFCodeFirst.Pages
{
    public class MainModel : PageModel
    {
        private readonly ILogger<MainModel> logger;

        public MainModel(ILogger<MainModel> logger)
        {
            this.logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
