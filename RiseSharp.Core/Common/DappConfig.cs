#region copyright
// <copyright file="DappConfig.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Runtime.Serialization;

namespace RiseSharp.Core.Common
{
    public class DappConfig
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "sdk_link")]
        public string SdkLink { get; set; }

        [DataMember(Name = "git")]
        public string Git { get; set; }

        [DataMember(Name = "gitusername")]
        public string GitUsername { get; set; }

        [DataMember(Name = "gitpassword")]
        public string GitPassword { get; set; }

        [DataMember(Name = "secret")]
        public string Secret { get; set; }

        [DataMember(Name = "publickeys")]
        public string PublicKeys { get; set; }

        [DataMember(Name = "isgit")]
        public bool IsGit { get; set; }

        [DataMember(Name = "newgenesisblock")]
        public bool NewGenesisBlock { get; set; }


        public Dapp ToDapp()
        {
            return new Dapp
            {
                Name = Name,
                Description = Description,
                Git = Git,
                Link = SdkLink
            };
        }
    }
}
