using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RiseSharp.Core.Api;
using RiseSharp.Core.Api.Messages.Node;
using RiseSharp.Core.Api.Messages.Peer;
using RiseSharp.Core.Api.Models;
using RiseSharp.Core.Common;
using RiseSharp.Core.Exceptions;
using RiseSharp.Core.Helpers;
using Transaction = RiseSharp.Core.Common.Transaction;

namespace RiseSharp.Core.Services
{
    public class AccountService
    {
        private readonly string _secret;
        private readonly string _secondSecret;
        private readonly ApiInfo _apiInfo;
        private readonly IRiseNodeApi _nodeApi;
        private readonly IRisePeerApi _peerApi;
        private readonly Address _address;

        public AccountService(string secret, string secondSecret="", ApiInfo apiInfo = null )
        {
            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new RiseSharpException("Secret is required");
            }

            if (_apiInfo == null)
            {
                _apiInfo = ApiInfo.GetDefaultApiInfo();
            }
            
            _nodeApi = new RiseNodeApi(_apiInfo);
            _peerApi = new RisePeerApi(_apiInfo);

            _secret = secret;
            _secondSecret = secondSecret;
            _address = CryptoHelper.GetAddress(_secret);
        }

        public string Secret => _secret;

        public string SecondSecret => _secondSecret;

        public Address GetAddress() => _address;

        /// <summary>
        /// Gets account details from a peer asynchronously 
        /// </summary>
        /// <returns>Account details</returns>
        public async Task<Api.Models.Account> GetAccountAsync()
        {
            var response = await _nodeApi.GetAccountAsync(new AccountRequest
            {
                Address = GetAddress().IdString
            });

            return response.Account;
        }

        /// <summary>
        /// Gets account details from a peer synchronously 
        /// </summary>
        /// <returns>Account details</returns>
        public Api.Models.Account GetAccount()
        {
            var response = GetAccountAsync().GetAwaiter().GetResult();
            return response;
        }

        public bool Send(string recipientId, string amount)
        {
            long amt;
            long.TryParse(amount, out amt);
            return SendAsync(recipientId, amt).GetAwaiter().GetResult();

        }
        /// <summary>
        /// Transfers an amount to recipient synchronously
        /// </summary>
        /// <param name="recipientId">recipient id</param>
        /// <param name="amount">amount</param>
        /// <returns></returns>
        public bool Send(string recipientId, long amount)
        {
            return SendAsync(recipientId, amount).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Transfers an amount to recipient asynchronously 
        /// </summary>
        /// <param name="recipientId">recipientid</param>
        /// <param name="amount">amount</param>
        /// <returns></returns>
        public async Task<bool> SendAsync(string recipientId, long amount)
        {
            if (string.IsNullOrWhiteSpace(recipientId))
            {
                throw new AccountException("Invalid recipient Id");
            }

            if (!recipientId.EndsWith(Constants.AddressSuffix, StringComparison.Ordinal))
            {
                throw new AccountException(
                    $"Invalid recipient id {recipientId}, always ends with {Constants.AddressSuffix}");
            }

            var amt = (long)(amount * Math.Pow(10, 8));
            var account = await GetAccountAsync();
            if (account.SecondSignature == 1 && string.IsNullOrWhiteSpace(_secondSecret))
            {
                throw new AccountException("Second signature is required.");
            }
            long bal;
            long.TryParse(account.Balance, out bal);
            if (bal == 0 || bal <= amt)
            {
                throw new AccountException("Account balance not sufficient");
            }
            if (amt < 0)
            {
                amt = bal + amt;
            }

            var trs = new Transaction
            {
                Type = TransactionType.Send,
                Amount = amt,
                Fee = Constants.Fees.Send,
                RecipientId = recipientId,
                Timestamp = TransactionHelper.GetUnixTransactionTime()
            };

            TransactionHelper.SignTransaction(ref trs, _secret, _secondSecret);

            var req = new PeerTransactionsRequest
            {
                Transaction = trs
            };

            var response = await _peerApi.SendTransactionAsync(req);
            if (!response.Success)
            {
                throw new AccountException(response.Message);
            }

            return true;
        }

        /// <summary>
        /// Votes upto 30 delegates
        /// </summary>
        /// <param name="publicKeys">public keys</param>
        /// <returns>Vote successful or not</returns>
        public bool Vote(IEnumerable<string> publicKeys)
        {
            return VoteAsync(publicKeys).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Votes upto 30 delegates
        /// </summary>
        /// <param name="publicKeys">public keys</param>
        /// <returns>Vote successful or not</returns>
        public async Task<bool> VoteAsync(IEnumerable<string> publicKeys)
        {
            var enumerable = publicKeys as string[] ?? publicKeys.ToArray();
            if (publicKeys == null || !enumerable.Any())
            {
                throw new AccountException("one or more delegate publickeys are required. You can pass upto 30 delegate publicKeys");
            }

            var keys = enumerable.Select(x => !x.StartsWith("+", StringComparison.Ordinal) ? "+" + x : x).ToList();
            
            long amount = 0;//(long)(0 * Math.Pow(10, 8));
            var trs = new Transaction
            {
                Type = TransactionType.Vote,
                Amount = amount,
                Fee = Constants.Fees.Vote,
                RecipientId = _address.IdString,
                Timestamp = TransactionHelper.GetUnixTransactionTime(),
                Asset = new DelegateVoteAsset
                {
                    Votes = keys
                }
            };

            TransactionHelper.SignTransaction(ref trs, _secret, _secondSecret);
            var req = new PeerTransactionsRequest { Transaction = trs };
            var response = await _peerApi.SendTransactionAsync(req);
            if (!response.Success)
            {
                throw new AccountException(response.Message);
            }

            return true;
        }


        
    }
}
