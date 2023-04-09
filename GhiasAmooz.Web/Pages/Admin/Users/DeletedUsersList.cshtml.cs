using GhiasAmooz.Core.DTOs;
using GhiasAmooz.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GhiasAmooz.Web.Pages.Admin.Users
{
    public class DeletedUsersListModel : PageModel
    {
        private IUserService _userService;

        public DeletedUsersListModel(IUserService userService)
        {
            _userService = userService;
        }

        public UsersForAdminViewModel usersForAdminViewModel { get; set; }

        public void OnGet(int pageId = 1, string filteruserName = "", string filterEmail = "")
        {
            usersForAdminViewModel = _userService.GetDelteUsers(pageId, filterEmail, filteruserName);
        }
    }
}
