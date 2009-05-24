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

namespace SPExLib.SharePoint {
    public static class SPWebCollectionExtensions {


        public static IEnumerable<TResult> Select<TResult>(this SPWebCollection source, Func<SPWeb, TResult> selector) {
            foreach (SPWeb web in source) {
                TResult result = selector(web);
                web.Dispose();
                yield return result;
            }
        }

        public static void ForEach(this SPWebCollection source, Action<SPWeb> action) {
            foreach (SPWeb web in source) {
                action(web);
                web.Dispose();
            }
        }


    }
}
