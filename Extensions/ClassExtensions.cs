using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace dotNET_Chat_Server.Extensions
{
    public static class ClassExtensions
    {
        public static Guid GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return Guid.Empty;
            }
            if (!Guid.TryParse(httpContext.User.Claims.Single(it => it.Type == "id").Value, out Guid userId))
            {
                return Guid.Empty;
            }
            return userId;
        }
    }
}
