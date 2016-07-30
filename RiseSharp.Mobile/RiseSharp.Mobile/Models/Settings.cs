#region copyright
// <copyright file="Settings.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under Apache 2.0
// </copyright>
// <author>Raj Bandi</author>
// <date>28/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;

namespace RiseSharp.Mobile.Models
{
    [DataContract]
    public class Settings
    {

        [DataMember(Name = "isprotected")]
        public bool IsSecurityEnabled { get; set; }

    }
}
