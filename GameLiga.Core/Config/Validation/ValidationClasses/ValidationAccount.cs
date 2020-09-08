using FluentValidation;
using GameLiga.Core.DTOModels;

namespace GameLiga.Core.Config.Validation.ValidationClasses
{
    public class ValidationAccount : AbstractValidator<CreateAccountDto>
    {
        public ValidationAccount()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.NickName).NotEmpty();
            RuleFor(c => c.Password).NotEmpty().MinimumLength(6);
            RuleFor(c => c.PhoneNumber).NotEmpty();
            RuleFor(c => c.Username).MinimumLength(6);

        }
    }
}
