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
    /// Extension methods for SPContentTypeCollection class
    /// </summary>
    public static class SPContentTypeCollectionExtension {
        /// <summary>
        /// Checks if the SPContentTypeCollection contains a content type with the specified name
        /// </summary>
        /// <param name="source">The SPContentTypeCollection object</param>
        /// <param name="name">Name of the content type</param>
        /// <returns><c>True</c> if found, otherwise <c>false</c></returns>
        /// <remarks>Comparison is case-insensitive</remarks>
        public static bool Contains(this SPContentTypeCollection source, string name) {
            return source.Any<SPContentType>(contentType => string.Compare(contentType.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        /// <summary>
        /// Checks if the SPContentTypeCollection contains a content type with the specified Id
        /// </summary>
        /// <param name="source">The SPContentTypeCollection object</param>
        /// <param name="id">Id of the content type</param>
        /// <returns><c>True</c> if found, otherwise <c>false</c></returns>
        public static bool Contains(this SPContentTypeCollection source, SPContentTypeId id) {
            return source.Any<SPContentType>(contentType => contentType.Id == id);            
        }

    
        
    }
}
