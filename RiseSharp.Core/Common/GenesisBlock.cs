#region copyright
// <copyright file="GenesisBlock.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using RiseSharp.Core.Extensions;
using NBitcoin.BouncyCastle.Math;

namespace RiseSharp.Core.Common
{
    public class GenesisBlock
    {
        public BigInteger Id { get; set; }

        public BigInteger PreviousBlockId { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        
        public int PayloadLength { get; set; }

        
        public string PayloadHash { get; set; }

        [DataMember(Name="delegate")]
        public string Delegate { get; set; }

        [DataMember(Name = "pointId")]
        public BigInteger PointId { get; set; }

        [DataMember(Name = "pointHeight")]
        public int PointHeight { get; set; }

        public int BlockCount { get; set; }

        public string Signature { get; set; }

        public bool SkipSignature { get; set; }

        public int Count { get; set; }

        public List<Transaction> Transactions = new List<Transaction>(); 
        public byte[] GetBytes(bool skipSignature = false)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(PreviousBlockId.ToByteArray());
                    writer.Write(Height);
                    writer.Write(Timestamp);

                    writer.Write(PayloadLength);
                    writer.Write(PayloadHash.FromHex());
                    writer.Write(Delegate.FromHex());
                    writer.Write(PointId.ToByteArray());
                    writer.Write(PointHeight);
                    writer.Write(BlockCount);
                    writer.Write(Height);

                    if (!skipSignature && !string.IsNullOrWhiteSpace(Signature))
                    {
                        writer.Write(Signature.FromHex());
                    }
                }
                return stream.ToArray();
            }
        }
    }
}
