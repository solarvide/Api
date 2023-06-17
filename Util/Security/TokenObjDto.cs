using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Security
{
    public class TokenObjDto
    {
        public long uID { get; set; }
        
        public string Username { get; set; }
        
        public string Name { get; set; }

        public long Type { get; set; }
        public long Company { get; set; }

    }
}
