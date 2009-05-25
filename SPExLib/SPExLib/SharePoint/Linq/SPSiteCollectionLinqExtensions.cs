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
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPExLib.General;
using SPExLib.Diagnostics;

namespace SPExLib.SharePoint.Linq
{
    /// <summary>
    /// LINQ extensions for SPSiteCollection
    /// </summary>
    public static class SPSiteCollectionLinqExtensions
    {
        /// <summary>
        /// Returns a collection of <see cref="SPSite"/> objects that will be disposed by its <see cref="IEnumerator"/>.
        /// </summary>
        /// <param name="sites">The <see cref="SPSiteCollection"/> that contains the sites to enumerate.</param>
        /// <returns>An <see cref="IEnumerable&lt;SPSite&gt;"/> that will dispose each <see cref="SPSite"/> returned.</returns>
        /// <remarks>For more information, see http://solutionizing.net/2009/01/05/linq-for-spwebcollection-revisited-assafeenumerable/.</remarks>
        public static IEnumerable<SPSite> AsSafeEnumerable(this SPSiteCollection sites)
        {
            return sites.AsSafeEnumerable(null);
        }

        public static IEnumerable<SPSite> AsSafeEnumerable(this SPSiteCollection sites, bool debug)
        {
            if (debug)
                return sites.AsSafeEnumerable(site => site.DebugIn("AsSafeEnumerable Disposing SPSite", s => s.Url));
            else
                return sites.AsSafeEnumerable();
        }

        public static IEnumerable<SPSite> AsSafeEnumerable(this SPSiteCollection sites, Action<SPSite> onDispose)
        {
            foreach (SPSite site in sites)
                try
                {
                    yield return site;
                }
                finally
                {
                    if (site != null)
                    {
                        if (onDispose != null)
                            onDispose(site);
                        site.Dispose();
                    }
                }
        }
    }
}
