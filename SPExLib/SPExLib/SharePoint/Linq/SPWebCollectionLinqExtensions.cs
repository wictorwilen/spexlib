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
using Microsoft.SharePoint;
using SPExLib.General;
using SPExLib.Diagnostics;

namespace SPExLib.SharePoint.Linq
{
    /// <summary>
    /// LINQ extensions for SPWebCollection
    /// </summary>
    public static class SPWebCollectionLinqExtensions
    {
        /// <summary>
        /// Returns a collection of <see cref="SPWeb"/> objects that will be disposed by its <see cref="IEnumerator"/>.
        /// </summary>
        /// <param name="webs">The <see cref="SPWebCollection"/> that contains the sites to enumerate.</param>
        /// <returns>An <see cref="IEnumerable&lt;SPWeb&gt;"/> that will dispose each <see cref="SPWeb"/> returned.</returns>
        /// <remarks>For more information, see http://solutionizing.net/2009/01/05/linq-for-spwebcollection-revisited-assafeenumerable/.</remarks>
        public static IEnumerable<SPWeb> AsSafeEnumerable(this SPWebCollection webs)
        {
            return webs.AsSafeEnumerable(null);
        }

        public static IEnumerable<SPWeb> AsSafeEnumerable(this SPWebCollection webs, bool debug)
        {
            if (debug)
                return webs.AsSafeEnumerable(web => web.DebugIn("AsSafeEnumerable Disposing SPWeb", w => w.Url));
            else
                return webs.AsSafeEnumerable();
        }

        public static IEnumerable<SPWeb> AsSafeEnumerable(this SPWebCollection webs, Action<SPWeb> onDispose)
        {
            foreach (SPWeb web in webs)
                try
                {
                    yield return web;
                }
                finally
                {
                    if (web != null)
                    {
                        if (onDispose != null)
                            onDispose(web);
                        web.Dispose();
                    }
                }
        }

        public static IEnumerable<TResult> Select<TResult>(this SPWebCollection source, Func<SPWeb, TResult> selector)
        {
            return source.AsSafeEnumerable().Select(selector);
        }

        public static void ForEach(this SPWebCollection source, Action<SPWeb> action)
        {
            source.AsSafeEnumerable().ForEach(action);
        }
    }
}
