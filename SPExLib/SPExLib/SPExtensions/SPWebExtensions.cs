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
using Microsoft.SharePoint;

namespace SPExLib.Extensions {
    public static class SPWebExtensions {
        public static bool ListExists(this SPWeb web, string name) {
            try {
                // -- Check if list exists.
                SPList list = web.Lists[name];
            }
            catch (ArgumentException) {
                return false;
            }
            return true;
        }
    }
}
