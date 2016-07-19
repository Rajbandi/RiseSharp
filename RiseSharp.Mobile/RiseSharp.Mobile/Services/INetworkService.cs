#region copyright
// <copyright file="INetworkService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>19/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RiseSharp.Mobile.Services
{
    public interface INetworkService
    {
        HttpClientHandler GetClientHandler();

        bool IsConnected();
    }
}
