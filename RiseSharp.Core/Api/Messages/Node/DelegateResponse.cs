#region copyright
// <copyright file="DelegateResponse.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;
using Delegate = RiseSharp.Core.Api.Models.Delegate;

namespace RiseSharp.Core.Api.Messages.Node
{
    [DataContract]
    public class DelegateResponse : BaseResponse
    {
        [DataMember(Name="delegate", Order = 2)]
        public Delegate Delegate { get; set; }
    }
}
