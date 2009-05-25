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
using System.Globalization;

namespace SPExLib.General
{
    public static class DateTimeExtensions {

        public static DateTime? ParseNull(object value) {
            if (value == null) {
                return null;
            }
            return DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }
    }
}
