using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TestRazorPages.Services;

namespace TestRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TestService _testService;

        public string Data
        {
            get
            {
                return _testService.GetValue();
            }
        }

        public IndexModel(ILogger<IndexModel> logger, TestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public void OnGet()
        {

        }
    }
}
