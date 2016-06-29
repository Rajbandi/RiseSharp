#region copyright
// <copyright file="DelegateUsernameAsset.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RiseSharp.Core.Common
{
    [DataContract]
    public class DelegateUsernameAsset : Asset
    {
        [DataMember(Name = "delegate")]
        public DelegateUsername Delegate { get; set; }

        public override byte[] GetBytes()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(Delegate.Username);
                }
                return stream.ToArray();
            }
        }
    }
}
