#region copyright
// <copyright file="Address.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Text;
using NBitcoin.BouncyCastle.Math;

namespace RiseSharp.Core.Common
{
    public class Address : BaseObject
    {
        public Address()
        {
            KeyPair = new KeyPair();
        }
        public KeyPair KeyPair { get; set; }
        public BigInteger Id { get; set; }

        public string IdString => $"{Id}{Constants.AddressSuffix}";

    }
}
