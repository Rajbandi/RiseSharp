#region copyright
// <copyright file="Dapp.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
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
    public class Dapp
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "git")]
        public string Git { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "type")]
        public int Type { get; set; }

        [DataMember(Name = "category")]
        public int Category { get; set; }


        public byte[] GetBytes()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(Name);
                    writer.Write(Description);
                    writer.Write(Git);
                    // writer.Write(Link);
                    writer.Write(Type);
                    writer.Write(Category);

                    return stream.ToArray();
                }
            }
        }
    }
}
