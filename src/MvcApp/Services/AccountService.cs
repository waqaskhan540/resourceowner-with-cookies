using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using MvcApp.Models;
using Newtonsoft.Json.Linq;

namespace MvcApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly string ClientID = string.Empty;
        private readonly string ClientSecret = string.Empty;
        private readonly string Scopes = string.Empty;
        private readonly string Authority = string.Empty;
        public AccountService()
        {
            ClientID = "client_id";
            ClientSecret = "client_secret";
            Scopes = "scopes";
            Authority = "authority";
        }
        public async Task<BaseModel> Login(string username, string password)
        {
            try
            {
               
                var tokenClient = new TokenClient(Authority + "/connect/token", ClientID, ClientSecret);

                var response = await tokenClient.RequestResourceOwnerPasswordAsync(username, password, Scopes);

                if (!response.IsError && response.Json != null)
                    return BaseModel.Success("", response.Json);

                if (response.IsError)
                {
                    var error = response.Json["error"].ToString();

                    JToken errorDescription;
                    var hasDescription = response.Json.TryGetValue("error_description", out errorDescription);

                    if (hasDescription)
                        return BaseModel.Error(errorDescription.ToString());

                    return BaseModel.Error(error);
                }

                return null;
            }
            catch (Exception)
            {

                return BaseModel.Error("Operation failed...");
            }
        }
    }
}
