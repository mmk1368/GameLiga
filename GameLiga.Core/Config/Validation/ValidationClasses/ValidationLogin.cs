using FluentValidation;
using GameLiga.Core.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLiga.Core.Config.Validation.ValidationClasses
{
    public class ValidationLogin : AbstractValidator<LoginDTO>
    {
        public ValidationLogin()
        {
            RuleFor(c => c.Username).NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
        }
    }
}
