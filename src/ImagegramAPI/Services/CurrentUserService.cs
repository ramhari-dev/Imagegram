using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagegramAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string AccountId
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey(""))
                {
                    return _httpContextAccessor.HttpContext.Request.Headers[""];
                }
                return string.Empty;
            }
        }
    }
}
