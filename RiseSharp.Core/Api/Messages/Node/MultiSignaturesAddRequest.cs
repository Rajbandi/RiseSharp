#region copyright
// <copyright file="MultiSignaturesAddRequest.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using RiseSharp.Core.Api.Messages.Common;
using RiseSharp.Core.Attributes;

namespace RiseSharp.Core.Api.Messages.Node
{
    public class MultiSignaturesAddRequest : BaseRequest
    {
        [QueryParam(Name = "secret")]
        public string Secret { get; set; }

        [QueryParam(Name = "secondSecret")]
        public string SecondSecret { get; set; }

        [QueryParam(Name="publicKey")]
        public string PublicKey { get; set; }

        [QueryParam(Name = "min")]
        public int? Min { get; set; }

        [QueryParam(Name = "lifetime")]
        public int? Lifetime { get; set; }
        
        [QueryParam(Name = "keysgroup")]
        public IList<string> KeysGroup { get; set; }

    }
}
