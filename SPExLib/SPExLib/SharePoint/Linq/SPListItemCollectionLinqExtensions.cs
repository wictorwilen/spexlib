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
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq.Base;

namespace SPExLib.SharePoint.Linq {
    /// <summary>
    /// Linq extensions for SPListItem
    /// </summary>
    public static class SPListItemCollectionLinqExtensions {
        public static bool Any(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            return source.Any<SPListItem>(predicate);
        }

        public static bool All(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            return source.All<SPListItem>(predicate);
        }

        public static int Count(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            return source.Count<SPListItem>(predicate);
        }

        public static IEnumerable<TResult> Select<TResult>(this SPListItemCollection source, Func<SPListItem, TResult> selector) {
            return source.Select<SPListItem, TResult>(selector);
        }

        public static IEnumerable<SPListItem> Where(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            return source.Where<SPListItem>(predicate);
        }
    }
}
