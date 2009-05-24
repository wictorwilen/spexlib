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
using System.Linq;
using System.Collections.Generic;
using Microsoft.SharePoint;

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
            return list.Views.Cast<SPView>().Any(view => string.Compare(view.Title, title, true) == 0);
        }

       
    }
}
