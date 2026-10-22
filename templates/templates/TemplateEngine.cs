using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace templates
{
    public class TemplateEngine
    {

        public static string Render(string template, Dictionary<string, string> dictionary)
        {
            foreach (var k in dictionary)
            {
                template = template.Replace("{{" + k.Key + "}}", k.Value);
            }

            var pozostale_placeholdery = Regex.Matches(template, "\\{\\{(\\w+)\\}\\}");

            foreach (Match p in pozostale_placeholdery)
                template = template.Replace(p.Value, $"[MISSING: {p.Groups[1].Value}]");

            

            return template;
        }

    }
}

