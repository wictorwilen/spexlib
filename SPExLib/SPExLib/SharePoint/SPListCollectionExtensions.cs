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
    public static class SPListCollectionExtensions {
        public static bool Contains(this SPListCollection source, string name)
        {
            return source.Any<SPList>(list => list.NameEquals(name));
        }

        /// <summary>
        /// Get the list with the specified name, or call <c>listBuilder</c> to create one if it doesn't exist.
        /// </summary>
        /// <param name="lists">The lists.</param>
        /// <param name="listName">The list name.</param>
        /// <param name="listBuilder">A function that creates a list given a list collection and list name.</param>
        /// <returns>The list.</returns>
        /// <remarks>For more information, see http://solutionizing.net/2009/03/19/more-sharepoint-higher-order-functions/.</remarks>
        public static SPList GetOrCreate(this SPListCollection lists, string listName, Func<SPListCollection, string, SPList> listBuilder)
        {
            SPList list = lists.FirstOrDefault<SPList>(l => l.NameEquals(listName));
            if (list == null && listBuilder != null)
                list = listBuilder(lists, listName);
            return list;
        }
    }
}
