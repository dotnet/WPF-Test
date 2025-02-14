// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Avalon.Test.ComponentModel
{

  using System;
  using System.Windows;
  using System.Windows.Controls;
  using Microsoft.Test.Logging;
  using Microsoft.Test.Input;

  public partial class ExternallyDefinedControlClass
  {

    Microsoft.Test.Logging.TestLog _log = new Microsoft.Test.Logging.TestLog("ExternallyDefinedControl");

    void OnLoaded (object sender, EventArgs e)
    {
	_log.LogStatus("About to click on the externally defined custom control.");
        UserInput.MouseLeftClickCenter (Button1);
	_log.LogStatus("Just clicked on the control.");
    }

    void HandleClick(object sender, RoutedEventArgs e)
    {
	_log.LogStatus("Just entered click event handler.");
	_log.LogStatus("Verified click handler works for clicking on an externally defined control.");

	if (sender == Button1)
	{
		_log.LogStatus("Click event was sent by the correct control.");
		_log.Result = TestResult.Pass;
	}
	else
	{
		_log.LogStatus("Click event was sent by some source other than the clicked control.");
		_log.Result = TestResult.Fail;
	}
	_log.Close();

	System.Windows.Application.Current.Shutdown();
    }
  }

}
