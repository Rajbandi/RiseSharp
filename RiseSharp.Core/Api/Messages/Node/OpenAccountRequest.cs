#region copyright
// <copyright file="OpenAccountRequest.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Attributes;

namespace RiseSharp.Core.Api.Messages.Node
{
    [DataContract]
    public class OpenAccountRequest : BaseRequest
    {
        [DataMember(Name="secret")]
        [QueryParam(Name="secret")]
        public string Secret { get; set; }
    }
}
