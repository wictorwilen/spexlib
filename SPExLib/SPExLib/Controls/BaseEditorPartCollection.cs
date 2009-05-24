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
using System.Collections;

namespace SPExLib.WebParts {
    public class BaseEditorPartCollection : ReadOnlyCollectionBase{
        public BaseEditorPartCollection(params BaseEditorPart[] args) {
            this.InnerList.AddRange(args);
        }
     
     
    }
}
