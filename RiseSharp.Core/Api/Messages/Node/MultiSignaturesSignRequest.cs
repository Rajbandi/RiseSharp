#region copyright
// <copyright file="MultiSignaturesSignRequest.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Attributes;

namespace RiseSharp.Core.Api.Messages.Node
{
    public class MultiSignaturesSignRequest : BaseRequest
    {
        [QueryParam(Name = "secret")]
        public string Secret { get; set; }

        [QueryParam(Name = "secondSecret")]
        public string SecondSecret { get; set; }

        [QueryParam(Name="publicKey")]
        public string PublicKey { get; set; }

        [QueryParam(Name = "transactionId")]
        public string TransactionId { get; set; }
    }
}
