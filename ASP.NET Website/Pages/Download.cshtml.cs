using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace ASP.NET_Website.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly ILogger<DownloadModel> _logger;

        public DownloadModel(ILogger<DownloadModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}