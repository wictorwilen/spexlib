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
