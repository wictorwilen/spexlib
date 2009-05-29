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

namespace SPExLib.SharePoint.Linq
{
    /// <summary>
    /// Provides LINQ extension methods for <see cref="SPWebCollection"/> objects.
    /// </summary>
    public static partial class SPWebCollectionLinqExtensions
    {
        #region Concat

        public static IEnumerable<SPWeb> Concat(this IEnumerable<SPWeb> first, SPWebCollection second)
        {
            return first.Concat(second.AsSafeEnumerable());
        }
        public static IEnumerable<SPWeb> Concat(this SPWebCollection first, SPWebCollection second)
        {
            return first.AsSafeEnumerable().Concat(second.AsSafeEnumerable());
        }

        #endregion

        #region Except

        public static IEnumerable<SPWeb> Except(this IEnumerable<SPWeb> first, SPWebCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Except(this IEnumerable<SPWeb> first, SPWebCollection second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPWeb> Except(this SPWebCollection first, SPWebCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Except(this SPWebCollection first, SPWebCollection second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region GroupJoin

        // TOuter / SPWeb
        public static IEnumerable<TResult> GroupJoin<TOuter, TKey, TResult>(this IEnumerable<TOuter> outer, SPWebCollection inner, Func<TOuter, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<TOuter, SPWebCollection, TResult> resultSelector)
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<TResult> GroupJoin<TOuter, TKey, TResult>(this IEnumerable<TOuter> outer, SPWebCollection inner, Func<TOuter, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<TOuter, SPWebCollection, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotImplementedException();
        }

        // SPWeb / SPWeb
        public static IEnumerable<TResult> GroupJoin<TKey, TResult>(this SPWebCollection outer, SPWebCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<SPWeb, SPWebCollection, TResult> resultSelector)
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<TResult> GroupJoin<TKey, TResult>(this SPWebCollection outer, SPWebCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<SPWeb, SPWebCollection, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotImplementedException();
        }

        // SPWeb / SPBase
        public static IEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(this SPWebCollection outer, SPBaseCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPWeb, IEnumerable<TInner>, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().GroupJoin(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(this SPWebCollection outer, SPBaseCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPWeb, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().GroupJoin(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPWeb / SPSite
        public static IEnumerable<TResult> GroupJoin<TKey, TResult>(this SPWebCollection outer, SPSiteCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<SPWeb, SPSiteCollection, TResult> resultSelector)
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<TResult> GroupJoin<TKey, TResult>(this SPWebCollection outer, SPSiteCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<SPWeb, SPSiteCollection, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Intersect

        public static IEnumerable<SPWeb> Intersect(this IEnumerable<SPWeb> first, SPWebCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Intersect(this IEnumerable<SPWeb> first, SPWebCollection second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPWeb> Intersect(this SPWebCollection first, SPWebCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Intersect(this SPWebCollection first, SPWebCollection second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Join

        // TOuter / SPWeb
        public static IEnumerable<TResult> Join<TOuter, TKey, TResult>(this IEnumerable<TOuter> outer, SPWebCollection inner, Func<TOuter, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<TOuter, SPWeb, TResult> resultSelector)
        {
            return outer.Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TOuter, TKey, TResult>(this IEnumerable<TOuter> outer, SPWebCollection inner, Func<TOuter, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<TOuter, SPWeb, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPWeb / SPWeb
        public static IEnumerable<TResult> Join<TKey, TResult>(this SPWebCollection outer, SPWebCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<SPWeb, SPWeb, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TKey, TResult>(this SPWebCollection outer, SPWebCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<SPWeb, SPWeb, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPWeb / SPBase
        public static IEnumerable<TResult> Join<TInner, TKey, TResult>(this SPWebCollection outer, SPBaseCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPWeb, TInner, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TInner, TKey, TResult>(this SPWebCollection outer, SPBaseCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPWeb, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPWeb / SPSite
        public static IEnumerable<TResult> Join<TKey, TResult>(this SPWebCollection outer, SPSiteCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<SPWeb, SPSite, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TKey, TResult>(this SPWebCollection outer, SPSiteCollection inner, Func<SPWeb, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<SPWeb, SPSite, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        #endregion

        #region SequenceEqual

        public static bool SequenceEqual(this IEnumerable<SPWeb> first, SPWebCollection second)
        {
            throw new NotSupportedException();
        }
        public static bool SequenceEqual(this IEnumerable<SPWeb> first, SPWebCollection second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static bool SequenceEqual(this SPWebCollection first, SPWebCollection second)
        {
            throw new NotSupportedException();
        }
        public static bool SequenceEqual(this SPWebCollection first, SPWebCollection second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Union

        public static IEnumerable<SPWeb> Union(this IEnumerable<SPWeb> first, SPWebCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Union(this IEnumerable<SPWeb> first, SPWebCollection second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPWeb> Union(this SPWebCollection first, SPWebCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Union(this SPWebCollection first, SPWebCollection second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
