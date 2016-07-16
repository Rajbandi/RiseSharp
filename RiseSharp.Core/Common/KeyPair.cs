#region copyright
// <copyright file="KeyPair.cs" >
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
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Core.Extensions;

namespace RiseSharp.Core.Common
{
    public class KeyPair
    {
        public byte[] PublicKey { get; set; }

        public byte[] PrivateKey { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("Public Key : {0}", PublicKey != null ? PublicKey.ToHex() : "");
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat("Private Key : {0}", PrivateKey != null ? PrivateKey.ToHex() : "");
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }
    }
}
