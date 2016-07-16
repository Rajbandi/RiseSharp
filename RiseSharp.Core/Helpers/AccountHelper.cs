#region copyright
// <copyright file="AccountHelper.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;
using RiseSharp.Core.Common;

namespace RiseSharp.Core.Helpers
{
    public static class AccountHelper
    {
        public static Account GetAccount(string secret)
        {
            var address = CryptoHelper.GetAddress(secret);
            return new Account
            {
                Address = address
            };
        }

      

    }
}
