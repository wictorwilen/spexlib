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

namespace SPExLib.SharePoint.Linq.Base
{
    /// <summary>
    /// Provides LINQ extension methods for <see cref="SPBaseCollection"/> objects.
    /// </summary>
    public static partial class SPBaseCollectionLinqExtensions
    {
        #region Concat

        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, SPBaseCollection second)
        {
            return first.Concat(second.Cast<TSource>());
        }

        public static IEnumerable<TSource> Concat<TSource>(this SPBaseCollection first, SPBaseCollection second)
        {
            return first.Cast<TSource>().Concat(second.Cast<TSource>());
        }

        #endregion

        #region Except

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, SPBaseCollection second)
        {
            return first.Except(second.Cast<TSource>());
        }
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, SPBaseCollection second, IEqualityComparer<TSource> comparer)
        {
            return first.Except(second.Cast<TSource>(), comparer);
        }

        public static IEnumerable<TSource> Except<TSource>(this SPBaseCollection first, SPBaseCollection second)
        {
            return first.Cast<TSource>().Except(second.Cast<TSource>());
        }
        public static IEnumerable<TSource> Except<TSource>(this SPBaseCollection first, SPBaseCollection second, IEqualityComparer<TSource> comparer)
        {
            return first.Cast<TSource>().Except(second.Cast<TSource>(), comparer);
        }

        #endregion

        #region GroupJoin

        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
        {
            return outer.GroupJoin(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.GroupJoin(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
        {
            return outer.Cast<TOuter>().GroupJoin(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Cast<TOuter>().GroupJoin(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        #endregion

        #region Intersect

        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, SPBaseCollection second)
        {
            return first.Intersect(second.Cast<TSource>());
        }
        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, SPBaseCollection second, IEqualityComparer<TSource> comparer)
        {
            return first.Intersect(second.Cast<TSource>(), comparer);
        }

        public static IEnumerable<TSource> Intersect<TSource>(this SPBaseCollection first, SPBaseCollection second)
        {
            return first.Cast<TSource>().Intersect(second.Cast<TSource>());
        }
        public static IEnumerable<TSource> Intersect<TSource>(this SPBaseCollection first, SPBaseCollection second, IEqualityComparer<TSource> comparer)
        {
            return first.Cast<TSource>().Intersect(second.Cast<TSource>(), comparer);
        }

        #endregion

        #region Join

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.Cast<TOuter>().Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, SPBaseCollection inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Cast<TOuter>().Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        #endregion

        #region SequenceEqual

        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, SPBaseCollection second)
        {
            return first.SequenceEqual(second.Cast<TSource>());
        }
        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, SPBaseCollection second, IEqualityComparer<TSource> comparer)
        {
            return first.SequenceEqual(second.Cast<TSource>(), comparer);
        }

        public static bool SequenceEqual<TSource>(this SPBaseCollection first, SPBaseCollection second)
        {
            return first.Cast<TSource>().SequenceEqual(second.Cast<TSource>());
        }
        public static bool SequenceEqual<TSource>(this SPBaseCollection first, SPBaseCollection second, IEqualityComparer<TSource> comparer)
        {
            return first.Cast<TSource>().SequenceEqual(second.Cast<TSource>(), comparer);
        }

        #endregion

        #region Union

        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, SPBaseCollection second)
        {
            return first.Union(second.Cast<TSource>());
        }
        public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, SPBaseCollection second, IEqualityComparer<TSource> comparer)
        {
            return first.Union(second.Cast<TSource>(), comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(this SPBaseCollection first, SPBaseCollection second)
        {
            return first.Cast<TSource>().Union(second.Cast<TSource>());
        }
        public static IEnumerable<TSource> Union<TSource>(this SPBaseCollection first, SPBaseCollection second, IEqualityComparer<TSource> comparer)
        {
            return first.Cast<TSource>().Union(second.Cast<TSource>(), comparer);
        }

        #endregion
    }
}
