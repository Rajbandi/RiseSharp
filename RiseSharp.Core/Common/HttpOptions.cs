#region copyright
// <copyright file="HttpOptions.cs" >
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
using System.Threading;
using System.Threading.Tasks;

namespace RiseSharp.Core.Common
{
    public class HttpOptions
    {
        public string Url { get; set; }
        public IProgress<double> Progress { get; set; }
        public CancellationToken Token { get; set; }
    }
}
