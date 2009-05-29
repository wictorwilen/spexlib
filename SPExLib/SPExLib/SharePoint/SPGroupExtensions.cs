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

namespace SPExLib.SharePoint
{
    public static class SPGroupExtensions
    {
        /// <summary>
        /// Returns a Boolean value that indicates whether the group name matches the given value.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if the name matches; otherwise, <c>false</c>.</returns>
        /// <remarks>Uses best guess for the obfuscated comparison criteria in SPGroupCollection.Item[string name].</remarks>
        public static bool NameEquals(this SPGroup group, string name)
        {
            return string.Equals(group.Name, name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
