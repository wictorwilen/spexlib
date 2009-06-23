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
using System.Web.UI;

namespace SPExLib.General
{
    /// <summary>
    /// Extensions to System.Web.UI.Control
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Searches the current naming container and all sub-containers for a server control with the specified id parameter.
        /// </summary>
        /// <typeparam name="T">The type of control to return.</typeparam>
        /// <param name="root">The control in which to search.</param>
        /// <param name="id">The identifier for the control to be found.</param>
        /// <returns>The specified control, or null if the specified control does not exist.</returns>
        public static T FindDescendentControl<T>(this Control root, string id) where T : Control
        {
            if (id == null)
                throw new ArgumentNullException("id");

            if (root == null)
                return null;

            // Build an enumeration of the current control and its descendents
            var controls = root.AsSingleton().Concat(root.GetDescendentControls());

            // Filter controls to find the requested ID
            var foundControls = from c in controls
                                let found = c.FindControl(id)
                                where found != null
                                select found;

            // Use First instead of Single to skip enumeration of remaining controls
            return foundControls.FirstOrDefault() as T;
        }

        /// <summary>
        /// Returns an enumeration of all descendents of the current control
        /// </summary>
        /// <param name="root">The control.</param>
        /// <returns>An enumeration of <c>root</c>'s the child controls</returns>
        /// <remarks>Uses a breadth-first non-recursive traversal algorithm</remarks>
        public static IEnumerable<Control> GetDescendentControls(this Control root)
        {
            var q = new Queue<Control>();

            var current = root;
            while (true)
            {
                if (current != null && current.HasControls())
                    foreach (Control child in current.Controls)
                        q.Enqueue(child);

                if (q.Count == 0)
                    yield break;

                current = q.Dequeue();
                yield return current;
            }
        }
    }
}
