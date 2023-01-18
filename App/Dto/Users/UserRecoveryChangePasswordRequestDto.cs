using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DtoUsers {
    public class UserRecoveryChangePasswordRequestDto {
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}
