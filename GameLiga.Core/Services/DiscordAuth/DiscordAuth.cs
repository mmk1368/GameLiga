using System;
using System.Collections.Generic;
using System.Text;

namespace GameLiga.Core.Services.DiscordAuth
{
    
    public class DiscordAuth
    {
        private string _clientId = "715120021558263828";
        private string _clientSecret = "3ixiJrhJoB-PpO4_mWQGMpSiWtgOIzVV";

        private string _discordUrl =
            "https://discord.com/api/oauth2/authorize?client_id=715120021558263828&redirect_uri=http%3A%2F%2Flocalhost%3A6916%2Fapi%2Faccount%2FCreateAccountdis&response_type=code&scope=identify%20email";
        public string login()
        {
            return "B";
        }
    }
}
