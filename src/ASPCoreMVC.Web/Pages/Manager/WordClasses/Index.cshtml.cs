using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPCoreMVC.Web.Pages.Manager.WordClasses
{
    [Authorize]
    public class WordClassIndexModel : AppPageModel
    {
        public void OnGet()
        {
        }
    }
}
