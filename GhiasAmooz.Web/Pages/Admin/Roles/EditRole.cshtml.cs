using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GhiasAmooz.Web.Pages.Admin.Roles
{

    public class EditRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public EditRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permissionService.GetRoleById(id);
            ViewData["Permissions"] = _permissionService.GetAllPermission();
            ViewData["SelectedPermissions"] = _permissionService.PermissionsRole(id);
        }
        public IActionResult OnPost(List<int> selectedPermission)
        {
            _permissionService.UpdateRole(Role);
            
            _permissionService.UpdatePermissionsRole(Role.RoleId, selectedPermission);

            return RedirectToPage("Index");
        }
    }
}
