


using Util.Security;
using App.DtoUsers;

namespace App.DtoUsers {
    public class ContainedResponseUserDto {
        public string UserTypeId { get; set; }

        public UserDefaultResponseDto User { get; set; }

        public TokenBuilded Token { get; set; }

    }
}
