using System;

namespace Blade.Util.Helper
{
    public class CheckHelper
    {
        public static void ThrowExceptionIfTrue<TE>(Func<bool> checkFunc, Func<TE> exceptionFunc) where TE : Exception
        {
            if (checkFunc())
                throw exceptionFunc();
        }
    }
}
