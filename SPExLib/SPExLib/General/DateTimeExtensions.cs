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
using Microsoft.SharePoint.Utilities;

namespace SPExLib.General
{
    public static class DateTimeExtensions {

        /// <summary>
        /// Static Datetime method that parses a value for a DateTime? value. if the value is null then null is returned
        /// </summary>
        /// <param name="value">the object to parse</param>
        /// <returns>A DateTime value or null</returns>
        public static DateTime? ParseNull(object value) {
            if (value == null) {
                return null;
            }
            return DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Converts a DateTime object to a string format used in SPQuery CAML
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>A date/time formatted for use in a SPQuery CAML query</returns>
        /// <remarks>Contribution from http://mo.notono.us/</remarks>
        public static string ToSPQueryStringFormat(this DateTime dateTime) {
            return SPUtility.CreateISO8601DateTimeFromSystemDateTime(dateTime);
        }

    }
}
