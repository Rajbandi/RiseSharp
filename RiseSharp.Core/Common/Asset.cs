#region copyright
// <copyright file="Asset.cs" >
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
using NBitcoin.Protocol;

namespace RiseSharp.Core.Common
{
 
    public abstract class Asset : IAsset
    {
        public abstract byte[] GetBytes();
    }
}
