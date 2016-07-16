#region copyright
// <copyright file="SvgImage.cs" >
// Copyright (c) 2016 Raj Bandi All Rights Reserved
// Licensed under MIT
// </copyright>
// <author>Raj Bandi</author>
// <date>16/7/2016</date>
// <summary></summary>
#endregion
using System.Reflection;
using Xamarin.Forms;

namespace RiseSharp.Mobile.Controls
{
    public class SvgImage : Image
    {
        /// <summary>
        /// The path to the svg file
        /// </summary>
        public static readonly BindableProperty SvgPathProperty =
          BindableProperty.Create("SvgPath", typeof(string), typeof(SvgImage), default(string));

        /// <summary>
        /// The path to the svg file
        /// </summary>
        public string SvgPath
        {
            get { return (string)GetValue(SvgPathProperty); }
            set { SetValue(SvgPathProperty, value); }
        }

        /// <summary>
        /// The assembly containing the svg file
        /// </summary>
        public static readonly BindableProperty SvgAssemblyProperty =
          BindableProperty.Create("SvgAssembly", typeof(Assembly), typeof(SvgImage), default(Assembly));

        /// <summary>
        /// The assembly containing the svg file
        /// </summary>
        public Assembly SvgAssembly
        {
            get { return (Assembly)GetValue(SvgAssemblyProperty); }
            set { SetValue(SvgAssemblyProperty, value); }
        }
    }
}
