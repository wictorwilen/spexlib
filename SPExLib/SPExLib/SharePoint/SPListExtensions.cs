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
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq.Base;

namespace SPExLib.SharePoint {
    /// <summary>
    /// Extensions for SPList
    /// </summary>
    public static class SPListExtensions {
        /// <summary>
        /// Checks if the specified view exists
        /// </summary>
        /// <param name="list">The SPList object</param>
        /// <param name="title">Title of the list (case insensitive)</param>
        /// <returns><c>True</c> if the view exists, otherwise <c>false</c></returns>
        public static bool ViewExists(this SPList list, string title) {
            return list.Views.Any<SPView>(view => string.Compare(view.Title, title, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public static bool Contains(this SPWebCollection source, string name) {
            return source.Any<SPList>(list => string.Compare(list.Title, name, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        /// <summary>
        /// Performs the <paramref name="action"/> on each item in the list
        /// </summary>
        /// <param name="source">The SPList object</param>
        /// <param name="action">The action to perform on the item</param>
        public static void ForEach(this SPList source, Action<SPListItem> action) {
            source.Items.ForEach(action);
        }

       
    }
}
