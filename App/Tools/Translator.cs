using Domain;
using Context.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace App
{
    public static class Translator {
        public static string Transl(string tag, string defaultValue, Microsoft.AspNetCore.Http.HttpRequest request) {
            if (String.IsNullOrWhiteSpace("tag")) {
                return "";
            }

            //OBTEM O VALOR DO IDIOMA
            StringValues languages;

            request.Headers.TryGetValue("language", out languages);

            string lang = languages.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(lang)) {
                lang = "en";
            }

            return Transl(tag, defaultValue, lang);
        }

        public static string Transl(string tag, string defaultValue, string lang = "en") {

            //Filtrar  array pela tag e pela lang para obter o valor do texto
            var _languageTags = (List<LanguageTag>)AppContext.GetData("langList");

            var result = _languageTags.Where(o => o.Tag == tag && o.Lang == lang).Select(o => o.Text).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(result)) {
                return defaultValue;
            }

            //Retorna o valor da mensagem
            return result.Trim();
        }

        public static List<LanguageTag> GetTagsListByLang(ContextApp ctx, string lang = "en", string usage = "api,webapp,mobileapp") {
            string[] usageList = usage.Split(',');

            var result = ctx.LanguageTags.Where(o => o.Lang == lang);

            if (usageList.Length > 3) {
                result = ctx.LanguageTags.Where(o => o.Lang == lang).Where(o => o.Usage.Contains(usageList[0]) || o.Usage.Contains(usageList[1]) || o.Usage.Contains(usageList[2]));
            }
            else if (usageList.Length > 2) {
                result = ctx.LanguageTags.Where(o => o.Lang == lang).Where(o => o.Usage.Contains(usageList[0]) || o.Usage.Contains(usageList[1]));
            }
            else {
                result = ctx.LanguageTags.Where(o => o.Lang == lang).Where(o => o.Usage.Contains(usageList[0]));
            }



            List<LanguageTag> languageTags = ctx.LanguageTags.Where(o => o.Lang == lang).ToList();

            return languageTags;
        }

        public static void UpdateTags(ContextApp ctx) {
            List<LanguageTag> languageTags = ctx.LanguageTags.ToList();

            AppDomain.CurrentDomain.SetData("langList", languageTags);

        }
    }
}
