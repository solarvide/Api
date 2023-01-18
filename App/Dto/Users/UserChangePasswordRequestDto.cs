using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DtoUsers {
    public class UserChangePasswordRequestDto
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

    }
}
