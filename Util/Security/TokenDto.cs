﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Security
{
    public class TokenBuilded
    {
        public bool authenticated { get; set; }
        
        public string created { get; set; }
        
        public string expiration { get; set; }
        
        public string accessToken { get; set; }
    }
}
