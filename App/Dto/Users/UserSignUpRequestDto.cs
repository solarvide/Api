using System;
using System.Text.Json.Serialization;
using App;

namespace App.DtoUsers
{
    public class UserSignUpRequestDto
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }

        public string? SurName { get; set; }

        public string? DocNumber { get; set; }

        public DateTime? Birthday { get; set; }

        public string? Phone { get; set; }

        public long? CountryId { get; set; }

        public string Email { get; set; }

        private string _password;

        public string Password
        {
            get => _password;
            set => _password = Util.Tools.MD5Hash(value);
        }

        public long? UserTypeId
        {
            get { return Convert.ToInt64(ConfigTag.GetValue("default_user_type_id")); }
        }

        public string? PushNotificationKey { get; set; }
        public bool? TwoFactory { get; set; }
        public string? PublicIp { get; set; }
        public string? PhotoUrl { get; set; }

    }

}