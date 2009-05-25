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
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;

namespace SPExLib.SharePoint.Linq
{
    /// <summary>
    /// Provides LINQ extension methods for <see cref="SPBaseCollection"/> objects.
    /// </summary>
    public static partial class SPBaseCollectionLinqExtensions
    {
        public static bool Any(this SPBaseCollection source)
        {
            return source.Count > 0;
        }

        public static bool Any<T>(this SPBaseCollection source, Func<T, bool> predicate)
        {
            return source.Cast<T>().Any(predicate);
        }

        public static bool Contains<TSource>(this SPBaseCollection source, TSource value)
        {
            return source.Cast<TSource>().Contains(value);
        }

        public static bool Contains<TSource>(this SPBaseCollection source, TSource value, IEqualityComparer<TSource> comparer)
        {
            return source.Cast<TSource>().Contains(value, comparer);
        }
    }
}
