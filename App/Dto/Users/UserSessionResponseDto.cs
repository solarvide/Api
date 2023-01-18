using Util.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace App.DtoUsers {
    public class UserSessionResponseDto {

        public string UserType { get; set; }

        public UserDefaultRequestDto User { get; set; }

        public TokenBuilded Token { get; set; }
    }
}