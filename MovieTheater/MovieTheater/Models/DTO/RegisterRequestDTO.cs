﻿using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models.DTO
{
    public class RegisterRequestDTO
    {
        [Required]

        public string UserName { get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
