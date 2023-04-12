using GhiasAmooz.Core.DTOs;
using GhiasAmooz.Core.Security;
using GhiasAmooz.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GhiasAmooz.Web.Pages.Admin.Users
{
    [PermissionChecker(5)]
    public class DeleteListModel : PageModel
    {
        private IUserService _userService;

        public DeleteListModel(IUserService userService)
        {
            _userService = userService;
        }
        public InformationUserViewModel InformationUserViewModel { get; set; }
        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            InformationUserViewModel = _userService.GetUserInformation(id);
        }
        public IActionResult OnPost(int UserId)
        {
            _userService.DeleteUser(UserId);
            return RedirectToPage("Index");
        }
    }
}
