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
using Microsoft.SharePoint;

namespace SPExLib.SharePoint.Security
{
    /// <summary>
    /// Provides extension methods to simplify <see cref="SPWeb"/> impersonation for elevated privileges.
    /// </summary>
    /// <remarks>For more information, see http://solutionizing.net/2009/01/06/elegant-spsite-elevation/.</remarks>
    public static class SPWebSecurityExtensions
    {
        public static void RunAsSystem(this SPWeb web, Action<SPWeb> action)
        {
            web.Site.RunAsSystem(web.ID, action);
        }

        public static T SelectAsSystem<T>(this SPWeb web, Func<SPWeb, T> selector)
        {
            return web.Site.SelectAsSystem(web.ID, selector);
        }
    }
}
