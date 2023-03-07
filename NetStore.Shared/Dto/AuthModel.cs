﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NetStore.Shared.Dto
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
       [JsonIgnore] public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}