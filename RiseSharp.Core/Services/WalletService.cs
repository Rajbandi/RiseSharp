using System;
using System.Collections.Generic;
using RiseSharp.Core.Common;

namespace RiseSharp.Core.Services
{
    public class WalletService
    {

        public WalletService()
        {
        }

        public IList<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public IList<Transaction> GetHistory(Account account = null)
        {
            throw new NotImplementedException();
        }

        public bool Transfer(Account account, string toAddress, long amount)
        {
            throw new NotImplementedException();
        }

        public bool Vote(Account account, IEnumerable<string> delegateAddresses)
        {
            throw new NotImplementedException();
        }

        public bool RegiterAsDelegate(Account account, string name)
        {
            throw new NotImplementedException();
        }
    }
}
