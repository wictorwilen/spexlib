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

namespace SPExLib.SharePoint
{
    /// <summary>
    /// Extensions for the SPUser class
    /// </summary>
    public static class SPUserExtension {
        /// <summary>
        /// Returns the user name without the provider prefix
        /// </summary>
        /// <param name="spUser">The SPUser object</param>
        /// <returns>The user name</returns>
        public static string GetFormsLoginName(this SPUser spUser)  {
            string loginName = spUser.LoginName;
            int colonIndex = loginName.IndexOf(':');
            return colonIndex < 0 ? loginName : loginName.Substring(colonIndex + 1);
        }
    }
}
