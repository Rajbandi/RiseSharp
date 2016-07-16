#region copyright
// <copyright file="RiseSharpException.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseSharp.Core.Exceptions
{
    public class RiseSharpException : Exception
    {
        public RiseSharpException()
        {
            
        }

        public RiseSharpException(string message) : base(message)
        {
            
        }

        public RiseSharpException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}
