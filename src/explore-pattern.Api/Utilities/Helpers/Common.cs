using System.Runtime.CompilerServices;

namespace explore_pattern.Api.Utilities.Helpers
{
    public static class Common
    {
        public static string GetMethodName([CallerMemberName] string methodName = "")
        {
            return methodName;
        }
    }
}
