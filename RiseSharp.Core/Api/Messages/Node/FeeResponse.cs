#region copyright
// <copyright file="FeeResponse.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;

namespace RiseSharp.Core.Api.Messages.Node
{
    [DataContract]
    public class FeeResponse : BaseResponse
    {
        [DataMember(Name = "fee")]
        public long Fee { get; set; }
    }

}
