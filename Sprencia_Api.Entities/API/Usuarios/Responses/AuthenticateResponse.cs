﻿namespace Sprencia_Api.Entities.API.Usuarios.Responses
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
