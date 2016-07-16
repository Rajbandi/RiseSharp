#region copyright
// <copyright file="DappResult.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseSharp.Core.Common
{
    public class DappResult
    {
        public string GenesisBlock { get; set; }

        public string BlockChain { get; set; }

        public string Error { get; set; }

        public string Path { get; set; }

        public bool IsGit { get; set; }
    }
}
