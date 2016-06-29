#region copyright
// <copyright file="Delegate.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;

namespace RiseSharp.Core.Api.Models
{
    [DataContract]
    public class Delegate
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "publickey")]
        public string PublicKey { get; set; }

        [DataMember(Name = "vote")]
        public string Vote { get; set; }

        [DataMember(Name = "producedblocks")]
        public int Producedblocks { get; set; }

        [DataMember(Name = "missedblocks")]
        public int Missedblocks { get; set; }

        [DataMember(Name = "rate")]
        public int Rate { get; set; }

        [DataMember(Name = "approval")]
        public double Approval { get; set; }

        [DataMember(Name = "productivity")]
        public double Productivity { get; set; }
    }

}
