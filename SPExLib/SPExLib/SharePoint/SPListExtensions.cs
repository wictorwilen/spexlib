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
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq.Base;

namespace SPExLib.SharePoint {
    /// <summary>
    /// Extensions for SPList
    /// </summary>
    public static class SPListExtensions {
        private static readonly string EmptyCamlQuery = "0";

        /// <summary>
        /// Creates an item but requires the Microsoft.SharePoint.SPListItem.Update() method to actually add the item to the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>An Microsoft.SharePoint.SPListItem object that represents the new item.</returns>
        /// <remarks>Optimized to add the item from an empty SPListItemCollection. For more information, see http://mo.notono.us/2009/03/beware-of-splistitemsadd.html</remarks>
        public static SPListItem AddItem(this SPList list)
        {
            return list.GetItems(new SPQuery { Query = EmptyCamlQuery })
                       .Add();
        }

        /// <summary>
        /// Checks if the specified view exists
        /// </summary>
        /// <param name="list">The SPList object</param>
        /// <param name="title">Title of the list (case insensitive)</param>
        /// <returns><c>True</c> if the view exists, otherwise <c>false</c></returns>
        public static bool ViewExists(this SPList list, string title) {
            return list.Views.Any<SPView>(view => string.Compare(view.Title, title, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        /// <summary>
        /// Performs the <paramref name="action"/> on each item in the list
        /// </summary>
        /// <param name="source">The SPList object</param>
        /// <param name="action">The action to perform on the item</param>
        // dahlbyk: I would prefer not to encourage/support the use of the Items property
        // Users should get in the habit of using SPQuery with View or ViewFields
        //public static void ForEach(this SPList source, Action<SPListItem> action) {
        //    source.Items.ForEach(action);
        //}

        /// <summary>
        ///  Returns a collection of items from the list based on the specified CAML query.
        /// </summary>
        /// <param name="source">The SPList object</param>
        /// <param name="whereQuery">A CAML Where statement</param>
        /// <returns>A <see cref="Microsoft.SharePoint.SPListItemCollection"/> object that represents the items.</returns>
        public static SPListItemCollection GetItems(this SPList source, string whereQuery) {
            return source.GetItems(new SPQuery { Query = whereQuery });
        }
        /// <summary>
        ///  Returns a collection of items from the list and view based on the specified CAML query.
        /// </summary>
        /// <param name="source">The SPList object</param>
        /// <param name="whereQuery">A CAML Where statement</param>
        /// <param name="viewName">The name of the view to query</param>
        /// <returns>A <see cref="Microsoft.SharePoint.SPListItemCollection"/> object that represents the items.</returns>
        public static SPListItemCollection GetItems(this SPList source, string whereQuery, string viewName) {
            return source.GetItems(new SPQuery { Query = whereQuery }, viewName);
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether the list name matches the given value.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if the name matches; otherwise, <c>false</c>.</returns>
        /// <remarks>Uses the same comparison criteria as SPListCollection.Item[string strListName].</remarks>
        public static bool NameEquals(this SPList list, string name)
        {
            // Microsoft.SharePoint.Utilities.SPUtilityInternal.StsCompareStrings
            return string.Equals(list.Title, name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
