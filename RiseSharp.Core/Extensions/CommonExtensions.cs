#region copyright
// <copyright file="CommonExtensions.cs" >
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
using NBitcoin;
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
                .Where(x => x%2 == 0)
                .Select(x => Convert.ToByte(str.Substring(x, 2), 16))
                .ToArray();
        }

        public static byte[] GetBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
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

        public static int ToUnixTimeInSeconds(this DateTime dateTime)
        {
            var dt = (dateTime.Kind != DateTimeKind.Utc) ? dateTime.ToUniversalTime() : dateTime;
            var epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var seconds = (int) (dt - epochTime).TotalSeconds;
            return seconds;
        }

        public static DateTime FromUnixTimeSeconds(this int unixTimeInSeconds)
        {
            var epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epochTime.AddSeconds(unixTimeInSeconds);
        }

        
        public static byte[] TakeBytes(this byte[] bytes, int length)
        {
            var byteArr = new byte[length];
            var index = 0;
            var len = bytes.Length;
            if (length >= len)
                return bytes;
            do
            {
               
                if (index >= len)
                    break;
            } while (bytes[index++] == '0');

            Buffer.BlockCopy(bytes, index, byteArr, 0, length);

            return byteArr;
        }
}
}
