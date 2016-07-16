#region copyright
// <copyright file="BlocksResponse.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using System.Runtime.Serialization;
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Api.Models;

namespace RiseSharp.Core.Api.Messages.Node
{
    [DataContract]
    public class BlocksResponse : BaseResponse
    {

        [DataMember(Name = "blocks")]
        public IList<Block> Blocks { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }
    }

}
