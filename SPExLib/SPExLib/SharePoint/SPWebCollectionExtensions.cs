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
using System.Text;
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq;

namespace SPExLib.SharePoint {
    /// <summary>
    /// Extensions for SPWebCollection
    /// </summary>
    public static class SPWebCollectionExtensions {

        public static bool Contains(this SPWebCollection source, string name) {
            return source.AsSafeEnumerable().Any<SPWeb>(web => string.Compare(web.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

    
    }
}
