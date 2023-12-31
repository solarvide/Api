﻿
using App.Dto.Company;
using System.Text.Json.Serialization;

namespace App.DtoUsers {
    public class UserDefaultResponseDto {

        public long Id { get; set; }

        public string PhotoUrl { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string DocNumber { get; set; }

        public string DefaultLanguage { get; set; }

        public bool EmailValidated { get; set; }

        public DateTime Birthday { get; set; }

        public bool? TwoFactory { get; set; }
        public CompanyResponseBasicDto Company { get; set; }
        public UserTypeResponseDto UserType { get; set; }



    }
}
