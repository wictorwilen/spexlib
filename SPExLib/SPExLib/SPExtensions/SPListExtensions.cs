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

namespace SPExLib.Extensions {
    public static class SPListExtensions {
        public static bool ViewExists(this SPList list, string title) {
            return list.Views.Cast<SPView>().Any(view => string.Compare(view.Title, title, true) == 0);
        }

    }
}
