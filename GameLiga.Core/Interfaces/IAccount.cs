using GameLiga.Core.DTOModels;

namespace GameLiga.Core.Interfaces
{
    public interface IAccount
    {
        BaseResult<string> CreateAccount(CreateAccountDto accountDto);
        string CreateAccountDiscord();
        BaseResult<string> Login(LoginDTO loginDTO);
    }
}