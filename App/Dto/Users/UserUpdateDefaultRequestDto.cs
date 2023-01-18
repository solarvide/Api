using Util;

namespace App.DtoUsers
{
    public class UserUpdateDefaultRequestDto
    {
   
        public string? PhotoUrl { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? DocNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Phone { get; set; }
        public long? CountryId { get; set; }
        public string? Email { get; set; }

        private string? _password;

        public string? Password
        {
            get => _password;
            set => _password = Tools.MD5Hash(value);
        }
        public long? UserTypeId { get; set; }
        public bool? RemovePhoto { get;set;}

    }

}
