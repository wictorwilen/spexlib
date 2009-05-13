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
using Microsoft.SharePoint;

namespace SPExLib.Extensions {
    public static class SPListItemExtension {
        public static string GetListItemString(this SPListItem item, string column) {
            object data = item.GetListItemData(column);

            if (data != null)
                return (string)data;
            else
                return string.Empty;
        }
        public static DateTime GetListItemDateTime(this SPListItem item, string column) {
            object data = item.GetListItemData(column);

            if (data != null)
                return (DateTime)data;
            else
                return new DateTime(1900, 1, 1);
        }

        public static bool GetListItemBool(this SPListItem item, string column) {
            object data =item.GetListItemData(column);

            if (data != null)
                return (bool)data;
            else
                return false;
        }

        public static object GetListItemData(this SPListItem item, string column) {
            if (item.Contains(column))
                return item[column];
            else
                return null;
        }

        public static bool Contains(this SPListItem item, string fieldName) {
            return item.Fields.ContainsField(fieldName);
        }



    }

}
