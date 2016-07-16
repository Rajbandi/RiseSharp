#region copyright
// <copyright file="Transaction.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.IO;
using System.Runtime.Serialization;
using RiseSharp.Core.Extensions;
using NBitcoin.BouncyCastle.Math;
using Newtonsoft.Json;

namespace RiseSharp.Core.Common
{
    [DataContract]
    public class Transaction : BaseObject
    {
        public BigInteger Id { get; set; }

        [DataMember(Name = "type")]
        public TransactionType Type { get; set; }

        [DataMember(Name = "amount")]
        public long Amount { get; set; }

        [DataMember(Name = "fee")]
        public long Fee { get; set; }

        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        [DataMember(Name = "recipientId")]
        public string RecipientId { get; set; }

        [DataMember(Name = "senderId")]
        public string SenderId { get; set; }

        [DataMember(Name = "senderPublicKey")]
        public string SenderPublicKey { get; set; }

        [DataMember(Name = "requesterPublicKey")]
        public string RequesterPublicKey { get; set; }

        [DataMember(Name = "asset")]
        public Asset Asset { get; set; }

        [DataMember(Name = "signature")]
        public string Signature { get; set; }

        [DataMember(Name = "signSignature")]
        public string SignSignature { get; set; }

        public override string ToString()
        {
            var json = JsonConvert.SerializeObject(this);
            return json;
        }
        public byte[] GetBytes()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write((byte)Type);
                    writer.Write(Timestamp);
                    writer.Write(SenderPublicKey.FromHex());

                    if (!string.IsNullOrWhiteSpace(RecipientId))
                    {
                        var recId = new BigInteger(RecipientId.Replace(Constants.AddressSuffix, ""));
                        writer.Write(recId.ToByteArray().TakeBytes(8));
                    }
                    else
                    {
                        writer.Write(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
                    }

                    writer.Write(Amount);

                    if (Asset != null)
                    {
                        writer.Write(Asset.GetBytes());
                    }

                    if (!string.IsNullOrWhiteSpace(Signature))
                    {
                        writer.Write(Signature.FromHex());
                    }

                    if (!string.IsNullOrWhiteSpace(SignSignature))
                    {
                        writer.Write(Signature.FromHex());
                    }

                }
                return stream.ToArray();
            }
        }
    }
}
