using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcApp.Models;

namespace MvcApp.Services
{
    public interface IAccountService
    {
        Task<BaseModel> Login(string username, string password);
    }
}
