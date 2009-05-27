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
        // SPBase / TInner
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.Cast<TOuter>().Join(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Cast<TOuter>().Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // TOuter / SPBase
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPBase / SPBase
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.Cast<TOuter>().Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Cast<TOuter>().Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }
    }
}
