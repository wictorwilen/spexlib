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
    /// Extensions to SPFieldCollection
    /// </summary>
    public static class SPFieldCollectionExtension {
        /// <summary>
        /// Checks if the SPFieldCollection contains a field with the specified id
        /// </summary>
        /// <param name="source">The SPFieldCollection object</param>
        /// <param name="id">Id of the field</param>
        /// <returns><c>True</c> if found, otherwise <c>false</c></returns>
        /// <remarks>The SPFieldCollection contains an internal method for this</remarks>
        public static bool Contains(this SPFieldCollection source, Guid id) {
            return source.Any<SPField>(field => field.Id == id);
        }
    }
}
