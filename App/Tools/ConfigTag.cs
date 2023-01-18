using Domain;
using Context.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;

namespace App
{
    public static class ConfigTag {
       

        public static string GetValue(string tag) {

            //Filtrar  array pela tag e pela lang para obter o valor do texto
            var _configTags = (List<ConfigurationTag>)AppContext.GetData("configList");

            var result = _configTags.Where(o => o.Tag == tag).Select(o => o.Value).FirstOrDefault();
            if (result == null) throw new ExceptionControlled("ConfigTag not Found", false, false);

            //Retorna o valor da mensagem
            return result.Trim();
        }


        public static void UpdateTags(ContextApp ctx) {
            List<ConfigurationTag> configurationTags = ctx.ConfigurationTags.ToList();

            AppDomain.CurrentDomain.SetData("configList", configurationTags);

        }
    }
}
