using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class Role
    {
        public Role()
        {
            AccountRole = new HashSet<AccountRole>();
            RolePermission = new HashSet<RolePermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccountRole> AccountRole { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
