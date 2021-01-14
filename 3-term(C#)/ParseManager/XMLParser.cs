using ConfigProvider;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParseManager
{
    public class XMLParser : IParser
    {
        readonly Regex mainPattern = new Regex(@"<(?<AllConfName>[^>]*)>\s*(?<Content>[\w\W]*)\s*<(/\k<AllConfName>[\w\W]*)>",
                RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        readonly Regex contentPattern = new Regex(@"\s*<(?<ClassName>[^>]*)>\s*(?<Content>[\w\W]*)\s*</\k<ClassName>>",
                RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        readonly Regex fieldPattern = new Regex(@"\s*<(?<FieldName>[^>]*)>\s*(?<Value>[\w\W]*)\s*</\k<FieldName>>",
                RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        public XMLParser()
        {

        }
        public Dictionary<string, object> Parse(string xml)
        {
            var match = mainPattern.Match(xml);
            string input;
            if (match.Success)
            {
                input = match.Groups["Content"].Value;
            }
            else
            {
                throw new ArgumentException();
            }

            Console.WriteLine(input);
            var objects = ParseObject(input);
            return objects;
        }

        private Dictionary<string, object> ParseObject(string xmlObj)
        {
            var result = new Dictionary<string, object>();

            foreach (Match matchClassWithContent in contentPattern.Matches(xmlObj))
            {
                var optionGroups = matchClassWithContent.Groups;
                string tag = optionGroups["ClassName"].Value.ToLower();
                var content = optionGroups["Content"].Value;
                var optionObject = new Dictionary<string, object>();
                foreach (Match matchFieldValue in fieldPattern.Matches(content))
                {
                    var fieldGroups = matchFieldValue.Groups;
                    var field = fieldGroups["FieldName"].Value.ToLower();
                    var value = fieldGroups["Value"].Value;
                    optionObject.Add(field, value);
                }
                result.Add(tag, optionObject);
            }
            return result;
        }
    }
}