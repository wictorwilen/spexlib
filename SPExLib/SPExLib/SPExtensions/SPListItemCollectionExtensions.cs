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
using Microsoft.SharePoint;

namespace SPExLib.SPExtensions {
    public static class SPListItemCollectionExtensions {
        public static List<SPListItem> FindByField(this SPListItemCollection input, string field, object value) {
            return (from SPListItem item in input where item[field] == value select item).ToList();
        }
        public static List<SPListItem> FindByField(this SPListItemCollection input, Guid field, object value) {
            return (from SPListItem item in input where item[field] == value select item).ToList();
        }

    }
}
