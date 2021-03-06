﻿/*
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
using System.Linq;
using Microsoft.SharePoint;
using SPExLib.SharePoint.Linq;
using SPExLib.SharePoint.Linq.Base;
using SPExLib.SharePoint.Tools;

namespace SPExLib.SharePoint {
    public static class SPWebExtensions {
        public static bool HasGroupAssociation(this SPWeb web, string name)
        {
            return web.AssociatedGroups.Any(group => group.NameEquals(name));
        }

        public static bool HasGroupAssociation(this SPWeb web, SPGroup group)
        {
            if (group == null)
                throw new ArgumentNullException("group");

            return web.HasGroupAssociation(group.Name);
        }

        public static void EnsureGroupAssociation(this SPWeb web, SPGroup group)
        {
            if (group == null)
                throw new ArgumentNullException("group");

            if (web.HasGroupAssociation(group))
                web.AssociatedGroups.Add(group);
        }

        /// <summary>
        /// Returns a new SPWeb reference to the parent of the specified web. The returned value must be disposed by the caller.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <returns>An SPWeb for the parent of the given web.</returns>
        /// <remarks>For more information, see http://solutionizing.net/2009/03/19/introducing-spweb-getparentweb/.</remarks>
        /// <exception cref="ArgumentNullException"><c>web</c> is <c>null</c>.</exception>
        [SPDisposeCheckIgnore(SPDisposeCheckID.SPDisposeCheckID_120, "The purpose of this method is to retrieve an SPWeb that is safe for the caller to dispose.")]
        public static SPWeb GetParentWeb(this SPWeb web)
        {
            if (web == null)
                throw new ArgumentNullException("web");
            return web.Site.OpenWeb(web.ParentWebId);
        }

        /// <summary>
        /// Returns a Boolean value that indicates whether the Web site name matches the given value.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if the name matches; otherwise, <c>false</c>.</returns>
        /// <remarks>Uses the same comparison criteria as SPWebCollection.Item[string name].</remarks>
        public static bool NameEquals(this SPWeb web, string name)
        {
            // Microsoft.SharePoint.Utilities.SPUtilityInternal.StsCompareStrings
            return string.Equals(web.Name, name, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ListExists(this SPWeb web, string name) {
            return web.Lists.Contains(name);
        }

        /// <summary>
        /// Retrieves the SPListTemplate with the specified internal name
        /// </summary>
        /// <param name="web"></param>
        /// <param name="internalName">Internal name of the SPListTemplate</param>
        /// <returns>An SPListTemplate object</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">If the SPListTemplate is not found</exception>
        /// <remarks>This method is useful when you have to retrieve list templates in language independant applications</remarks>
        public static SPListTemplate GetListTemplateByInternalName(this SPWeb web, string internalName) {
            foreach (SPListTemplate template in web.ListTemplates) {
                if (string.Equals(template.InternalName, internalName, StringComparison.InvariantCultureIgnoreCase)) {
                    return template;
                }
            }
            throw new ArgumentOutOfRangeException("internalName", internalName, "The SPListTemplate with that internal name could not be found");
        }
    }
}
