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
        }
        public IActionResult OnPost()
        {
            _permissionService.UpdateRole(Role);
            //TODO Add permission
            return RedirectToPage("Index");
        }
    }
}
