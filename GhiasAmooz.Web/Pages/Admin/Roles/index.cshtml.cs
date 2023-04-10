using GhiasAmooz.Core.DTOs;
using GhiasAmooz.Core.Services;
using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GhiasAmooz.Web.Pages.Admin.Roles
{
    public class indexModel : PageModel
    {
        private IPermissionService _permissionService;

        public indexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public List<Role> RolesList { get; set; }

        public void OnGet()
        {
            RolesList = _permissionService.GetRoles();
        }
        
    }
}
