#region copyright
// <copyright file="QueryParamAttribute.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System;

namespace RiseSharp.Core.Attributes
{
    /// <summary>
    /// QueryParamAttribute flags a property for including in request query parameters
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryParamAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
