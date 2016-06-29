#region copyright
// <copyright file="CommonExtensions.cs" >
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
using System.Text;
using System.Threading.Tasks;
using NBitcoin.DataEncoders;

namespace RiseSharp.Core.Extensions
{
    public static class CommonExtensions
    {
        public static string ToHex(this byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public static byte[] FromHex(this string str)
        {
            return Enumerable.Range(0, str.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(str.Substring(x, 2), 16))
                    .ToArray();
        }
        public static byte[] GetBytes(this long val)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return bytes;
        }
        public static long GetLongBytes(this byte[] val)
        {
            long longValue = BitConverter.ToInt64(val, 0);
            return longValue;
        }
        public static byte[] GetBytes(this int val)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return bytes;
        }

        public static int GetBytes(this byte[] val)
        {
            int intValue = BitConverter.ToInt32(val, 0);
            return intValue;
        }

        public static string ToBase64(this byte[] bytes)
        {
            return new Base64Encoder().EncodeData(bytes);
        }

        public static byte[] FromBase64(this string str)
        {
            return new Base64Encoder().DecodeData(str);
        }
    }
}
