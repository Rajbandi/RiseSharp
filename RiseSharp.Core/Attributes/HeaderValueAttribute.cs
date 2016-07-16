#region copyright
// <copyright file="HeaderValueAttribute.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;

namespace RiseSharp.Core.Attributes
{
    /// <summary>
    /// QueryParamAttribute flags a property for including in request query parameters
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class HeaderValueAttribute : Attribute
    {
        public string Name { get; set; }

        public object Default { get; set; }
    }
}
