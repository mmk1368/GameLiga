using System;
using System.Collections.Generic;

namespace GameLiga.Infrastructure.Data.Entities
{
    public partial class Account
    {
        public Account()
        {
            AccountPermission = new HashSet<AccountPermission>();
            AccountRole = new HashSet<AccountRole>();
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PromotionalCode { get; set; }
        public string Referred { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<AccountPermission> AccountPermission { get; set; }
        public virtual ICollection<AccountRole> AccountRole { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
