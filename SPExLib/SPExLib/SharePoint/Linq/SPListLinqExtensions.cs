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
using System.Text;
using Microsoft.SharePoint;

namespace SPExLib.SharePoint.Linq {
    /// <summary>
    /// Linq extensions for SPList
    /// </summary>
    public static class SPListLinqExtensions {
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
