using ZooApp.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ZooApp.Api.Services
{
    
        public class CurrentUserService1 : ICurrentUserService
        {
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CurrentUserService1(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }

            public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
}
