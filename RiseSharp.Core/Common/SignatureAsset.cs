#region copyright
// <copyright file="SignatureAsset.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using RiseSharp.Core.Extensions;

namespace RiseSharp.Core.Common
{
    /// <summary>
    /// This class represents signature asset transaction of type =1
    /// </summary>
    [DataContract]
    public class SignatureAsset : Asset
    {
        [DataMember(Name = "signature")]
        public string Signature { get; set; }
        public override byte[] GetBytes()
        {
            return Signature.FromHex();
        }
    }
}
