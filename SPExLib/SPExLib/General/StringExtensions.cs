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
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SPExLib.General {
    /// <summary>
    /// Extensions to the String class
    /// </summary>
    public static class StringExtensions {
        static Regex nonstd = new Regex(@"[^a-zA-Z0-9\s]");
        static Regex whites = new Regex(@"\s+");
        static Regex dashes = new Regex(@"^[-]|[-]+$");


        /// <summary>
        /// Extension class that adds the static string.Format directly on the string object
        /// </summary>
        /// <param name="format">The string object</param>
        /// <param name="args">Format arguments</param>
        /// <returns>A string</returns>
        public static string FormatWith(this string format, params object[] args) {
            return string.Format(format, (object[])args);
        }

        public static string UrlNameFromTitle(this string title) {
            return UrlNameFromTitle(title, title.Length, true);
        }

        public static string UrlNameFromTitle(this string title, bool preserveCasing) {
            return UrlNameFromTitle(title, title.Length, preserveCasing);
        }

        public static string UrlNameFromTitle(this string title, int maxlength, bool preserveCasing) {

            string s = nonstd.Replace(RemoveDiacritics(title), string.Empty);
            s = whites.Replace(s, "-");
            if (s.Length > maxlength) {
                s = s.Substring(0, maxlength);
            }
            s = dashes.Replace(s, string.Empty);
            if (preserveCasing) {
                return s;
            }
            return s.ToLower();
        }

        /// <summary>
        /// Removes diacritics from a string
        /// </summary>
        /// <param name="s">the string</param>
        /// <returns>A string without diacritics</returns>
        /// <example>
        /// <code >
        /// "Wilén".RemoveDiacritics();
        /// </code>
        /// will return
        /// <code>
        /// "Wilen"
        /// </code>
        /// </example>
        public static string RemoveDiacritics(this string s) {

            string d = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < d.Length; i++) {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(d[i]);
                if (uc != UnicodeCategory.NonSpacingMark) {
                    sb.Append(d[i]);
                }

            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
