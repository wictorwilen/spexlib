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
    /// Provides extension methods to simplify <see cref="SPSite"/> impersonation for elevated privileges.
    /// </summary>
    /// <remarks>For more information, see http://solutionizing.net/2009/01/06/elegant-spsite-elevation/.</remarks>
    public static class SPSiteImpersonationExtensions
    {
        public static SPUserToken GetSystemToken(this SPSite site)
        {
            SPUserToken token = null;
            bool tempCADE = site.CatchAccessDeniedException;
            try
            {
                site.CatchAccessDeniedException = false;
                token = site.SystemAccount.UserToken;
            }
            catch (UnauthorizedAccessException)
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (SPSite elevSite = new SPSite(site.ID))
                        token = elevSite.SystemAccount.UserToken;
                });
            }
            finally
            {
                site.CatchAccessDeniedException = tempCADE;
            }
            return token;
        }

        public static void RunAsSystem(this SPSite site, Action<SPSite> action)
        {
            using (var elevSite = new SPSite(site.ID, site.GetSystemToken()))
                action(elevSite);
        }

        public static void RunAsSystem(this SPSite site, Guid webId, Action<SPWeb> action)
        {
            site.RunAsSystem(elevSite =>
            {
                using (var elevWeb = elevSite.OpenWeb(webId))
                    action(elevWeb);
            });
        }

        public static void RunAsSystem(this SPSite site, string url, Action<SPWeb> action)
        {
            site.RunAsSystem(elevSite =>
            {
                using (var elevWeb = elevSite.OpenWeb(url))
                    action(elevWeb);
            });
        }

        public static T SelectAsSystem<T>(this SPSite site, Func<SPSite, T> selector)
        {
            using (SPSite elevSite = new SPSite(site.ID, site.GetSystemToken()))
                return selector(elevSite);
        }

        public static T SelectAsSystem<T>(this SPSite site, Guid webId, Func<SPWeb, T> selector)
        {
            return site.SelectAsSystem(elevSite =>
            {
                using (var elevWeb = elevSite.OpenWeb(webId))
                    return selector(elevWeb);
            });
        }

        public static T SelectAsSystem<T>(this SPSite site, string url, Func<SPWeb, T> selector)
        {
            return site.SelectAsSystem(elevSite =>
            {
                using (var elevWeb = elevSite.OpenWeb(url))
                    return selector(elevWeb);
            });
        }
    }
}
