﻿using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class AccountRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}
