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
    /// Enumeration of SPDisposeCheck patterns.
    /// For more information, see http://code.msdn.microsoft.com/SPDisposeCheck/.
    /// </summary>
    public enum SPDisposeCheckID
    {
        /// <summary>
        /// Undefined
        /// </summary>
        SPDisposeCheckID_000 = 0,
        /// <summary>
        /// Microsoft.SharePoint.SPList.BreakRoleInheritance() method
        /// </summary>
        SPDisposeCheckID_100 = 100,
        /// <summary>
        /// Microsoft.SharePoint.SPSite new() operator
        /// </summary>
        SPDisposeCheckID_110 = 110,
        /// <summary>
        /// Microsoft.SharePoint.SPSite.OpenWeb()
        /// </summary>
        SPDisposeCheckID_120 = 120,
        /// <summary>
        /// Microsoft.SharePoint.SPSite.AllWebs[] indexer
        /// </summary>
        SPDisposeCheckID_130 = 130,
        /// <summary>
        /// Microsoft.SharePoint.SPSite.RootWeb, LockIssue, Owner, and SecondaryContact properties
        /// </summary>
        SPDisposeCheckID_140 = 140,
        /// <summary>
        /// Microsoft.SharePoint.SPSite.AllWebs.Add() method
        /// </summary>
        SPDisposeCheckID_150 = 150,
        /// <summary>
        /// Microsoft.SharePoint.SPWeb.GetLimitedWebPartManager() method
        /// </summary>
        SPDisposeCheckID_160 = 160,
        /// <summary>
        /// Microsoft.SharePoint.SPWeb.ParentWeb property
        /// </summary>
        SPDisposeCheckID_170 = 170,
        /// <summary>
        /// Microsoft.SharePoint.SPWeb.Webs property
        /// </summary>
        SPDisposeCheckID_180 = 180,
        /// <summary>
        /// Microsoft.SharePoint.SPWeb.Webs.Add() method
        /// </summary>
        SPDisposeCheckID_190 = 190,
        /// <summary>
        /// Microsoft.SharePoint.SPWebCollection.Add() method 
        /// </summary>
        SPDisposeCheckID_200 = 200,
        /// <summary>
        /// Microsoft.SharePoint.WebControls.SPControl GetContextSite() and GetContextWeb() methods
        /// </summary>
        SPDisposeCheckID_210 = 210,
        /// <summary>
        /// Microsoft.SharePoint.SPContext Current.Site / SPContext.Site and SPContext.Current.Web / SPContext.Web properties
        /// </summary>
        SPDisposeCheckID_220 = 220,
        /// <summary>
        /// Microsoft.SharePoint.Administration.SPSiteCollection[] indexer
        /// </summary>
        SPDisposeCheckID_230 = 230,
        /// <summary>
        /// Microsoft.SharePoint.Administration.Add() method
        /// </summary>
        SPDisposeCheckID_240 = 240,
        /// <summary>
        /// Microsoft.SharePoint.Publishing.GetPublishingWebs() method
        /// </summary>
        SPDisposeCheckID_300 = 300,
        /// <summary>
        /// Microsoft.SharePoint.Publishing.PublishingWebCollection.Add() method
        /// </summary>
        SPDisposeCheckID_310 = 310,
        /// <summary>
        /// Microsoft.SharePoint.Publishing.PublishingWeb.GetVariation() method 
        /// </summary>
        SPDisposeCheckID_320 = 320,
        /// <summary>
        /// Microsoft.Office.Server.UserProfiles.PersonalSite property 
        /// </summary>
        SPDisposeCheckID_400 = 400,
        /// <summary>
        /// Microsoft.SharePoint.Portal.SiteData.AreaManager.GetArea() method
        /// </summary>
        SPDisposeCheckID_500 = 500,
        /// <summary>
        /// All
        /// </summary>
        SPDisposeCheckID_999 = 999
    }
}
