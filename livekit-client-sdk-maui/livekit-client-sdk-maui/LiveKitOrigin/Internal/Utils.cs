using System;
using System.Diagnostics;

namespace LiveKit.Internal
{
    /// <summary>
    /// The class <c>Utils</c> contains internal utilities used for FfiClient 
    /// The log part is useful to print messages only when "LK_DEBUG" is defined.
    /// </summary>
    internal static class Utils
    {
        private const string PREFIX = "LiveKit";
        private const string LK_DEBUG = "LK_DEBUG";

        [Conditional(LK_DEBUG)]
        public static void Debug(object msg)
        {
            System.Diagnostics.Debug.Write($"Log: {PREFIX}: {msg}");
        }

        public static void Error(object msg)
        {
            System.Diagnostics.Debug.Write($"Error: {PREFIX}: {msg}");
        }

        
    }
}
