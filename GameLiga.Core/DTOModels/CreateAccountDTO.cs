using System;
using System.Collections.Generic;
using System.Text;

namespace GameLiga.Core.DTOModels
{
    public class CreateAccountDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PromotionalCode { get; set; }
        public string Referred { get; set; }
    }
}
