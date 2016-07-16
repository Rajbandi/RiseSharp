#region copyright
// <copyright file="BaseResponse.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace RiseSharp.Core.Api.Messages.Common
{
    /// <summary>
    /// Base response class for all the api response classes. Every api response object should be inherited from this class.
    /// </summary>
    [DataContract]
    public abstract class BaseResponse
    {
        [DataMember(Name = "success", Order = 1)]
        public bool Success { get; set; }

        [DataMember(Name = "error", Order = 2, EmitDefaultValue = false, IsRequired = false)]
        public string Error { get; set; }

        [DataMember(Name = "message", Order = 3, EmitDefaultValue = false, IsRequired = false)]
        public string Message { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
