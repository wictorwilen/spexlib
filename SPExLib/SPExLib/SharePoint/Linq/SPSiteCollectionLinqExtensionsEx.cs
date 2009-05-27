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
    /// Provides LINQ extension methods for <see cref="SPSiteCollection"/> objects.
    /// </summary>
    public static partial class SPSiteCollectionLinqExtensions
    {
        #region Concat

        public static IEnumerable<SPSite> Concat(this IEnumerable<SPSite> first, SPSiteCollection second)
        {
            return first.Concat(second.AsSafeEnumerable());
        }
        public static IEnumerable<SPSite> Concat(this SPSiteCollection first, SPSiteCollection second)
        {
            return first.AsSafeEnumerable().Concat(second.AsSafeEnumerable());
        }

        #endregion

        #region Except

        public static IEnumerable<SPSite> Except(this IEnumerable<SPSite> first, SPSiteCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Except(this IEnumerable<SPSite> first, SPSiteCollection second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> Except(SPSiteCollection first, SPSiteCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Except(SPSiteCollection first, SPSiteCollection second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region GroupJoin

        // TOuter / SPSite
        public static IEnumerable<TResult> GroupJoin<TOuter, TKey, TResult>(this IEnumerable<TOuter> outer, SPSiteCollection inner, Func<TOuter, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<TOuter, SPSiteCollection, TResult> resultSelector)
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<TResult> GroupJoin<TOuter, TKey, TResult>(this IEnumerable<TOuter> outer, SPSiteCollection inner, Func<TOuter, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<TOuter, SPSiteCollection, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotImplementedException();
        }

        // SPSite / SPSite
        public static IEnumerable<TResult> GroupJoin<TKey, TResult>(this SPSiteCollection outer, SPSiteCollection inner, Func<SPSite, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<SPSite, SPSiteCollection, TResult> resultSelector)
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<TResult> GroupJoin<TKey, TResult>(this SPSiteCollection outer, SPSiteCollection inner, Func<SPSite, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<SPSite, SPSiteCollection, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotImplementedException();
        }

        // SPSite / SPBase
        public static IEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(this SPSiteCollection outer, SPBaseCollection inner, Func<SPSite, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPSite, IEnumerable<TInner>, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().GroupJoin(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(this SPSiteCollection outer, SPBaseCollection inner, Func<SPSite, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPSite, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().GroupJoin(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPSite / SPWeb
        public static IEnumerable<TResult> GroupJoin<TKey, TResult>(this SPSiteCollection outer, SPWebCollection inner, Func<SPSite, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<SPSite, SPWebCollection, TResult> resultSelector)
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<TResult> GroupJoin<TKey, TResult>(this SPSiteCollection outer, SPWebCollection inner, Func<SPSite, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<SPSite, SPWebCollection, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Intersect

        public static IEnumerable<SPSite> Intersect(this IEnumerable<SPSite> first, SPSiteCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Intersect(this IEnumerable<SPSite> first, SPSiteCollection second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> Intersect(SPSiteCollection first, SPSiteCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Intersect(SPSiteCollection first, SPSiteCollection second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Join

        // TOuter / SPSite
        public static IEnumerable<TResult> Join<TOuter, TKey, TResult>(this IEnumerable<TOuter> outer, SPSiteCollection inner, Func<TOuter, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<TOuter, SPSite, TResult> resultSelector)
        {
            return outer.Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TOuter, TKey, TResult>(this IEnumerable<TOuter> outer, SPSiteCollection inner, Func<TOuter, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<TOuter, SPSite, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPSite / SPSite
        public static IEnumerable<TResult> Join<TKey, TResult>(this SPSiteCollection outer, SPSiteCollection inner, Func<SPSite, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<SPSite, SPSite, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TKey, TResult>(this SPSiteCollection outer, SPSiteCollection inner, Func<SPSite, TKey> outerKeySelector, Func<SPSite, TKey> innerKeySelector, Func<SPSite, SPSite, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPSite / SPBase
        public static IEnumerable<TResult> Join<TInner, TKey, TResult>(this SPSiteCollection outer, SPBaseCollection inner, Func<SPSite, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPSite, TInner, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TInner, TKey, TResult>(this SPSiteCollection outer, SPBaseCollection inner, Func<SPSite, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPSite, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().Join(inner.Cast<TInner>(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        // SPSite / SPWeb
        public static IEnumerable<TResult> Join<TKey, TResult>(this SPSiteCollection outer, SPWebCollection inner, Func<SPSite, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<SPSite, SPWeb, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TKey, TResult>(this SPSiteCollection outer, SPWebCollection inner, Func<SPSite, TKey> outerKeySelector, Func<SPWeb, TKey> innerKeySelector, Func<SPSite, SPWeb, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().Join(inner.AsSafeEnumerable(), outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        #endregion

        #region SequenceEqual

        public static IEnumerable<SPSite> SequenceEqual(this IEnumerable<SPSite> first, SPSiteCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> SequenceEqual(this IEnumerable<SPSite> first, SPSiteCollection second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> SequenceEqual(SPSiteCollection first, SPSiteCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> SequenceEqual(SPSiteCollection first, SPSiteCollection second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Union

        public static IEnumerable<SPSite> Union(this IEnumerable<SPSite> first, SPSiteCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Union(this IEnumerable<SPSite> first, SPSiteCollection second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> Union(SPSiteCollection first, SPSiteCollection second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Union(SPSiteCollection first, SPSiteCollection second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
