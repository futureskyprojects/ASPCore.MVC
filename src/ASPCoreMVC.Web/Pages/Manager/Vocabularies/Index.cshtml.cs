using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreMVC.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPCoreMVC.Web.Pages.Manager.Vocabularies
{
    [Authorize(ASPCoreMVCPermissions.VocabularyManager.Default)]
    public class VocabularyIndexModel : AppPageModel
    {
        public void OnGet()
        {
        }
    }
}
