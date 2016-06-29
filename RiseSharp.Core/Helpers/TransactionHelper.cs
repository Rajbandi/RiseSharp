#region copyright
// <copyright file="TransactionHelper.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Core.Extensions;
using NBitcoin;
using NBitcoin.BouncyCastle.Math;
using RiseSharp.Core.Api.Messages.Node;
using Transaction = RiseSharp.Core.Common.Transaction;

namespace RiseSharp.Core.Helpers
{
    public static class TransactionHelper
    {
        public static byte[] GetBytes(Transaction trs, bool skipSignature = true, bool skipSecondSignature = true)
        {
            using (var ms = new MemoryStream())
            {
                if (trs != null)
                {
                    using (var br = new BinaryWriter(ms))
                    {
                        br.Write((short)trs.Type);
                        br.Write((int)trs.Timestamp);
                        br.Write(trs.Amount);
                        br.Write((int)trs.Fee);
                        //if (!string.IsNullOrWhiteSpace(trs.SenderId))
                        //{
                        //    br.Write(trs.SenderId);
                        //}
                        
                        if (!string.IsNullOrWhiteSpace((trs.SenderPublicKey)))
                        {
                            br.Write(trs.SenderPublicKey.FromHex());
                        }
                        if (!string.IsNullOrEmpty(trs.RequesterPublicKey))
                        {
                            br.Write(trs.RequesterPublicKey.FromHex());
                        }
                        if (!string.IsNullOrWhiteSpace(trs.RecipientId))
                        {
                            var recId = trs.RecipientId.Replace("L", "");
                            var num = new BigInteger(Encoding.UTF8.GetBytes(recId)).ToByteArray();
                            br.Write(num.Take(8).ToArray());   
                        }
                        else
                        {
                            br.Write(new byte[8]);
                        }

                        if (trs.Asset != null)
                        {
                            br.Write(trs.Asset.GetBytes());
                        }

                        if (!string.IsNullOrWhiteSpace(trs.Signature))
                        {
                            br.Write(trs.Signature.FromHex());
                        }
                    }
                }
                return ms.ToArray();
            }
        }

        public static void SignTransaction(ref Transaction trs, string secret)
        {
            var address = CryptoHelper.GetAddress(secret);
            var keys = address.KeyPair;

            trs.SenderId = address.IdString;
            trs.SenderPublicKey = keys.PublicKey.ToHex().ToLower();

            var trsBytes = trs.GetBytes();
            var hash = CryptoHelper.Sha256(trsBytes);
            var signature = CryptoHelper.Sign(hash, keys.PrivateKey);
            trs.Signature = signature.ToHex().ToLower();
            trsBytes = trs.GetBytes();
            trs.Id = CryptoHelper.GetId(trsBytes);
        }
    }
}
