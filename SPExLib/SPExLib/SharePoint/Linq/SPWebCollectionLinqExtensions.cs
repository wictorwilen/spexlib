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
using SPExLib.Diagnostics;

namespace SPExLib.SharePoint.Linq
{
    /// <summary>
    /// LINQ extensions for SPWebCollection
    /// </summary>
    public static partial class SPWebCollectionLinqExtensions
    {
        #region AsSafeEnumerable

        /// <summary>
        /// Returns a collection of <see cref="SPWeb"/> objects that will be disposed by its <see cref="IEnumerator"/>.
        /// </summary>
        /// <param name="webs">The <see cref="SPWebCollection"/> that contains the sites to enumerate.</param>
        /// <returns>An <see cref="IEnumerable{SPWeb}"/> that will dispose each <see cref="SPWeb"/> returned.</returns>
        /// <remarks>For more information, see http://solutionizing.net/2009/01/05/linq-for-spwebcollection-revisited-assafeenumerable/.</remarks>
        public static IEnumerable<SPWeb> AsSafeEnumerable(this SPWebCollection webs)
        {
            return webs.AsSafeEnumerable(null);
        }

        public static IEnumerable<SPWeb> AsSafeEnumerable(this SPWebCollection webs, bool debug)
        {
            if (debug)
                return webs.AsSafeEnumerable(web => web.DebugIn("AsSafeEnumerable Disposing SPWeb", w => w.Url));
            else
                return webs.AsSafeEnumerable();
        }

        public static IEnumerable<SPWeb> AsSafeEnumerable(this SPWebCollection webs, Action<SPWeb> onDispose)
        {
            foreach (SPWeb web in webs)
                try
                {
                    yield return web;
                }
                finally
                {
                    if (web != null)
                    {
                        if (onDispose != null)
                            onDispose(web);
                        web.Dispose();
                    }
                }
        }

        #endregion

        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            throw new NotSupportedException();
        }
        public static TAccumulate Aggregate<TAccumulate>(this SPWebCollection source, TAccumulate seed, Func<TAccumulate, SPWeb, TAccumulate> func)
        {
            return source.AsSafeEnumerable().Aggregate(seed, func);
        }
        public static TResult Aggregate<TAccumulate, TResult>(this SPWebCollection source, TAccumulate seed, Func<TAccumulate, SPWeb, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            return source.AsSafeEnumerable().Aggregate(seed, func, resultSelector);
        }

        public static bool All(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            return source.AsSafeEnumerable().All(predicate);
        }

        public static bool Any(this SPWebCollection source)
        {
            return source.Count > 0;
        }
        public static bool Any(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            return source.AsSafeEnumerable().Any(predicate);
        }

        public static decimal? Average(this SPWebCollection source, Func<SPWeb, decimal?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static decimal Average(this SPWebCollection source, Func<SPWeb, decimal> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double Average(this SPWebCollection source, Func<SPWeb, double> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double Average(this SPWebCollection source, Func<SPWeb, int> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double Average(this SPWebCollection source, Func<SPWeb, long> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double? Average(this SPWebCollection source, Func<SPWeb, double?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double? Average(this SPWebCollection source, Func<SPWeb, int?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static double? Average(this SPWebCollection source, Func<SPWeb, long?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static float? Average(this SPWebCollection source, Func<SPWeb, float?> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }
        public static float Average(this SPWebCollection source, Func<SPWeb, float> selector)
        {
            return source.AsSafeEnumerable().Average(selector);
        }

        public static IEnumerable<SPWeb> Concat(this SPWebCollection first, IEnumerable<SPWeb> second)
        {
            return first.AsSafeEnumerable().Concat(second);
        }

        public static bool Contains(this SPWebCollection source, SPWeb value)
        {
            throw new NotSupportedException();
        }
        public static bool Contains(this SPWebCollection source, SPWeb value, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static int Count(this SPWebCollection source)
        {
            return source.Count;
        }
        public static int Count(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            return source.AsSafeEnumerable().Count(predicate);
        }

        public static IEnumerable<SPWeb> DefaultIfEmpty(this SPWebCollection source)
        {
            return source.AsSafeEnumerable().DefaultIfEmpty();
        }
        public static IEnumerable<SPWeb> DefaultIfEmpty(this SPWebCollection source, SPWeb defaultValue)
        {
            return source.AsSafeEnumerable().DefaultIfEmpty(defaultValue);
        }

        public static IEnumerable<SPWeb> Distinct(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Distinct(this SPWebCollection source, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static SPWeb ElementAt(this SPWebCollection source, int index)
        {
            throw new NotSupportedException();
        }
        public static SPWeb ElementAtOrDefault(this SPWebCollection source, int index)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPWeb> Except(this SPWebCollection first, IEnumerable<SPWeb> second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Except(this SPWebCollection first, IEnumerable<SPWeb> second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static SPWeb First(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPWeb First(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            throw new NotSupportedException();
        }
        public static SPWeb FirstOrDefault(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPWeb FirstOrDefault(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<IGrouping<TKey, SPWeb>> GroupBy<TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<IGrouping<TKey, SPWeb>> GroupBy<TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TKey, TElement>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<SPWeb, TElement> elementSelector)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<TResult> GroupBy<TKey, TResult>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<TKey, SPWebCollection, TResult> resultSelector)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TKey, TElement>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<SPWeb, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<TResult> GroupBy<TKey, TElement, TResult>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<SPWeb, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<TResult> GroupBy<TKey, TResult>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<TKey, SPWebCollection, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<TResult> GroupBy<TKey, TElement, TResult>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<SPWeb, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(this SPWebCollection outer, IEnumerable<TInner> inner, Func<SPWeb, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPWeb, IEnumerable<TInner>, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> GroupJoin<TInner, TKey, TResult>(this SPWebCollection outer, IEnumerable<TInner> inner, Func<SPWeb, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPWeb, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static IEnumerable<SPWeb> Intersect<SPWeb>(this SPWebCollection first, IEnumerable<SPWeb> second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Intersect<SPWeb>(this SPWebCollection first, IEnumerable<SPWeb> second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<TResult> Join<TInner, TKey, TResult>(this SPWebCollection outer, IEnumerable<TInner> inner, Func<SPWeb, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPWeb, TInner, TResult> resultSelector)
        {
            return outer.AsSafeEnumerable().Join(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TInner, TKey, TResult>(this SPWebCollection outer, IEnumerable<TInner> inner, Func<SPWeb, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<SPWeb, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.AsSafeEnumerable().Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static SPWeb Last(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPWeb Last(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            throw new NotSupportedException();
        }
        public static SPWeb LastOrDefault(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPWeb LastOrDefault(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public static long LongCount(this SPWebCollection source)
        {
            return source.Count;
        }
        public static long LongCount(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            return source.Count(predicate);
        }

        public static SPWeb Max(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }
        public static decimal Max(this SPWebCollection source, Func<SPWeb, decimal> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static double Max(this SPWebCollection source, Func<SPWeb, double> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static int Max(this SPWebCollection source, Func<SPWeb, int> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static long Max(this SPWebCollection source, Func<SPWeb, long> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static long? Max(this SPWebCollection source, Func<SPWeb, long?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static decimal? Max(this SPWebCollection source, Func<SPWeb, decimal?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static double? Max(this SPWebCollection source, Func<SPWeb, double?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static int? Max(this SPWebCollection source, Func<SPWeb, int?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static TResult Max<TResult>(this SPWebCollection source, Func<SPWeb, TResult> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static float? Max(this SPWebCollection source, Func<SPWeb, float?> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }
        public static float Max(this SPWebCollection source, Func<SPWeb, float> selector)
        {
            return source.AsSafeEnumerable().Max(selector);
        }

        public static double? Min(this SPWebCollection source, Func<SPWeb, double?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static int? Min(this SPWebCollection source, Func<SPWeb, int?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static decimal Min(this SPWebCollection source, Func<SPWeb, decimal> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static decimal? Min(this SPWebCollection source, Func<SPWeb, decimal?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static double Min(this SPWebCollection source, Func<SPWeb, double> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static TResult Min<TResult>(this SPWebCollection source, Func<SPWeb, TResult> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static long? Min(this SPWebCollection source, Func<SPWeb, long?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static int Min(this SPWebCollection source, Func<SPWeb, int> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static float? Min(this SPWebCollection source, Func<SPWeb, float?> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static long Min(this SPWebCollection source, Func<SPWeb, long> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }
        public static float Min(this SPWebCollection source, Func<SPWeb, float> selector)
        {
            return source.AsSafeEnumerable().Min(selector);
        }

        public static IOrderedEnumerable<SPWeb> OrderBy<SPWeb, TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static IOrderedEnumerable<SPWeb> OrderBy<SPWeb, TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, IComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static IOrderedEnumerable<SPWeb> OrderByDescending<SPWeb, TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static IOrderedEnumerable<SPWeb> OrderByDescending<SPWeb, TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, IComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPWeb> Reverse(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<TResult> Select<TResult>(this SPWebCollection source, Func<SPWeb, TResult> selector)
        {
            return source.AsSafeEnumerable().Select(selector);
        }
        public static IEnumerable<TResult> Select<TResult>(this SPWebCollection source, Func<SPWeb, int, TResult> selector)
        {
            return source.AsSafeEnumerable().Select(selector);
        }

        public static IEnumerable<TResult> SelectMany<TResult>(this SPWebCollection source, Func<SPWeb, IEnumerable<TResult>> selector)
        {
            return source.AsSafeEnumerable().SelectMany(selector);
        }
        public static IEnumerable<TResult> SelectMany<TResult>(this SPWebCollection source, Func<SPWeb, int, IEnumerable<TResult>> selector)
        {
            return source.AsSafeEnumerable().SelectMany(selector);
        }
        public static IEnumerable<TResult> SelectMany<TCollection, TResult>(this SPWebCollection source, Func<SPWeb, IEnumerable<TCollection>> collectionSelector, Func<SPWeb, TCollection, TResult> resultSelector)
        {
            return source.AsSafeEnumerable().SelectMany(collectionSelector, resultSelector);
        }
        public static IEnumerable<TResult> SelectMany<TCollection, TResult>(this SPWebCollection source, Func<SPWeb, int, IEnumerable<TCollection>> collectionSelector, Func<SPWeb, TCollection, TResult> resultSelector)
        {
            return source.AsSafeEnumerable().SelectMany(collectionSelector, resultSelector);
        }

        public static bool SequenceEqual(this SPWebCollection first, IEnumerable<SPWeb> second)
        {
            throw new NotSupportedException();
        }
        public static bool SequenceEqual(this SPWebCollection first, IEnumerable<SPWeb> second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static SPWeb Single(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPWeb Single(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            throw new NotSupportedException();
        }
        public static SPWeb SingleOrDefault(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }
        public static SPWeb SingleOrDefault(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPWeb> Skip(this SPWebCollection source, int count)
        {
            return source.AsSafeEnumerable().Skip(count);
        }

        public static IEnumerable<SPWeb> SkipWhile(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            return source.AsSafeEnumerable().SkipWhile(predicate);
        }
        public static IEnumerable<SPWeb> SkipWhile(this SPWebCollection source, Func<SPWeb, int, bool> predicate)
        {
            return source.AsSafeEnumerable().SkipWhile(predicate);
        }

        public static decimal? Sum(this SPWebCollection source, Func<SPWeb, decimal?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static decimal Sum(this SPWebCollection source, Func<SPWeb, decimal> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static double? Sum(this SPWebCollection source, Func<SPWeb, double?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static double Sum(this SPWebCollection source, Func<SPWeb, double> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static int? Sum(this SPWebCollection source, Func<SPWeb, int?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static int Sum(this SPWebCollection source, Func<SPWeb, int> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static long Sum(this SPWebCollection source, Func<SPWeb, long> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static long? Sum(this SPWebCollection source, Func<SPWeb, long?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static float? Sum(this SPWebCollection source, Func<SPWeb, float?> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }
        public static float Sum(this SPWebCollection source, Func<SPWeb, float> selector)
        {
            return source.AsSafeEnumerable().Sum(selector);
        }

        public static IEnumerable<SPWeb> Take(this SPWebCollection source, int count)
        {
            return source.AsSafeEnumerable().Take(count);
        }

        public static IEnumerable<SPWeb> TakeWhile(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            return source.AsSafeEnumerable().TakeWhile(predicate);
        }
        public static IEnumerable<SPWeb> TakeWhile(this SPWebCollection source, Func<SPWeb, int, bool> predicate)
        {
            return source.AsSafeEnumerable().TakeWhile(predicate);
        }

        public static SPWeb[] ToArray(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }

        public static Dictionary<TKey, SPWeb> ToDictionary<TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static Dictionary<TKey, SPWeb> ToDictionary<TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<SPWeb, TElement> elementSelector)
        {
            throw new NotSupportedException();
        }
        public static Dictionary<TKey, TElement> ToDictionary<TKey, TElement>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<SPWeb, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }

        public static List<SPWeb> ToList(this SPWebCollection source)
        {
            throw new NotSupportedException();
        }

        public static ILookup<TKey, SPWeb> ToLookup<TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector)
        {
            throw new NotSupportedException();
        }
        public static ILookup<TKey, SPWeb> ToLookup<TKey>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }
        public static ILookup<TKey, TElement> ToLookup<TKey, TElement>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<SPWeb, TElement> elementSelector)
        {
            throw new NotSupportedException();
        }
        public static ILookup<TKey, TElement> ToLookup<TKey, TElement>(this SPWebCollection source, Func<SPWeb, TKey> keySelector, Func<SPWeb, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPWeb> Union(this SPWebCollection first, IEnumerable<SPWeb> second)
        {
            throw new NotSupportedException();
        }
        public static IEnumerable<SPWeb> Union(this SPWebCollection first, IEnumerable<SPWeb> second, IEqualityComparer<SPWeb> comparer)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<SPWeb> Where(this SPWebCollection source, Func<SPWeb, bool> predicate)
        {
            return source.AsSafeEnumerable().Where(predicate);
        }
        public static IEnumerable<SPWeb> Where(this SPWebCollection source, Func<SPWeb, int, bool> predicate)
        {
            return source.AsSafeEnumerable().Where(predicate);
        }
    }
}
