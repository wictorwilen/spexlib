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
using Microsoft.SharePoint.Administration;

namespace SPExLib.SharePoint.Linq.Base
{
    /// <summary>
    /// Provides LINQ extension methods for <see cref="SPBaseCollection"/> objects.
    /// </summary>
    public static partial class SPBaseCollectionLinqExtensions
    {
        #region Dispose-safe Cast

        public static IEnumerable<TSource> Cast<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>(false);
        }
        public static IEnumerable<TSource> Cast<TSource>(this SPBaseCollection source, bool overrideDisposeGuard)
        {
            if (!overrideDisposeGuard && IsDisposableCollection(source))
                throw new NotSupportedException("Invalid cast.");
            return Enumerable.Cast<TSource>(source);
        }

        private static bool IsDisposableCollection(SPBaseCollection source)
        {
            return source is SPWebCollection || source is SPSiteCollection;
        }

        #endregion

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

        public static TSource First<TSource>(this SPBaseCollection source) {
            return source.Cast<TSource>().First<TSource>();
        }

        public static TSource First<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate) {
            return source.Cast<TSource>().First<TSource>(predicate);
        }  

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this SPBaseCollection source, Func<TSource, IEnumerable<TResult>> selector)
        {
            return source.Cast<TSource>().SelectMany(selector);
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this SPBaseCollection source, Func<TSource, int, IEnumerable<TResult>> selector)
        {
            return source.Cast<TSource>().SelectMany(selector);
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this SPBaseCollection source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return source.Cast<TSource>().SelectMany(collectionSelector, resultSelector);
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this SPBaseCollection source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return source.Cast<TSource>().SelectMany(collectionSelector, resultSelector);
        }

        public static IEnumerable<TSource> Where<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().Where(predicate);
        }
    }
}
