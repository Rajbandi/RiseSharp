#region copyright
// <copyright file="ApiInfo.cs" >
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
    /// ApiInfo contains api related information
    /// </summary>
    public class ApiInfo
    {
        /// <summary>
        /// if true, uses https otherwise http
        /// </summary>
        public bool? UseHttps { get; set; }

        /// <summary>
        /// Domain or Ip 
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Port 
        /// </summary>
        public int? Port { get; set; }

    }
}
