using GhiasAmooz.Core.DTOs;
using GhiasAmooz.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GhiasAmooz.Web.Pages.Admin.Users
{
    public class indexModel : PageModel
    {
        private IUserService _userService;

        public indexModel(IUserService userService)
        {
            _userService = userService;
        }

        public UsersForAdminViewModel  usersForAdminViewModel { get; set; }

        public void OnGet( int pageId = 1, string filteruserName = "",string filterEmail = "")
        {
            usersForAdminViewModel = _userService.GetUsers(pageId,filterEmail, filteruserName);
        }
        
    }
}
