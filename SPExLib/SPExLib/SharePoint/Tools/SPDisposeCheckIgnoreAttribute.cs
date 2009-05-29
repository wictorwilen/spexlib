//--------------------------------------------------------------------------------
// This file is a "Sample" as part of the MICROSOFT SDK SAMPLES FOR SHAREPOINT
// PRODUCTS AND TECHNOLOGIES
//
// (c) 2008 Microsoft Corporation.  All rights reserved.  
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;

namespace SPExLib.SharePoint.Tools
{
    /// <summary>
    /// Attribute to mark exceptions to the rules checked by SPDisposeCheck.
    /// For more information, see http://code.msdn.microsoft.com/SPDisposeCheck/.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
    public class SPDisposeCheckIgnoreAttribute : Attribute
    {
        public SPDisposeCheckIgnoreAttribute(SPDisposeCheckID Id, string Reason)
        {
            this.Id = Id;
            this.Reason = Reason;
        }

        protected SPDisposeCheckIgnoreAttribute()
            : this(default(SPDisposeCheckID), "")
        {
        }

        public SPDisposeCheckID Id { get; set; }
        public string Reason { get; set; }
    }
}