﻿namespace MusicServiceMauiClient.DTOs.IdentityDTOs
{
    public class RegisterDTO
    {
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;

        public string? RoleName {  get; set; } = string.Empty;
    }
}
