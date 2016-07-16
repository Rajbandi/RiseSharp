#region copyright
// <copyright file="LoaderStatusSyncResponse.cs" >
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
    public class LoaderStatusSyncResponse : BaseResponse
    {
        [DataMember(Name = "syncing")]
        public bool Syncing { get; set; }

        [DataMember(Name = "blocks")]
        public int Blocks { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }
    }

}
