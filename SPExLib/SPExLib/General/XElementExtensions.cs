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
using System.Xml;
using System.Xml.Linq;

namespace SPExLib.General {
    public static class XElementExtensions {
      
        
        // Kudos to Eric White: http://blogs.msdn.com/ericwhite/archive/2008/12/22/convert-xelement-to-xmlnode-and-convert-xmlnode-to-xelement.aspx
        public static XmlNode GetXmlNode(this XElement element) {
            using (XmlReader xmlReader = element.CreateReader()) {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlReader);
                return xmlDoc;
            }
        }

        public static XmlElement GetXmlElement(this XElement element) {
            return GetXmlNode(element).FirstChild as XmlElement;
        }
    }
}
