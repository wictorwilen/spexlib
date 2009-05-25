/*
 * SharePoint Extensions Library
 * http://SPExLib.codeplex.com/
 * 
 * ------------------------------------------
 * 
 * Licensed under the Microsoft Public License (Ms-PL) 
 * http://www.opensource.org/licenses/ms-pl.html
 * 
 */
using System;
using System.Diagnostics;

namespace SPExLib.Diagnostics
{
    /// <summary>
    /// Provides extension methods to simplify inline Debug tracing.
    /// </summary>
    /// <remarks>For more information, see http://solutionizing.net/2009/04/14/elegant-inline-debug-tracing/.</remarks>
    public static partial class DebugExtensions
    {
        #region Debug Wrappers

        [Conditional("DEBUG")]
        private static void WriteLine<T>(T value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        [Conditional("DEBUG")]
        private static void WriteLine<T>(T value, string category)
        {
            System.Diagnostics.Debug.WriteLine(value, category);
        }

        [Conditional("DEBUG")]
        private static void WriteLineIf<T>(bool condition, T value)
        {
            System.Diagnostics.Debug.WriteLineIf(condition, value);
        }

        [Conditional("DEBUG")]
        private static void WriteLineIf<T>(bool condition, T value, string category)
        {
            System.Diagnostics.Debug.WriteLineIf(condition, value, category);
        }

        #endregion

        #region Helper Functions

        [Conditional("DEBUG")]
        private static void WriteLine<T, R>(T value, Func<T, R> selector)
        {
            WriteLine(selector(value));
        }

        [Conditional("DEBUG")]
        private static void WriteLine<T, R>(T value, string category, Func<T, R> selector)
        {
            WriteLine(selector(value), category);
        }

        [Conditional("DEBUG")]
        private static void WriteLineWhere<T>(T value, Func<T, bool> predicate)
        {
            WriteLineIf(predicate(value), value);
        }

        [Conditional("DEBUG")]
        private static void WriteLineWhere<T>(T value, string category, Func<T, bool> predicate)
        {
            WriteLineIf(predicate(value), value, category);
        }

        [Conditional("DEBUG")]
        private static void WriteLineWhere<T, R>(T value, Func<T, bool> predicate, Func<T, R> selector)
        {
            WriteLineIf(predicate(value), selector(value));
        }

        [Conditional("DEBUG")]
        private static void WriteLineWhere<T, R>(T value, string category, Func<T, bool> predicate, Func<T, R> selector)
        {
            WriteLineIf(predicate(value), selector(value), category);
        }

        #endregion

        public static T Debug<T>(this T value)
        {
            WriteLine(value);
            return value;
        }

        public static T Debug<T, R>(this T value, Func<T, R> selector)
        {
            WriteLine(value, selector);
            return value;
        }

        public static T DebugIn<T>(this T value, string category)
        {
            WriteLine(value, category);
            return value;
        }

        public static T DebugIn<T, R>(this T value, string category, Func<T, R> selector)
        {
            WriteLine(value, category, selector);
            return value;
        }

        public static T DebugWhere<T>(this T value, Func<T, bool> predicate)
        {
            WriteLineWhere(value, predicate);
            return value;
        }

        public static T DebugWhere<T, R>(this T value, Func<T, bool> predicate, Func<T, R> selector)
        {
            WriteLineWhere(value, predicate, selector);
            return value;
        }

        public static T DebugInWhere<T>(this T value, string category, Func<T, bool> predicate)
        {
            WriteLineWhere(value, category, predicate);
            return value;
        }

        public static T DebugInWhere<T, R>(this T value, string category, Func<T, bool> predicate, Func<T, R> selector)
        {
            WriteLineWhere(value, category, predicate, selector);
            return value;
        }
    }
}
