#region copyright
// <copyright file="BlockHelper.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Core.Common;
using RiseSharp.Core.Exceptions;
using RiseSharp.Core.Extensions;

namespace RiseSharp.Core.Helpers
{
    /// <summary>
    /// BlockHelper provides common block related functions
    /// </summary>
    public static class BlockHelper
    {
        public static Block CreateNewBlock(Account genesisAccount, Dapp dapp)
        {
            var transactions = new List<Transaction>();
            var delegates = new List<Account>();

            var sender = AccountHelper.GetAccount(CryptoHelper.GenerateSecret());

            long totalAmount = 0;

            var balTransaction = new Transaction
            {
                Type = TransactionType.Send,
                Amount = 10000000000000000,
                Fee = 0,
                Timestamp = 0,
                RecipientId = genesisAccount.Address.IdString,
                SenderId = sender.Address.IdString,
                SenderPublicKey = sender.Address.KeyPair.PublicKey.ToHex()
            };
            totalAmount += balTransaction.Amount;

            var bytes = balTransaction.GetBytes();
            balTransaction.Signature = CryptoHelper.Sign(bytes, sender.Address.KeyPair.PrivateKey).ToHex();
            balTransaction.Id = CryptoHelper.GetId(sender.Address.KeyPair.PublicKey);
            
            transactions.Add(balTransaction);

            for (int index = 0; index < Constants.ActiveDelegates; index++)
            {
                var delegateSecret = CryptoHelper.GenerateSecret();
                var delAccount = AccountHelper.GetAccount(delegateSecret);
                delegates.Add(delAccount);
                var userName = string.Format("genesisDelegate{0}", index + 1);

                var delTransaction = new Transaction
                {
                    Type = TransactionType.Delegate,
                    Amount = 0,
                    Fee = 0,
                    Timestamp = 0,
                    RecipientId = null,
                    SenderId = delAccount.Address.IdString,
                    SenderPublicKey = delAccount.Address.KeyPair.PublicKey.ToHex(),

                    Asset = new DelegateUsernameAsset
                    {
                        Delegate = new DelegateUsername
                        {
                            Username = userName
                        }
                    }
                };

                var delBytes = delTransaction.GetBytes();
                delTransaction.Signature = CryptoHelper.Sign(delBytes, delAccount.Address.KeyPair.PrivateKey).ToHex();
                delTransaction.Id = CryptoHelper.GetId(delBytes);

                transactions.Add(delTransaction);
            }

            var votes = delegates.Select(vote => string.Format("+{0}", vote.Address.KeyPair.PublicKey.ToHex()));

            var voteAsset = new DelegateVoteAsset();
            voteAsset.Votes.AddRange(votes);

            var voteTransaction = new Transaction
            {
                Type = TransactionType.Vote,
                Amount = 0,
                Fee = 0,
                Timestamp = 0,
                RecipientId = genesisAccount.Address.IdString,
                SenderId = genesisAccount.Address.IdString,
                SenderPublicKey = genesisAccount.Address.KeyPair.PublicKey.ToHex(),
                Asset = voteAsset
            };
            var voteBytes = voteTransaction.GetBytes();
            voteTransaction.Signature = CryptoHelper.Sign(voteBytes, genesisAccount.Address.KeyPair.PrivateKey).ToHex();
            voteTransaction.Id = CryptoHelper.GetId(voteBytes);

            transactions.Add(voteTransaction);

            var dappTransaction = new Transaction
            {
                Type = TransactionType.Dapp,
                Amount = 0,
                Fee = 0,
                Timestamp = 0,
                RecipientId = null,
                SenderId = genesisAccount.Address.IdString,
                SenderPublicKey = genesisAccount.Address.KeyPair.PublicKey.ToHex(),
                Asset = new DappAsset
                {
                    Dapp = dapp
                }
            };

            var dappBytes = dappTransaction.GetBytes();
            dappTransaction.Signature = CryptoHelper.Sign(dappBytes, genesisAccount.Address.KeyPair.PrivateKey).ToHex();
            dappTransaction.Id = CryptoHelper.GetId(dappBytes);

            transactions.Add(dappTransaction);
            
            var sortedTransactions = transactions.OrderBy(t => (int) t.Type).ThenBy(t => t.Amount).ToList();
            var payloadLength = 0;
            var hashBuf = new List<byte>();
            foreach (var sortedTransaction in sortedTransactions)
            {
                var trBytes = sortedTransaction.GetBytes();
                payloadLength += trBytes.Length;
                hashBuf.AddRange(trBytes);
            }
            var payloadHash = CryptoHelper.Sha256(hashBuf.ToArray());
            var block = new Block
            {
               Version = 0,
               TotalAmount = 0,
               TotalFee = 0,
               PayloadHash = payloadHash.ToHex(),
               Timestamp = 0,
               NumberOfTransactions = sortedTransactions.Count,
               PayloadLength = payloadLength,
               PreviousBlock = null,
               GeneratorPublicKey = sender.Address.KeyPair.PublicKey.ToHex(),
               Transactions = sortedTransactions,
               Height = 1
            };
            var blockBytes = block.GetBytes();
            block.BlockSignature = CryptoHelper.Sign(blockBytes, sender.Address.KeyPair.PrivateKey).ToHex();
            block.Id = CryptoHelper.GetId(blockBytes).ToString();
            return block;
        }

        public static DappTransactionBlock CreateFromBlock(Block genesisBlock, Account genesisAccount, Dapp dapp)
        {
            var sender = AccountHelper.GetAccount(CryptoHelper.GenerateSecret());

            foreach (var transaction in genesisBlock.Transactions)
            {
                if (transaction.Type == TransactionType.Dapp)
                {
                    var asset = (DappAsset) transaction.Asset;
                    if (asset != null)
                    {
                        if (asset.Dapp.Name == dapp.Name )
                        {
                            throw new DappException(string.Format("Dapp with name {0} already exist", dapp.Name));
                        }
                        if (asset.Dapp.Git == dapp.Git)
                        {
                            throw new DappException(string.Format("Dapp with git {0} already exist", dapp.Git));
                        }
                        if (asset.Dapp.Link == dapp.Link)
                        {
                            throw new DappException(string.Format("Dapp with link {0} already exist", dapp.Link));
                        }
                    }
                }
            }

            var dappTransaction = new Transaction
            {
                Type = TransactionType.Dapp,
                Amount = 0,
                Fee = 0,
                Timestamp = 0,
                RecipientId = null,
                SenderId = genesisAccount.Address.IdString,
                SenderPublicKey = genesisAccount.Address.KeyPair.PublicKey.ToHex(),
                Asset = new DappAsset
                {
                    Dapp = dapp
                }
            };

            var dappBytes = dappTransaction.GetBytes();
            dappTransaction.Signature = CryptoHelper.Sign(dappBytes, genesisAccount.Address.KeyPair.PrivateKey).ToHex();
            dappTransaction.Id = CryptoHelper.GetId(dappBytes);

            genesisBlock.PayloadLength += dappBytes.Length;

            var payloadBytes = genesisBlock.PayloadHash.FromHex();

            var trBytes = new byte[payloadBytes.Length + dappBytes.Length];
            Buffer.BlockCopy(payloadBytes, 0, trBytes, 0, payloadBytes.Length);
            Buffer.BlockCopy(dappBytes, payloadBytes.Length, trBytes, 0, dappBytes.Length);

            var trHash = CryptoHelper.Sha256(trBytes);

            genesisBlock.Transactions.Add(dappTransaction);
            genesisBlock.NumberOfTransactions++;
            genesisBlock.GeneratorPublicKey = sender.Address.KeyPair.PublicKey.ToHex();

            var blockBytes = genesisBlock.GetBytes();
            genesisBlock.BlockSignature = CryptoHelper.Sign(blockBytes, sender.Address.KeyPair.PublicKey).ToHex();
            genesisBlock.Id = CryptoHelper.GetId(blockBytes).ToString();

            return new DappTransactionBlock
            {
                Block =  genesisBlock,
                Dapp =  dappTransaction
            };
        }
    }
}
