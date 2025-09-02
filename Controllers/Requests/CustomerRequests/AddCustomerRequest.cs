﻿using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.Controllers.Requests.CustomerRequests
{
    public class AddCustomerRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
