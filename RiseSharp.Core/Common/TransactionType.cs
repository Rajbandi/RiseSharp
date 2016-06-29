#region copyright
// <copyright file="TransactionType.cs" >
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

namespace RiseSharp.Core.Common
{
    public enum TransactionType
    {
        Send = 0,
        Signature = 1,
        Delegate = 2,
        Vote = 3,
        Multi = 4,
        Dapp = 5,
        InTransfer = 6,
        OutTransfer = 7

    }
}
