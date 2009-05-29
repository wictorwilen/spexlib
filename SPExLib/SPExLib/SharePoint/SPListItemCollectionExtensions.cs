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
using System.Collections.Generic;
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq;

namespace SPExLib.SharePoint {
    public static class SPListItemCollectionExtensions {
        public static IEnumerable<SPListItem> FindByField(this SPListItemCollection input, string field, object value) {
            return from item in input
                   where item[field] == value
                   select item;
        }
        public static IEnumerable<SPListItem> FindByField(this SPListItemCollection input, Guid field, object value) {
            return from item in input 
                   where item[field] == value 
                   select item;
        }      
    }
}
