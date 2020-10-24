﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNET_Chat_Server.ValueModels
{
    public static class RoutesModel
    {
        public static class Api
        {
            public static class Authentication
            {
                public const string Register = "Register";
                public const string Login = "Login";
            }

            public static class Users
            {
                public const string Chats = "Chats";
            }
        }
    }
}
