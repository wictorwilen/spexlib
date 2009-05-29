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
using SPExLib.SharePoint.Linq.Base;

namespace SPExLib.SharePoint
{
    public static class SPGroupCollectionExtensions
    {
        public static bool Contains(this SPGroupCollection groups, string name)
        {
            return groups.Any<SPGroup>(group => group.NameEquals(name));
        }

        /// <summary>
        /// Get the group with the specified name, or call <c>groupBuilder</c> to create one if it doesn't exist.
        /// </summary>
        /// <param name="groups">The groups.</param>
        /// <param name="groupName">The group name.</param>
        /// <param name="groupBuilder">A function that creates a group given a group collection and group name.</param>
        /// <returns>The group.</returns>
        /// <remarks>For more information, see http://solutionizing.net/2009/03/19/more-sharepoint-higher-order-functions/.</remarks>
        public static SPGroup GetOrCreate(this SPGroupCollection groups, string groupName, Func<SPGroupCollection, string, SPGroup> groupBuilder)
        {
            SPGroup group = groups.FirstOrDefault<SPGroup>(g => g.NameEquals(groupName));
            if (group == null && groupBuilder != null)
                group = groupBuilder(groups, groupName);
            return group;
        }

        public static SPGroup GetOrCreate(this SPGroupCollection groups, string groupName,
                                          string description, SPUser owner, SPUser defaultUser)
        {
            return groups.GetOrCreate(groupName, (builderGroups, builderName) =>
            {
                builderGroups.Add(builderName, owner, defaultUser, description);
                return builderGroups[builderName];
            });
        }
    }
}
