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
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace SPExLib.SharePoint {
    /// <summary>
    /// Extensions for SPFile
    /// </summary>
    public static class SPFileExtensions {
        static readonly string[] sizeFormat = new string[] { "{0} bytes", "{0} KB", "{0} MB", "{0} GB", "{0} TB", "{0} PB", "{0} EB", "{0} ZB", "{0} YB" };
        /// <summary>
        /// Gets the file size as string.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static string GetFileSizeAsString(this SPFile file) {
            double s = file.Length;
            
            int i = 0;
            while (i < sizeFormat.Length - 1 && s >= 1024) {
                s = (int)(100 * s / 1024) / 100.0;
                i++;
            }
            return string.Format(sizeFormat[i], s.ToString("###,###,###.##"));
        }
    }
}
