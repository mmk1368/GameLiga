using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class AccountPermission
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int PermissionId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
