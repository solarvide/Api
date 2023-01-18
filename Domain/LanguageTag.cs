using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class LanguageTag : Base.BaseEntityWithIdWithoutChange
    {
        public string Tag { get; set; }

        public string Text { get; set; }

        public string Lang { get; set; }

        public bool IsHtml { get; set; } = false;

        public string Usage { get; set; } = "api,webapp,mobileapp";
    }
}
