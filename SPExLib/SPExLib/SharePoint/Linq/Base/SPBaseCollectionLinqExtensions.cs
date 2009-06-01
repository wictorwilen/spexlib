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

        public static TSource Aggregate<TSource>(this SPBaseCollection source, Func<TSource, TSource, TSource> func)
        {
            return source.Cast<TSource>().Aggregate(func);
        }
        public static TAccumulate Aggregate<TSource, TAccumulate>(this SPBaseCollection source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            return source.Cast<TSource>().Aggregate(seed, func);
        }
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this SPBaseCollection source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            return source.Cast<TSource>().Aggregate(seed, func, resultSelector);
        }

        public static bool All<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().All(predicate);
        }
 
        public static bool Any(this SPBaseCollection source)
        {
            return source.Count > 0;
        }
        public static bool Any<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().Any(predicate);
        }

        public static decimal? Average<TSource>(this SPBaseCollection source, Func<TSource, decimal?> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }
        public static decimal Average<TSource>(this SPBaseCollection source, Func<TSource, decimal> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }        
        public static double Average<TSource>(this SPBaseCollection source, Func<TSource, double> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }
        public static double Average<TSource>(this SPBaseCollection source, Func<TSource, int> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }
        public static double Average<TSource>(this SPBaseCollection source, Func<TSource, long> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }
        public static double? Average<TSource>(this SPBaseCollection source, Func<TSource, double?> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }
        public static double? Average<TSource>(this SPBaseCollection source, Func<TSource, int?> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }
        public static double? Average<TSource>(this SPBaseCollection source, Func<TSource, long?> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }
        public static float? Average<TSource>(this SPBaseCollection source, Func<TSource, float?> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }
        public static float Average<TSource>(this SPBaseCollection source, Func<TSource, float> selector)
        {
            return source.Cast<TSource>().Average(selector);
        }

        public static IEnumerable<TSource> Concat<TSource>(this SPBaseCollection first, IEnumerable<TSource> second)
        {
            return first.Cast<TSource>().Concat(second);
        }

        public static bool Contains<TSource>(this SPBaseCollection source, TSource value)
        {
            return source.Cast<TSource>().Contains(value);
        }
        public static bool Contains<TSource>(this SPBaseCollection source, TSource value, IEqualityComparer<TSource> comparer)
        {
            return source.Cast<TSource>().Contains(value, comparer);
        }

        public static int Count(this SPBaseCollection source)
        {
            return source.Count;
        }
        public static int Count<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().Count(predicate);
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().DefaultIfEmpty();
        }
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this SPBaseCollection source, TSource defaultValue)
        {
            return source.Cast<TSource>().DefaultIfEmpty(defaultValue);
        }

        public static IEnumerable<TSource> Distinct<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().Distinct();
        }
        public static IEnumerable<TSource> Distinct<TSource>(this SPBaseCollection source, IEqualityComparer<TSource> comparer)
        {
            return source.Cast<TSource>().Distinct(comparer);
        }

        public static TSource ElementAt<TSource>(this SPBaseCollection source, int index)
        {
            return source.Cast<TSource>().ElementAt(index);
        }
        public static TSource ElementAtOrDefault<TSource>(this SPBaseCollection source, int index)
        {
            return source.Cast<TSource>().ElementAt(index);
        }

        public static IEnumerable<TSource> Except<TSource>(this SPBaseCollection first, IEnumerable<TSource> second)
        {
            return first.Cast<TSource>().Except(second);
        }
        public static IEnumerable<TSource> Except<TSource>(this SPBaseCollection first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return first.Cast<TSource>().Except(second, comparer);
        }

        public static TSource First<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().First();
        }
        public static TSource First<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().First(predicate);
        }
        public static TSource FirstOrDefault<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().FirstOrDefault();
        }
        public static TSource FirstOrDefault<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().FirstOrDefault(predicate);
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector)
        {
            return source.Cast<TSource>().GroupBy(keySelector);
        }
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.Cast<TSource>().GroupBy(keySelector, comparer);
        }
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return source.Cast<TSource>().GroupBy(keySelector, elementSelector);
        }
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
        {
            return source.Cast<TSource>().GroupBy(keySelector, resultSelector);
        }
        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return source.Cast<TSource>().GroupBy(keySelector, elementSelector, comparer);
        }
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
        {
            return source.Cast<TSource>().GroupBy(keySelector, elementSelector, resultSelector);
        }
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return source.Cast<TSource>().GroupBy(keySelector, resultSelector, comparer);
        }
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return source.Cast<TSource>().GroupBy(keySelector, elementSelector, resultSelector, comparer);
        }

        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
        {
            return outer.Cast<TOuter>().GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Cast<TOuter>().GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static IEnumerable<TSource> Intersect<TSource>(this SPBaseCollection first, IEnumerable<TSource> second)
        {
            return first.Cast<TSource>().Intersect(second);
        }
        public static IEnumerable<TSource> Intersect<TSource>(this SPBaseCollection first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return first.Cast<TSource>().Intersect(second);
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.Cast<TOuter>().Join(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(this SPBaseCollection outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return outer.Cast<TOuter>().Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
        }

        public static TSource Last<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().Last();
        }
        public static TSource Last<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().Last(predicate);
        }
        public static TSource LastOrDefault<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().LastOrDefault();
        }
        public static TSource LastOrDefault<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().LastOrDefault(predicate);
        }

        public static long LongCount(this SPBaseCollection source)
        {
            return source.Count;
        }
        public static long LongCount<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Count(predicate);
        }

        public static TSource Max<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().Max();
        }
        public static decimal Max<TSource>(this SPBaseCollection source, Func<TSource, decimal> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static double Max<TSource>(this SPBaseCollection source, Func<TSource, double> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static int Max<TSource>(this SPBaseCollection source, Func<TSource, int> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static long Max<TSource>(this SPBaseCollection source, Func<TSource, long> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static long? Max<TSource>(this SPBaseCollection source, Func<TSource, long?> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static decimal? Max<TSource>(this SPBaseCollection source, Func<TSource, decimal?> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static double? Max<TSource>(this SPBaseCollection source, Func<TSource, double?> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static int? Max<TSource>(this SPBaseCollection source, Func<TSource, int?> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static TResult Max<TSource, TResult>(this SPBaseCollection source, Func<TSource, TResult> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static float? Max<TSource>(this SPBaseCollection source, Func<TSource, float?> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }
        public static float Max<TSource>(this SPBaseCollection source, Func<TSource, float> selector)
        {
            return source.Cast<TSource>().Max(selector);
        }

        public static double? Min<TSource>(this SPBaseCollection source, Func<TSource, double?> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static int? Min<TSource>(this SPBaseCollection source, Func<TSource, int?> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static decimal Min<TSource>(this SPBaseCollection source, Func<TSource, decimal> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static decimal? Min<TSource>(this SPBaseCollection source, Func<TSource, decimal?> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static double Min<TSource>(this SPBaseCollection source, Func<TSource, double> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static TResult Min<TSource, TResult>(this SPBaseCollection source, Func<TSource, TResult> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static long? Min<TSource>(this SPBaseCollection source, Func<TSource, long?> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static int Min<TSource>(this SPBaseCollection source, Func<TSource, int> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static float? Min<TSource>(this SPBaseCollection source, Func<TSource, float?> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static long Min<TSource>(this SPBaseCollection source, Func<TSource, long> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }
        public static float Min<TSource>(this SPBaseCollection source, Func<TSource, float> selector)
        {
            return source.Cast<TSource>().Min(selector);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector)
        {
            return source.Cast<TSource>().OrderBy(keySelector);
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return source.Cast<TSource>().OrderBy(keySelector, comparer);
        }
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector)
        {
            return source.Cast<TSource>().OrderByDescending(keySelector);
        }
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return source.Cast<TSource>().OrderByDescending(keySelector, comparer);
        }

        public static IEnumerable<TSource> Reverse<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>();
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this SPBaseCollection source, Func<TSource, TResult> selector)
        {
            return source.Cast<TSource>().Select(selector);
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this SPBaseCollection source, Func<TSource, int, TResult> selector)
        {
            return source.Cast<TSource>().Select(selector);
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

        public static bool SequenceEqual<TSource>(this SPBaseCollection first, IEnumerable<TSource> second)
        {
            return first.Cast<TSource>().SequenceEqual(second);
        }
        public static bool SequenceEqual<TSource>(this SPBaseCollection first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return first.Cast<TSource>().SequenceEqual(second, comparer);
        }

        public static TSource Single<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().Single();
        }
        public static TSource Single<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().Single(predicate);
        }
        public static TSource SingleOrDefault<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().SingleOrDefault();
        }
        public static TSource SingleOrDefault<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().SingleOrDefault(predicate);
        }

        public static IEnumerable<TSource> Skip<TSource>(this SPBaseCollection source, int count)
        {
            return source.Cast<TSource>().Skip(count);
        }

        public static IEnumerable<TSource> SkipWhile<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().SkipWhile(predicate);
        }
        public static IEnumerable<TSource> SkipWhile<TSource>(this SPBaseCollection source, Func<TSource, int, bool> predicate)
        {
            return source.Cast<TSource>().SkipWhile(predicate);
        }

        public static decimal? Sum<TSource>(this SPBaseCollection source, Func<TSource, decimal?> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static decimal Sum<TSource>(this SPBaseCollection source, Func<TSource, decimal> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static double? Sum<TSource>(this SPBaseCollection source, Func<TSource, double?> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static double Sum<TSource>(this SPBaseCollection source, Func<TSource, double> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static int? Sum<TSource>(this SPBaseCollection source, Func<TSource, int?> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static int Sum<TSource>(this SPBaseCollection source, Func<TSource, int> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static long Sum<TSource>(this SPBaseCollection source, Func<TSource, long> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static long? Sum<TSource>(this SPBaseCollection source, Func<TSource, long?> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static float? Sum<TSource>(this SPBaseCollection source, Func<TSource, float?> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }
        public static float Sum<TSource>(this SPBaseCollection source, Func<TSource, float> selector)
        {
            return source.Cast<TSource>().Sum(selector);
        }

        public static IEnumerable<TSource> Take<TSource>(this SPBaseCollection source, int count)
        {
            return source.Cast<TSource>().Take(count);
        }

        public static IEnumerable<TSource> TakeWhile<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().TakeWhile(predicate);
        }
        public static IEnumerable<TSource> TakeWhile<TSource>(this SPBaseCollection source, Func<TSource, int, bool> predicate)
        {
            return source.Cast<TSource>().TakeWhile(predicate);
        }

        public static TSource[] ToArray<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().ToArray();
        }

        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector)
        {
            return source.Cast<TSource>().ToDictionary(keySelector);
        }
        public static Dictionary<TKey, TSource> ToDictionary<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.Cast<TSource>().ToDictionary(keySelector, comparer);
        }
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return source.Cast<TSource>().ToDictionary(keySelector, elementSelector);
        }
        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return source.Cast<TSource>().ToDictionary(keySelector, elementSelector, comparer);
        }

        public static List<TSource> ToList<TSource>(this SPBaseCollection source)
        {
            return source.Cast<TSource>().ToList();
        }

        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector)
        {
            return source.Cast<TSource>().ToLookup(keySelector);
        }
        public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this SPBaseCollection source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.Cast<TSource>().ToLookup(keySelector, comparer);
        }
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return source.Cast<TSource>().ToLookup(keySelector,elementSelector);
        }
        public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this SPBaseCollection source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return source.Cast<TSource>().ToLookup(keySelector, elementSelector, comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(this SPBaseCollection first, IEnumerable<TSource> second)
        {
            return first.Cast<TSource>().Union(second);
        }
        public static IEnumerable<TSource> Union<TSource>(this SPBaseCollection first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return first.Cast<TSource>().Union(second, comparer);
        }

        public static IEnumerable<TSource> Where<TSource>(this SPBaseCollection source, Func<TSource, bool> predicate)
        {
            return source.Cast<TSource>().Where(predicate);
        }
        public static IEnumerable<TSource> Where<TSource>(this SPBaseCollection source, Func<TSource, int, bool> predicate)
        {
            return source.Cast<TSource>().Where(predicate);
        }
    }
}
