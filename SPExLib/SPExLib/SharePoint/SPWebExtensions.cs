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

namespace SPExLib.SharePoint {
    public static class SPWebExtensions {
        /// <summary>
        /// Returns a Boolean value that indicates whether the Web site name matches the given value.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if the name matches; otherwise, <c>false</c>.</returns>
        /// <remarks>Uses the same comparison criteria as SPWebCollection.Item[string name].</remarks>
        public static bool NameEquals(this SPWeb web, string name)
        {
            // Microsoft.SharePoint.Utilities.SPUtilityInternal.StsCompareStrings
            return string.Equals(web.Name, name, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ListExists(this SPWeb web, string name) {
            return web.Lists.Contains(name);
        }
    }
}
