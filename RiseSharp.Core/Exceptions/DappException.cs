#region copyright
// <copyright file="DappException.cs" >
// Copyright (c) 2016 All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>26/6/2016</date>
// <summary></summary>
#endregion
using System;

namespace RiseSharp.Core.Exceptions
{
    public class DappException : Exception
    {
        public DappException() 
        {
            
        }

        public DappException(string message) : base(message)
        {
            
        }

        public DappException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}
