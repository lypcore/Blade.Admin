using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Blade.Util
{
    public class RegexAttribute : ValidationAttribute
    {
        private readonly string _expression;
        public RegexAttribute(string expression)
        {
            _expression = expression;
        }
        public override bool IsValid(object value)
        {
            Regex regex = new Regex(_expression);
            return regex.IsMatch(value?.ToString() == null ? "" : value.ToString());
        }
    }
}
