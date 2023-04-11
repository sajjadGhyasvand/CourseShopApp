using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GhiasAmooz.Web.Pages.Admin.Roles
{
    public class CreateRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet()
        {
            ViewData["Permissions"] = _permissionService.GetAllPermission();
        }
        public IActionResult OnPost(List<int> selectedPermission)
        {
            
            Role.IsDelete = false;

            int roleId = _permissionService.AddRole(Role);
            _permissionService.AddPermissionsToRole(roleId,selectedPermission);
            return RedirectToPage("Index");
        }
    }
}
