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
using System.Collections;
using System.Collections.Generic;

namespace SPExLib.General
{
    /// <summary>
    /// Provides extension methods related to <see cref="IEnumerable"/> and <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> with a single element.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="singleton"/>.</typeparam>
        /// <param name="singleton">The element to return as a singleton.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> with <paramref name="singleton"/> as its only element.</returns>
        public static IEnumerable<T> AsSingleton<T>(this T singleton)
        {
            yield return singleton;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
                action(obj);
        }

        public static void ForEach<T>(this IEnumerable source, Action<T> action)
        {
            foreach (T obj in source)
                action(obj);
        }
    }
}
