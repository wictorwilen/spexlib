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
using System.Linq;

namespace SPExLib.Extensions
{
    public static class SPUserExtension {
        public static string GetFormsLoginName(this SPUser spUser)  {
            return spUser.LoginName.Contains(':') ? spUser.LoginName.Split(':')[1] : spUser.LoginName;

        }
    }
}
