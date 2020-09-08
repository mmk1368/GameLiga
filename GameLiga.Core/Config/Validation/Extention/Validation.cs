using FluentValidation;
using FluentValidation.AspNetCore;
using GameLiga.Core.Config.Validation.ValidationClasses;
using GameLiga.Core.DTOModels;
using Microsoft.Extensions.DependencyInjection;

namespace GameLiga.Core.Config.Validation.Extention
{
    public static class Validation
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddMvcCore()
                .AddFluentValidation(fv =>
             {
                 fv.ImplicitlyValidateChildProperties = true;
             });

            services.AddTransient<IValidator<CreateAccountDto>, ValidationAccount>();
            services.AddTransient<IValidator<LoginDTO>, ValidationLogin>();

            return services;
        }
    }
}
