using GhiasAmooz.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        #region Roles
        List<Role> GetRoles();
        int AddRole(Role role);
        Role GetRoleById(int roleId);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        void AddRolesToUser(List<int> roleIds, int userId);
        void EditRolesuser(int userId, List<int> rolesId );
        #endregion

    }
}
