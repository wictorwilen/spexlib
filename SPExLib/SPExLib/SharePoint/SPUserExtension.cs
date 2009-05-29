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
    public static class SPUserExtension {
        public static string GetFormsLoginName(this SPUser spUser)  {
            string loginName = spUser.LoginName;
            int colonIndex = loginName.IndexOf(':');
            return colonIndex < 0 ? loginName : loginName.Substring(colonIndex);
        }
    }
}
