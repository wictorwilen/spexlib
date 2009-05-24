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

namespace SPExLib.SharePoint {
    public static class SPListItemCollectionExtensions {
        public static List<SPListItem> FindByField(this SPListItemCollection input, string field, object value) {
            return (from SPListItem item in input where item[field] == value select item).ToList();
        }
        public static List<SPListItem> FindByField(this SPListItemCollection input, Guid field, object value) {
            return (from SPListItem item in input where item[field] == value select item).ToList();
        }

        public static void ForEach(this SPListItemCollection source, Action<SPListItem> action) {
            if (source.Count == 0) {
                return;
            }
            foreach (SPListItem item in source) {
                action(item);
            }            
        }
        public static bool Any(this SPListItemCollection source) {
            return source.Count != 0;
        }

        public static bool Any(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            if (source.Count == 0) {
                return false;
            }
            foreach (SPListItem item in source) {
                if (predicate(item)) {
                    return true;
                }
            }
            return false;
        }
        public static bool All(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            if (source.Count == 0) {
                return false;
            }
            foreach (SPListItem item in source) {
                if (!predicate(item)) {
                    return false;
                }
            }
            return true;
        }
        public static int Count(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            if (source.Count == 0) {
                return 0;
            }
            int count = 0;
            foreach (SPListItem item in source) {
                if (predicate(item)) {
                    count++;
                }
            }

            return count;
        }

        public static IEnumerable<TResult> Select<TResult>(this SPListItemCollection source, Func<SPListItem, TResult> selector) {
            foreach (SPListItem item in source) {
                TResult result = selector(item);
                yield return result;
            }            
        }

        public static IEnumerable<SPListItem> Where(this SPListItemCollection source, Func<SPListItem, bool> predicate) {
            foreach (SPListItem item in source) {
                if (predicate(item)) {
                    yield return item;
                }

            }
        }
        
        
    }
}
