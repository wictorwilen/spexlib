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
using System.Linq;
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq;
using SPExLib.General;

namespace SPExLib.SharePoint {
    /// <summary>
    /// Extensions for SPWebCollection
    /// </summary>
    public static class SPWebCollectionExtensions {
        public static bool ContainsByName(this SPWebCollection source, string name) {
            return source.Any(web => web.NameEquals(name));
        }

        public static bool ContainsByUrl(this SPWebCollection source, string url) {
            return source.Names.Contains(url);
        }

        public static void ForEach(this SPWebCollection source, Action<SPWeb> action) {
            source.AsSafeEnumerable().ForEach(action);
        }
    }
}
