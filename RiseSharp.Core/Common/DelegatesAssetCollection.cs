#region copyright
// <copyright file="DelegatesAssetCollection.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RiseSharp.Core.Common
{
    [DataContract]
    public class DelegatesAssetCollection
    {
        public DelegatesAssetCollection()
        {
            
        }

        public DelegatesAssetCollection(IEnumerable<string> delegates)
        {
            List.AddRange(delegates);
        }

        [DataMember(Name = "list")]
        public List<string> List = new List<string>(); 
    }
}
