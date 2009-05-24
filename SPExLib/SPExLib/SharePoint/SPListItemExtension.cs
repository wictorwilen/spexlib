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

namespace SPExLib.SharePoint {
    public static class SPListItemExtension {
        /// <summary>
        /// Returns the specified column value, typed as string, from a list item
        /// </summary>
        /// <param name="item">The SPListItem</param>
        /// <param name="column">Name of the column</param>
        /// <returns>A string value, if no data is found, or the column is not found,  <c>string.Empty</c> is returned</returns>
        public static string GetListItemString(this SPListItem item, string column) {
            object data = item.GetListItemData(column);

            if (data != null)
                return (string)data;
            else
                return string.Empty;
        }
        /// <summary>
        /// Returns the specified column value, typed as DateTime, from a list item
        /// </summary>
        /// <param name="item">The SPListItem</param>
        /// <param name="column">Name of the column</param>
        /// <returns>A DateTime value, if no data is found, or the column is not found,  <c>1900-01-01</c> is returned</returns>
        public static DateTime GetListItemDateTime(this SPListItem item, string column) {
            object data = item.GetListItemData(column);

            if (data != null)
                return (DateTime)data;
            else
                return new DateTime(1900, 1, 1);
        }
        /// <summary>
        /// Returns the specified column value, typed as bool, from a list item
        /// </summary>
        /// <param name="item">The SPListItem</param>
        /// <param name="column">Name of the column</param>
        /// <returns>A bool value, if no data is found, or the column is not found, <c>False</c> is returned</returns>
        public static bool GetListItemBool(this SPListItem item, string column) {
            object data =item.GetListItemData(column);

            if (data != null)
                return (bool)data;
            else
                return false;
        }
        /// <summary>
        /// Returns the value of the specified column value
        /// </summary>
        /// <param name="item">The SPListItem</param>
        /// <param name="column">Name of the column</param>
        /// <returns>The value of the column, if the column is not found <c>Null</c> is returned</returns>
        public static object GetListItemData(this SPListItem item, string column) {
            if (item.Contains(column))
                return item[column];
            else
                return null;
        }

        /// <summary>
        /// Checks if the list contains a field with the specified name
        /// </summary>
        /// <param name="item">The SPListItem item</param>
        /// <param name="fieldName">The name of the Field</param>
        /// <returns><c>True</c> if the field exits, otherwisr <c>False</c></returns>
        public static bool Contains(this SPListItem item, string fieldName) {
            return item.Fields.ContainsField(fieldName);
        }



    }

}
