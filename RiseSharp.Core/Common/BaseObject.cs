#region copyright
// <copyright file="BaseObject.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using Newtonsoft.Json;

namespace RiseSharp.Core.Common
{
    public abstract class BaseObject
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}