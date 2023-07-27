﻿namespace PeopleDataV1.ViewModels.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
    }
}
