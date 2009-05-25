/*
 * SharePoint Extensions Library
 * http://SPExLib.codeplex.com/
 * 
 * ------------------------------------------
 * 
 * by Wictor Wilén
 * http://www.wictorwilen.se
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

namespace SPExLib.SharePoint.Linq {
    /// <summary>
    /// Linq extensions for SPListItem
    /// </summary>
    public static class SPListItemCollectionLinqExtensions {
        /// <summary>
        /// Performs the <paramref name="action"/> on each item in the list
        /// </summary>
        /// <param name="source">The SPListItemCollection object</param>
        /// <param name="action">The action to perform on the item</param>
        public static void ForEach(this SPListItemCollection source, Action<SPListItem> action) {
            source.ForEach(action);
        }

        public static bool Any(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            return source.Any(predicate);
        }

        public static bool All(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            return source.Cast<SPListItem>().All(predicate);
        }

        public static int Count(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            return source.Cast<SPListItem>().Count(predicate);
        }

        public static IEnumerable<TResult> Select<TResult>(this SPListItemCollection source, Func<SPListItem, TResult> selector) {
            return source.Cast<SPListItem>().Select(selector);
        }

        public static IEnumerable<SPListItem> Where(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            return source.Cast<SPListItem>().Where(predicate);
        }
    }
}
