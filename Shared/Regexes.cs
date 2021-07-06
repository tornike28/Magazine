using System.Text.RegularExpressions;

namespace Shared
{
    public static class RegExes
    {
        public static Regex IdNumber => new Regex("^[0-9]{11}$");
        public static Regex Age => new Regex("^[0-9]{1,2}$");
        public static Regex Gender => new Regex("^[1-2]{1}$");
        public static Regex Point => new Regex("^[1-100]{1}$");
        public static Regex CommandName => new Regex("^[1-5]{1}$");
        public static Regex QueryName => new Regex("^[1-4]{1}$");
    }
}
