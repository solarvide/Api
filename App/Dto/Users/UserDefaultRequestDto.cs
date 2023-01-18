using Domain;

namespace App.DtoUsers {
    public class UserDefaultRequestDto {
        public int companyId { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? DocNumber { get; set; }
        public DateTime Birthday { get; set; }
        public bool Kyc { get; set; }
        public string Phone { get; set; }
        public long CountryId { get; set; }
        public string? DefaultLanguage { get; set; }
        public string Email { get; set; }

        private string _password;

        public string Password {
            get => _password;
            set => _password = Util.Tools.MD5Hash(value);
        }

        public long UserTypeId { get; set; }


    }

}
