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
using SPExLib.Diagnostics;

namespace SPExLib.SharePoint.Linq
{
    /// <summary>
    /// LINQ extensions for SPSiteCollection
    /// </summary>
    public static partial class SPSiteCollectionLinqExtensions
    {
        #region AsSafeEnumerable

        /// <summary>
        /// Returns a collection of <see cref="SPSite"/> objects that will be disposed by its <see cref="IEnumerator"/>.
        /// </summary>
        /// <param name="sites">The <see cref="SPSiteCollection"/> that contains the sites to enumerate.</param>
        /// <returns>An <see cref="IEnumerable{SPSite}"/> that will dispose each <see cref="SPSite"/> returned.</returns>
        /// <remarks>For more information, see http://solutionizing.net/2009/01/05/linq-for-spwebcollection-revisited-assafeenumerable/.</remarks>
        public static IEnumerable<SPSite> AsSafeEnumerable(this SPSiteCollection sites)
        {
            return sites.AsSafeEnumerable(null);
        }

        public static IEnumerable<SPSite> AsSafeEnumerable(this SPSiteCollection sites, bool debug)
        {
            if (debug)
                return sites.AsSafeEnumerable(site => site.DebugIn("AsSafeEnumerable Disposing SPSite", s => s.Url));
            else
                return sites.AsSafeEnumerable();
        }

        public static IEnumerable<SPSite> AsSafeEnumerable(this SPSiteCollection sites, Action<SPSite> onDispose)
        {
            foreach (SPSite site in sites)
                try
                {
                    yield return site;
                }
                finally
                {
                    if (site != null)
                    {
                        if (onDispose != null)
                            onDispose(site);
                        site.Dispose();
                    }
                }
        }

        #endregion

        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            throw new NotSupportedException();
        }
        public static TAccumulate Aggregate<TAccumulate>(this SPSiteCollection source, TAccumulate seed, Func<TAccumulate, SPSite, TAccumulate> func)
        {
            return source.AsSafeEnumerable().Aggregate(seed, func);
        }
        public static TResult Aggregate<TAccumulate, TResult>(this SPSiteCollection source, TAccumulate seed, Func<TAccumulate, SPSite, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            return source.AsSafeEnumerable().Aggregate(seed, func, resultSelector);
        }

        public static bool All(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            return source.AsSafeEnumerable().All(predicate);
        }

        public static bool Any(this SPSiteCollection source)
        {
            return source.Count > 0;
        }
        public static bool Any(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            return source.AsSafeEnumerable().Any(predicate);
        }

        public static decimal? Average(this SPSiteCollection source, Func<SPSite, decimal?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static decimal Average(this SPSiteCollection source, Func<SPSite, decimal> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double Average(this SPSiteCollection source, Func<SPSite, double> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double Average(this SPSiteCollection source, Func<SPSite, int> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double Average(this SPSiteCollection source, Func<SPSite, long> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double? Average(this SPSiteCollection source, Func<SPSite, double?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double? Average(this SPSiteCollection source, Func<SPSite, int?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double? Average(this SPSiteCollection source, Func<SPSite, long?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static float? Average(this SPSiteCollection source, Func<SPSite, float?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static float Average(this SPSiteCollection source, Func<SPSite, float> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }

        public static IEnumerable<SPSite> Concat(this SPSiteCollection first, IEnumerable<SPSite> second)
        {
            return first.AsSafeEnumerable().Concat(second);
        }

        public static bool Contains(this SPSiteCollection source, SPSite value)
        {
            throw new NotSupportedException();
        }
        public static bool Contains(this SPSiteCollection source, SPSite value, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static int Count(this SPSiteCollection source)
        {
            return source.Count;
        }
        public static int Count(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            return source.AsSafeEnumerable().Count(predicate);
        }

        public static IEnumerable<SPSite> DefaultIfEmpty(this SPSiteCollection source)
        {
            return source.AsSafeEnumerable().DefaultIfEmpty();
        }
        public static IEnumerable<SPSite> DefaultIfEmpty(this SPSiteCollection source, SPSite defaultValue)
        {
            return source.AsSafeEnumerable().DefaultIfEmpty(defaultValue);
        }

        public static IEnumerable<SPSite> Distinct(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Distinct(this SPSiteCollection source, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static SPSite ElementAt(this SPSiteCollection source, int index)
        {
            throw new NotSupportedException();
        }
        public static SPSite ElementAtOrDefault(this SPSiteCollection source, int index)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> Except(this SPSiteCollection first, IEnumerable<SPSite> second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Except(this SPSiteCollection first, IEnumerable<SPSite> second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static SPSite First(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPSite First(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            throw new NotSupportedException();
        }
        public static SPSite FirstOrDefault(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPSite FirstOrDefault(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<IGrouping<TKey, SPSite>> GroupBy<TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<IGrouping<TKey, SPSite>> GroupBy<TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TKey, TElement>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<SPSite, TElement> elementSelector)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<TResult> GroupBy<TKey, TResult>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<TKey, SPSiteCollection, TResult> resultSelector)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TKey, TElement>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<SPSite, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<TResult> GroupBy<TKey, TElement, TResult>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<SPSite, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<TResult> GroupBy<TKey, TResult>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<TKey, SPSiteCollection, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<TResult> GroupBy<TKey, TElement, TResult>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<SPSite, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(this SPSiteCollection outer, IEnumerable<TInner> inner, Func<SPSite, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPSite, IEnumerable<TInner>, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(this SPSiteCollection outer, IEnumerable<TInner> inner, Func<SPSite, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPSite, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static IEnumerable<SPSite> Intersect<SPSite>(this SPSiteCollection first, IEnumerable<SPSite> second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Intersect<SPSite>(this SPSiteCollection first, IEnumerable<SPSite> second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<TResult> Join<TInner, TKey, TResult>(this SPSiteCollection outer, IEnumerable<TInner> inner, Func<SPSite, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPSite, TInner, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().Join(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TInner, TKey, TResult>(this SPSiteCollection outer, IEnumerable<TInner> inner, Func<SPSite, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPSite, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static SPSite Last(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPSite Last(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            throw new NotSupportedException();
        }
        public static SPSite LastOrDefault(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPSite LastOrDefault(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public static long LongCount(this SPSiteCollection source)
        {
            return source.Count;
        }
        public static long LongCount(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            return source.Count(predicate);
        }

        public static SPSite Max(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }
        public static decimal Max(this SPSiteCollection source, Func<SPSite, decimal> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static double Max(this SPSiteCollection source, Func<SPSite, double> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static int Max(this SPSiteCollection source, Func<SPSite, int> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static long Max(this SPSiteCollection source, Func<SPSite, long> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static long? Max(this SPSiteCollection source, Func<SPSite, long?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static decimal? Max(this SPSiteCollection source, Func<SPSite, decimal?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static double? Max(this SPSiteCollection source, Func<SPSite, double?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static int? Max(this SPSiteCollection source, Func<SPSite, int?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static TResult Max<TResult>(this SPSiteCollection source, Func<SPSite, TResult> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static float? Max(this SPSiteCollection source, Func<SPSite, float?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static float Max(this SPSiteCollection source, Func<SPSite, float> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }

        public static double? Min(this SPSiteCollection source, Func<SPSite, double?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static int? Min(this SPSiteCollection source, Func<SPSite, int?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static decimal Min(this SPSiteCollection source, Func<SPSite, decimal> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static decimal? Min(this SPSiteCollection source, Func<SPSite, decimal?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static double Min(this SPSiteCollection source, Func<SPSite, double> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static TResult Min<TResult>(this SPSiteCollection source, Func<SPSite, TResult> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static long? Min(this SPSiteCollection source, Func<SPSite, long?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static int Min(this SPSiteCollection source, Func<SPSite, int> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static float? Min(this SPSiteCollection source, Func<SPSite, float?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static long Min(this SPSiteCollection source, Func<SPSite, long> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static float Min(this SPSiteCollection source, Func<SPSite, float> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }

        public static IOrderedEnumerable<SPSite> OrderBy<SPSite, TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static IOrderedEnumerable<SPSite> OrderBy<SPSite, TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, IComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static IOrderedEnumerable<SPSite> OrderByDescending<SPSite, TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static IOrderedEnumerable<SPSite> OrderByDescending<SPSite, TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, IComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> Reverse(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<TResult> Select<TResult>(this SPSiteCollection source, Func<SPSite, TResult> selector)
        {
            return source.AsSafeEnumerable().Select(selector);
        }
        public static IEnumerable<TResult> Select<TResult>(this SPSiteCollection source, Func<SPSite, int, TResult> selector)
        {
            return source.AsSafeEnumerable().Select(selector);
        }

        public static IEnumerable<TResult> SelectMany<TResult>(this SPSiteCollection source, Func<SPSite, IEnumerable<TResult>> selector)
        {
            return source.AsSafeEnumerable().SelectMany(selector);
        }
        public static IEnumerable<TResult> SelectMany<TResult>(this SPSiteCollection source, Func<SPSite, int, IEnumerable<TResult>> selector)
        {
            return source.AsSafeEnumerable().SelectMany(selector);
        }
        public static IEnumerable<TResult> SelectMany<TCollection, TResult>(this SPSiteCollection source, Func<SPSite, IEnumerable<TCollection>> collectionSelector, Func<SPSite, TCollection, TResult> resultSelector)
        {
            return source.AsSafeEnumerable().SelectMany(collectionSelector, resultSelector);
        }
        public static IEnumerable<TResult> SelectMany<TCollection, TResult>(this SPSiteCollection source, Func<SPSite, int, IEnumerable<TCollection>> collectionSelector, Func<SPSite, TCollection, TResult> resultSelector)
        {
            return source.AsSafeEnumerable().SelectMany(collectionSelector, resultSelector);
        }

        public static bool SequenceEqual(this SPSiteCollection first, IEnumerable<SPSite> second)
        {
            throw new NotSupportedException();
        }
        public static bool SequenceEqual(this SPSiteCollection first, IEnumerable<SPSite> second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static SPSite Single(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPSite Single(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            throw new NotSupportedException();
        }
        public static SPSite SingleOrDefault(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPSite SingleOrDefault(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> Skip(this SPSiteCollection source, int count)
        {
            return source.AsSafeEnumerable().Skip(count);
        }

        public static IEnumerable<SPSite> SkipWhile(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            return source.AsSafeEnumerable().SkipWhile(predicate);
        }
        public static IEnumerable<SPSite> SkipWhile(this SPSiteCollection source, Func<SPSite, int, bool> predicate)
        {
            return source.AsSafeEnumerable().SkipWhile(predicate);
        }

        public static decimal? Sum(this SPSiteCollection source, Func<SPSite, decimal?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static decimal Sum(this SPSiteCollection source, Func<SPSite, decimal> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static double? Sum(this SPSiteCollection source, Func<SPSite, double?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static double Sum(this SPSiteCollection source, Func<SPSite, double> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static int? Sum(this SPSiteCollection source, Func<SPSite, int?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static int Sum(this SPSiteCollection source, Func<SPSite, int> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static long Sum(this SPSiteCollection source, Func<SPSite, long> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static long? Sum(this SPSiteCollection source, Func<SPSite, long?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static float? Sum(this SPSiteCollection source, Func<SPSite, float?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static float Sum(this SPSiteCollection source, Func<SPSite, float> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }

        public static IEnumerable<SPSite> Take(this SPSiteCollection source, int count)
        {
            return source.AsSafeEnumerable().Take(count);
        }

        public static IEnumerable<SPSite> TakeWhile(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            return source.AsSafeEnumerable().TakeWhile(predicate);
        }
        public static IEnumerable<SPSite> TakeWhile(this SPSiteCollection source, Func<SPSite, int, bool> predicate)
        {
            return source.AsSafeEnumerable().TakeWhile(predicate);
        }

        public static SPSite[] ToArray(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }

        public static Dictionary<TKey, SPSite> ToDictionary<TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static Dictionary<TKey, SPSite> ToDictionary<TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<SPSite, TElement> elementSelector)
        {
            throw new NotSupportedException();
        }
        public static Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<SPSite, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }

        public static List<SPSite> ToList(this SPSiteCollection source)
        {
            throw new NotSupportedException();
        }

        public static ILookup<TKey, SPSite> ToLookup<TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static ILookup<TKey, SPSite> ToLookup<TKey>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static ILookup<TKey, TElement> ToLookup<TKey, TElement>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<SPSite, TElement> elementSelector)
        {
            throw new NotSupportedException();
        }
        public static ILookup<TKey, TElement> ToLookup<TKey, TElement>(this SPSiteCollection source, Func<SPSite, TKey> keySelector, Func<SPSite, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> Union(this SPSiteCollection first, IEnumerable<SPSite> second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPSite> Union(this SPSiteCollection first, IEnumerable<SPSite> second, IEqualityComparer<SPSite> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPSite> Where(this SPSiteCollection source, Func<SPSite, bool> predicate)
        {
            return source.AsSafeEnumerable().Where(predicate);
        }
        public static IEnumerable<SPSite> Where(this SPSiteCollection source, Func<SPSite, int, bool> predicate)
        {
            return source.AsSafeEnumerable().Where(predicate);
        }
    }
}
