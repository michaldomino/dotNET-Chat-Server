﻿namespace dotNET_Chat_Server.ValueModels
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

            public static class Chats
            {
                public const string AddUsers = "AddUsers";
                public const string Create = "Create";
                public const string GetMembers = "GetMembers";
                public const string GetMessages = "GetMessages";
                public const string SendMessage = "SendMessage";
            }

            public static class Users
            {
                public const string Chats = "Chats";
                public const string Search = "Search";
            }
        }
    }
}
