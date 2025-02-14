﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.Test.Xaml.Types.Schema;

namespace Microsoft.Test.Xaml.Schema.MethodTests.XamlTypeTests
{
    /// <summary>
    /// Tests for XamlType.GetEnumeratorMethod
    /// </summary>
    public class GetEnumeratorMethodTests : XamlTypeTestBase
    {
        /// <summary>
        /// Collection type with GetEnumerator method
        /// </summary>
        public void CollectionTypeWithGetEnumeratorMethodTest()
        {
            GetEnumeratorMethodTest(typeof(TypeWithGetEnumeratorAndOneParameterAddMethod));
        }
    }
}
