using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InredningOnline.Pages
{
    [Authorize(Roles = "user")]
    public class CompletedModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
