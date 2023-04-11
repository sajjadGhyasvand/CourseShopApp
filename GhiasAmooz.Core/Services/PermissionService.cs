using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Context;
using GhiasAmooz.DataLayer.Entities.Permissions;
using GhiasAmooz.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GhiasAmooz.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private GhiasAmoozContext _context;
        public PermissionService(GhiasAmoozContext context)
        {
            _context = context;
        }

        public void AddPermissionsToRole(int roleId, List<int> permissions)
        {
            foreach (var p in permissions)
            {
                _context.RolePermission.Add(new RolePermission
                {
                    PermissionId = p,
                    RoleId = roleId
                });
            }
            _context.SaveChanges();
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public void EditRolesuser(int userId, List<int> rolesId)
        {
            //Delete All Roles User
            _context.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));
            //Add New Role
            AddRolesToUser(rolesId, userId);
        }

        public List<Permission> GetAllPermission()
        {
           return _context.Permission.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public List<int> PermissionsRole(int roleId)
        {
           return _context.RolePermission
                .Where(r=>r.RoleId == roleId)
                .Select(r=>r.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
            _context.RolePermission.Where(p=>p.RoleId == roleId)
                .ToList().ForEach(p=>_context.RolePermission.Remove(p));

            AddPermissionsToRole(roleId, permissions);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
    }
}
