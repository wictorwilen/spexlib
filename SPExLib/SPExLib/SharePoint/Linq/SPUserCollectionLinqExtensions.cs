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
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq.Base;

namespace SPExLib.SharePoint.Linq {
    /// <summary>
    /// Linq extensioins for SPUserCollection
    /// </summary>
    public static class SPUserCollectionLinqExtensions {

        public static IEnumerable<TResult> Select<TResult>(this SPUserCollection source, Func<SPUser, TResult> selector)
        {
            return source.Select<SPUser, TResult>(selector);
        }
        
    }
}
