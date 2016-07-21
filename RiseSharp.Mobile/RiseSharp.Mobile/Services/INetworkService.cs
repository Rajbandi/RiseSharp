#region copyright
// <copyright file="INetworkService.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>19/7/2016</date>
// <summary></summary>
#endregion

using System.Net.Http;

namespace RiseSharp.Mobile.Services
{
    public interface INetworkService
    {
        HttpMessageHandler GetClientHandler();

        bool IsConnected { get; }
    }
}
