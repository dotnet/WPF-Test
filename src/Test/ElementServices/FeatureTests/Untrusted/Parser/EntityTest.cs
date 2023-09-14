// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Avalon.Test.CoreUI.Trusted;
using Avalon.Test.CoreUI;
using System.Threading;
using System.Windows.Threading;

using System.Reflection;
using System.Collections;
using System.Xml;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using System.Windows.Markup;
using System.Runtime.InteropServices;
using Avalon.Test.CoreUI.Common;

using Avalon.Test.CoreUI.Source;
using Microsoft.Test.Win32;
using Microsoft.Test;
using Microsoft.Test.Discovery;

namespace Avalon.Test.CoreUI.Parser
{
	/// <summary>
	/// Testing XML entities
	/// </summary>
	/// <remarks>
	/// This class uses a XmlValidatingReader to parse a XAML file having XML entities
	/// If the XAML parses fine, it passes the test and fails the test otherwise.
	/// </remarks>
    [TestDefaults]
	public class EntityTest
	{
		#region RunTest
		/// <summary>
		/// Test case Entry point
		/// </summary>
		public void RunTest()
		{
			ValidateAndParse("EntityTest.xaml");
		}
		#endregion RunTest

		/// <summary>
		/// Method to parse XAML using a XmlValidatingReader
		/// </summary>
		/// <param name="filename">File to be parsed</param>
		private void ValidateAndParse(string filename)
		{
			// We need the context for parsing XAML files
			CreateContext();

			CoreLogger.LogStatus("Parsing XAML file: " + filename);
			Stream xamlFileStream = File.OpenRead(filename);
			object root = null;
			try
			{
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.ProhibitDtd = false;
				settings.ValidationType = ValidationType.DTD;
				root = System.Windows.Markup.XamlReader.Load(XmlReader.Create(xamlFileStream, settings));
				CoreLogger.LogTestResult(true, "Test passed.");
			}
			finally
			{
				// done with the stream
				xamlFileStream.Close();
			}
		}

		static Dispatcher s_dispatcher;

		/// <summary>
		/// Creating Dispatcher
		/// </summary>
		private void CreateContext()
		{
            s_dispatcher = Dispatcher.CurrentDispatcher;   
		}
	}
}
