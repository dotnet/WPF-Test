using System;
using WFCTestLib.Util;
using WFCTestLib.Log;
using ReflectTools;
using WPFReflectTools;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Forms.Integration;

using SWF = System.Windows.Forms;
using SD = System.Drawing;

//
// Testcase:    ScalingAndTransforms
// Description: Verify the expected behaviors when an AV container is Scaled or Transformed
// Author:      a-wboyde
//
namespace WindowsFormsHostTests
{

public class ScalingAndTransforms : WPFReflectBase
{
    #region Testcase setup
    public ScalingAndTransforms(string[] args) : base(args) { }

    // class vars
    private StackPanel sp;
    private WindowsFormsHost wfh1;
    private WindowsFormsHost wfh2;
    private SWF.Button wfb1;
    private SWF.Button wfb2;
    private SWF.Button wfb3;
    private Label lab1;

    protected override void InitTest(TParams p)
    {
        this.Title = "Scaling And Transforms";
        this.Topmost = true;
        this.Topmost = false;
        this.Width = 500;
        this.Height = 500;

        base.InitTest(p);
    }
    #endregion

    //==========================================
    // Scenarios
    //==========================================
    #region Scenarios
    [Scenario("1) Scale the StackPanel x2 and verify that button is resized but the font remains")]
    public ScenarioResult Scenario1(TParams p)
    {
        ScenarioResult sr = new ScenarioResult();
        SetUpControls();

        // save original button sizes
        SD.Size sizBtn1 = wfb1.ClientSize;
        SD.Size sizBtn2 = wfb2.ClientSize;
        SD.Size sizBtn3 = wfb3.ClientSize;

        // "Scale the StackPanel x2"
        TransformGroup group = new TransformGroup();
        group.Children.Add(sp.LayoutTransform);
        group.Children.Add(new ScaleTransform(2d, 2d));
        sp.LayoutTransform = group;
        MyPause();

        // "verify that button is resized but the font remains"

        // first two buttons should be double in width and height
        WPFMiscUtils.IncCounters(sr, sizBtn1.Width * 2, wfb1.ClientSize.Width, "Button 1 not expected Width", p.log);
        WPFMiscUtils.IncCounters(sr, sizBtn1.Height * 2, wfb1.ClientSize.Height, "Button 1 not expected Height", p.log);
        WPFMiscUtils.IncCounters(sr, sizBtn2.Width * 2, wfb2.ClientSize.Width, "Button 2 not expected Width", p.log);
        WPFMiscUtils.IncCounters(sr, sizBtn2.Height * 2, wfb2.ClientSize.Height, "Button 2 not expected Height", p.log);

        // since button 3 is stretched to width of StackPanel, it's width should not change, but height should
        WPFMiscUtils.IncCounters(sr, sizBtn3.Width, wfb3.ClientSize.Width, "Button 3 not expected Width", p.log);
        WPFMiscUtils.IncCounters(sr, sizBtn3.Height * 2, wfb3.ClientSize.Height, "Button 3 not expected Height", p.log);

        // check for font by seeing if there are any black pixels visible in button image
        this.Topmost = true;
        SD.Bitmap bmpBtn1 = Utilities.GetBitmapOfControl(wfb1);
        SD.Bitmap bmpBtn2 = Utilities.GetBitmapOfControl(wfb2);
        SD.Bitmap bmpBtn3 = Utilities.GetBitmapOfControl(wfb3);
        this.Topmost = false;

        WPFMiscUtils.IncCounters(sr, p.log, Utilities.ContainsColor(bmpBtn1, SD.Color.Black),
            "Cannot find any font color in button 1");
        WPFMiscUtils.IncCounters(sr, p.log, Utilities.ContainsColor(bmpBtn2, SD.Color.Black),
            "Cannot find any font color in button 2");
        WPFMiscUtils.IncCounters(sr, p.log, Utilities.ContainsColor(bmpBtn3, SD.Color.Black),
            "Cannot find any font color in button 3");

        return sr;
    }

    [Scenario("2) Rotate the StackPanel 180 degrees and verify that the button has been repositioned but not rotated and it's size remains the same")]
    public ScenarioResult Scenario2(TParams p)
    {
        ScenarioResult sr = new ScenarioResult();
        SetUpControls();

        //// debug - create window with manual test code !!!
        //Win win = new Win();
        //win.Show();
        //Utilities.ActiveFreeze();

        // save original button locations in screen coordinates (b = before)
        SD.Point ptBtn1b = wfb1.PointToScreen(wfb1.Location);
        SD.Point ptBtn2b = wfb2.PointToScreen(wfb2.Location);
        SD.Point ptBtn3b = wfb3.PointToScreen(wfb3.Location);

        // save original button sizes
        SD.Size sizBtn1 = wfb1.ClientSize;
        SD.Size sizBtn2 = wfb2.ClientSize;
        SD.Size sizBtn3 = wfb3.ClientSize;

        // "Rotate the StackPanel 180 degrees"
        TransformGroup group = new TransformGroup();
        group.Children.Add(sp.LayoutTransform);
        group.Children.Add(new RotateTransform(180d));
        sp.LayoutTransform = group;
        MyPause();

        // "verify that the button has been repositioned"

        // get current locations of buttons (a = after)
        SD.Point ptBtn1a = wfb1.PointToScreen(wfb1.Location);
        SD.Point ptBtn2a = wfb2.PointToScreen(wfb2.Location);
        SD.Point ptBtn3a = wfb3.PointToScreen(wfb3.Location);

        // Note: since rotating 180 degrees, x coordinate should be the same, Y coordinate should be larger
        WPFMiscUtils.IncCounters(sr, ptBtn1b.X, ptBtn1a.X, "Button 1 X coordinate not as expected", p.log);
        WPFMiscUtils.IncCounters(sr, ptBtn2b.X, ptBtn2a.X, "Button 2 X coordinate not as expected", p.log);
        WPFMiscUtils.IncCounters(sr, ptBtn3b.X, ptBtn3a.X, "Button 3 X coordinate not as expected", p.log);
        WPFMiscUtils.IncCounters(sr, p.log, ptBtn1a.Y > ptBtn1b.Y, "Button 1 Y coordinate not as expected");
        WPFMiscUtils.IncCounters(sr, p.log, ptBtn2a.Y > ptBtn2b.Y, "Button 2 Y coordinate not as expected");
        WPFMiscUtils.IncCounters(sr, p.log, ptBtn3a.Y > ptBtn3b.Y, "Button 3 Y coordinate not as expected");

        // "and it's size remains the same"
        WPFMiscUtils.IncCounters(sr, sizBtn1, wfb1.ClientSize, "Button 1 size has changed", p.log);
        WPFMiscUtils.IncCounters(sr, sizBtn2, wfb2.ClientSize, "Button 2 size has changed", p.log);
        WPFMiscUtils.IncCounters(sr, sizBtn3, wfb3.ClientSize, "Button 3 size has changed", p.log);

        return sr;
    }

    #endregion
    
    #region Helper Functions

    private void SetUpControls()
    {
        // set up controls
        sp = new StackPanel();

        // create some random labels as separators
        lab1 = new Label();
        lab1.Content = "Avalon Label 1";
        lab1.Background = Brushes.LightBlue;
        Label lab2 = new Label();
        lab2.Content = "Avalon Label 2";
        lab2.Background = Brushes.LightGreen;
        Label lab3 = new Label();
        lab3.Content = "Avalon Label 3";
        lab3.Background = Brushes.LightPink;

        // create WFH with panel with multiple WF controls
        wfh1 = new WindowsFormsHost();
        SWF.Panel wfp = new SWF.Panel();

        // create two wf buttons
        wfb1 = new SWF.Button();
        wfb1.Text = "HELLO FROM WF BUTTON 1";
        wfb1.Width = 200;
        wfb2 = new SWF.Button();
        wfb2.Text = "Hello from wf button 2";
        wfb2.Width = 200;

        // put buttons in panel
        wfb2.Top = wfb1.Bottom;
        wfp.Controls.Add(wfb1);
        wfp.Controls.Add(wfb2);
        wfh1.Child = wfp;

        // create WFH with another WF control
        wfh2 = new WindowsFormsHost();

        // note extra spaces in text so that center of button is free of text!
        // this helps when attempting to validate "Radial Gradients"
        wfb3 = new SWF.Button();
        wfb3.Text = "HELLO FROM     WF BUTTON 3";
        wfb3.Width = 200;
        wfh2.Child = wfb3;

        // add stuff to StackPanel
        sp.Children.Add(lab1);
        sp.Children.Add(wfh1);
        sp.Children.Add(lab2);
        sp.Children.Add(wfh2);
        sp.Children.Add(lab3);

        this.Content = sp;
        MyPause();
    }

    private static void MyPause()
    {
        WPFReflectBase.DoEvents();
        SWF.Application.DoEvents();
        System.Threading.Thread.Sleep(500);
    }

    #endregion

    #region Manual Test Code

    public class Win : Window
    {
        WindowsFormsHost host;

        public Win()
        {
            SWF.Button button = new SWF.Button();

            host = new WindowsFormsHost();
            host.Background = Brushes.Blue;
            this.Background = Brushes.Beige;
            button.Text = "WF Button";
            button.Click += delegate
            {
                host.Padding = new Thickness();
                host.Margin = new Thickness();
            };
            host.Child = button;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(host);

            Button avButton = new Button();
            avButton.Content = "Scale x2";
            avButton.Click += delegate
            {
                TransformGroup group = new TransformGroup();
                group.Children.Add(stackPanel.LayoutTransform);
                group.Children.Add(new ScaleTransform(2d, 2d));
                stackPanel.LayoutTransform = group;

            };
            stackPanel.Children.Add(avButton);

            avButton = new Button();
            avButton.Content = "Scale / 2";
            avButton.Click += delegate
            {
                TransformGroup group = new TransformGroup();
                group.Children.Add(stackPanel.LayoutTransform);
                group.Children.Add(new ScaleTransform(0.5d, 0.5d));
                stackPanel.LayoutTransform = group;

            };
            stackPanel.Children.Add(avButton);

            avButton = new Button();
            avButton.Content = "Rotate 180";
            avButton.Click += delegate
            {
                TransformGroup group = new TransformGroup();
                group.Children.Add(stackPanel.LayoutTransform);
                group.Children.Add(new RotateTransform(180d));
                stackPanel.LayoutTransform = group;

            };
            stackPanel.Children.Add(avButton);

            Content = stackPanel;
        }
    }

    #endregion
}
}

// Keep these in sync by running the testcase locally through the driver whenever
// you add, remove, or rename scenarios.
//
// [Scenarios]
//@ 1) Scale the StackPanel x2 and verify that button is resized but the font remains

//@ 2) Rotate the StackPanel 180 degrees and verify that the button has been repositioned but not rotated and it's size remains the same
