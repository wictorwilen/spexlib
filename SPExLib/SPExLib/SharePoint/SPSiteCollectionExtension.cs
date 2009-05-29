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
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq;
using SPExLib.General;

namespace SPExLib.SharePoint {
    public static class SPSiteCollectionExtension {

        public static void ForEach(this SPSiteCollection source, Action<SPSite> action) {
            source.AsSafeEnumerable().ForEach(action);
        }
    
    }
}
