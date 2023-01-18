using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DtoUsers {
    public class UserEmailDisponibleRequestDto {
        public string CurrentEmail { get; set; }

        public string TargetEmail { get; set; }
    }
}
