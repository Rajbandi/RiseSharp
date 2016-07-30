#region copyright
// <copyright file="IDatabaseService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseSharp.Mobile.Models;

namespace RiseSharp.Mobile.Services
{
    public interface IDatabaseService
    {
        IEnumerable<WalletAddress> GetWalletAddresses();

        void SaveWalletAddress(WalletAddress address);

        void DeleteAddress(string address);

        WalletAddress GetWalletAddress();

        Settings GetSettings();

        void SaveSettings();
    }
}
