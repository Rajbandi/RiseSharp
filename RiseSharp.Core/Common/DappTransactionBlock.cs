#region copyright
// <copyright file="DappTransactionBlock.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RiseSharp.Core.Common
{
    [DataContract]
    public class DappTransactionBlock
    {
        [DataMember(Name = "block")]
        public Block Block { get; set; }

        [DataMember(Name = "dapp")]
        public Transaction Dapp { get; set; }
    }
}
