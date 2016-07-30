#region copyright
// <copyright file="INetworkService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System.Net.Http;

namespace RiseSharp.Mobile.Services
{
    public interface INetworkService
    {
        HttpMessageHandler GetMessageHandler();
        HttpClientHandler GetClientHandler();

        bool IsConnected { get; }
    }
}
