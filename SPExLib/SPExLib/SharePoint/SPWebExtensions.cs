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
using System.Linq;
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq;

namespace SPExLib.SharePoint {
    public static class SPWebExtensions {
        public static bool ListExists(this SPWeb web, string name) {

            return web.Lists.Cast<SPList>().Any(list => string.Compare(list.Title, name, StringComparison.CurrentCultureIgnoreCase) == 0);            
        }
    }
}
