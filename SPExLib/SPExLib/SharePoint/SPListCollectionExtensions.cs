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
        public static bool Contains(this SPListCollection source, string title) {
            return source.Any<SPList>(list => string.Compare(list.Title, title, StringComparison.CurrentCultureIgnoreCase) == 0);
        }
    }
}
