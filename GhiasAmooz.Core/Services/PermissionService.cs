using GhiasAmooz.Core.Services.Interfaces;
using GhiasAmooz.DataLayer.Context;
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

        public void EditRolesuser(int userId, List<int> rolesId)
        {
            //Delete All Roles User
            _context.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));
            //Add New Role
            AddRolesToUser(rolesId, userId);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
