#region copyright
// <copyright file="VersionResponse.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;

namespace RiseSharp.Core.Api.Messages.Node
{
    /// <summary>
    /// Peer version response
    /// </summary>
    [DataContract]
    public class VersionResponse : BaseResponse
    {
        [DataMember(Name = "version", Order=2)]
        public string Version { get; set; }

        [DataMember(Name = "build", Order = 3)]
        public string Build { get; set; }
    }
}
