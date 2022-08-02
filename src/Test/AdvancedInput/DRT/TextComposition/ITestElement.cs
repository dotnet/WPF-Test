// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace DRT
{

    public interface ITestElement
    {

         //
         // Get the current text composition.
         //
         TextComposition TextComposition
         {
            get;
         }
    }
}

