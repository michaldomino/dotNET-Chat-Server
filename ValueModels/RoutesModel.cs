using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.ValueModels
{
    public static class RoutesModel
    {
        public static class Api
        {
            private const string API_ROUTE = "api";

            public static class Authentication
            {
                private const string AUTHENTICATION_ROUTE = API_ROUTE + "/authentication";

                public const string Register = AUTHENTICATION_ROUTE + "/register";
                public const string Login = AUTHENTICATION_ROUTE + "/login";
            }
        }
    }
}
