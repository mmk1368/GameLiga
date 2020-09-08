using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            AccountPermission = new HashSet<AccountPermission>();
            RolePermission = new HashSet<RolePermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccountPermission> AccountPermission { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
