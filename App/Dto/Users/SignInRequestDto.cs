using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DtoUsers
{
    public class SignInRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Description("Não obrigatório")]
        public string? PushNotificationToken { get; set; }

        public string? PublicIp { get; set; }
    }
}
