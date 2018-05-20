using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CSharpBits.Common.Utility.Class
{
    public static class ClassUtility
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
