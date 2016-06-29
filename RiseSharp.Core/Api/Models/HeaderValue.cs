#region copyright
// <copyright file="HeaderValue.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
namespace RiseSharp.Core.Api.Models
{
    /// <summary>
    /// Represents request header value
    /// </summary>
    public class HeaderValue
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public HeaderValue()
        {

        }

        /// <summary>
        /// Parameterized constructor with header value.
        /// </summary>
        /// <param name="name">Header name</param>
        /// <param name="value">Header value</param>
        public HeaderValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
