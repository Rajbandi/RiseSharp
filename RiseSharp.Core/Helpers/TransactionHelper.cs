#region copyright
// <copyright file="transactionhelper.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
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
using RiseSharp.Core.Common;
using Transaction = RiseSharp.Core.Common.Transaction;

namespace RiseSharp.Core.Helpers
{
    public static class TransactionHelper
    {
       
        public static void SignTransaction(ref Transaction trs, string secret, string secondSecret="")
        {
            var address = CryptoHelper.GetAddress(secret);
            var keys = address.KeyPair;

            trs.SenderId = address.IdString;
            trs.SenderPublicKey = keys.PublicKey.ToHex().ToLower();
            var signature = GetSignature(trs, address);
            trs.Signature = signature.ToHex().ToLower();

            if (!string.IsNullOrWhiteSpace(secondSecret))
            {
                trs.SignSignature = GetSignature(trs, secondSecret).ToHex().ToLower();
            }
            var trsBytes = trs.GetBytes();
            trs.Id = CryptoHelper.GetId(trsBytes);
        }

        public static byte[] GetSignature(Transaction trs, string secret)
        {
            var address = CryptoHelper.GetAddress(secret);
            var signature = GetSignature(trs, address);
            return signature;
        }

        public static byte[] GetSignature(Transaction trs, Address address)
        {
            var keys = address.KeyPair;
            var trsBytes = trs.GetBytes();

            var hash = CryptoHelper.Sha256(trsBytes);
            var signature = CryptoHelper.Sign(hash, keys.PrivateKey);
            return signature;
        }

        public static int GetUnixTransactionTime()
        {
            var beginEpochTime = new DateTime(2016,05,24,17,0,0,DateTimeKind.Utc);
            var currentTime = DateTime.UtcNow;

            var beginEpochSeconds = beginEpochTime.ToUnixTimeInSeconds();
            var currentTimeSeconds = currentTime.ToUnixTimeInSeconds();

            var seconds = currentTimeSeconds - beginEpochSeconds;

            return seconds;
        }

        public static DateTime GetTransactionTime(int seconds)
        {
            var beginEpochTime = new DateTime(2016, 05, 24, 17, 0, 0, DateTimeKind.Utc);
            var epochTime = beginEpochTime.AddSeconds(seconds);
            var unixSeconds = epochTime.ToUnixTimeInSeconds();
            var utcDate = unixSeconds.FromUnixTimeSeconds();
            return utcDate;
        }

    }
}
