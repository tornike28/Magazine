

namespace Shared
{
    public static class IsNullHelper
    {
        public static bool IsNull<T>(this T obj)
        {
            return obj == null;
        }
    }
}
