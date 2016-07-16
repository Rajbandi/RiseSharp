#region copyright
// <copyright file="BaseRequest.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Collections.Generic;
using System.Reflection;
using RiseSharp.Core.Api.Models;
using RiseSharp.Core.Attributes;
using Newtonsoft.Json;

namespace RiseSharp.Core.Api.Messages.Common
{
    public abstract class BaseRequest
    {
        protected readonly List<string> QueryParams = new List<string>();

        [QueryParam(Name = "limit")]
        public int? Limit { get; set; }

        [QueryParam(Name = "offset")]
        public int? Offset { get; set; }

        [QueryParam(Name = "orderBy")]
        public string OrderBy { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public virtual string ToQuery()
        {
            var propCollection = GetType().GetRuntimeProperties();

            foreach (PropertyInfo property in propCollection)
            {
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    var attr = attribute as QueryParamAttribute;
                    if (attr != null)
                    {
                        var val = property.GetValue(this);
                        if (val != null)
                            QueryParams.Add($"{attr.Name}={val}");
                    }
                }
            }

            return string.Join("&", QueryParams.ToArray());
        }

        public IEnumerable<HeaderValue> GetHeaderValues()
        {
            var headerValues = new List<HeaderValue>();

            var propCollection = GetType().GetRuntimeProperties();

            foreach (PropertyInfo property in propCollection)
            {
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    var attr = attribute as HeaderValueAttribute;
                    if (attr != null)
                    {
                        var val = property.GetValue(this) ?? attr.Default;
                        if (val != null)
                        {
                            headerValues.Add(new HeaderValue(attr.Name, val.ToString()));
                        }
                    }
                }
            }

            return headerValues;
        }
    }
}
