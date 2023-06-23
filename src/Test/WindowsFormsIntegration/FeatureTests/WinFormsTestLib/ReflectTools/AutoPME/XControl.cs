using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using SystemPens = System.Drawing.SystemPens;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using WFCTestLib.Util;
using WFCTestLib.Log;
using ReflectTools;
using System.Runtime.InteropServices;

namespace ReflectTools.AutoPME
{
    public abstract class XControl : XComponent
    {
        private Control c;

        private Control newC;   // a newly-created object for use with testing Reset properties

        public XControl(String[] args) : base(args) { }

        protected override void InitTest(TParams p)
        {
            base.InitTest(p);
            ExcludedEvents.Add("UserPreferenceChanged");
            ExcludedEvents.Add("UserPreferenceChanging");
            // Exclude the following properties from AutoTest testing
            ExcludedProperties.Add("TopLevel");     // Exclude TopLevel since it can't be set to true if control is parented
            ExcludedProperties.Add("Anchor");       // Do we want to exclude this?
            ExcludedProperties.Add("RightToLeft");  // Can be set to Inherit but never returns it.
            ExcludedProperties.Add("ImeMode");      // Can be set to Inherit but never returns it.
            ExcludedProperties.Add("AllowDrop");    // Fails without UIPermission (expected)
			ExcludedProperties.Add("AutoRelocate"); // Obsolete
            if (PreHandleMode)
                ExcludedProperties.Add("Visible");  // Always returns false before handle is created.

            if (!Utilities.HavePermission(LibSecurity.AllWindows))
                ExcludedProperties.Add("Capture");  // This fails if we don't have AllWindows

            // Initialize the new object
            newC = (Control)CreateObject(p);

            // Exclude Text on Win9x (bug #44781).  There are chars on Win9x that cannot be
            // round-tripped, even if they are valid Unicode characters.
            //
            if (Utilities.IsWin9x)
                ExcludedProperties.Add("Text");
        }

        private Control GetControl(TParams p)
        {
            if (p.target is Control)
                return (Control)p.target;
            else
            {
                p.log.WriteLine("object !instanceof Control");
                return null;
            }
        }

        //
        // AutoTest custom methods for raising events.
        //
        protected virtual void RaisePaint(TParams p)
        {
            Control c = (Control)p.target;
            Graphics g = c.CreateGraphics();
            PaintEventArgs e = new PaintEventArgs(g, p.ru.GetContainedRectangle(c.Bounds));

            InvokeOnEventMethod(p.target, "Paint", new object[] { e });
            g.Dispose();
        }

        protected virtual void RaiseControlRemoved(TParams p)
        {
            ControlEventArgs e = new ControlEventArgs(new Control());

            InvokeOnEventMethod(p.target, "ControlRemoved", new object[] { e });
        }

        protected void RaiseQueryAccessibilityHelp(TParams p)
        {
            // Getting this will raise the event
            p.log.WriteLine("AccessibilityObject.Help returned \"{0}\"", ((Control)p.target).AccessibilityObject.Help);
        }

        protected AccessibleRole GetDefaultAccessibleRoleForType(Type t)
        {
            AccessibleRole ar;
            if (t == typeof(Button))
                ar = AccessibleRole.PushButton;
            else if (t == typeof(ContainerControl))
                ar = AccessibleRole.Client;
            else if (t == typeof(CheckBox))
                ar = AccessibleRole.CheckButton;
            else if (t == typeof(CheckedListBox))
                ar = AccessibleRole.List;
            else if (t == typeof(ComboBox))
                ar = AccessibleRole.ComboBox;
            else if (t == typeof(ContextMenuStrip))
                ar = AccessibleRole.MenuPopup;
            else if (t == typeof(DataGridView))
                ar = AccessibleRole.Table;
            else if (t == typeof(DataGridViewComboBoxEditingControl))
                ar = AccessibleRole.ComboBox;
            else if (t == typeof(DataGridViewTextBoxEditingControl))
                ar = AccessibleRole.Text;
            else if (t == typeof(BindingNavigator))
                ar = AccessibleRole.ToolBar;
            else if (t == typeof(DateTimePicker))
                ar = AccessibleRole.DropList;
            else if (t == typeof(DomainUpDown))
                ar = AccessibleRole.ComboBox;
            else if (t == typeof(FlowLayoutPanel))
                ar = AccessibleRole.Client;
            else if (t == typeof(Form))
                ar = AccessibleRole.Client;
            else if (t == typeof(GroupBox))
                ar = AccessibleRole.Grouping;
            else if (t == typeof(HScrollBar))
                ar = AccessibleRole.ScrollBar;
            else if (t == typeof(Label))
                ar = AccessibleRole.StaticText;
            else if (t == typeof(LinkLabel))
                ar = AccessibleRole.StaticText;
            else if (t == typeof(ListBox))
                ar = AccessibleRole.List;
            else if (t == typeof(ListView))
                ar = AccessibleRole.List;
            else if (t == typeof(MaskedTextBox))
                ar = AccessibleRole.Text;
            else if (t == typeof(MenuStrip))
                ar = AccessibleRole.MenuBar;
            else if (t == typeof(MonthCalendar))
                ar = AccessibleRole.Client;
            else if (t == typeof(NumericUpDown))
                ar = AccessibleRole.ComboBox;
            else if (t == typeof(Panel))
                ar = AccessibleRole.Client;
            else if (t == typeof(PictureBox))
                ar = AccessibleRole.Client;
            else if (t == typeof(PrintPreviewControl))
                ar = AccessibleRole.Client;
            else if (t == typeof(PrintPreviewDialog))
                ar = AccessibleRole.Client;
            else if (t == typeof(ProgressBar))
                ar = AccessibleRole.ProgressBar;
            else if (t == typeof(PropertyGrid))
                ar = AccessibleRole.Client;
            else if (t == typeof(RadioButton))
                ar = AccessibleRole.RadioButton;
            else if (t == typeof(ToolStripContainer))
                ar = AccessibleRole.Client;
            else if (t == typeof(RichTextBox))
                ar = AccessibleRole.Text;
            else if (t == typeof(ScrollableControl))
                ar = AccessibleRole.Client;
            else if (t == typeof(SplitContainer))
                ar = AccessibleRole.Client;
            else if (t == typeof(Splitter))
                ar = AccessibleRole.Client;
            else if (t == typeof(StatusStrip))
                ar = AccessibleRole.StatusBar;
            else if (t == typeof(TabControl))
                ar = AccessibleRole.PageTabList;
            else if (t == typeof(TableLayoutPanel))
                ar = AccessibleRole.Client;
            else if (t == typeof(TabPage))
                ar = AccessibleRole.Client;
            else if (t == typeof(TextBox))
                ar = AccessibleRole.Text;
            else if (t == typeof(ThreadExceptionDialog))
                ar = AccessibleRole.Window;
            else if (t == typeof(ToolStrip))
                ar = AccessibleRole.ToolBar;
            else if (t == typeof(ToolStripDropDown))
                ar = AccessibleRole.MenuPopup;
            else if (t == typeof(ToolStripDropDownMenu))
                ar = AccessibleRole.MenuPopup;
            else if (t == typeof(ToolStripOverflow))
                ar = AccessibleRole.MenuPopup;
            else if (t == typeof(TrackBar))
                ar = AccessibleRole.Slider;
            else if (t == typeof(TreeView))
                ar = AccessibleRole.Outline;
            else if (t == typeof(UserControl))
                ar = AccessibleRole.Client;
            else if (t == typeof(VScrollBar))
                ar = AccessibleRole.ScrollBar;
            else if (t == typeof(WebBrowser))
                ar = AccessibleRole.Client;
            //Note: these types are requirements in certain tests, and aren't in the libs.
            else if (t.Name == "InheritComboBox")
                ar = GetDefaultAccessibleRoleForType(typeof(ComboBox));
            else if (t.Name == "InheritRichTextBox")
                ar = GetDefaultAccessibleRoleForType(typeof(RichTextBox));
            else if (t.Name == "InheritTabControl")
                ar = GetDefaultAccessibleRoleForType(typeof(TabControl));
            else
                throw new ArgumentException("Type " + t.ToString() + " default role not defined.  Please add expected default to the XControl class.  Contact SamuRai for details on what the correct default accessible role should be or see the control reference at http://www.msdn.microsoft.com/library/default.asp?url=/library/en-us/msaa/msaapndx_4erc.asp");
            return ar;
        }
        /**
         * ==================================================
         * TESTS
         * ==================================================
         */
        // Dummy Scenario to be called if the method being tested is marked <InternalOnly/>
        [Scenario(false)]
        protected virtual ScenarioResult InternalOnlyMethod(TParams p)
        {
            p.log.WriteTag("InternalOnly", true);
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult get_Bottom(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("Botom is " + c.Bottom.ToString());
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult get_CanFocus(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("CanFocus is " + c.CanFocus.ToString());
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult get_CanSelect(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("CanSelect is " + c.CanSelect.ToString());
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult set_Capture(TParams p, bool value)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            ScenarioResult sr = new ScenarioResult();
            bool expected = !c.Capture;
            bool bSet = SecurityCheck(sr, delegate
            {
                c.Capture = expected;
            }, typeof(Control).GetMethod("set_Capture"), LibSecurity.AllWindows);
            expected = bSet ? expected : !expected;
            sr.IncCounters(expected, c.Capture, "FAIL: Didn't get expected capture value", p.log);
            return get_Capture(p);
        }

        protected virtual ScenarioResult get_Capture(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            bool b = p.ru.GetBoolean();
            SafeMethods.SetCapture(c, b);
            return new ScenarioResult(b, c.Capture, "FAIL: couldn't get capture", p.log);
        }

        protected virtual ScenarioResult get_ClientRectangle(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Rectangle r = c.ClientRectangle;

            p.log.WriteLine("ClientRectangle is " + r.ToString());
            return new ScenarioResult(r.X == 0 && r.Y == 0 && r.Width == c.ClientSize.Width && r.Height == c.ClientSize.Height);
        }

        protected virtual ScenarioResult set_ClientSize(TParams p, Size value)
        {
            return get_ClientSize(p);
        }

        protected virtual ScenarioResult get_ClientSize(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Size pt = p.ru.GetSize(this.Size);

            p.log.WriteLine("ClientSize was " + c.ClientSize.ToString());
            p.log.WriteLine("ClientSize to be " + pt.ToString());
            c.ClientSize = pt;

            Size ppt = c.ClientSize;

            p.log.WriteLine("ClientSize is " + ppt.ToString());

            // Form can't get narrower than 88 pixels.
            if ((c is Form) && (pt.Width < 88))
                pt.Width = 88;

            return new ScenarioResult(pt.Equals(ppt));
        }

        protected virtual ScenarioResult get_Controls(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            System.Windows.Forms.Control.ControlCollection cc = c.Controls;

            return new ScenarioResult(cc != null);
        }

        protected virtual ScenarioResult get_Created(TParams p)
        {
            ScenarioResult result = new ScenarioResult();

            c = (Control)CreateObject(p);
            result.IncCounters(!c.Created, "FAIL: returned true, expected false", p.log);

            bool expected = true;

            Controls.Add(c);
            Application.DoEvents();
            if (PreHandleMode)
            {
                p.log.WriteLine("Created returns false in PreHandleMode");
                expected = false;
            }

            result.IncCounters(c.Created == expected, "FAIL: after adding control to the Form returned " + c.Created + ", expected " + expected, p.log);
            return result;
        }

        protected virtual ScenarioResult get_DisplayRectangle(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Rectangle r = c.DisplayRectangle;
            Size s = c.ClientSize;

            p.log.WriteLine("DisplayRect is " + r.ToString());
            p.log.WriteLine("ClientSize is " + s.ToString());
            return new ScenarioResult(r.Width == s.Width && r.Height == s.Height);
        }

        protected virtual ScenarioResult get_IsDisposed(TParams p)
        { return Dispose(p); }

        protected virtual ScenarioResult get_Disposing(TParams p)
        { return Dispose(p); }

        protected virtual ScenarioResult set_Enabled(TParams p, bool value)
        { return get_Enabled(p); }

        protected virtual ScenarioResult get_Enabled(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            bool b = c.Enabled;

            p.log.WriteLine("Enabled was " + b.ToString());
            c.Enabled = !b;

            bool bb = c.Enabled;

            p.log.WriteLine("Enabled is " + bb.ToString());
            return new ScenarioResult(b != bb);
        }

        protected virtual ScenarioResult get_Focused(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult result = new ScenarioResult();
            Button b = new Button();
            bool expected = true;

            Controls.Add(b);
            SafeMethods.Focus(b);
            Application.DoEvents();
            result.IncCounters(!c.Focused, "FAIL: returned true expected false", p.log);
            SafeMethods.Focus(c);
            if (PreHandleMode)
            {
                p.log.WriteLine("cannot focus in PreHandleMode");
                expected = false;
            }

            result.IncCounters(c.Focused == expected, "FAIL: returned " + c.Focused + " expected " + expected, p.log);
            return result;
        }

        protected virtual ScenarioResult get_HasChildren(TParams p)
        {
            ScenarioResult result = new ScenarioResult();

            // HasChildren will be false for almost every newly created control
            c = (Control)CreateObject(p);
            result.IncCounters(c.HasChildren == (c.Controls.Count != 0), "FAILED initial state", p.log);

            // Add child and verify HasChildren is now true
            c.Controls.Add(new Button());
            result.IncCounters(c.HasChildren, "FAILED: returned false after child control added", p.log);
            return result;
        }

        protected virtual ScenarioResult set_ImeMode(TParams p, ImeMode value)
        {
            return get_ImeMode(p);
        }

        protected virtual ScenarioResult get_ImeMode(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            System.Windows.Forms.ImeMode imemd = c.ImeMode;

            p.log.WriteLine("initially Got: " + EnumTools.GetEnumStringFromValue(typeof(System.Windows.Forms.ImeMode), (int)imemd));
            if (System.Text.Encoding.Default.CodePage == 932)   // Japanese
                imemd = (ImeMode)p.ru.GetValidJapaneseImeValue();
            else if (System.Text.Encoding.Default.CodePage == 949)  // Korean
                imemd = (ImeMode)p.ru.GetValidKoreanImeValue();
            else
                imemd = (ImeMode)p.ru.GetDifferentEnumValue(typeof(System.Windows.Forms.ImeMode), (int)imemd);

            p.log.WriteLine("Setting to: " + EnumTools.GetEnumStringFromValue(typeof(System.Windows.Forms.ImeMode), (int)imemd));
            c.ImeMode = imemd;

            ImeMode imemd2 = c.ImeMode;

            p.log.WriteLine("retrieved: " + EnumTools.GetEnumStringFromValue(typeof(System.Windows.Forms.ImeMode), (int)imemd2));
            Application.DoEvents();

	    //Added to reflect changes in QFE 4448, in which ImeMode.OnHalf got added but returns ImeMode.On
	    //First check if ImeMode.OnHalf exists
            if (Enum.IsDefined(typeof(System.Windows.Forms.ImeMode), "OnHalf"))
            {
                if(imemd == ImeMode.OnHalf)
		            return new ScenarioResult(imemd2 == ImeMode.On);
            }


            return new ScenarioResult(imemd2 == GetExpectedImeMode(c, imemd));
        }

        protected virtual ScenarioResult get_IsHandleCreated(TParams p)
        {
            ScenarioResult result = new ScenarioResult();

            c = (Control)CreateObject(p);
            result.IncCounters(!c.IsHandleCreated, "FAIL: returned true, expected false", p.log);

            Controls.Add(c);
            Application.DoEvents();

            bool expected = true;

            if (PreHandleMode)
            {
                p.log.WriteLine("In PreHandleMode IsHandleCreated returns false");
                expected = false;
            }

            result.IncCounters(c.IsHandleCreated == expected, "FAIL: returned " + c.IsHandleCreated + ", expected " + expected, p.log);
            return result;
        }

        protected virtual ScenarioResult set_Left(TParams p, int value)
        {
            return get_Left(p);
        }

        protected virtual ScenarioResult get_Left(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // TODO: get real validation for docked controls.
            //       for now, we'll just remove the Dock property
            //  AND override in xRichControl
            ((Control)c).Dock = DockStyle.None;

            int l = c.Left;

            p.log.WriteLine("Left was " + l.ToString());

            int x;

            if (c is Form && ((Form)c).TopLevel)
                x = p.ru.GetScreenPoint().X;
            else
                x = p.ru.GetRange(0, c.Width);

            int ll = p.ru.GetRange(-c.Width / 2, x - (c.Width / 2));

            p.log.WriteLine("Setting Left to " + ll.ToString());
            c.Left = ll;
            l = c.Left;
            p.log.WriteLine("Left is " + l.ToString());
            return new ScenarioResult(l == ll);
        }

        protected virtual ScenarioResult set_Location(TParams p, Point value)
        {
            return get_Location(p);
        }

        // when Visible = falase, Dock has no effect on location
        protected virtual ScenarioResult get_Location(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            if (c is Form)
            {
                c = new Form();
            }
            else
            {
                // if Control is parented to GroupBox - from previous scenarios
                // it's location will not be (0, 0)
                // So we'll parent out control to the Form
                if ((SafeMethods.GetParent(c) != null) && (!SafeMethods.GetParent(c).Equals(this)))
                {
                    SafeMethods.GetParent(c).Controls.Remove(c);
                    this.Controls.Clear();
                    this.Controls.Add(c);
                    Application.DoEvents();
                }
            }

            p.log.WriteLine("current Visible: " + c.Visible);
            p.log.WriteLine("current Dock: " + c.Dock.ToString());

            Point pt = c.Location;

            p.log.WriteLine("Location was " + pt.ToString());

            Point ppt = p.ru.GetScreenPoint();

            p.log.WriteLine("Setting to Location " + ppt.ToString());
            c.Location = ppt;
            p.log.WriteLine("Location is " + c.Location.ToString());

            // If control is docked and Visible, its location will not change
            // Splitter respects docking even when it's not visible
            if (c.Dock != DockStyle.None && (c.Visible || c is Splitter))
            {
                return new ScenarioResult(c.Location.Equals(pt));
            }

            return new ScenarioResult(c.Location.Equals(ppt));
        }

        protected virtual ScenarioResult set_Parent(TParams p, Control value)
        {
            //don't call get_Parent, will cause a SecurityException with the wrong stack
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Control pc = SafeMethods.GetParent(c);
            if (pc != null) p.log.WriteLine("Parent was " + pc.ToString());

            Control expected = null;

            if (c is Form) ((Form)c).TopLevel = false;

            // pick a new parent
            int i = p.ru.GetRange(0, 5);

            p.log.WriteLine(i.ToString());
            switch (i)
            {
                case 0: // null
                    p.log.WriteLine("Setting Parent to null");
                    expected = null;
                    c.Parent = expected;
                    break;

                case 1: // itself
                    p.log.WriteLine("Setting Parent to self");
                    try
                    {
                        expected = c;
                        c.Parent = expected;
                        return new ScenarioResult(false, "Control can't be parented to itself");
                    }
                    catch (Exception)
                    {
                        expected = pc;
                    }
                    break;

                case 2: // it's current parent
                    p.log.WriteLine("Setting Parent to Parent");
                    expected = SafeMethods.GetParent(c);
                    c.Parent = expected;
                    break;

                case 3: // another control already on the form
                    p.log.WriteLine("Setting Parent to control already on form");

                    GroupBox gb = new GroupBox();

                    this.Controls.Add(gb);
                    expected = gb;
                    c.Parent = expected;
                    break;

                case 4: // another control not yet on the form
                default:
                    p.log.WriteLine("Setting Parent to control not yet on form");

                    GroupBox gb2 = new GroupBox();
                    expected = gb2;
                    c.Parent = expected;
                    this.Controls.Add(gb2);
                    break;
            }

            Control pc2 = SafeMethods.GetParent(c);

            AddObjectToForm(p);
            return new ScenarioResult(pc2 == expected, "EXPECTED: " + (expected == null ? "null" : expected.ToString()) + "; GOT: " + (pc2 == null ? "null" : pc2.ToString()));
        }

        protected virtual ScenarioResult get_Parent(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            ScenarioResult sr = new ScenarioResult();
            Control pc = null;

            bool gotParent = SecurityCheck(sr, delegate
            {
                pc = c.Parent;
            }, typeof(Control).GetMethod("get_Parent"), LibSecurity.AllWindows);
            if (!gotParent)
            { sr.IncCounters(null == pc, "FAIL: get_Parent returned a value in partial trust", p.log); }


            if (pc != null) p.log.WriteLine("Parent was " + pc.ToString());

            Control expected = null;

            if (c is Form) ((Form)c).TopLevel = false;

            switch (p.ru.GetRange(0, 5))
            {
                case 0: // null
                    p.log.WriteLine("Setting Parent to null");
                    expected = null;
                    c.Parent = null;
                    break;

                case 1: // itself
                    p.log.WriteLine("Setting Parent to self");
                    expected = SafeMethods.GetParent(c);
					try
					{
						c.Parent = c;
						sr.IncCounters(new ScenarioResult(false, "Control can't be parented to itself (expected exception)", p.log));
					}
					catch (NotSupportedException) { }//For a control with a readonly controls collection, it will throw NSE instead of ArgE
					catch (ArgumentException) { }
                    break;

                case 2: // it's current parent
                    p.log.WriteLine("Setting Parent to Parent");
                    expected = SafeMethods.GetParent(c);
                    c.Parent = expected;
                    break;

                case 3: // another control already on the form
                    p.log.WriteLine("Setting Parent to control already on form");

                    GroupBox gb = new GroupBox();

                    this.Controls.Add(gb);
                    expected = gb;
                    c.Parent = expected;
                    break;

                case 4: // another control not yet on the form
                default:
                    p.log.WriteLine("Setting Parent to control not yet on form");

                    GroupBox gb2 = new GroupBox();
                    c.Parent = gb2;

                    expected = gb2;
                    this.Controls.Add(gb2);
                    break;
            }

            Control finalParent = null;
            gotParent = SecurityCheck(sr, delegate
            {
                finalParent = c.Parent;
            }, typeof(Control).GetMethod("get_Parent"), LibSecurity.AllWindows);
            if (!gotParent)
            { finalParent = SafeMethods.GetParent(c); }

            AddObjectToForm(p);
            sr.IncCounters(expected, finalParent, "FAIL: Final parent was incorrect", p.log);

            return sr;
        }

        protected virtual ScenarioResult get_RecreatingHandle(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            bool b = c.RecreatingHandle;

            p.log.WriteLine("RecreatingHandle is " + b.ToString());
            return ScenarioResult.Pass;
        }

        // when Visible = false, Docking has no effect on returned Right value
        protected virtual ScenarioResult get_Right(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("current IsHandleCreated: " + c.IsHandleCreated);
            p.log.WriteLine("current Visible: " + c.Visible);
            p.log.WriteLine("current Dock: " + c.Dock.ToString());

            int r = c.Right;

            p.log.WriteLine("Right was " + r.ToString());
            p.log.WriteLine("Bounds were " + c.Bounds.ToString());
            c.Width++;

            int rr = c.Right;

            p.log.WriteLine("Right is " + rr.ToString());
            p.log.WriteLine("Bounds are " + c.Bounds.ToString());

            // Right changes when Dock = None, Left or Visible = false 
            if (c.Dock != DockStyle.None && c.Dock != DockStyle.Left && c.Visible && c.IsHandleCreated)
            {
                return new ScenarioResult(c.Right == r);
            }

            return new ScenarioResult(rr == r + 1);
        }

        protected virtual ScenarioResult set_TabIndex(TParams p, int value)
        {
            return get_TabIndex(p);
        }

        protected virtual ScenarioResult get_TabIndex(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            int initTabIndex = c.TabIndex;

            p.log.WriteLine("initial TabIndex: " + initTabIndex.ToString());

            int newTabIndex = p.ru.GetInt();

            try
            {
                p.log.WriteLine("setting TabIndex to: " + newTabIndex.ToString());
                c.TabIndex = newTabIndex;
                if (newTabIndex < 0)
                    return new ScenarioResult(false, "FAILED: didn't throw exception for negative TabIndex", p.log);
            }
            catch (ArgumentException)
            {
                ScenarioResult sr = new ScenarioResult();

                sr.IncCounters(newTabIndex < 0, "FAILED: exception was thrown for non-negative value", p.log);
                sr.IncCounters(c.TabIndex == initTabIndex, "FAILED: didn't preserve initial TabIndex", p.log);
                return sr;
            }
            catch (Exception e)
            {
                return new ScenarioResult(false, "FAILED: unexpected exception was thrown: " + e.Message, p.log);
            }
            p.log.WriteLine("new TabIndex: " + c.TabIndex.ToString());
            return new ScenarioResult(c.TabIndex == newTabIndex, "FAILED: set/get TabIndex", p.log);
        }

        protected virtual ScenarioResult set_TabStop(TParams p, bool value)
        {
            return get_TabStop(p);
        }

        protected virtual ScenarioResult get_TabStop(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            bool b = c.TabStop;

            p.log.WriteLine("TabStop was " + b.ToString());
            c.TabStop = !b;

            bool bb = c.TabStop;

            p.log.WriteLine("TabStop is " + bb.ToString());
            return new ScenarioResult(b != bb);
        }

        protected virtual ScenarioResult set_Text(TParams p, String value)
        {
            return get_Text(p);
        }

        protected virtual ScenarioResult get_Text(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            String sold = c.Text;
            String ss = p.ru.GetString(32, true);

            p.log.WriteLine("Text was " + sold);
            p.log.WriteLine("Setting Text to " + ss);
            textInASCII(ss);
            c.Text = ss;

            String s = c.Text;

            p.log.WriteLine("Text is " + s);
            textInASCII(s);

            // On Win9x, there are some chars that are not round-trippable even though
            // they are valid Unicode chracters.  According to TadaoM, it is sufficient to
            // just test the string length rather than muck with filtering all those characters.
            if (Utilities.IsWin9x)
                return new ScenarioResult(ss.Length == s.Length, "FAIL: Set string len = " + ss.Length + "; returned string len = " + s.Length, p.log);
            else
                return new ScenarioResult(s.Equals(ss));
        }

        protected void textInASCII(string toPrint)
        {
            string temp = "   ";

            for (int i = 0; i < toPrint.Length; i++)
            {
                temp += " " + (int)toPrint[i] + "  ";
            }

            scenarioParams.log.WriteLine(temp);
        }

        protected virtual ScenarioResult set_Top(TParams p, int value)
        {
            return get_Top(p);
        }

        protected virtual ScenarioResult get_Top(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            int l = c.Top;

            p.log.WriteLine("current IsHandleCreated: " + c.IsHandleCreated);
            p.log.WriteLine("current Visible: " + c.Visible);
            p.log.WriteLine("Current dock: " + c.Dock.ToString());
            p.log.WriteLine("Top was " + l.ToString());

            int ll = p.ru.GetRange(-c.Width / 2, p.ru.GetScreenPoint().Y - (c.Width / 2));

            p.log.WriteLine("Setting top to " + ll.ToString());
            c.Top = ll;
            p.log.WriteLine("Top is " + c.Top.ToString());
            if (PreHandleMode && c is Splitter && (c.Parent != null))
            {
                p.log.WriteLine("testing Splitter in PreHandle mode");
                p.log.WriteLine("curent IsHandleCreated: " + c.IsHandleCreated);
                return new ScenarioResult(c.Top == l, "FAIL: Expected " + l, p.log);
            }
            else
                // Top will change only when Dock is None and control is visible and the handle is created
                if (c.Dock != DockStyle.None && c.Visible && c.IsHandleCreated)
                    return new ScenarioResult(c.Top == l, "FAIL: Expected " + l, p.log);
                else
                    return new ScenarioResult(c.Top == ll, "FAIL: Expected " + l, p.log);
        }

        protected virtual ScenarioResult get_TopLevelControl(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;


            Control actual = null;
            ScenarioResult sr = new ScenarioResult();
            bool bSet = SecurityCheck(sr, delegate
            {
                actual = c.TopLevelControl;
            }, typeof(Control).GetMethod("get_TopLevelControl"), LibSecurity.AllWindows);

            Control expected = null;
            if (bSet)
            {
                expected = c;
                while (expected != null && !(expected is Form && ((Form)expected).TopLevel))
                { expected = SafeMethods.GetParent(expected); }
            }

            return new ScenarioResult(expected, actual, "FAIL: Unexpected TopLevelControl", p.log);
        }

        protected virtual ScenarioResult set_Visible(TParams p, bool value)
        {
            return get_Visible(p);
        }

        protected virtual ScenarioResult get_Visible(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            bool b = c.Visible;
            bool bb;

            p.log.WriteLine("Visible was " + b.ToString());
            c.Visible = !b;
            bb = c.Visible;
            p.log.WriteLine("Visible is " + bb.ToString());
            c.Visible = b;

            bool expected = !b;

            if (PreHandleMode)
            {
                p.log.WriteLine("In PreHandleMode Visible returns false");
                expected = false;
            }

            return new ScenarioResult(bb == expected);
        }

        protected virtual ScenarioResult set_WindowTarget(TParams p, IWindowTarget value)
        {
            return InternalOnlyMethod(p);
        }

        protected virtual ScenarioResult get_WindowTarget(TParams p)
        {
            return InternalOnlyMethod(p);
        }

        protected virtual ScenarioResult BringToFront(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            /*      //TODO: add case for Control without parent
            bool bParent = (c.Parent != null);
            bool b1 = (this == c);
            p.log.WriteLine("current control has parent: " + bParent.ToString() + ", c & this same: " + b1.ToString());

            // saving current state of the control
            int initInd = this.Controls.GetChildIndex(c);
    */
                        // send control to Front, its ChildIndex should become 0
            c.BringToFront();

            /*       int ind = this.Controls.GetChildIndex(c);
            p.log.WriteLine("after bringing control to Front its ChildIndex: " + ind.ToString());

            // check if TopLevelControl's name is the name of current control
            string current = (typeof(c).ToString()).Trim();
            string topLevel = ((c.TopLevelControl).ToString()).Trim();
            // retrieve name of control from both strings
            current = current.Substring(current.LastIndexOf(".") + 1, current.Length - current.LastIndexOf(".") - 1);
            topLevel = topLevel.Substring(1, topLevel.IndexOf(",") - 1); //get rid of 'x' at the beginning
            int iSame = System.String.Compare(current, topLevel);
            this.Controls.SetChildIndex(this, initInd);
            return new ScenarioResult((ind == 0) && (iSame == 0), "failed to bring control to the Front", p.log);
      */
                        return ScenarioResult.Pass;
        }

        /* No longer used
        private bool clicked = false;
                public void Clicked(Object source, MouseEventArgs e)           //for MouseEvent
                {
                    clicked = true;
                }    
        */
                        private bool IsSpecialCaseCallWndProc(Control c)
        {
            // These used to use "if ( c.GetType == tyepof(Foo) )", but these wouldn't cover
            // subclasses for inheritance tests, so we changed them to use the "is" operator
            if (c is DateTimePicker) return true;

            if (c is GroupBox) return true;

            if (c is Label) return true;

            if (c is LinkLabel) return true;

            if (c is Panel) return true;

            if (c is PictureBox) return true;

            if (c is ProgressBar) return true;

            if (c is ScrollableControl) return true;

            return false;
        }
#if false        
        protected virtual ScenarioResult CallWndProc(TParams p, int msg, IntPtr wParam, IntPtr lParam)
        {
// This method is gone for RTM
return ScenarioResult.Pass;
/*
            AddRequiredPermission(LibSecurity.AllWindows);

            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            MouseEventHandler eh = new MouseEventHandler(this.Clicked);
            clicked = false;
            c.MouseUp += eh;

            c.CallWndProc(win.WM_LBUTTONUP, (IntPtr)0, (IntPtr)0);
            Application.DoEvents();

            c.MouseUp -= eh;

            // force success if special-cased control
            if (IsSpecialCaseCallWndProc(c)) clicked = true;
            return new ScenarioResult(clicked);
*/

        }
#endif

        protected virtual ScenarioResult Contains(TParams p, Control ctl)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ctl = c;

            System.Windows.Forms.Control.ControlCollection cc = c.Controls;

            if (cc.Count != 0) ctl = (Control)(cc[0]);

            bool b = c.Contains(ctl);

            if (ctl == c)
                return new ScenarioResult(!b, "Contains should return false for self");
            else
                return new ScenarioResult(b, "Contains failed for contained control");
        }

        protected virtual ScenarioResult get_ContainsFocus(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult sr = new ScenarioResult();

            // We'll use ContainsFocus instead of Focused since a control's child can have focus
            // and Focused will return false
            bool b = c.ContainsFocus;

            p.log.WriteLine(" initial ContainsFocus: " + b.ToString());
            p.log.WriteLine("1. setting Focus to control...");
            SafeMethods.Focus(c);

            p.log.WriteLine(" new Focused: " + c.Focused.ToString());
            p.log.WriteLine(" ContainsFocus returns: " + c.ContainsFocus.ToString());
            if (PreHandleMode && c is Form)
            {
                c = (Control)CreateObject(p);
            }

            // Forms with child controls or forms return false for Focused and true for ContainsFocus.
            if (!PreHandleMode && (c.Focused || c is UpDownBase || (c is Form && !c.Focused && (((Form)c).IsMdiContainer) || c.Controls.Count > 0)))
                sr.IncCounters(c.ContainsFocus, "FAILED: returned False for focused control", p.log);
            else
                sr.IncCounters(!c.ContainsFocus, "FAILED: returned True for non-focused control", p.log);

            System.Windows.Forms.Control.ControlCollection cc = c.Controls;

            // It doesn't quite work this way on the grid so we'll skip this test.
            if (cc.Count != 0)
            {
                p.log.WriteLine("2. setting Focus to contained control...");
                SafeMethods.Focus((cc[0]));
                p.log.WriteLine(" contained control Focused: " + cc[0].Focused.ToString());
                b = c.ContainsFocus;
                if (cc[0].Focused)
                    sr.IncCounters(b, "FAILED: returned False when contained control is focused", p.log);
                else
                {
                    p.log.WriteLine(" control itself is Focused: " + c.Focused.ToString());
                    if (c.Focused)
                        sr.IncCounters(c.ContainsFocus, "FAILED: returned False for focused control", p.log);
                    else
                        sr.IncCounters(!c.ContainsFocus, "FAILED: returned True for non-focused control", p.log);
                }

                p.log.WriteLine(" ContainsFocus returns: " + b.ToString());
            }

            return sr;
        }

        protected virtual ScenarioResult CreateControl(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult sr = new ScenarioResult();

            // 
            // our tested control is already CREATED
            //  calling CreateControl() on already created control should not affect 
            //  Created-property of this control, no matter the control is visible or not
            //
            bool b;

            p.log.WriteLine("   Initial Created: " + c.Created.ToString());
            p.log.WriteLine("1. calling CreateControl() on already created control with Visible=true");
            b = c.Visible;               // saving initial Visible
            c.Visible = true;
            c.CreateControl();
            p.log.WriteLine("   new Created: " + c.Created.ToString());
            sr.IncCounters(c.Created, "FAILED: to maintain control created when it's visible", p.log);
            p.log.WriteLine("2. calling CreateControl() on already created control with Visible=false");
            c.Visible = false;
            c.CreateControl();
            p.log.WriteLine("   new Created: " + c.Created.ToString());
            sr.IncCounters(c.Created, "FAILED: to maintain control created when it's not visible", p.log);
            c.Visible = b;                  // restoring initial Visible

            //
            // declaring new control, that is not initially created
            //   when its Visible is set to false, calling CreateControl() 
            //  control should not be created
            //
            p.log.WriteLine("4. declaring new non-Visible control...");

            Control cc = new Control();
            Form f = new Form();

            f.Visible = true;
            f.CreateControl();
            cc.Visible = false;
            p.log.WriteLine("   Created: " + cc.Created.ToString());
            p.log.WriteLine("  a. calling CreateControl()");
            cc.CreateControl();
            p.log.WriteLine("   new Created: " + cc.Created.ToString());
            sr.IncCounters(!cc.Created, "FAILED: non-visible control should not be created", p.log);
            p.log.WriteLine("  b. adding non-visible not-created control to the form");
            f.Controls.Add(cc);
            p.log.WriteLine("    new Created: " + cc.Created.ToString());
            sr.IncCounters(!cc.Created, "FAILED: Non-visible control should not be created, even if added to form ", p.log);
            p.log.WriteLine("  c. calling CreateControl for non-visible not-created control that was added to the form");
            cc.CreateControl();
            p.log.WriteLine("   new Created: " + cc.Created.ToString());
            sr.IncCounters(!cc.Created, "FAILED: non-visible control on the form should not be created", p.log);

            // when Visible = true CreateControl() should create 
            // **changing Visible to True calls CreateControl for control with created parent
            //
            p.log.WriteLine("5. changing Visible for control on the form(control is not-created & non-visible) - it should call CreateControl()");
            cc.Visible = true;
            p.log.WriteLine("   new Created: " + cc.Created.ToString());
            sr.IncCounters(cc.Created, "FAILED: setting Visible=true for control on the form didn't call CreateControl()", p.log);
            p.log.WriteLine("6. calling CreateControl() for visible created control on the form");
            cc.CreateControl();
            p.log.WriteLine("   new Created: " + cc.Created.ToString());
            sr.IncCounters(cc.Created, "FAILED: CreateControl() for created control on the form didn't preserved it's 'Created'", p.log);
            cc.Dispose();
            f.Dispose();
            b = cc.Created;
            cc = new Control();
            cc.Visible = true;
            p.log.WriteLine("7. calling CreateControl for visible control without parent");
            p.log.WriteLine("   initial Created: " + cc.Created.ToString());
            cc.CreateControl();
            p.log.WriteLine("   new Created: " + cc.Created.ToString());
            sr.IncCounters(cc.Created, "FAILED: visible control was not created", p.log);
            sr.IncCounters(!b, "FAILED: created is true after Dispose()", p.log);
            return sr;
        }

        protected virtual ScenarioResult Focus(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // We'll use ContainsFocus instead of Focused since a control's child can have focus
            // and Focused will return false
            bool initialFocus = c.ContainsFocus;
            bool can = c.CanFocus;
            ScenarioResult sr = new ScenarioResult();

            p.log.WriteLine("ContainsFocus was: " + initialFocus.ToString());
            p.log.WriteLine("CanFocus: " + can.ToString());

            bool bSetFocus = SecurityCheck(sr, delegate
            { c.Focus(); }, typeof(Control).GetMethod("Focus"), LibSecurity.AllWindows);

            if (can && bSetFocus)
            {
                sr.IncCounters(c.CanFocus, "FAIL: did not Focus when CanFocus", p.log);
            }
            else
            {
                sr.IncCounters(initialFocus, c.ContainsFocus, "FAIL: performed focusing when Cannot focus(!?)", p.log);
            }

            p.log.WriteLine("new ContainsFocus is: " + (c.ContainsFocus).ToString());
            return sr;
        }

        //
        // when child-control has Width or Height = 0, GetChildAtPoint cannot retrieve this child
        //
        // CONSIDER: Does the control and its children have to be visible for this to work?
        //
        protected virtual ScenarioResult GetChildAtPoint(TParams p, Point value)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Point pt = p.ru.GetPoint(new Point(c.ClientSize));

            p.log.WriteLine("ClientSize of the control: " + c.ClientSize.ToString());
            p.log.WriteLine("initial point to get a child at: " + pt.ToString());
            p.log.WriteLine("number of child-controls on the control: " + c.Controls.Count.ToString());

            // SECURITY: GetChildAtPoint only demands AllWindows if the control returned from
            //           UnsafeNativeMethods.ChildWindowFromPoint is not a descendant.  This
            //			 should never happen, so we can basically assume this method does not
            //			 require any permissions.  Not much we can do otherwise.
            //AddRequiredPermission(LibSecurity.AllWindows);
            Control ctl = c.GetChildAtPoint(pt);

            if ((c.Controls.Count == 0) && (ctl != null))
                return new ScenarioResult(false, "FAILED: returned non-null for control with no children", p.log);
            else if ((c.Controls.Count != 0) && (ctl == null))
            {
                // point is outside of child-controls - need to adjust it
                Size clsz = c.Controls[0].ClientSize;
                Point loc = c.Controls[0].Location;
                Size parentSz = c.ClientSize;

                p.log.WriteLine("Bounds of 1st child: " + (c.Controls[0].Bounds).ToString());

                // picking point within child's ClientArea--constrain it with a 1 pixel border
                pt = p.ru.GetPoint(1, clsz.Width - 1, 1, clsz.Height - 1);

                // adjust point according to location of child
                pt = new Point(loc.X + pt.X, loc.Y + pt.Y);
                p.log.WriteLine("new point to get a child: " + pt.ToString());
                ctl = c.GetChildAtPoint(pt);

                //Utilities.MarkPoint(c, pt);     // For debugging--paint a marker to show the point.
                // in cases when Width or Height of child = 0, this child cannot be retrieved
		// ToolStripDropDowns may have scrollbuttons that may or may not be visible
                // Likewise with controls outside of the client area (and maybe invisible controls?)
                if ((clsz.Width != 0 && clsz.Height != 0) && (pt.X >= 0 && pt.X < parentSz.Width) && (pt.Y >= 0 && pt.Y < parentSz.Height) && c.Controls[0].Visible)
                    return new ScenarioResult(ctl == c.Controls[0], "FAILED: Expected " + c.Controls[0] + ", but got " + ctl, p.log);
	        else if ((c is ToolStripDropDownMenu) && (!c.Controls[0].Visible))
 		    return new ScenarioResult(true);
                else
                    return new ScenarioResult(ctl == null, "FAILED: Expected null but got " + ctl, p.log);
            }

            return ScenarioResult.Pass;
        }

        //
        // when child-control has Width or Height = 0, GetChildAtPoint cannot retrieve this child
        //
        // CONSIDER: Does the control and its children have to be visible for this to work?
        //
        protected virtual ScenarioResult GetChildAtPoint(TParams p, Point value, GetChildAtPointSkip skip)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            skip = p.ru.GetEnumValue<GetChildAtPointSkip>();
            Point pt = p.ru.GetPoint(new Point(c.ClientSize));

            p.log.WriteLine("ClientSize of the control: " + c.ClientSize.ToString());
            p.log.WriteLine("initial point to get a child at: " + pt.ToString());
            p.log.WriteLine("number of child-controls on the control: " + c.Controls.Count.ToString());

            // SECURITY: GetChildAtPoint only demands AllWindows if the control returned from
            //           UnsafeNativeMethods.ChildWindowFromPoint is not a descendant.  This
            //			 should never happen, so we can basically assume this method does not
            //			 require any permissions.  Not much we can do otherwise.
            //AddRequiredPermission(LibSecurity.AllWindows);
            Control ctl = c.GetChildAtPoint(pt, skip);

            if ((c.Controls.Count == 0) && (ctl != null))
                return new ScenarioResult(false, "FAILED: returned non-null for control with no children", p.log);
            else if ((c.Controls.Count != 0) && (ctl == null))
            {
                // point is outside of child-controls - need to adjust it
                Control targetControl = c.Controls[0];
                Size clsz = targetControl.ClientSize;
                Point loc = targetControl.Location;
                Size parentSz = c.ClientSize;

                p.log.WriteLine("Bounds of 1st child: " + (c.Controls[0].Bounds).ToString());

                // picking point within child's ClientArea--constrain it with a 1 pixel border
                pt = p.ru.GetPoint(1, clsz.Width - 1, 1, clsz.Height - 1);

                // adjust point according to location of child
                pt = new Point(loc.X + pt.X, loc.Y + pt.Y);
                p.log.WriteLine("new point to get a child: " + pt.ToString());
                switch (skip)
                {
                    case GetChildAtPointSkip.Disabled:
                        bool prevEnabled = targetControl.Enabled;
                        try
                        {
                            targetControl.Enabled = false;
                            ctl = c.GetChildAtPoint(pt, GetChildAtPointSkip.Disabled);
                            return new ScenarioResult(null, ctl, "FAIL: should have skipped disabled child", p.log);
                        }
                        finally { targetControl.Enabled = prevEnabled; }
                    case GetChildAtPointSkip.Invisible:
                        bool prevVisible = targetControl.Visible;
                        try
                        {
                            targetControl.Visible = false;
                            ctl = c.GetChildAtPoint(pt, GetChildAtPointSkip.Invisible);
                            return new ScenarioResult(null, ctl, "FAIL: should have skipped disabled child", p.log);
                        }
                        finally { targetControl.Visible = prevVisible; }
                    case GetChildAtPointSkip.None:
                        //normal testing follows
                        break;
                    case GetChildAtPointSkip.Transparent:
                        //normal testing follows
                        break;
                }
                ctl = c.GetChildAtPoint(pt, GetChildAtPointSkip.None);


                //Utilities.MarkPoint(c, pt);     // For debugging--paint a marker to show the point.
                // in cases when Width or Height of child = 0, this child cannot be retrieved
		// ToolStripDropDowns may have scrollbuttons that may or may not be visible
                // Likewise with controls outside of the client area (and maybe invisible controls?)
                if ((clsz.Width != 0 && clsz.Height != 0) && (pt.X >= 0 && pt.X < parentSz.Width) && (pt.Y >= 0 && pt.Y < parentSz.Height) && c.Controls[0].Visible)
                    return new ScenarioResult(ctl == c.Controls[0], "FAILED: Expected " + c.Controls[0] + ", but got " + ctl, p.log);
		else if ((c is ToolStripDropDownMenu) && (!c.Controls[0].Visible))
		    return new ScenarioResult(true);
                else
                    return new ScenarioResult(ctl == null, "FAILED: Expected null but got " + ctl, p.log);
            }

            return ScenarioResult.Pass;
        }


        protected virtual ScenarioResult GetContainerControl(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult sr = new ScenarioResult();
            IContainerControl container = null;
            bool bSuccess = SecurityCheck(sr, delegate
            { container = c.GetContainerControl(); }, typeof(Control).GetMethod("GetContainerControl"), LibSecurity.AllWindows);

            if (bSuccess && container != null)
            {
                Control current = c;
                bool bFoundContainer = false;
                while (null != current)
                {
                    if (current == container)
                    { bFoundContainer = true; }
                    current = SafeMethods.GetParent(current);
                }
                sr.IncCounters(bFoundContainer, "FAIL: returned object was not a parent of the control", p.log);
            }
            return sr;
        }

        protected virtual ScenarioResult GetNextControl(TParams p, Control ctl, Boolean forward)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult sr = ScenarioResult.Pass;

            if (c.Controls.Count != 0)
            {
                ctl = (Control)(c.Controls[0]);

                Control cc = c.GetNextControl(ctl, true);

                cc = c.GetNextControl(cc, false);
                sr = new ScenarioResult(cc == ctl, "Forward and back didn't return same control");
            }

            return sr;
        }

        protected virtual ScenarioResult Hide(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            bool b;

            c.Hide();
            b = c.Visible;
            c.Show();
            return new ScenarioResult(!b, "Hide didn't set Visible to false");
        }

        private bool painted = false;

        private void Painted(Object source, PaintEventArgs e)
        {
            painted = true;
            scenarioParams.log.WriteLine("*******************PAINT EVENT FIRED***********************");
        }

        // TODO: Several controls (e.g. MonthCalendar, GroupBox, Label, TabControl, TextBox
        //                              RichTextBox, ProgressBar)
        //       do not get paint events. You can add a PaintEvent handler to those controls,
        //       but you don't end up getting any PaintEvents. We need to find a way to deal
        //       with all controls in a generic manner, or we need to special case these
        //       scenarios in each of those XTests and just return ScenarioResult.Pass after
        //       calling the appropriate Update method.
        //
        // You can tell if a control should receive Paint events by seeing if it or its
        // base class calls SetStyle(ControlStyles.UserPaint, true).  UserPaint is false by
        // default so it must explicitly be set to true for the control to receive paint
        // events.
        //
        // <seealso member="UpdateScenario"/>
        // <seealso member="RefreshScenario"/>
        private bool IsSpecialCasePaintControl(Control c)
        {
            // These used to use "if ( c.GetType == tyepof(Foo) )", but these wouldn't cover
            // subclasses for inheritance tests, so we changed them to use the "is" operator
            if (c is DateTimePicker) return true;

            if (c is MonthCalendar) return true;

            if (c is GroupBox) return true;

            // KevinTao: These are UserPaint controls.  They should receive paint events.
            //if (c is LinkLabel) return true;
            //if (c is Label) return true;
            if (c is ListBox) return true;

            if (c is ListView) return true;

            if (c is CheckedListBox) return true;

            if (c is ProgressBar) return true;

            if (c is TabControl) return true;

            if (c is TextBox) return true;

            if (c is RichTextBox) return true;

            if (c is ComboBox) return true;

            if (c is TrackBar) return true;

            if (c is NumericUpDown) return true;

            if (c is DomainUpDown) return true;

            // FlatStyle.System controls don't fire paint events
            if (c is ButtonBase && ((ButtonBase)c).FlatStyle == FlatStyle.System)
                return true;

            // LinkLabel doesn't do FlatStyle.System so we only special case Label
            if (c.GetType() == typeof(Label) && ((Label)c).FlatStyle == FlatStyle.System)
                return true;

            if (c is GroupBox && ((GroupBox)c).FlatStyle == FlatStyle.System)
                return true;

            return false;
        }

        //
        // Move control out from under security bubble as it causes failures in the
        // scenarios which raise paint events.
        //
        private void MoveControlOutOfSecurityBubble(TParams p, Control c)
        {
            if (!Utilities.HavePermission(LibSecurity.AllWindows) && c.Location.Y < 200)
            {
                c.Dock = (c is Splitter) ? DockStyle.Bottom : DockStyle.None;
                c.Top = 200;
                p.log.WriteLine("Moving control out from under the security bubble: " + c.Location);
            }
        }

		protected virtual void PrepareForInvalidate(TParams p)
		{
			this.Size = new Size(800, 800);
			c = GetControl(p);
			c.Size = new Size(200, 200);
			c.Location = new Point(200, 200);

			SafeMethods.Activate(this);
			SafeMethods.Focus(this);
			Application.DoEvents();
			System.Threading.Thread.Sleep(100);
			Application.DoEvents();
		}

        protected virtual ScenarioResult Invalidate(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // make sure the control is visible and created
            if (c is Form) ((Form)c).TopLevel = false;

            AddObjectToForm(p);
            Application.DoEvents();
            c.Visible = true;
            Application.DoEvents();
            p.log.WriteLine("Bounds are " + c.Bounds.ToString());
            p.log.WriteLine("ClientRectangle is " + c.ClientRectangle.ToString());
            p.log.WriteLine("Form.ClentSize: " + this.ClientSize.ToString());
            MoveControlOutOfSecurityBubble(p, c);
            if (controlWillNotInvalidate(c, p))
            {
                return ScenarioResult.Pass;
            }

            ScenarioResult sr = new ScenarioResult();
	    PrepareForInvalidate(p);

            painted = false;



            PaintEventHandler peh = new PaintEventHandler(this.Painted);

            ((Control)c).Paint += peh;

            // need to make sure that there is visible rectangle to  Invalidate
            if (GetVisibleRectangle(p, c) == Rectangle.Empty)
            {
                return ScenarioResult.Pass;
            }

            c.Invalidate();
            p.log.WriteLine("before DoEvents onPaint was called: " + painted.ToString());
            if (painted) sr.Comments = "Invalidate not asynchronous";

            sr.IncCounters(!painted);
            Application.DoEvents();
            p.log.WriteLine("after DoEvents onPaint was called: " + painted.ToString());
            if (!IsSpecialCasePaintControl(c))
            {
                if (!painted) sr.Comments = "DoEvents did not process Paint message";

                sr.IncCounters(painted);
            }

            p.log.WriteLine("current Visible: " + c.Visible);
            painted = false;
            c.Invalidate();
            c.Update();
            p.log.WriteLine("after Invalidate&Update onPaint was called: " + painted.ToString());
            if (!IsSpecialCasePaintControl(c))
            {
                if (!painted) sr.Comments = "Update didn't process Paint message";

                sr.IncCounters(painted);
            }

            ((Control)c).Paint -= peh;
            return sr;
        }

        protected virtual ScenarioResult Invalidate(TParams p, Boolean invalidateChildren)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // make sure the control is visible and created
            if (c is Form) ((Form)c).TopLevel = false;

            AddObjectToForm(p);
            c.Visible = true;
            MoveControlOutOfSecurityBubble(p, c);
            if (controlWillNotInvalidate(c, p))
            {
                return ScenarioResult.Pass;
            }

            ScenarioResult sr = new ScenarioResult();

            painted = false;

			PrepareForInvalidate(p);

            PaintEventHandler peh = new PaintEventHandler(this.Painted);

            ((Control)c).Paint += peh;

            // need to make sure that there is visible rectangle to  Invalidate
            if (GetVisibleRectangle(p, c) == Rectangle.Empty)
            {
                return ScenarioResult.Pass;
            }

            c.Invalidate(true);
            p.log.WriteLine("before DoEvents onPaint was called: " + painted.ToString());
            if (painted) sr.Comments = "Invalidate not asynchronous";

            sr.IncCounters(!painted);
            Application.DoEvents();
            p.log.WriteLine("after DoEvents onPaint was called: " + painted.ToString());
            if (!IsSpecialCasePaintControl(c))
            {
                if (!painted) sr.Comments = "DoEvents did not process Paint message";

                sr.IncCounters(painted);
            }

            p.log.WriteLine("current Visible: " + c.Visible);
            painted = false;
            c.Invalidate(false);
            c.Update();
            p.log.WriteLine("after Invalidate&Update onPaint was called: " + painted.ToString());
            if (!IsSpecialCasePaintControl(c))
            {
                if (!painted) sr.Comments = "Update didn't process Paint message";

                sr.IncCounters(painted);
            }

            ((Control)c).Paint -= peh;
            return sr;
        }

        //
        // Returns a rectangle within the control that is within the control's
        // parent's bounds.
        //
        private Rectangle GetVisibleRectangle(TParams p, Control cc)
        {
            Rectangle cb = cc.RectangleToScreen(cc.ClientRectangle);
            //top level control
            if (SafeMethods.GetParent(cc) == null)
                return cc.ClientRectangle;
            Rectangle pb = SafeMethods.GetParent(cc).RectangleToScreen(SafeMethods.GetParent(cc).ClientRectangle);
            Rectangle ir = Rectangle.Intersect(cb, pb);

            // The control must be outside of its parent's bounds
            if (ir.IsEmpty)
            {
                p.log.WriteLine("control and its container have no visible intersection-area");
                return Rectangle.Empty;
            }

            // Form can be paritally outside of the screen
            Form f = SafeMethods.FindForm(cc);
            Rectangle screen = SystemInformation.WorkingArea;

            p.log.WriteLine("Screen: " + screen);

            Rectangle fBounds = f.DesktopBounds;

            p.log.WriteLine("Form in screen coord: " + fBounds);

            Rectangle fVisible = Rectangle.Intersect(screen, fBounds);

            p.log.WriteLine("Visible part of the Form in screen coord: " + fVisible);
            ir = Rectangle.Intersect(ir, fVisible);

            // rectangle must be within visible area of the Form
            if (ir.IsEmpty)
            {
                p.log.WriteLine("control and Form have no visible intersection-area");
                return Rectangle.Empty;
            }

            Rectangle rr;

            do { rr = p.ru.GetIntersectingRectangle(ir); } while (rr.Width < 1 || rr.Height < 1);

            //  -- special case for TabPage ---
            // for TabPage it's neccessary to remember about its 'tab'-part(with text)
            // we need to generate intersecting rectangle within TabPage without this part with text
            if (cc is TabPage)
            {
                int dif = 34;  // need to figure out how to calculate 

                // Height of the strip with caption of TabPage
                if (ir.Height < dif)
                {
                    return Rectangle.Empty;
                }

                while (Rectangle.Intersect(cb, rr).Height < dif || rr.Width == 0)
                {
                    rr = p.ru.GetIntersectingRectangle(ir);
                }
            }

            return cc.RectangleToClient(rr);
        }

        protected virtual ScenarioResult Invalidate(TParams p, Rectangle rc)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("control ClientRectangle is " + c.ClientRectangle.ToString());
            p.log.WriteLine("Form ClientRectangle is " + this.ClientRectangle.ToString());

            // make sure the control is visible and created
            if (c is Form) ((Form)c).TopLevel = false;
            if (c is ToolStripDropDown && !Utilities.HavePermission(LibSecurity.AllWindows))
            {
                ((ToolStripDropDown)c).TopLevel = false;
                ((ToolStripDropDown)c).Parent = this;
            }

            AddObjectToForm(p);
            c.Visible = true;
            Application.DoEvents();

            // on WinXP and Win98 have to give some time to receive previous events
            System.Threading.Thread.Sleep(500);

            // more debug info for Panel
            if (c is Panel)
            {
                p.log.WriteLine("location of Panel: " + ((Panel)c).Location.ToString());
                p.log.WriteLine("Form contains Panel: " + this.Controls.Contains(c));
                ((Panel)c).AutoScroll = false;   // if scrollbar is only visible then no invalidation
            }

            MoveControlOutOfSecurityBubble(p, c);
            if (controlWillNotInvalidate(c, p))
            {
                return ScenarioResult.Pass;
            }

            ScenarioResult sr = new ScenarioResult();

			PrepareForInvalidate(p); 
			
			painted = false;

            PaintEventHandler peh = new PaintEventHandler(this.Painted);

            ((Control)c).Paint += peh;
            rc = GetVisibleRectangle(p, c);

            // doesn't make sense to invalidate empty rectangle
            if (rc == Rectangle.Empty)
            {
                return ScenarioResult.Pass;
            }

            p.log.WriteLine("intersection to be Invalidated: " + Rectangle.Intersect(c.ClientRectangle, rc).ToString());

            // for controls with border when rectangle to Invalidate contains only border
            // onPaint will not be triggered
            if ((Rectangle.Intersect(c.ClientRectangle, rc).Width < 3 || Rectangle.Intersect(c.ClientRectangle, rc).Height < 3))
            {
                p.log.WriteLine("  Invalidate will not be triggered");
                return ScenarioResult.Pass;
            }

            // rectangle to update is in Form coordinates already
            p.log.WriteLine("rectangle to update is " + rc.ToString());

            // in case of 'bizarre' region rectangle-to-invalidate may not be within visible
            // part of the control - to ensure visibility change region to standard 'rectangle'-region
            ((Control)c).Region = null;
            c.Invalidate(rc);
            p.log.WriteLine("before DoEvents onPaint was called: " + painted.ToString());
            if (painted) sr.Comments = "Invalidate not asynchronous";

            sr.IncCounters(!painted);
            Application.DoEvents();
            p.log.WriteLine("after DoEvents onPaint was called: " + painted.ToString());
            if (!IsSpecialCasePaintControl(c))
                sr.IncCounters(painted, "DoEvents did not process Paint message: " + rc.ToString(), p.log);

            painted = false;
            rc = GetVisibleRectangle(p, c);

            // rectangle to update is in Form coordinates already
            p.log.WriteLine("rectangle to update is " + rc.ToString());
            p.log.WriteLine("intersection to be Invalidated: " + Rectangle.Intersect(c.ClientRectangle, rc).ToString());

            // for controls with border when rectangle to Invalidate contains only border
            // onPaint will not be triggered
            if ((Rectangle.Intersect(c.ClientRectangle, rc).Width < 3 || Rectangle.Intersect(c.ClientRectangle, rc).Height < 3))
            {
                p.log.WriteLine(" Invalidate will not be triggered");
                return ScenarioResult.Pass;
            }

            p.log.WriteLine("current Visible: " + c.Visible);
            c.Invalidate(rc);
            c.Update();
            p.log.WriteLine("after Invalidate&Update onPaint was called: " + painted.ToString());
            if (!IsSpecialCasePaintControl(c))
                sr.IncCounters(painted, "Update didn't process Paint message: " + rc.ToString(), p.log);

            c.Paint -= peh;
            if (c is ToolStripDropDown && !Utilities.HavePermission(LibSecurity.AllWindows))
            {
                ((ToolStripDropDown)c).Parent = null;
                ((ToolStripDropDown)c).TopLevel = true;
            }
            return sr;
        }

        protected virtual ScenarioResult Invalidate(TParams p, Rectangle rc, Boolean invalidateChildren)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("ClientRectangle is " + c.ClientRectangle.ToString());

            // make sure the control is visible and created
            if (c is Form) ((Form)c).TopLevel = false;
            if (c is ToolStripDropDown && !Utilities.HavePermission(LibSecurity.AllWindows))
            {
                ((ToolStripDropDown)c).TopLevel = false;
                ((ToolStripDropDown)c).Parent = this;
            }

            AddObjectToForm(p);
            c.Visible = true;
            Application.DoEvents();

            // on WinXP     and Win98 have to give some time for previous events to be received
            System.Threading.Thread.Sleep(500);
            if (c is Panel)
            {
                p.log.WriteLine("location of Panel: " + ((Panel)c).Location.ToString());
                p.log.WriteLine("Form contains Panel: " + this.Controls.Contains(c));
                ((Panel)c).AutoScroll = false;  // if scrollbar only visible - no invalidating
            }

            MoveControlOutOfSecurityBubble(p, c);
            if (controlWillNotInvalidate(c, p))
            {
                return ScenarioResult.Pass;
            }

            ScenarioResult sr = new ScenarioResult();

			PrepareForInvalidate(p);

            painted = false;

            PaintEventHandler peh = new PaintEventHandler(this.Painted);

            ((Control)c).Paint += peh;
            rc = GetVisibleRectangle(p, c);

            // doesn't make sense to invalidate empty rectangle
            if (rc == Rectangle.Empty)
            {
                return ScenarioResult.Pass;
            }

            //    p.log.WriteLine("intersection to be Invalidated: " + Rectangle.Intersect(c.ClientRectangle, rc).ToString());
            // for controls with border when rectangle to Invalidate contains only border
            // onPaint will not be triggered
            if ((Rectangle.Intersect(c.ClientRectangle, rc).Width < 3 || Rectangle.Intersect(c.ClientRectangle, rc).Height < 3))
            {
                p.log.WriteLine("  Invalidate will not be triggered");
                return ScenarioResult.Pass;
            }

            // rectangle to update is in Form's coordinates already
            p.log.WriteLine("rectangle to update is " + rc.ToString());

            // in case of 'bizarre' region rectangle-to-invalidate may not be within visible
            // part of the control - to ensure visibility change region to standard 'rectangle'-region
            ((Control)c).Region = null;
            c.Invalidate(rc, true);
            p.log.WriteLine("before DoEvents onPaint was called: " + painted.ToString());
            if (painted) sr.Comments = "Invalidate not asynchronous";

            sr.IncCounters(!painted);
            Application.DoEvents();
            p.log.WriteLine("after DoEvents onPaint was called: " + painted.ToString());
            if (!IsSpecialCasePaintControl(c))
            {
                if (!painted) sr.Comments = "DoEvents did not process Paint message: " + rc.ToString(); ;
                sr.IncCounters(painted);
            }

            painted = false;
            rc = GetVisibleRectangle(p, c);

            // rectangle to update in in Form's coordinates already
            p.log.WriteLine("rectangle to update is " + rc.ToString());

            //    p.log.WriteLine("intersection to be Invalidated: " + Rectangle.Intersect(c.ClientRectangle, rc).ToString());
            // for controls with border when rectangle to Invalidate contains only border
            // onPaint will not be triggered
            if ((Rectangle.Intersect(c.ClientRectangle, rc).Width < 3 || Rectangle.Intersect(c.ClientRectangle, rc).Height < 3))
            {
                p.log.WriteLine(" Invalidate will not be triggered");
                return ScenarioResult.Pass;
            }

            p.log.WriteLine("current Visible: " + c.Visible);
            c.Invalidate(rc, false);
            c.Update();
            p.log.WriteLine("after Invalidate&Update onPaint was called: " + painted.ToString());
            if (!IsSpecialCasePaintControl(c))
            {
                if (!painted) sr.Comments = "Update didn't process Paint message: " + rc.ToString();

                sr.IncCounters(painted);
            }

            ((Control)c).Paint -= peh;
            if (c is ToolStripDropDown && !Utilities.HavePermission(LibSecurity.AllWindows))
            {
                ((ToolStripDropDown)c).Parent = null;
                ((ToolStripDropDown)c).TopLevel = true;
            }
            return sr;
        }

        //
        //  if only border of Panel is visible, onPaint will not be triggered when
        // Invalidating or Refreshing
        // will use this helper in all Invalidate/Refresh related scenarios to return Pass 
        // for Panel/MultiplexPanel if only their border is visible
        //
        bool controlWillNotInvalidate(Control cc, TParams p)
        {
            Rectangle r1 = cc.RectangleToScreen(cc.ClientRectangle);
            //toplevel control - most likely will Invalidate
            if (SafeMethods.GetParent(cc) == null)
                return false;

            Rectangle r2 = SafeMethods.GetParent(cc).RectangleToScreen(SafeMethods.GetParent(cc).ClientRectangle);


            Rectangle ir = Rectangle.Intersect(r1, r2);

            p.log.WriteLine("in ControlWillNotInvalidate: intersection: " + ir);

            // Control might be obscured by security bubble.
            if (!Utilities.HavePermission(LibSecurity.AllWindows) && cc.Location.Y < 200)
            {
                p.log.WriteLine("Security bubble obscures control.  Won't invalidate.");
                return true;
            }

            if (ir.Width == r1.Height && ir.Height == r1.Height)
            {
                return false;
            }
            else
            {
                p.log.WriteLine("Visible area of control is less than 2 x 2.  Won't invalidate.");
                p.log.WriteLine("intersection: " + ir.ToString());
                return true;
            }
        }

        protected virtual ScenarioResult PerformLayout(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            c.PerformLayout();
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult PerformLayout(TParams p, Control affectedControl, String affectedProperty)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            affectedControl = null;
            if (c.Controls.Count != 0)
                affectedControl = (Control)(c.Controls[0]);

            //TODO: We have to change the following line.
            affectedProperty = "Visible";
            c.PerformLayout(affectedControl, affectedProperty);
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult PointToClient(TParams p, Point pt)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            pt = p.ru.GetPoint();
            return new ScenarioResult(c.PointToClient(c.PointToScreen(pt)).Equals(pt));
        }

        protected virtual ScenarioResult PointToScreen(TParams p, Point pt)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            pt = p.ru.GetPoint();
            return new ScenarioResult(c.PointToScreen(c.PointToClient(pt)).Equals(pt));
        }

        protected virtual ScenarioResult PreProcessMessage(TParams p, ref Message msg)
        {
            // UNDONE: can't test this the standard way because it only does a LinkDemand, and this
            //         assembly has full trust, so it passes.
            //AddRequiredPermission(LibSecurity.UnmanagedCode);
            // TODO: implement.
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Message m = new Message();

            c.PreProcessMessage(ref m);
            return InternalOnlyMethod(p);
        }


		protected virtual ScenarioResult PreProcessControlMessage(TParams p, ref Message msg)
		{
			if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

			Message m = new Message();
			ScenarioResult sr = new ScenarioResult();
			new NamedPermissionSet("FullTrust").Assert();
//			new SecurityPermission(PermissionState.Unrestricted).Assert();
			PreProcessControlState pcs = c.PreProcessControlMessage(ref m);
			Boolean b = c.PreProcessMessage(ref m);

			switch (pcs)
			{
				case PreProcessControlState.MessageNeeded:
					sr.IncCounters(!b);
					break;

				case PreProcessControlState.MessageNotNeeded:
					sr.IncCounters(!b);
					break;
				case PreProcessControlState.MessageProcessed:
					sr.IncCounters(b);
					break;
			}

			sr.IncCounters(InternalOnlyMethod(p));
			return sr;
		}

        protected virtual ScenarioResult RectangleToClient(TParams p, Rectangle r)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            r = p.ru.GetRectangle();
            return new ScenarioResult(c.RectangleToClient(c.RectangleToScreen(r)).Equals(r));
        }

        protected virtual ScenarioResult RectangleToScreen(TParams p, Rectangle r)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            r = p.ru.GetRectangle();
            return new ScenarioResult(c.RectangleToScreen(c.RectangleToClient(r)).Equals(r));
        }

        protected virtual ScenarioResult Refresh(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // make sure the control is visible and created
            if (c is Form) ((Form)c).TopLevel = false;
            if (c is ToolStripDropDown && !Utilities.HavePermission(LibSecurity.AllWindows))
            {
                ((ToolStripDropDown)c).TopLevel = false;
                ((ToolStripDropDown)c).Parent = this;
            }

            AddObjectToForm(p);
            c.Visible = true;
            p.log.WriteLine("current Visible: " + c.Visible);
            MoveControlOutOfSecurityBubble(p, c);
            if (controlWillNotInvalidate(c, p))
            {
                return ScenarioResult.Pass;
            }

            painted = false;

            PaintEventHandler peh = new PaintEventHandler(this.Painted);

            c.Paint += peh;

            //************************************************
            Rectangle rc = GetVisibleRectangle(p, c);

            // doesn't make sense to invalidate empty rectangle
            if (rc == Rectangle.Empty)
            {
                return ScenarioResult.Pass;
            }

            // in case of 'bizarre' region rectangle-to-invalidate may not be within visible
            // part of the control - to ensure visibility change region to standard 'rectangle'-region
            ((Control)c).Region = null;
            c.Invalidate(rc, true);

            //**********************************************************************************
            c.Refresh();

            // force success if special-cased paint control
            // !!! for new controls IsSpecialCase.. may return False as they are
            // not named among special controls --> add line for new control in IsSpecial..
            if (IsSpecialCasePaintControl(c)) painted = true;

            c.Paint -= peh;
            if (c is ToolStripDropDown && !Utilities.HavePermission(LibSecurity.AllWindows))
            {
                ((ToolStripDropDown)c).Parent = null;
                ((ToolStripDropDown)c).TopLevel = true;
            }
            return new ScenarioResult(painted);
        }

        protected virtual ScenarioResult ResetText(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("initial Text: " + c.Text);
            c.ResetText();
            p.log.WriteLine("Text after reset: " + c.Text);

            bool bResult = c.Text == "";

            return new ScenarioResult(bResult, "FAILED: didn't reset Text to empty string", p.log);
        }

        protected virtual ScenarioResult ResumeLayout(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            c.SuspendLayout();
            c.PerformLayout();
            c.ResumeLayout();
            c.PerformLayout();
            return ScenarioResult.Pass;
        }

        protected ScenarioResult ResumeLayout(TParams p, bool b)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            c.ResumeLayout(false);
            c.ResumeLayout(true);
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult Select(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            if (c is Form) return ScenarioResult.Pass;

            bool canFocus = c.CanFocus;

            p.log.WriteLine("current CanFocus: " + canFocus);

            //need to set Active Control to none
            SafeMethods.SetActiveControl(this, null);
            SafeMethods.Focus(this);
            Application.DoEvents();
            BeginSecurityCheck(LibSecurity.AllWindows);
            c.Select();
            EndSecurityCheck();

            // We'll use ContainsFocus instead of Focused since a control's child can have focus
            // and Focused will return false
            bool result = (canFocus && c.ContainsFocus) || (!canFocus && !c.ContainsFocus);

            p.log.WriteLine("after Select Focused = " + c.Focused.ToString());
            return new ScenarioResult(result);
        }

        //todo: may want to make this test against form or a container control and verify that the next control is selected(activated)
        protected virtual ScenarioResult SelectNextControl(TParams p, Control ctl, Boolean forward, Boolean tabStopOnly, Boolean nested, Boolean wrap)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ctl = c;

            int rng = -1;

            p.log.WriteLine("start ctrl: " + ctl.ToString());

            //check to see if composite control
            if (c.Controls.Count != 0)
            {
                rng = p.ru.GetRange(0, c.Controls.Count - 1);
                ctl = (Control)(c.Controls[rng]);
            }

            foreach (Control ct in c.Controls)
            {
                p.log.WriteLine(ct.ToString());
            }

            p.log.WriteLine("Rng: " + rng.ToString());
            p.log.WriteLine("End ctrl: " + ctl.ToString());
            forward = p.ru.GetBoolean();
            tabStopOnly = p.ru.GetBoolean();
            nested = p.ru.GetBoolean();
            wrap = p.ru.GetBoolean();
            p.log.WriteLine("Forward: " + forward.ToString() + " tabStopOnly: " + tabStopOnly.ToString());
            p.log.WriteLine("Nested: " + nested.ToString() + " Wrap: " + wrap.ToString());
            try
            {
                Application.DoEvents();
                bool b = c.SelectNextControl(ctl, forward, tabStopOnly, nested, wrap);

                p.log.WriteLine("SelectNextControl returned " + b.ToString());

                // Perform check for security purpose.  We want to trigger a security exception.
                while (Controls.Count < 2)
                {
                    Controls.Add(new Button());
                }

                // We'll do it on the form since it's a container control
                SelectNextControl(Controls[0], true, false, false, true);
            }
            catch (SecurityException)
            {
                // UNDONE: This is lame, but the logic that determines if a SecurityException is
                //         thrown is too complex, and would be more work than the test would be
                //         worth.
                BeginSecurityCheck(LibSecurity.AllWindows);
                throw;
            }
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult SendToBack(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            c.SendToBack();
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult Show(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            c.Show();
            return new ScenarioResult(c.Visible, "Show did not set Visible to true");
        }

        protected virtual ScenarioResult SuspendLayout(TParams p)
        {
            return ResumeLayout(p);
        }

        protected virtual ScenarioResult Update(TParams p)
        {
            return Invalidate(p);
        }

        private bool IsMnemonic(TParams p, bool expected, char charCode, String text)
        {
            p.log.Write("Is '" + charCode.ToString() + "' the mnemonic for \"" + text + "\"?  ");

            bool b = Control.IsMnemonic(charCode, text);

            p.log.WriteLine(b ? "YES" : "NO");
            return b == expected;
        }

        protected virtual ScenarioResult set_CausesValidation(TParams p, bool value)
        {
            return get_CausesValidation(p);
        }

        protected virtual ScenarioResult get_CausesValidation(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            bool b = c.CausesValidation;

            p.log.WriteLine("CausesValidation was " + b.ToString());
            c.CausesValidation = !b;

            bool bb = c.CausesValidation;

            p.log.WriteLine("CausesValidation is " + bb.ToString());
            return new ScenarioResult(b != bb);
        }

        protected virtual ScenarioResult get_Handle(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            int h = (int)c.Handle;

            p.log.WriteLine("Handle is " + h.ToString());
            if (PreHandleMode)
            {
                p.target = CreateObject(p);
            }

            return new ScenarioResult(h != 0, "handle not created");
        }

        protected virtual ScenarioResult ResetRightToLeft(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // Get the default value from an unaltered instance of this control
            RightToLeft defaultValue = newC.RightToLeft;

            p.log.WriteLine("default RightToLeft = " + defaultValue.ToString());

            RightToLeft newValue;

            newValue = (RightToLeft)p.ru.GetEnumValue(typeof(RightToLeft));
            p.log.WriteLine("setting RightToLeft to " + newValue.ToString());
            c.RightToLeft = newValue;

            // ResetRightToLeft resets RightToLeft to Inherit
            // so we will need to compare it to Parent.RightToLeft
            p.log.WriteLine("calling ResetRightToLeft()");
            c.ResetRightToLeft();
            newValue = c.RightToLeft;
            if (SafeMethods.GetParent(c) != null)
            {
                RightToLeft expected = SafeMethods.GetParent(c).RightToLeft;

                // cannot set RightToLeft on ListBox - on Win9X, NT4 OSes
                if (c is ListBox && (SafeMethods.GetOSVersion().Platform != System.PlatformID.Win32NT || SafeMethods.GetOSVersion().Version.Major < 5))
                    expected = RightToLeft.No;

                p.log.WriteLine("Default value = {0}, Expected_value = {1}, New_value_after_Reset = {2}", defaultValue.ToString(), expected.ToString(), newValue.ToString());
                return new ScenarioResult(expected.Equals(newValue));
            }
            else
            {
                return new ScenarioResult(true, "The Form/Control has no parent to inherit RTL settings from!");
            }
        }

        protected virtual ScenarioResult ResetForeColor(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // Get the default value from an unaltered instance of this control
            Color defaultValue = newC.ForeColor;
            Color newValue;

            c.ForeColor = p.ru.GetColor();
            c.ResetForeColor();
            newValue = c.ForeColor;
            p.log.WriteLine("Default = {0}, New = {1}", defaultValue, newValue);
            return new ScenarioResult(defaultValue.Equals(newValue));
        }

        protected virtual ScenarioResult ResetBackColor(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // Get the default value from an unaltered instance of this control
            Color defaultValue = newC.BackColor;
            Color newValue;

            c.BackColor = p.ru.GetColor();
            c.ResetBackColor();
            newValue = c.BackColor;
            p.log.WriteLine("Default = {0}, New = {1}", defaultValue, newValue);
            return new ScenarioResult(defaultValue.Equals(newValue));
        }

        protected virtual ScenarioResult ResetFont(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // Get the default value from an unaltered instance of this control
            Font defaultValue = newC.Font;
            Font newValue;

            Font newFont = p.ru.GetFont();
            // work around VSWhidbey #107035 for Label controls
            if (c is Label && (newFont.Unit == GraphicsUnit.Inch || newFont.SizeInPoints > 150))
                newFont = new Font(newFont.FontFamily, Math.Min(newFont.Size, 150f), newFont.Style, GraphicsUnit.Pixel);
            c.Font = newFont;
            c.ResetFont();
            newValue = c.Font;
            p.log.WriteLine("Default = {0}, New = {1}", defaultValue, newValue);
            return new ScenarioResult(defaultValue.Equals(newValue));
        }

        private bool invokeSuccess;

        private delegate void delVoidParamsVoid();

        private delegate void delVoidParamsIntStringObject(int n, String s, Object o);

        private void VoidMethodVoid()
        {
            invokeSuccess = true;
        }

        private void VoidMethodIntStringObject(int n, String s, Object o)
        {
            invokeSuccess = true;
        }

        //Looks like these two methods are removed from Control.
        protected virtual ScenarioResult BeginInvoke(TParams p, Delegate method, Object[] args)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            invokeSuccess = false;
            args = new Object[] { 42, "Howdy!", this };
            c.BeginInvoke(new delVoidParamsIntStringObject(this.VoidMethodIntStringObject), args);
            if (invokeSuccess)
                return new ScenarioResult(false, "InvokeAsync not asynchronous");

            Application.DoEvents();
            return new ScenarioResult(invokeSuccess, "InvokeAsync failed");
        }

        protected virtual ScenarioResult BeginInvoke(TParams p, Delegate method)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            invokeSuccess = false;
            c.BeginInvoke(new delVoidParamsVoid(this.VoidMethodVoid));
            if (invokeSuccess)
                return new ScenarioResult(false, "InvokeAsync not asynchronous");

            Application.DoEvents();
            return new ScenarioResult(invokeSuccess, "InvokeAsync failed");
        }

        // TODO: Test that EndInvoke returns a value properly
        //
        protected virtual ScenarioResult EndInvoke(TParams p, IAsyncResult asyncResult)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            invokeSuccess = false;
            c.EndInvoke(c.BeginInvoke(new delVoidParamsVoid(this.VoidMethodVoid)));
            return new ScenarioResult(invokeSuccess, "InvokeAsync not asynchronous");
        }

        protected virtual ScenarioResult Invoke(TParams p, Delegate method, Object[] args)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            invokeSuccess = false;
            args = new Object[] { 42, "Howdy!", this };
            c.Invoke(new delVoidParamsIntStringObject(this.VoidMethodIntStringObject), args);
            return new ScenarioResult(invokeSuccess, "Invoke failed");
        }

        protected virtual ScenarioResult Invoke(TParams p, Delegate method)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            invokeSuccess = false;
            c.Invoke(new delVoidParamsVoid(this.VoidMethodVoid));
            return new ScenarioResult(invokeSuccess, "Invoke failed");
        }

        protected virtual ScenarioResult FindForm(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult sr = new ScenarioResult();
            Form found = null;
            bool bFound = SecurityCheck(sr, delegate
            {
                found = c.FindForm();
            }, typeof(Control).GetMethod("FindForm"), LibSecurity.AllWindows);


            Control expected = null;
            if (bFound)
            {
                expected = c;

                while (SafeMethods.GetParent(expected) != null)
                { expected = SafeMethods.GetParent(expected); }
            }

            return new ScenarioResult(expected, found, "FAIL: FindForm found the wrong form", p.log);
        }

        protected virtual ScenarioResult DoDragDrop(TParams p, Object data, DragDropEffects allowedEffects)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            data = "Howdy!";
            allowedEffects = (DragDropEffects)p.ru.GetEnumValue(typeof(DragDropEffects));
            SafeMethods.FindForm(c).BringToFront();
            Application.DoEvents();

            // This test would hang if the control was outside of the bounds of the form,
            // so we'll resize the form and relocate the control for this test.
            Rectangle origFormBounds = this.DesktopBounds;
            Point origLoc = c.Location;

            c.Location = new Point(10, 10);
            this.DesktopBounds = new Rectangle(10, 10, 300, 300);
            SafeMethods.SetCursorPosition(c.PointToScreen(new Point(Math.Max(0, -c.Left), Math.Max(0, -c.Top))));
            p.log.WriteLine("Effect tested: " + allowedEffects.ToString());
            p.log.WriteLine("Control bounds: " + c.Bounds.ToString());
            p.log.WriteLine("Form.ClientSize : " + this.ClientSize.ToString());

            DragDropEffects ddeDone = c.DoDragDrop(data, allowedEffects);

            Application.DoEvents();
            p.log.WriteLine("DoDragDrop return value: " + ddeDone.ToString());
            c.Location = origLoc;
            this.DesktopBounds = origFormBounds;
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult CreateGraphics(TParams p, IntPtr dc)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult sr = ScenarioResult.Pass;
            Graphics gr = c.CreateGraphics();

            gr.DrawLine(SystemPens.WindowText, 0, 0, c.Width, c.Height);
            gr.DrawLine(SystemPens.WindowText, c.Width, 0, 0, c.Height);
            Application.DoEvents();
            try
            {
                gr.DrawLine(SystemPens.WindowText, 0, 0, c.Width, c.Height);
                gr.DrawLine(SystemPens.WindowText, c.Width, 0, 0, c.Height);
                gr.Dispose();
            }
            catch (Exception)
            {
                sr = new ScenarioResult(false, "Graphics disposed by forcing message loop");
            }
            c.Invalidate();
            return sr;
        }

        protected virtual ScenarioResult CreateGraphics(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult sr = ScenarioResult.Pass;
            Graphics gr = c.CreateGraphics();

            gr.DrawLine(SystemPens.WindowText, 0, 0, c.Width, c.Height);
            gr.DrawLine(SystemPens.WindowText, c.Width, 0, 0, c.Height);
            Application.DoEvents();
            try
            {
                gr.DrawLine(SystemPens.WindowText, 0, 0, c.Width, c.Height);
                gr.DrawLine(SystemPens.WindowText, c.Width, 0, 0, c.Height);
                gr.Dispose();
            }
            catch (Exception)
            {
                sr = new ScenarioResult(false, "FAILED: Graphics disposed by forcing message loop");
            }
            c.Invalidate();
            return sr;
        }

        protected virtual ScenarioResult set_RightToLeft(TParams p, RightToLeft value)
        {
            return get_RightToLeft(p);
        }

        protected virtual ScenarioResult get_RightToLeft(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            RightToLeft rtle = c.RightToLeft;

            p.log.WriteLine("initially Got: " + EnumTools.GetEnumStringFromValue(typeof(System.Windows.Forms.RightToLeft), (int)rtle));
            rtle = (RightToLeft)p.ru.GetDifferentEnumValue(typeof(System.Windows.Forms.RightToLeft), (int)rtle);
            p.log.WriteLine("Setting to: " + EnumTools.GetEnumStringFromValue(typeof(System.Windows.Forms.RightToLeft), (int)rtle));
            c.RightToLeft = rtle;

            RightToLeft rtle2 = c.RightToLeft;

            p.log.WriteLine("retrieved: " + EnumTools.GetEnumStringFromValue(typeof(System.Windows.Forms.RightToLeft), (int)rtle2));
            Application.DoEvents();
            return new ScenarioResult(rtle2 == GetExpectedRightToLeft(c, rtle), "Expected " + GetExpectedRightToLeft(c, rtle));
        }

        //
        // Returns the expected RightToLeft value given the value set to the control's property.
        //
        private RightToLeft GetExpectedRightToLeft(Control c, RightToLeft setValue)
        {
            if (setValue != RightToLeft.Inherit)
                return setValue;
            else
            {
                // No need to travel up the parent chain since this control will inherit directly
                // from its parent.
                if (SafeMethods.GetParent(c) != null)
                    return SafeMethods.GetParent(c).RightToLeft;
                else
                {
                    // This code copied from Control.DefaultRightToLeft (Private)
                    // We should use RTL by default if the lower 10 bits of LCID are 0x01 or 0x0d.
                    //int lcid = System.Globalization.CultureInfo.CurrentCulture.LCID & 0x3FF; // 0x3FF == lower 10 bits
                    //if (lcid == 0x01 || lcid == 0x0d) 
                    //        return RightToLeft.Yes;
                    //else
                    return RightToLeft.No;
                }
            }
        }

        protected virtual ScenarioResult set_Region(TParams p, Region value)
        {
            return get_Region(p);
        }

        protected virtual ScenarioResult get_Region(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Region orig = c.Region;
            Region region = p.ru.GetRegion(c.Size);

            //willsad 3/2/00
            // Region Type enum cannot be null when setting the random region
            // need to get different region to avoid null ref exception
            while (region == null)
            {
                region = p.ru.GetRegion(c.Size);
            }

            if (c is Form)
            {                      // This is only protected for top-level Forms
                ((Form)c).MdiParent = null;
                ((Form)c).TopLevel = true;
                //				BeginSecurityCheck(LibSecurity.AllWindows);
            }
            
            ScenarioResult sr = new ScenarioResult();
            bool bSet = SecurityCheck(sr, delegate
            {
                c.Region = region;
            }, typeof(Control).GetMethod("set_Region"), (c is Form) ? LibSecurity.AllWindows : LibSecurity.SafeTopLevelWindows);

            bool passed = (c.Region == region);

            // Return region to original value so painting tests aren't screwed up
            SafeMethods.SetRegion(c, orig);
            return new ScenarioResult(bSet, passed, "FAIL: incorrect region", p.log);
        }

        protected virtual ScenarioResult get_InvokeRequired(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            bool b = c.InvokeRequired;

            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult set_ForeColor(TParams p, Color value)
        {
            return get_ForeColor(p);
        }

        protected virtual ScenarioResult get_ForeColor(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Color co = c.ForeColor;
            Color cc = p.ru.GetColor();

            c.ForeColor = cc;
            return new ScenarioResult(cc.Equals(c.ForeColor));
        }

        protected virtual ScenarioResult set_BackColor(TParams p, Color value)
        {
            return get_BackColor(p);
        }

        protected virtual ScenarioResult get_BackColor(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Color co = c.BackColor;
            Color cc = p.ru.GetColor();

            c.BackColor = cc;
            if (PreHandleMode)
                p.target = CreateObject(p);

            return new ScenarioResult(cc.Equals(c.BackColor));
        }

        protected virtual ScenarioResult set_Font(TParams p, Font value)
        {
            return get_Font(p);
        }

        protected virtual ScenarioResult get_Font(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Font f = c.Font;

            p.log.WriteLine("initial Font: " + f.ToString());

            Font ff = p.ru.GetFont();
            // work around VSWhidbey #107035 - Win32Exception for large Fonts on Label
            if (c is Label && (ff.Unit == GraphicsUnit.Inch || ff.SizeInPoints > 150))
                ff = new Font(ff.FontFamily, Math.Min(ff.Size, 150f), ff.Style, GraphicsUnit.Pixel);

            p.log.WriteLine("setting Font to: " + ff.ToString());
            c.Font = ff;
            return new ScenarioResult(ff.Equals(c.Font));
        }

        protected virtual ScenarioResult get_DefaultFont(TParams p)
        {
            Font defaultFont = Control.DefaultFont;
            OperatingSystem osv = SafeMethods.GetOSVersion();

            // JPN WinNT4 has special logic to default to MS UI Gothic
            if (osv.Platform == System.PlatformID.Win32NT && osv.Version.Major <= 4)
            {
                if ((System.Globalization.CultureInfo.CurrentUICulture.LCID & 0x3ff) == 0x0011)
                {
                    p.log.WriteLine("System is JPN NT4, expect MS UI Gothic 8 pt.");
                    p.log.WriteLine("System is JPN NT4, real DefaultFont is " + defaultFont.ToString());
                    if ((System.Globalization.CultureInfo.CurrentCulture.EnglishName.ToString()).IndexOf("Japan") != -1)
                        return new ScenarioResult(defaultFont != null, "Failed: font is null", p.log);

                    return new ScenarioResult(defaultFont.Name == "MS UI Gothic" && defaultFont.Size == 8, "DefaultFont was " + defaultFont);
                }
            }

            // We're really only concerned about the JPN NT4 special case.  The rest of the time,
            // it uses the DEFAULT_GUI_FONT, or a few other choices if that doesn't work.
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult set_ContextMenuStrip(TParams p, ContextMenuStrip value)
        {
            return get_ContextMenuStrip(p);
        }

        protected virtual ScenarioResult get_ContextMenuStrip(TParams p)
        {
            ScenarioResult sr = new ScenarioResult();

            c = GetControl(p);

            ContextMenuStrip cm = c.ContextMenuStrip;
            ContextMenuStrip cm2 = null;

            if (p.ru.GetBoolean())
            {
                cm2 = new ContextMenuStrip();
                cm2.Items.Add(new ToolStripButton());
                cm2.Items.Add(new ToolStripLabel());
                cm2.Items.Add(new ToolStripMenuItem());
                cm2.Items.Add(new ToolStripSeparator());
            }

            c.ContextMenuStrip = cm2;

            sr.IncCounters(cm2 == c.ContextMenuStrip, "Wasn't the right ContextMenuStrip.", p.log);

            if (cm2 != null)
                sr.IncCounters(cm2.Items.Count == 4, "Item count was: " + cm2.Items.Count, p.log);

            return sr;
        }

        protected virtual ScenarioResult set_Dock(TParams p, DockStyle value)
        {
            return get_Dock(p);
        }

        protected virtual ScenarioResult get_Dock(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            DockStyle cde = c.Dock;

            p.log.WriteLine("Dock was " + cde.ToString());
            cde = (DockStyle)p.ru.GetDifferentEnumValue(typeof(DockStyle), (int)cde);
            p.log.WriteLine("Setting Dock to " + cde.ToString());
            c.Dock = cde;
            p.log.WriteLine("Dock is " + c.Dock.ToString());
            return new ScenarioResult(cde == c.Dock);
        }

        protected virtual ScenarioResult set_Cursor(TParams p, Cursor value)
        {
            return get_Cursor(p);
        }

        protected virtual ScenarioResult get_Cursor(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Cursor cu = c.Cursor;

            cu = p.ru.GetCursor();
            BeginSecurityCheck(LibSecurity.SafeSubWindows);
            c.Cursor = cu;
            EndSecurityCheck();
            p.log.Write("UseWaitCursor: " + c.UseWaitCursor);
            return new ScenarioResult(c.UseWaitCursor ? c.Cursor == Cursors.WaitCursor : c.Cursor == cu);
        }

        protected virtual ScenarioResult set_BackgroundImageLayout(TParams p, ImageLayout value)
        {
            return get_BackgroundImageLayout(p);
        }

        protected virtual ScenarioResult get_BackgroundImageLayout(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ImageLayout il = c.BackgroundImageLayout;

            il = (ImageLayout)p.ru.GetEnumValue(typeof(ImageLayout));
            p.log.WriteLine("Setting to " + il.ToString());
            c.BackgroundImageLayout = il;
            return new ScenarioResult(il == c.BackgroundImageLayout, "Set " + il.ToString() + " but Got " + c.BackgroundImageLayout.ToString());
        }

        protected virtual ScenarioResult set_BackgroundImage(TParams p, Image value)
        {
            return get_BackgroundImage(p);
        }

        // Used to fail because of ASURT #19067--now closed.
        //
        protected virtual ScenarioResult get_BackgroundImage(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            Image i = c.BackgroundImage;

            i = p.ru.GetImage(ImageStyle.Random);
            c.BackgroundImage = i;
            return new ScenarioResult(i == c.BackgroundImage);
        }

        protected virtual ScenarioResult set_Anchor(TParams p, AnchorStyles value)
        {
            return get_Anchor(p);
        }

        protected virtual ScenarioResult get_IsMirrored(TParams p)
        {
            p.log.WriteLine("Tested by exclusive test using control consumption");
            return ScenarioResult.Pass;

        }


        protected virtual ScenarioResult get_Anchor(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            AnchorStyles cae = c.Anchor;

            cae = (AnchorStyles)p.ru.GetDifferentEnumValue(typeof(AnchorStyles), (int)cae);
            c.Anchor = cae;
            return new ScenarioResult(cae == c.Anchor);
        }

        protected virtual ScenarioResult set_AllowDrop(TParams p, bool value)
        {
            p.log.WriteLine("In Control.AllowDrop");
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            // SECURITY: Simple security verification.  We only demand when setting it to true.
            // Updated, AllowDrop throws an InvalidOperationException when Clipboard access is denied, not a SecurityException (AndrewD)

			p.log.WriteLine(c.AllowDrop.ToString());
            //Check whether we have read access to the clipboard (the same as AllClipboard)
            bool hasClip = Utilities.HavePermission(LibSecurity.AllClipboard);

            p.log.WriteLine("Security: checking ClipboardPermission: " + (hasClip ? "Granted" : "DENIED"));
            try
            {
                //Attempt to set AllowDrop if we don't have ClipboardRead, this should throw IOE
                c.AllowDrop = true;
                //Should have thrown by now if we had perms
                if (!hasClip)
                {
                    //Mimic the EndSecurityCheck exception
                    throw new ReflectBaseException("FAIL (SECURITY): Setting Control.AllowDrop=true without AllClipboard succeeded (expected InvalidOperationException)");
                }
            }
            catch (InvalidOperationException e)
            {
                //If we can't explain this InvalidOperationException based on the security level
                if (hasClip)
                { throw; }
                else
                {
					p.log.WriteLine(c.AllowDrop.ToString());
					p.log.WriteLine(e.InnerException.ToString());
					p.log.WriteLine("Control.AllowDrop threw InvalidOperationException (as expected) because ClipboardPermission was denied");
                }
            }
            return get_AllowDrop(p);
        }

        protected virtual ScenarioResult get_AllowDrop(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
			try
			{
				ScenarioResult result = new ScenarioResult();

				try
				{
					c.AllowDrop = false;
					result.IncCounters(!c.AllowDrop, "FAIL: set to false, returned true", p.log);

					// We only demand when setting it to true
					SafeMethods.SetAllowDrop(c, true);
					result.IncCounters(c.AllowDrop, "FAIL: set to true, returned false", p.log);
				}
				catch (Exception e)
				{
					// Make sure SecurityExceptions propagate up (bug #78939 by design)
					if (e.InnerException is SecurityException)
						throw e.InnerException;
					else if (e.InnerException is System.Threading.ThreadStateException)
					{
						p.log.LogException(e);
						return new ScenarioResult(false, p.log, BugDb.ASURT, 139401, "ThreadStateException when run as HREF exe.  Postponed for Whidbey.");
					}
					else
						throw;
				}
				return result;
			}
			finally
			{
				SafeMethods.SetAllowDrop(c, false);
			}
        }

        protected virtual ScenarioResult set_IsAccessible(TParams p, bool value)
        {
            return get_IsAccessible(p);
        }

        protected virtual ScenarioResult get_IsAccessible(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            bool b = c.IsAccessible;

            c.IsAccessible = !b;
            return new ScenarioResult(c.IsAccessible == !b);
        }

        protected virtual ScenarioResult set_AccessibleRole(TParams p, AccessibleRole value)
        {
            return get_AccessibleRole(p);
        }

        protected virtual ScenarioResult get_AccessibleRole(TParams p)
        {
            ScenarioResult sr = new ScenarioResult();
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            AccessibleRole are = c.AccessibleRole;

            p.log.WriteLine("AccessibleRole was " + are.ToString());
            are = (AccessibleRole)p.ru.GetDifferentEnumValue(typeof(AccessibleRole), (int)are);
            p.log.WriteLine("Setting AccessibleRole to " + are.ToString());
            c.AccessibleRole = are;
            p.log.WriteLine("AccessibleRole is " + c.AccessibleRole.ToString());
            sr.IncCounters(are, c.AccessibleRole, "Control.AccessibleRole not the value set.", p.log);
            sr.IncCounters(are, c.AccessibilityObject.Role, "Control.AccessibilityObject.Role not the value set for AccessibleRole.", p.log);
            p.log.WriteLine("Setting AccessibleRole to the Default.");
            c.AccessibleRole = AccessibleRole.Default;
            AccessibleRole expectedDefaultRole = GetDefaultAccessibleRoleForType(c.GetType());
            sr.IncCounters(AccessibleRole.Default, c.AccessibleRole, "Control.AccessibleRole not AccessibleRole.Default.", p.log);
            sr.IncCounters(expectedDefaultRole, SafeMethods.GetAccessibleRole(c.AccessibilityObject), "Control.AccessibilityObject.Role not the value expected when setting AccessibleRole to the default.", p.log);
            return sr;
        }

        protected virtual ScenarioResult set_AccessibleName(TParams p, String value)
        {
            return get_AccessibleName(p);
        }

        protected virtual ScenarioResult get_AccessibleName(TParams p)
        {
            ScenarioResult sr = new ScenarioResult();
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            String s = c.AccessibleName;
            p.log.WriteLine("AccessibleName was " + s);
            s = p.ru.GetString(255, true);
            c.AccessibleName = s;
            p.log.WriteLine("AccessibleName is " + c.AccessibleName);
            p.log.WriteLine("Control.AccessibleObject.Name is " + c.AccessibilityObject.Name);
            sr.IncCounters(s, c.AccessibleName, "Control.AccessibleName not the value it was set to.", p.log);
            sr.IncCounters(s, c.AccessibilityObject.Name, "Control.AccessiblityObject.Name not the value Control.AccessibleName was set to.", p.log);
            return sr;
        }

        protected virtual ScenarioResult set_AccessibleDescription(TParams p, String s)
        {
            return get_AccessibleDescription(p);
        }

        protected virtual ScenarioResult get_AccessibleDescription(TParams p)
        {
            ScenarioResult sr = new ScenarioResult();
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            String s = c.AccessibleDescription;
            p.log.WriteLine("AccessibleDescription was " + s);
            s = p.ru.GetString(255, true);
            c.AccessibleDescription = s;
            p.log.WriteLine("AccessibleDescription is " + c.AccessibleDescription);
            p.log.WriteLine("Control.AccessibleObject.Description is " + c.AccessibilityObject.Description);
            sr.IncCounters(s, c.AccessibleDescription, "Control.AccessibleDescription not the value it was set to.", p.log);
            sr.IncCounters(s, c.AccessibilityObject.Description, "Control.AccessiblityObject.Description not the value Control.AccessibleDescription was set to.", p.log);
            return sr;

        }

        protected virtual ScenarioResult set_AccessibleDefaultActionDescription(TParams p, String s)
        {
            return get_AccessibleDefaultActionDescription(p);
        }

        protected virtual ScenarioResult get_AccessibleDefaultActionDescription(TParams p)
        {
            ScenarioResult sr = new ScenarioResult();
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            String s = c.AccessibleDefaultActionDescription;
            p.log.WriteLine("AccessibleDefaultActionDescription was " + s);
            s = p.ru.GetString(255, true);
            c.AccessibleDefaultActionDescription = s;
            p.log.WriteLine("AccessibleDefaultActionDescription is " + c.AccessibleDefaultActionDescription);
            p.log.WriteLine("Control.AccessibleObject.DefaultAction is " + c.AccessibilityObject.DefaultAction);
            sr.IncCounters(s, c.AccessibleDefaultActionDescription, "Control.AccessibleDefaultActionDescription not the value it was set to.", p.log);
            sr.IncCounters(s, c.AccessibilityObject.DefaultAction, "Control.AccessiblityObject.DefaultAction not the value Control.AccessibleDefaultActionDescription was set to.", p.log);
            return sr;
        }

        // Calling AccessibilityObject results in handle creation. 
        // AccObj.Bounds return unpredictable resuls when Form with the control 
        // has no handle created and was not yet shown.
        // AccessibleObject.Bounds will depend on a location of the Form.
        // This scenario can be removed from PreHandle scenarios
        [PreHandleScenario(false)]
        protected virtual ScenarioResult get_AccessibilityObject(TParams p)
        {
            // Need to override per control to test the following properties:
            // DefaultAction
            // KeyboardShortcut
            // Parent
            // State
            // Value
            // The following properties are tested elsewhere in XControl
            // Description
            // Name
            // Role

            ScenarioResult sr = new ScenarioResult();
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            AccessibleObject cao = c.AccessibilityObject;
            p.log.WriteLine("Test Accessible Object Bounds");
            sr.IncCounters(c.RectangleToScreen(c.ClientRectangle), SafeMethods.GetAccessibleBounds(cao), "Bounds for control and the accessible object don't match.", p.log);
            return sr;
        }

        protected virtual ScenarioResult get_CompanyName(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            String cn = c.CompanyName;
            String en = "Microsoft Corporation";

            return new ScenarioResult(cn.Equals(en));
        }

        protected virtual ScenarioResult get_ProductName(TParams p)
        {

            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

			//The unicode value of the registered trademark symbol
			int characterCode = 0x00AE;
            String actualValue = c.ProductName;
            String oldExpectedValue = "Microsoft(R) .NET Framework";
			String newExpectedValue = "Microsoft" + Convert.ToChar(characterCode) + " .NET Framework"; 

            return new ScenarioResult(actualValue.Equals(oldExpectedValue) || actualValue.Equals(newExpectedValue), "Unexpected value: " + actualValue);
        }

        protected virtual ScenarioResult get_ProductVersion(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            String pv = c.ProductVersion;

            return new ScenarioResult(!pv.Equals(null));
        }

        protected virtual ScenarioResult ResetCursor(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // Get the default value from an unaltered instance of this control
            Cursor defaultValue = newC.Cursor;
            Cursor newValue;

            c.Cursor = p.ru.GetCursor();
            c.ResetCursor();
            newValue = c.Cursor;
            p.log.WriteLine("Default = {0}, New = {1}", defaultValue, newValue);
            p.log.WriteLine("UseWaitCursor = " + c.UseWaitCursor);
            return new ScenarioResult(c.UseWaitCursor ? newValue == Cursors.WaitCursor : defaultValue.Equals(newValue));
        }

        // get_Control.Site calls base.get_Site
        protected override ScenarioResult get_Site(TParams p)
        {
            return base.get_Site(p);
        }

        // basically set_Site also calls bast.set_Site()
        // with only difference that it raises On[Font/ForeColor/BackColor/Cursor]Changed
        // events in these properties change as a result base.set_Site() call
        // As base(Component) implementation of Site doesn't really do anything,
        // it doesn't make sense to check if listed events are raised - it will never be the case
        // So we'll just call base.set_Site()
        protected override ScenarioResult set_Site(TParams p, ISite value)
        {
            return base.set_Site(p, value);
        }

        protected virtual ScenarioResult get_DataBindings(TParams p)
        {
            p.log.WriteLine("Tested by DataBinding automation");
            return ScenarioResult.Pass;
        }

        protected ScenarioResult ResetBindings(TParams p)
        {
            p.log.WriteLine("Tested by DataBinding automation");
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult get_BindingContext(TParams p)
        {
            p.log.WriteLine("Tested by DataBinding automation");
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult set_BindingContext(TParams p, BindingContext value)
        {
            p.log.WriteLine("Tested by DataBinding automation");
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult Invalidate(TParams p, Region region, bool invalidateChildren)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            if (c is Form)
                ((Form)c).TopLevel = false;

            region = p.ru.GetRegion(c.Size);
            invalidateChildren = p.ru.GetBoolean();
            c.Invalidate(region, invalidateChildren);
            Application.DoEvents();
            return ScenarioResult.Pass;
        }

        protected virtual ScenarioResult Invalidate(TParams p, Region region)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            if (c is Form)
                ((Form)c).TopLevel = false;

            region = p.ru.GetRegion(c.Size);
            c.Invalidate(region);
            Application.DoEvents();
            return ScenarioResult.Pass;
        }

        [OverrideScenario]
        protected override ScenarioResult Dispose(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("Control.IsDisposed before calling Control.Dispose is " + c.IsDisposed.ToString());
            p.log.WriteLine("Control.Disposing before calling Control.Dispose is " + c.Disposing.ToString());

            bool result;

            try
            {
                c.Dispose();
                p.log.WriteLine("Control.Disposing after calling Control.Dispose is " + c.Disposing.ToString());
                p.log.WriteLine("Control.IsDisposed after calling Control.Dispose is " + c.IsDisposed.ToString());
                result = c.IsDisposed;
            }
            catch (Exception e)
            {
                p.log.WriteLine("Exception thrown: " + e.ToString());
                result = false;
            }

            RecreateControl(p);
            return new ScenarioResult(result);
        }

        protected virtual void RecreateControl(TParams p)
        {
            // since we nuked the Control by calling Dispose, we should recreate it.
            // we can't guarantee that this method is the last one called.
            p.target = (Control)this.CreateObject(p);
            if (c is Form)
                ((Form)c).TopLevel = false;

            this.AddObjectToForm(p);
            Application.DoEvents();
        }

        //
        // Special case methods to handle Docked, Anchored, and AutoSize controls
        //
        protected bool PreservesHeight(Control c, TParams p)
        {
            DockStyle dock = c.Dock;

            if ((c is Label) && ((Label)c).AutoSize)
            {
                p.log.WriteLine("AutoSize = true");
                return true;
            }

			if ((c is TextBox) && (!((TextBox)c).Multiline) && ((TextBox)c).AutoSize)
			{
				p.log.WriteLine("AutoSize = true");
				return true;
			}

            if ((c is RichTextBox) && (!((RichTextBox)c).Multiline) && ((RichTextBox)c).AutoSize)
            {
                p.log.WriteLine("AutoSize = true");
                return true;
            }

            if ((c is PictureBox) && ((PictureBox)c).SizeMode == PictureBoxSizeMode.AutoSize)
            {
                p.log.WriteLine("AutoSize = true");
                return true;
            }

            if ((c is TrackBar) && ((TrackBar)c).Orientation == Orientation.Horizontal && ((TrackBar)c).AutoSize)
            {
                p.log.WriteLine("Orientation = Horizontal");
                p.log.WriteLine("AutoSize = true");
                return true;
            }

            if (c is UpDownBase)
                return true;

            if (c is DateTimePicker)
                return true;

            if (c is ComboBox && ((ComboBox)c).DropDownStyle != ComboBoxStyle.Simple)
                return true;

            if (PreHandleMode && c is Splitter && (dock == DockStyle.Left || dock == DockStyle.Right || dock == DockStyle.Fill))
                return true;

            // no AutoSize property or AutoSize == false 
            if ((dock == DockStyle.Left || dock == DockStyle.Right || dock == DockStyle.Fill) && c.Visible)
                return true;

            if (c is ToolStrip && (((ToolStrip)c).AutoSize || (((ToolStrip)c).Dock == DockStyle.Left || ((ToolStrip)c).Dock == DockStyle.Fill || ((ToolStrip)c).Dock == DockStyle.Right)))
            { return true; }
            // DockStyle Top and Bottom
            return false;
        }

        protected bool PreservesWidth(Control c, TParams p)
        {
            DockStyle dock = c.Dock;

            if ((c is Label) && ((Label)c).AutoSize)
            {
                p.log.WriteLine("AutoSize = true");
                return true;
            }

            if ((c is PictureBox) && ((PictureBox)c).SizeMode == PictureBoxSizeMode.AutoSize)
            {
                p.log.WriteLine("AutoSize = true");
                return true;
            }

            if ((c is TrackBar) && ((TrackBar)c).Orientation == Orientation.Vertical && ((TrackBar)c).AutoSize)
            {
                p.log.WriteLine("Orientation = Vertical");
                p.log.WriteLine("AutoSize = true");
                return true;
            }

            if (PreHandleMode && ((c is Splitter) || (c is ToolStrip)) && (dock == DockStyle.Top || dock == DockStyle.Bottom || dock == DockStyle.Fill))
                return true;

            // no AutoSize property or AutoSize == false  
            if ((dock == DockStyle.Top || dock == DockStyle.Bottom || dock == DockStyle.Fill) && c.Visible)
                return true;

            if (c is ToolStrip && (((ToolStrip)c).AutoSize || (((ToolStrip)c).Dock == DockStyle.Top || ((ToolStrip)c).Dock == DockStyle.Fill || ((ToolStrip)c).Dock == DockStyle.Bottom)))
            { return true; }

            // DockStyle Left and Right
            return false;
        }

        protected int GetExpectedX(Control c, Rectangle orig, Rectangle expected)
        {
            DockStyle ds = c.Dock;

            if (ds == DockStyle.Fill || ds == DockStyle.Left || ds == DockStyle.Top || ds == DockStyle.Bottom)
                return orig.X;

            if (ds == DockStyle.Right)
                return orig.X + (orig.Width - expected.Width);

            // Not Docked
            return expected.X;
        }

        protected int GetExpectedY(Control c, Rectangle orig, Rectangle expected)
        {
            DockStyle ds = c.Dock;

            if (ds == DockStyle.Fill || ds == DockStyle.Top || ds == DockStyle.Left || ds == DockStyle.Right)
                return orig.Y;

            if (ds == DockStyle.Bottom)
                return orig.Y + (orig.Height - expected.Height);

            // Not Docked
            return expected.Y;
        }

        // NOTE:  SetSizeHelper() IS NOW OBSOLETE!!  Need to move this code to get_Size() and fix
        //        any tests that break.
        // Use this enum to determine which method/property SetSizeHelper tests.
        //
        protected enum SizeMethod { SetSizeMethod, SizeProperty }

        //
        // SetSizeHelper contains code to test both the SetSize methods.  Specify which
        // method to test using the SizeMethod enum.  The ScenarioResult is returned in the
        // "result" out parameter.
        //
        // TODO: (KevinTao 9/14/2000) Create virtual CalculateExpectedHeight() and one for width.
        //       Control classes can override these methods rather than polluting XRichControl
        //       with special case code.
        //
        protected virtual void SetSizeHelper(TParams p, SizeMethod which, out ScenarioResult result)
        {
            if ((c = GetControl(p)) == null)
            {
                result = ScenarioResult.Fail;
                return;
            }

            Control parent = SafeMethods.GetParent(c);

            if (parent == null)
                p.log.WriteLine("Parent is null.");
            else
                p.log.WriteLine("Parent's Size: " + parent.Size.ToString());

            DockStyle initDS = DockStyle.None;

            if (c is CheckedListBox)
            {
                p.log.WriteLine("-- testing CheckedListBox --");
                initDS = ((CheckedListBox)c).Dock;
                ((CheckedListBox)c).Dock = DockStyle.None;
                p.log.WriteLine("number of Items: " + ((CheckedListBox)c).Items.Count);
                p.log.WriteLine("IntegralHeight: " + ((CheckedListBox)c).IntegralHeight);
                p.log.WriteLine("ItemHeight: " + ((CheckedListBox)c).ItemHeight);
            }

            p.log.WriteLine("current DockStyle: " + ((Enum)c.Dock).ToString());

            Size origSize = c.Size;

            Size maxSize = this.Size;
            if (c is ToolStripDropDown | c is Form)
                maxSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;

            Size newSize = p.ru.GetSize(maxSize);

            if (c is ComboBox && newSize.Width == 0)
                newSize.Width = 1;
            if (c is Splitter)
            {
                if (newSize.Width < 3)
                    newSize.Width = 3;
                if (newSize.Height < 3)
                    newSize.Height = 3;
            }

            p.log.WriteLine("Size was " + origSize.ToString());
            p.log.WriteLine("Setting Size to " + newSize.ToString());
            if (which == SizeMethod.SetSizeMethod)
                c.Size = new Size(newSize.Width, newSize.Height);
            else
                c.Size = newSize;

            Size expectedSize = newSize;

            if (PreservesWidth(c, p))
            {
                expectedSize.Width = origSize.Width;
                p.log.WriteLine("Preserves width at " + expectedSize.Width);
            }

            if (PreservesHeight(c, p))
            {
                expectedSize.Height = origSize.Height;
                p.log.WriteLine("Preserves height at " + expectedSize.Height);
            }
            else if (c is ListBox)
                expectedSize.Height = listBoxExpectedHeight((ListBox)c, origSize.Height, newSize.Height, p);

            if (c is SplitContainer)
            {
                SplitContainer sc = (SplitContainer)c;
                int wd = 0;
                if (sc.BorderStyle == BorderStyle.FixedSingle)
                    wd = SystemInformation.BorderSize.Width;
                else if (sc.BorderStyle == BorderStyle.Fixed3D)
                    wd = SystemInformation.Border3DSize.Width;

                wd = sc.Panel1MinSize + sc.Panel2MinSize + sc.SplitterWidth + wd;
                if (expectedSize.Width < wd && (sc.Orientation == Orientation.Vertical))
                    expectedSize.Width = wd;
                if (expectedSize.Height < wd && (sc.Orientation == Orientation.Horizontal))
                    expectedSize.Height = wd;
            }

            Size sz = c.Size;

            p.log.WriteLine("Size is " + sz.ToString());
            p.log.WriteLine("expected Size is " + expectedSize.ToString());
            if (c is CheckedListBox)
            {
                ((CheckedListBox)c).Dock = initDS;
            }

            result = new ScenarioResult(sz.Equals(expectedSize));
        }

        //
        //  when ListBox has 1)DrawMode.Normal or DrawMode.OwnerDrawFixed, 2)IntegralHeight = true,
        //  3)Items.Count > 0
        //  Height of ListBox is adjusted to show only fully displayed items
        //
        protected int listBoxExpectedHeight(ListBox lb, int origHeight, int newHeight, TParams p)
        {
            int expectedHeight = newHeight;

            p.log.WriteLine("current BorderStyle = " + lb.BorderStyle.ToString());
            if (PreHandleMode)
                return expectedHeight;

            // when IntegralHeight = true Height of ListBox is adjusted to show only full items
            if (lb.DrawMode != DrawMode.OwnerDrawVariable && lb.IntegralHeight && lb.Items.Count > 0)
            {
                p.log.WriteLine("DrawMode: " + lb.DrawMode.ToString());
                p.log.WriteLine("IntegralHeight: " + lb.IntegralHeight);
                p.log.WriteLine("Height was " + origHeight);

                // calculate expected Height
                // GetItemHeight(index) returns real Height of items
                // all items have the same Height in iven DrawModes
                int itmHght = lb.GetItemHeight(0);    // real Item Height
                int delta = origHeight - itmHght * (int)(origHeight / itmHght);

                p.log.WriteLine("GetItemHeight(): " + itmHght);
                p.log.WriteLine("delta = " + delta);

                // when new Height < ItemHeight * n + delta, resulting Height will be set to delta
                if (newHeight < (itmHght * (int)(newHeight / itmHght) + delta))
                    expectedHeight = newHeight - itmHght;

                expectedHeight = itmHght * (int)(expectedHeight / itmHght) + delta;
                if (expectedHeight < 0 && newHeight < delta)
                {
                    if (newHeight == 0)
                        expectedHeight = delta;
                    else
                        expectedHeight = newHeight;
                }
                // not true any more               
                //    if ((expectedHeight == 0) && (delta == 0))
                //          expectedHeight = itmHght;
            }

            p.log.WriteLine("expected Height: " + expectedHeight);
            return expectedHeight;
        }

        protected virtual ScenarioResult get_Size(TParams p)
        {
            ScenarioResult result;

            SetSizeHelper(p, SizeMethod.SizeProperty, out result);
            return result;
        }

        protected virtual ScenarioResult set_Size(TParams p, Size value)
        {
            return get_Size(p);
        }

        protected virtual ScenarioResult set_Width(TParams p, int value)
        {
            return get_Width(p);
        }

        protected virtual ScenarioResult get_Width(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            p.log.WriteLine("current DockStyle: " + ((Enum)c.Dock).ToString());

            int oldWidth = c.Width;
            int newWidth = p.ru.GetRange(0, c.Size.Width * 3); // set upper bound of 3 x current width
            if (c is Splitter)
            {
                if (newWidth < 3)
                    newWidth = 3;
            }

            p.log.WriteLine("initial Width is " + oldWidth.ToString());
            p.log.WriteLine("setting width to " + newWidth.ToString());
            c.Width = newWidth;

            int w = c.Width;
            int wExpected = newWidth;

            p.log.WriteLine("new Width is " + w.ToString());
            if (PreservesWidth(c, p))
                wExpected = oldWidth;

            // Width of the Vertical SplitContainer is limited by the value below
            if (c is SplitContainer && ((SplitContainer)c).Orientation == Orientation.Vertical)
            {
                SplitContainer sc = (SplitContainer)c;
                int wd = 0;
                if (sc.BorderStyle == BorderStyle.FixedSingle)
                    wd = SystemInformation.BorderSize.Width;
                else if (sc.BorderStyle == BorderStyle.Fixed3D)
                    wd = SystemInformation.Border3DSize.Width;

                wd = sc.Panel1MinSize + sc.Panel2MinSize + sc.SplitterWidth + wd;
                if (wExpected < wd)
                    wExpected = wd;
            }

            p.log.WriteLine("expected Width: " + wExpected.ToString());
            return new ScenarioResult(w == wExpected, "failed to set/get Width as expected", p.log);
        }

        //
        // Used with BoundsHelper to determine which bounds method or property to use in
        // the test.
        //
        protected enum BoundsMethod
        {
            Property,                   // Bounds property
            MethodNoSpecified,          // SetBounds(int, int, int, int)
            MethodSpecified             // SetBounds(int, int, int, int, BoundsSpecified)
        }

        //
        // Helper method to test all three Bounds methods/property.
        //
        protected virtual void BoundsHelper(TParams p, BoundsMethod which, out ScenarioResult result)
        {
            if ((c = GetControl(p)) == null)
            {
                result = ScenarioResult.Fail;
                return;
            }

            p.log.WriteLine("current DockStyle: " + ((Enum)c.Dock).ToString());

            Rectangle origRect = c.Bounds;
            Rectangle newRect = p.ru.GetIntersectingRectangle(this.ClientRectangle);

            //BoundsSpecified bs = 0;
            BoundsSpecified bs = BoundsSpecified.All;

            p.log.WriteLine("initial Bounds: " + origRect.ToString());
            p.log.WriteLine("Setting Bounds to " + newRect.ToString());
            switch (which)
            {
                case BoundsMethod.Property:
                    c.Bounds = newRect;
                    break;

                case BoundsMethod.MethodNoSpecified:
                    c.SetBounds(newRect.X, newRect.Y, newRect.Width, newRect.Height);
                    break;

                case BoundsMethod.MethodSpecified:
                    bs = (BoundsSpecified)p.ru.GetEnumValue(typeof(BoundsSpecified));
                    p.log.WriteLine("SetBounds parameters : " + newRect.ToString() + ", " + bs.ToString());
                    c.SetBounds(newRect.X, newRect.Y, newRect.Width, newRect.Height, bs);
                    break;

                default:
                    throw new ArgumentException("Invalid BoundsMethod: " + which.ToString());
            }

            // Adjust expected Rect to account for dock, autosize, bounds specified, etc.
            Rectangle bounds = c.Bounds;
            Rectangle rExpected;

            p.log.WriteLine("new Bounds: " + bounds.ToString());
            if (which != BoundsMethod.MethodSpecified)
                rExpected = newRect;    // start with the new rect
            else
            {
                rExpected = origRect;   // start with orig rect, and add specified bounds
                if ((bs & BoundsSpecified.X) == BoundsSpecified.X)
                    rExpected.X = newRect.X;

                if ((bs & BoundsSpecified.Y) == BoundsSpecified.Y)
                    rExpected.Y = newRect.Y;

                if ((bs & BoundsSpecified.Width) == BoundsSpecified.Width)
                    rExpected.Width = newRect.Width;

                if ((bs & BoundsSpecified.Height) == BoundsSpecified.Height)
                    rExpected.Height = newRect.Height;
            }

            if (c is Splitter)
            {
                if (rExpected.Width == 0) rExpected.Width = 3;

                if (rExpected.Height == 0) rExpected.Height = 3;
            }

            if (c is SplitContainer)
            {
                SplitContainer sc = ((SplitContainer)c);
                int borderSize = 0;
                switch (sc.BorderStyle)
                {
                    case BorderStyle.FixedSingle:
                        borderSize = SystemInformation.BorderSize.Width;
                        break;
                    case BorderStyle.Fixed3D:
                        borderSize = SystemInformation.Border3DSize.Width;
                        break;
                }
                int minAllowed = sc.Panel1MinSize + sc.Panel2MinSize +
                    sc.SplitterWidth + borderSize;
                if ((sc.Orientation == Orientation.Vertical) && (rExpected.Width < minAllowed))
                    rExpected.Width = minAllowed;
                else if ((sc.Orientation == Orientation.Horizontal) && (rExpected.Height < minAllowed))
                    rExpected.Height = minAllowed;
            }

            if (PreservesHeight(c, p))
                rExpected.Height = origRect.Height;
            else if (c is ListBox && (bs & BoundsSpecified.Height) == BoundsSpecified.Height)
                rExpected.Height = listBoxExpectedHeight((ListBox)c, origRect.Height, newRect.Height, p);

            if (PreservesWidth(c, p))
                rExpected.Width = origRect.Width;

            //
            // Height of a ComboBox with DropDownStyle != ComboBoxStyle.Simple
            // will be set depending of Font.Height before handle is created 
            // TODO: (?) in some cases we have handle already created for the ComboBox when running in PreHandleMode (?)
            // attempt to re-create control results in multiple failures afterwards.
            // At current stage we'll leave the situation as it is.	 But will need to look into this later on.
            //
            if (PreHandleMode && c is ComboBox && (((ComboBox)c).DropDownStyle != ComboBoxStyle.Simple))
            {
                //  rExpected.Height = (int)c.Font.Height + SystemInformation.BorderSize.Height * 4 + 3;
                p.log.WriteLine("... testing ComboBox in prehandle mode...");
                p.log.WriteLine(" ComboBox.PreferredHeight = " + ((ComboBox)c).PreferredHeight);
                if (c.IsHandleCreated)		 // preserves orig Height for DropDownStyle other than Simple
                    rExpected.Height = origRect.Height;
                else

                    //  (KevinTao)
                    //  TODO: ComboBox height is always PreferredHeight if the ComboBox is parented so this code didn't work for me
                    //        in Whidbey or RTM.  Need to figure out if this code was correct in the first place.
                    //					rExpected.Height = newRect.Height;
                    rExpected.Height = ((ComboBox)c).PreferredHeight;

                p.log.WriteLine("ComboBox.IsHandleCreated: " + c.IsHandleCreated);
            }

            // correct Location
            rExpected.X = GetExpectedX(c, origRect, rExpected);
            rExpected.Y = GetExpectedY(c, origRect, rExpected);
            p.log.WriteLine("expected Bounds: " + rExpected.ToString());
            result = new ScenarioResult(bounds.Equals(rExpected));
        }

        protected virtual ScenarioResult set_Bounds(TParams p, Rectangle value)
        {
            return get_Bounds(p);
        }

        protected virtual ScenarioResult get_Bounds(TParams p)
        {
            ScenarioResult result;

            BoundsHelper(p, BoundsMethod.Property, out result);
            return result;
        }

        protected virtual ScenarioResult SetBounds(TParams p, Int32 x, Int32 y, Int32 width, Int32 height)
        {
            ScenarioResult result;

            BoundsHelper(p, BoundsMethod.MethodNoSpecified, out result);
            return result;
        }

        protected virtual ScenarioResult SetBounds(TParams p, Int32 x, Int32 y, Int32 width, Int32 height, BoundsSpecified specified)
        {
            ScenarioResult result;

            BoundsHelper(p, BoundsMethod.MethodSpecified, out result);
            return result;
        }

        protected virtual ScenarioResult set_Height(TParams p, int value)
        {
            return get_Height(p);
        }

        protected virtual ScenarioResult get_Height(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            int origHeight = c.Height;
            //int newHeight = p.ru.GetRange(1, 1024);
            int newHeight = p.ru.GetRange(1, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);

            p.log.WriteLine("initial Height is " + origHeight.ToString());
            p.log.WriteLine("Setting Height to " + newHeight.ToString());
            c.Height = newHeight;

            int height = c.Height;
            int hExpected = newHeight;

            p.log.WriteLine(" new Height is " + height.ToString());
            if (PreservesHeight(c, p))
                hExpected = origHeight;
            else if (c is ListBox)
                hExpected = listBoxExpectedHeight((ListBox)c, origHeight, newHeight, p);

            // Height of the Horizontal SplitContainer is limited by the value below
            if (c is SplitContainer && ((SplitContainer)c).Orientation == Orientation.Horizontal)
            {
                SplitContainer sc = (SplitContainer)c;
                int ht = 0;
                if (sc.BorderStyle == BorderStyle.FixedSingle)
                    ht = SystemInformation.BorderSize.Height;
                else if (sc.BorderStyle == BorderStyle.Fixed3D)
                    ht = SystemInformation.Border3DSize.Height;

                ht = sc.Panel1MinSize + sc.Panel2MinSize + sc.SplitterWidth + ht;
                if (hExpected < ht)
                    hExpected = ht;
            }
            p.log.WriteLine("expected Height: " + hExpected.ToString());
            return new ScenarioResult(height == hExpected, "failed set/get Height as expected", p.log);
        }

        // Use this enum to determine which method/property ScaleHelper tests.
        //
        protected enum ScaleMethod { OneParam, TwoParam, Struct }

        //
        // ScaleHelper contains code to test both the Scale methods.  Specify which
        // method to test using the ScaleMethod enum.  The ScenarioResult is returned in the
        // "result" out parameter.
        // TODO: Remove logic for the one param.  We only have SizeF now.

#pragma warning disable 618 // 618 = Obsolete
        protected virtual void ScaleHelper(TParams p, ScaleMethod which, out ScenarioResult result)
        {
            if ((c = GetControl(p)) == null)
            {
                result = ScenarioResult.Fail;
                return;
            }

            result = new ScenarioResult();
            p.log.WriteLine("current DockStyle: " + ((Enum)c.Dock).ToString());

            // REVIEW: What is this for?
            c.Scale(0.5f);
            c.Scale(2.0f);

            // Set up scale values based on which method we're testing
            //
            float xScale;
            float yScale;

            if (which == ScaleMethod.OneParam)
            {
                xScale = 0.5f;
                yScale = xScale;
            }
            else
            {
                xScale = 0.5f;
                yScale = 4.0f;

                // Max height appears to be 29632, so we only allow a height of 1/4 this so that we can test it
                if (c.Height > 7408) c.Height = 7408;
            }

            // Set up variables and call the appropriate Scale() method
            //
            Size origSize = c.Size;
            Size expectedSize = new Size((int)(origSize.Width * xScale), (int)(origSize.Height * yScale));
            Size newSize;
            Point origLocation = c.Location;
            Point expectedLocation = new Point((int)(origLocation.X * xScale), (int)(origLocation.Y * yScale));
            Point newLocation;

            p.log.WriteLine("initial Size was " + origSize.ToString());
            p.log.WriteLine("initial Location was " + origLocation.ToString());
            if (which == ScaleMethod.OneParam)
                c.Scale(xScale);
            else if (which == ScaleMethod.TwoParam)
                c.Scale(xScale, yScale);
            else
            {
                SizeF newScale = new SizeF(xScale, yScale);
                c.Scale(newScale);
            }

            newSize = c.Size;
            newLocation = c.Location;

            // Calculate expected size and location
            //
            if (PreservesHeight(c, p))
                expectedSize.Height = origSize.Height;
            else if (c is ListBox)
                expectedSize.Height = listBoxExpectedHeight((ListBox)c, origSize.Height, newSize.Height, p);

            if (PreservesWidth(c, p))
                expectedSize.Width = origSize.Width;

            expectedLocation.X = GetExpectedX(c, new Rectangle(origLocation, origSize), new Rectangle(newLocation, newSize));
            expectedLocation.Y = GetExpectedY(c, new Rectangle(origLocation, origSize), new Rectangle(newLocation, newSize));

            // Check results
            //
            if (which == ScaleMethod.OneParam)
            {
                p.log.WriteLine("after Scale({0}) Size is {1}", xScale, newSize.ToString());
                p.log.WriteLine("after Scale({0}) Location is {1}", xScale, newLocation.ToString());
            }
            else
            {
                p.log.WriteLine("after Scale({0}, {1}) Size is {2}", xScale, yScale, newSize.ToString());
                p.log.WriteLine("after Scale({0}, {1}) Location is {2}", xScale, yScale, newLocation.ToString());
            }

            result.IncCounters(newSize.Equals(expectedSize), "1. Size: " + newSize + " != " + expectedSize, p.log);
            result.IncCounters(newLocation.Equals(expectedLocation), "2. Loc: " + newLocation + " != " + expectedLocation, p.log);

            // Rescale to original size and check results
            //
            if (which == ScaleMethod.OneParam)
                c.Scale(1.0f / xScale);
            else if (which == ScaleMethod.TwoParam)
                c.Scale(1.0f / xScale, 1.0f / yScale);
            else
            {
                SizeF oldScale = new SizeF(1 / xScale, 1 / yScale);
                c.Scale(oldScale);
            }

            newSize = c.Size;
            newLocation = c.Location;
            p.log.WriteLine("recreated Size is " + newSize.ToString());
            p.log.WriteLine("recreated Location is " + newLocation.ToString());

            // due to bug #34060 resolution - "round-off impercision is by Design"
            // we'll allow small flactuation in results
            bool res = origSize.Equals(newSize) || (Math.Abs(origSize.Width - newSize.Width) <= 1 && Math.Abs(origSize.Height - newSize.Height) <= 1);

            if (!res && (origSize.Height + origLocation.Y < 0 || origSize.Width + origLocation.X < 0))
                result.IncCounters(false, p.log, BugDb.ASURT, 115223, "3. Size: " + newSize + " != " + origSize);
            else
                result.IncCounters(res, "3. Size: " + newSize + " != " + origSize, p.log);

            res = origLocation.Equals(newLocation) || (Math.Abs(origLocation.X - newLocation.X) <= 1 && Math.Abs(origLocation.Y - newLocation.Y) <= 1);
            result.IncCounters(res, "4. Loc: " + newLocation + " != " + origLocation, p.log);

            // in ListBox this small impercision results in greater difference in Height
            // when IntegralHeight = true
            if (origSize != newSize)
            {
                if (c is ListBox && ((ListBox)c).IntegralHeight == true)
                {
                    int temp = Math.Abs(origSize.Height - newSize.Height);
                    int temp1 = ((ListBox)c).GetItemHeight(0);

                    if (Math.IEEERemainder(temp, temp1) == 0)
                    {
                        p.log.WriteLine("Height differs because of round-off imprecision");
                        result = ScenarioResult.Pass;
                    }
                }
            }

            // in ComboBox this small imprecision results in greater difference in Height
            // when IntegralHeight = true
            if (origSize != newSize)
            {
                if (c is ComboBox && ((ComboBox)c).IntegralHeight == true)
                {
                    int temp = Math.Abs(origSize.Height - newSize.Height);
                    int temp1 = ((ComboBox)c).GetItemHeight(0);

                    if (Math.IEEERemainder(temp, temp1) == 0)
                    {
                        p.log.WriteLine("Height differs because of round-off imprecision");
                        result = ScenarioResult.Pass;
                    }
                }
            }
        }

        protected virtual ScenarioResult Scale(TParams p, SizeF factor)
        {
            ScenarioResult result;

            ScaleHelper(p, ScaleMethod.TwoParam, out result);
            return result;
        }

#pragma warning restore 618 // 618 = Obsolete
        protected virtual ScenarioResult Scale(TParams p, float ratio)
        {
            ScenarioResult result;

            ScaleHelper(p, ScaleMethod.OneParam, out result);
            return result;
        }
#pragma warning restore 618 // 618 = Obsolete
        protected virtual ScenarioResult Scale(TParams p, float dx, float dy)
        {
            ScenarioResult result;

            ScaleHelper(p, ScaleMethod.TwoParam, out result);
            return result;
        }		//
        //This method will show up as an extra scenario.  It used to be a test for Control.SetNewControls(),
        //which was replaced with the AddRange() method on the Controls collection.  No harm in keeping this
        //test though, since we could use additional collection coverage.

        protected virtual ScenarioResult ControlsAddRange(TParams p, Control[] value)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult sr = new ScenarioResult();
            // Temporarily removing RadioButton - it throws an exception in internet zone: bug 480421
            //Control[] ca = new Control[] { new Button(), new CheckBox(), new RadioButton() };
            Control[] ca = new Control[] { new Button(), new Button(), new Button() };
            int initNumber = c.Controls.Count;

            p.log.WriteLine("initial number of controls on tested control: " + initNumber);
            p.log.WriteLine("adding " + ca.Length.ToString() + " controls by Controls.AddRange...");
            c.Controls.AddRange(ca);
            if (c.Controls.Count != ca.Length + initNumber)
            {
                sr.IncCounters(false, "FAILED: added " + (c.Controls.Count - initNumber).ToString() + " controls instead of " + initNumber, p.log);
                return sr;
            }

            for (int i = 0; i < ca.Length; i++)
            {
                Application.DoEvents();
                try
                {
                    int index = c.Controls.GetChildIndex(ca[i]);

                    Application.DoEvents();
                    c.Controls.Remove(ca[i]);
                    Application.DoEvents();
                    p.log.WriteLine(i + "-control was found among newly added controls");
                    sr.IncCounters(true);
                }
                catch (ArgumentException)
                {
                    sr.IncCounters(false, "FAILED: " + ca[i].ToString() + " - (" + i + ")-control was not found among newly added", p.log);
                }
                catch (Exception e)
                {
                    sr.IncCounters(false, "FAILED: when tried to find " + ca[i].ToString() + " - (" + i + ")-control among just added wrong exception was thrown: " + e.Message, p.log);
                }
            }

            sr.IncCounters(c.Controls.Count == initNumber, "FAILED: to Remove just added controls", p.log);
            return sr;
        }

        protected virtual ScenarioResult ResetImeMode(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            c.ImeMode = (ImeMode)p.ru.GetDifferentEnumValue(typeof(ImeMode), (int)ImeMode.Inherit);
            c.ResetImeMode();

            ImeMode expectedResult = ExpectedReturnedImeDefault(c);

            return new ScenarioResult(c.ImeMode == expectedResult, "ImeMode: " + c.ImeMode + "  Expected result: " + expectedResult, p.log);
        }

        protected virtual ScenarioResult set_Name(TParams p, string s)
        {
            return get_Name(p);
        }

        protected virtual ScenarioResult get_Name(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            string newName = p.ru.GetString(p.ru.GetRange(0, 1000));

            c.Name = newName;
            return new ScenarioResult(c.Name.Equals(newName), "Name set to:\n" + newName + "\n\nName is:\n" + c.Name);
        }

        protected virtual ScenarioResult set_Tag(TParams p, object o)
        {
            return get_Tag(p);
        }

        protected virtual ScenarioResult get_Tag(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            object newTag = new Object();

            c.Tag = newTag;
            return new ScenarioResult(c.Tag == newTag);
        }

        // Returns the actual default ImeMode of the given control.  Contrast with
        // ExpectedRetrunedImeDefault(), which gives you what value the control would actually
        // return if it was set to its default.
        //
        private ImeMode ExpectedActualImeDefault(Control c)
        {
            if (c is ButtonBase || c is Label || c is MonthCalendar || c is PictureBox || c is ProgressBar || c is ScrollBar || c is Splitter || c is TrackBar)
                return ImeMode.Disable;
            else
                return ImeMode.Inherit;
        }

        // Returns what the given control should return if its ImeMode property were in its
        // default state.  This may differ from the actual default, e.g. in the case of ImeMode.Inherit.
        //
        private ImeMode ExpectedReturnedImeDefault(Control c)
        {
            return GetExpectedImeMode(c, ExpectedActualImeDefault(c));
        }

        //
        // Returns the expected ImeMode value given the value set to the control's property,
        //
        protected ImeMode GetExpectedImeMode(Control c, ImeMode setValue)
        {
            if (setValue != ImeMode.Inherit)
                return setValue;
            else
            {
                // No need to travel up the parent chain since this control will inherit directly
                // from its parent.
                if (SafeMethods.GetParent(c) != null)
                    return SafeMethods.GetParent(c).ImeMode;
                else
                    return ImeMode.NoControl;
            }
        }

        //
        // Whidbey features
        //
        protected virtual ScenarioResult set_AutoSize(TParams p, bool value)
        {
            return get_AutoSize(p);
        }

        //	TODO: add more specific coverage
        protected virtual ScenarioResult get_AutoSize(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // we may need to remember initial AutoSize and then restore it after the test
            // in order to avoid impact on other scenarios
            bool orig = c.AutoSize;
            bool newAutoSize = p.ru.GetBoolean();

            p.log.WriteLine("change AutoSize from {0} to {1}", c.AutoSize, newAutoSize);
            c.AutoSize = newAutoSize;
            p.log.WriteLine("new AutoSize = " + c.AutoSize);
            bool result = c.AutoSize == newAutoSize;

            c.AutoSize = orig;
            return new ScenarioResult(result, "Failed: to set/get AutoSize", p.log);
        }
        protected virtual ScenarioResult set_AutoRelocate(TParams p, bool value)
        {
		return ScenarioResult.Pass;
        }

		protected virtual ScenarioResult get_AutoRelocate(TParams p)
		{
			return ScenarioResult.Pass;
		}
		protected virtual ScenarioResult set_Margin(TParams p, Padding value)
        {
            return get_Margin(p);
        }

        protected virtual ScenarioResult get_Margin(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // Win32 Exception thrown from ReflectTools.ReflectBase.TestEngine
            // for very big values - will restrict with max
            int max = 512;
            Padding newValue = p.ru.GetPadding(max, max, max, max);

            p.log.WriteLine("change Margin from {0} to {1}", c.Margin, newValue);
            c.Margin = newValue;
            p.log.WriteLine("new Margin = " + c.Margin);
            return new ScenarioResult(c.Margin == newValue, "Failed: to set/get Margin", p.log);
        }

        protected virtual ScenarioResult set_Padding(TParams p, Padding value)
        {
            return get_Padding(p);
        }

        protected virtual ScenarioResult get_Padding(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult result = new ScenarioResult();

            // Win32 Exception thrown from ReflectTools.ReflectBase.TestEngine
            // for very big values - will restrict with max
            int max = 512;
            Padding newValue = p.ru.GetPadding(max, max, max, max);

            p.log.WriteLine("change Padding from {0} to {1}", c.Padding, newValue);
            try
            {
                c.Padding = newValue;
                p.log.WriteLine("new Padding = " + c.Padding);
                result.IncCounters(c.Padding == newValue, "Failed: to set/get Padding", p.log);
            }
            catch (OverflowException e)
            {
                p.log.WriteLine("Exception: " + e.ToString());
                result.IncCounters(false, p.log, BugDb.VSWhidbey, 148029, "OverflowException for large Padding");
            }
            return result;
        }

        protected virtual ScenarioResult get_PreferredSize(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult result = new ScenarioResult();
            Size initPrefSize = c.PreferredSize;
            string initText = c.Text;
            Font initFont = c.Font;
            Size initSize = c.Size;

            // increase Font to change PreferredSize
            //int increase = p.ru.GetRange(5, 1024);
            int increase = p.ru.GetRange(5, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 10);

            // If Size of the control changes as a result of the Font.Increase
            // PreferredSize should be also updated
            if (!(c is DateTimePicker))
                c.Text = p.ru.GetString(Int32.MaxValue, true);
            // have to limit length of text for Button with UseCompatibleTextRendering = false
            // due to Postponed VSWhidbey #535880
            if ((c is Button) && (!((Button)c).UseCompatibleTextRendering) && (c.Text.Length > 500))
                c.Text = c.Text.Substring(0, 500);

            p.log.WriteLine("Get PreferredSize on control with Text.Length = " + c.Text.Length);
            result.IncCounters(IncreaseControlPreferredSize(c, increase, p), "Failed: to change Font", p.log);
            p.log.WriteLine("PreferredSize: init/new: {0}/{1} ", initPrefSize, c.PreferredSize);
            p.log.WriteLine("Size: init/new: {0}/{1} ", initSize, c.Size);

            // verify PreferredSize increase
            bool pass = (c.PreferredSize.Width >= initPrefSize.Width) && (c.PreferredSize.Height > initPrefSize.Height);

            //If you have a ComboBox, it may be bound by PreferredHeight if in one of the DropDown styles.
            ComboBox cb = c as ComboBox;
            if (cb != null)
            {
                if (cb.DropDownStyle == ComboBoxStyle.DropDown || cb.DropDownStyle == ComboBoxStyle.DropDownList)
                    pass = (c.PreferredSize.Width >= initPrefSize.Width) && (c.PreferredSize.Height >= initPrefSize.Height);
            }
            // In some cases Height may remain unchanged if Text is "" (ButtonBase)
            // For controls like Form, GroupBox, Panel, ListBox, PictureBox, etc.
            // Font.Size doesn't affect PreferredSize
            if (((c is ButtonBase) && (c.Text == "")) || (c is Form) || (c is GroupBox) || (c is Panel) || (c is ListView) || (c is PictureBox) || (c is ProgressBar) || (c is PropertyGrid) || (c is Splitter) || (c is TabControl) || (c is TrackBar) || (c is TreeView) || (c is PrintPreviewControl) || (c is ScrollBar) || (c is PropertyGrid))
                    pass = (c.PreferredSize.Width >= initPrefSize.Width) && (c.PreferredSize.Height == initPrefSize.Height);
            
            // For Button control with AutoSizeMode = GrowOnly Height may remain unchanged even for non-empty text
            // - In case if initial Height already exceeded Height required to accomodate Text string.
            if ((c is Button) && (c.Text.Length > 0) && (((Button)c).AutoSizeMode == AutoSizeMode.GrowOnly)) 
                pass = (c.PreferredSize.Width >= initPrefSize.Width) && (c.PreferredSize.Height >= initPrefSize.Height);

            // For ContainerControls like Form, PropertyBrowser.
            // Font.Size affects PreferredSize if AutoScaleMode = Font
            if ((c is ContainerControl) && (((ContainerControl)c).AutoScaleMode == AutoScaleMode.Font))
                pass = (c.PreferredSize.Width >= initPrefSize.Width) && (c.PreferredSize.Height >= initPrefSize.Height);

            // For TextBoxBase-derived controls only onde dimension of the PreferredSize can increase with Font increase
            // - especially for large fonts
            if (c is TextBoxBase && (Marshal.SizeOf(typeof(IntPtr)) * 8 == 64))
                pass = (c.PreferredSize.Width >= initPrefSize.Width) || (c.PreferredSize.Height >= initPrefSize.Height);

            //Note much you can guarantee for DataGridView -- it would even be possible to have Width and Height
            //both _decrease_ if you have funky autosizing going on
            if (c is DataGridView)
                pass = true;

            // For ListBox PreferredSize remains unchanged for OwnerDraw* modes and PreHandleMode
            if ((c is ListBox) && ((((ListBox)c).DrawMode != DrawMode.Normal) || PreHandleMode))
                pass = (c.PreferredSize.Width == initPrefSize.Width) && (c.PreferredSize.Height == initPrefSize.Height);

            // log several known bugs
            if (c is ListBox && PreHandleMode)
                result.IncCounters(pass, p.log, BugDb.VSWhidbey, 151141, "Unexpected PreferredSize prior handle creation");
            else if (c is RichTextBox && PreHandleMode)
                result.IncCounters(pass, p.log, BugDb.VSWhidbey, 151735, "RTB returns default PreferredSize prior handle creation");
            else if (c is CheckedListBox && !pass && c.PreferredSize.Height == initPrefSize.Height)
                result.IncCounters(true, p.log, BugDb.VSWhidbey, 151155, "CLB: Won't Fix bug: PreferredSize always returns default Height");
            else if (c is SplitContainer && !pass && ((SplitContainer)c).AutoSize)
                result.IncCounters(pass, p.log, BugDb.VSWhidbey, 163396, "SC: PreferredSize changes with Font increase when AutoSize = true");
            else
                result.IncCounters(pass, "Failed: to adjust PreferredSize for control with Text.Length = " + c.Text.Length, p.log);

            if ((c is ListBox) && (c.Text == "") && (initSize.Width != c.Size.Width || initSize.Height != c.Size.Height) && (initPrefSize.Height == c.PreferredSize.Height))
                result.IncCounters(false, p.log, BugDb.VSWhidbey, 148270, "PreferredSize didn't change when actual Size has changed");

            if ((c is ListBox) && !pass)
            {
                p.log.WriteLine("Items.Count = " + ((ListBox)c).Items.Count);
                p.log.WriteLine("SelectedIndex: " + ((ListBox)c).SelectedIndex);
                p.log.WriteLine("DrawMode: " + ((ListBox)c).DrawMode);
            }

            // restore initial conditions
            if (!(c is DateTimePicker))
                c.Text = initText;
            c.Font = initFont;
            c.Size = initSize;

            //p.log.WriteLine("PrefSize after restore: " + c.PreferredSize);
            return result;
        }

        protected virtual bool IncreaseControlPreferredSize(Control cc, int delta, TParams pp)
        {
            float initFontSize = cc.Font.Size;
            Font newFont = new Font(cc.Font.FontFamily, cc.Font.Size + delta, cc.Font.Style, cc.Font.Unit);
            if (cc is Label && (newFont.Unit == GraphicsUnit.Inch || newFont.SizeInPoints > 100))
                pp.log.WriteLine("test may hang due to VSWhidbey #107035");

            pp.log.WriteLine("new Font: Style: {0}- Unit: {1}- SizeInPoints {2}", newFont.Style, newFont.Unit, newFont.SizeInPoints);
            pp.log.WriteLine("init Font = " + cc.Font);
            pp.log.WriteLine("new Font = " + newFont);
            pp.log.WriteLine("change Font.Size from {0} to {1}", cc.Font.Size, newFont.Size);
            pp.log.WriteLine("change Font.Height from {0} to {1}", cc.Font.Height, newFont.Height);
            cc.Font = newFont;
            Application.DoEvents();

            bool success = (cc.Font.Size == newFont.Size);

            // in some cases Font is not set exactly - we are not testing it here
            // we will be safisfied that the Font.Size was increased
            if (!success)
            {
                pp.log.WriteLine("new Font.Size: " + cc.Font.Size);
                if (cc is RichTextBox)
                    success = (cc.Font.Size > initFontSize);
            }

            return (success);
        }

        //	If proposedSize is (0, 0) it's converted into (Int32.Max, Int32.Max)
        //	So when proposedZise == (0, 0) || (Int32.Max, Int32.Max), default PreferredSize is returned
        //  The logic to calculate GetPreferredSize() is very complicated
        //  So we'll just make sure that GetPreferredSize (proposedSize) returns within
        //  expected boundaries defined by current Control.MaximumSize and MinimumSize.
        //
        protected virtual ScenarioResult GetPreferredSize(TParams p, Size proposedSize)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult result = new ScenarioResult();
            Size initSize = c.PreferredSize;
            Size initControlSize = c.Size;

            p.log.WriteLine("default PreferredSize = " + initSize);
            p.log.WriteLine("1. call when (0, 0) is proposed");

            Size retSize = c.GetPreferredSize(Size.Empty);

            result.IncCounters(retSize.Equals(initSize), "Failed: returned " + retSize + " when proposed (0, 0)", p.log);
            p.log.WriteLine("2. call when (Int32.Max, Int32.Max) is proposed");
            retSize = c.GetPreferredSize(new Size(Int32.MaxValue, Int32.MaxValue));
            result.IncCounters(retSize.Equals(initSize), "Failed: returned " + retSize + " when proposed (Int32.Max, Int32.Max)", p.log);
            p.log.WriteLine("3. call when exact default PreferredSize is proposed");
            retSize = c.GetPreferredSize(initSize);
            result.IncCounters(retSize.Equals(initSize), "Failed: returned " + retSize + " when proposed default PreferredSize", p.log);

            // remember MinimumSize and MaximumSize to restore at the end of the scenario
            Size saveMaxSize = c.MaximumSize;
            Size saveMinSize = c.MinimumSize;

            p.log.WriteLine("4. call when MaximimSize is smaller than default PreferredSize and (0, 0) is proposed");

            // make sure new MaxSize doesn't contain 0 - 0 means unlimited
            Size newSize = p.ru.GetSize(1, initSize.Width - 1, 1, initSize.Height - 1);

            c.MaximumSize = newSize;
            if (c is ComboBox)
                newSize.Height = 0;
            result.IncCounters(c.MaximumSize.Equals(newSize), "Failed to set MaximumSize", p.log);
            retSize = c.GetPreferredSize(Size.Empty);

            // if MinimumSize.Width or Height is greater than MaximumSize.Width/Height
            // the MinimumSize will take precedence
            Size expSize = newSize;

            if (c.MinimumSize.Width > expSize.Width)
                expSize.Width = c.MinimumSize.Width;

            if (c.MinimumSize.Height > expSize.Height)
                expSize.Height = c.MinimumSize.Height;

            if (c is ComboBox)
                result.IncCounters(retSize.Width <= expSize.Width, "Failed: returned " + retSize + " when MaxSize = " + newSize, p.log);
            else
                result.IncCounters(retSize.Width <= expSize.Width && retSize.Height <= expSize.Height, "Failed: returned " + retSize + " when MaxSize = " + newSize, p.log);
            p.log.WriteLine("5. call when MinimumSize is greater than default PreferredSize and (0, 0) is proposed");
            newSize = p.ru.GetSize(initSize.Width + 1, initSize.Height + 1);
            c.MaximumSize = Size.Empty; // clear Maximum restriction 
            c.MinimumSize = newSize;
            if (c is ComboBox)
                newSize.Height = 0;
            result.IncCounters(c.MinimumSize.Equals(newSize), "Failed to set MinimumSize", p.log);
            retSize = c.GetPreferredSize(Size.Empty);
            result.IncCounters(retSize.Width >= newSize.Width && retSize.Height >= newSize.Height, "Failed: returned " + retSize + " when MinSize = " + newSize, p.log);

            // restore MaximumSize and MinimumSize
            c.MinimumSize = saveMinSize;
            c.MaximumSize = saveMaxSize;
            c.Size = initControlSize;
            return result;
        }

        //
        //	This property is interesting for people writing designers
        //  Will require additional coverage
        //  For now will verify that the LeyoutEngine is not null
        //
        protected virtual ScenarioResult get_LayoutEngine(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            object retValue = c.LayoutEngine;

            // verify that it's not null
            return new ScenarioResult(retValue != null, "Failed: returned value is null", p.log);
        }

        //
        //	Scrolls the contents of the specified windows client area
        // Visual verification is needed
        // For AutoPME wi'll just make sure that we can call the function
        // with random values of its arguments
        //	dx - amount of horizontal scrolling
        //	dy - amount of vertical scrolling
        //		protected virtual ScenarioResult ScrollWindow(TParams p, Int32 dx, Int32 dy)
        //		{
        //			if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
        //
        //			// We're just making sure ScrollWindow doesn't throw an exception.
        //			scrollWindowHelper(p, 0);
        //			return ScenarioResult.Pass;
        //		}

        //	Scrolls the contents of the specified windows client area
        // Visual verification is needed
        // For AutoPME wi'll just make sure that we can call the function
        // with random values of its arguments
        //	dx - amount of horizontal scrolling
        //	dy - amount of vertical scrolling
        //	scrollRect - portion of the client area to be scrolled
        //	clipRect - coordinates of the clipping rectangle. Only device bits within

        // the clipping rectangle are affected. Bits scrolled from the outside of the 
        // rectangle to the inside are painted; but scrolled from inside to the outside are not painted.
        //	rgnUpdate - region that is invalidated by scrolling
        //	enumVal - flags for scrolling (eraze, invalidate, scrollchildren, smoothscroll)
        //		protected virtual ScenarioResult ScrollWindow(TParams p, Int32 dx, Int32 dy, Rectangle scrollRect, Rectangle clipRect, Region rgnUpdate, ScrollType enumVal)
        //		{
        //			if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
        //
        //			// We're just making sure ScrollWindow doesn't throw an exception.
        //			scrollWindowHelper(p, 1);
        //			return ScenarioResult.Pass;
        //		}

        //
        // Helper to test ScrollWindow 
        // 'region' defines which version of the ScrollWindow is called
        //
        //		protected void scrollWindowHelper(TParams p, int nOverLoadNum) {
        //			int dxVal = p.ru.GetRange(int.MinValue, int.MaxValue);
        //			int dyVal = p.ru.GetRange(int.MinValue, int.MaxValue);
        //			Rectangle scrollRectVal = p.ru.GetRectangle();
        //			Rectangle clipRectVal = p.ru.GetRectangle();
        //			Region regionVal = null;
        //
        //			p.log.WriteLine("horizontal scroll amount: " + dxVal);
        //			p.log.WriteLine("vertical scroll amount: " + dyVal);
        //			p.log.WriteLine("area to be scrolled: " + scrollRectVal);
        //			p.log.WriteLine("clip area : " + clipRectVal);
        //
        //			if (p.ru.GetBoolean())
        //			{
        //				regionVal = p.ru.GetRegion(c.Size);
        //				p.log.WriteLine("region : " + regionVal);
        //			}
        //			else
        //				p.log.WriteLine("region is null");
        //
        //			ScrollType flags = (ScrollType)p.ru.GetEnumValue(typeof(System.Windows.Forms.ScrollType), true);
        //
        //			p.log.WriteLine("ScrollType: " + flags);
        //			p.log.WriteLine("call ScrollWindow()");
        //
        //			switch (nOverLoadNum)
        //			{
        //				case 0:
        //					c.ScrollWindow(dxVal, dyVal);
        //					break;
        //				case 1:
        //					c.ScrollWindow(dxVal, dyVal, scrollRectVal, clipRectVal, regionVal, flags);
        //					break;
        //				default:
        //					throw new ArgumentException("nOverLoadNum must be 0 or 1");
        //			}
        //
        //			p.log.WriteLine("just completed the call");
        //		}
        //
        protected virtual ScenarioResult set_MaximumSize(TParams p, Size value)
        {
            return get_MaximumSize(p);
        }

        //	Property name can change - "MaximumSize" name doesn't reflect 
        // actual meaning of the property and is misleading
        protected virtual ScenarioResult get_MaximumSize(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult result = new ScenarioResult();
            Size origMaxSize = c.MaximumSize;
            Size origControlSize = c.Size;
            //Size newSize = p.ru.GetSize(Int16.MaxValue / 10, Int16.MaxValue / 10);
            int newWidth = p.ru.GetRange(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width);
            int newHeight = p.ru.GetRange(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            Size newSize = new Size(newWidth, newHeight);

            // 1. change MaximumSize
            p.log.WriteLine("1. change MaximumSize from {0} to {1}", c.MaximumSize, newSize);
            c.MaximumSize = newSize;
            p.log.WriteLine("new MaximumSize = " + c.MaximumSize);
            result.IncCounters(c.MaximumSize == newSize, "FAIL: set/get MaximumSize", p.log);

            // 2. Try modifying size to value larger than max.
            p.log.WriteLine("2. Try modifying size to value larger than max.  Size should return max.");
            Size randSize = p.ru.GetSize(newSize.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, newSize.Height, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            Size origSize = c.Size;

            // in partial trust, window can not be set off the screen
            Size expected = newSize;
            if (c is Form)
            {
                if (((Form)c).IsRestrictedWindow)
                {
                    p.log.WriteLine("IsRestrictedWindow, adjusting expected size...");
                    Rectangle working = Screen.GetWorkingArea(c);
                    expected.Width = working.Width - c.Location.X;
                    expected.Height = working.Height - c.Location.Y;
                    p.log.WriteLine("	new expected (" + expected.Width + ", " + expected.Height + ")");
                }
            }

            p.log.WriteLine("setting Size to " + randSize);
            c.Size = randSize;

            if (PreservesHeight(c, p))
                expected.Height = origSize.Height;

            if (PreservesWidth(c, p))
                expected.Width = origSize.Width;

            //[achin] - MonthCalendar size depends on how many calendars are completely visible
			if (c is MonthCalendar)
			{
				p.log.WriteLine(c.Size.ToString());
				result.IncCounters(((c.Size.Width <= expected.Width) && (c.Size.Height <= expected.Height)), "FAIL: Size is greater than MaximumSize", expected.ToString(), c.Size.ToString(), p.log);
			}
			else if (c is ListBox)
				expected.Height = listBoxExpectedHeight((ListBox)c, origSize.Height, newSize.Height, p);
			else
                result.IncCounters(expected, c.Size, "FAIL: set Size", p.log);

            // restore minsize so as not to break subsequent sizing scenarios.
            c.MaximumSize = origMaxSize;
            c.Size = origControlSize;
            return result;
        }

        protected virtual ScenarioResult set_MinimumSize(TParams p, Size value)
        {
            return get_MinimumSize(p);
        }

        //	Property name can change - "MinimumSize" name doesn't reflect 
        // actual meaning of the property and is misleading
        // VSWhidbey 135632: Min and MaximumSize do affect control size now.
        protected virtual ScenarioResult get_MinimumSize(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            // should accept any Size
            // TODO: investigate Win32 exception from ReflectBase and
            // then remove restrictions on Size
            //Size newSize = p.ru.GetSize ();
            ScenarioResult result = new ScenarioResult();
            Application.DoEvents();
            Size origMinSize = c.MinimumSize;
            Size origControlSize = c.Size;
            //Size newSize = p.ru.GetSize(Int16.MaxValue / 10, Int16.MaxValue / 10);
            int newWidth = p.ru.GetRange(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width);
            int newHeight = p.ru.GetRange(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            Size newSize = new Size(newWidth, newHeight);

            // 1. change MinimumSize
            p.log.WriteLine("1. change MinimumSize from {0} to {1}", c.MinimumSize, newSize);
            c.MinimumSize = newSize;
            p.log.WriteLine("new MinimumSize = " + c.MinimumSize);
            if (c is ComboBox)
                newSize.Height = 0;
            result.IncCounters(c.MinimumSize == newSize, "FAIL: set/get MinimumSize", p.log);

            // 2. Try modifying size to value smaller than min.
            p.log.WriteLine("2. Try modifying size to value smaller than min.  Size should return min.");
            Size randSize = p.ru.GetSize(0, newSize.Width, 0, newSize.Height);
            Size origSize = c.Size;
            Size expected = newSize;
            p.log.WriteLine("setting Size to " + randSize);
            c.Size = randSize;
            Application.DoEvents();
            if (PreservesHeight(c, p))
                expected.Height = origSize.Height;

            if (PreservesWidth(c, p))
                expected.Width = origSize.Width;

            //[achin] - MonthCalendar size depends on how many calendars are completely visible
            if (c is MonthCalendar)
            {
                p.log.WriteLine(c.Size.ToString());
                result.IncCounters(((c.Size.Width >= expected.Width) && (c.Size.Height >= expected.Height)), "FAIL: Size is less than MinimumSize", expected.ToString(), c.Size.ToString(), p.log);
            }
            else if (c is ListBox)
                expected.Height = listBoxExpectedHeight((ListBox)c, origSize.Height, newSize.Height, p);
			else if (c is TextBox)
				//TextBox nolonger preserves height when AutoSize = true
				expected.Height = c.PreferredSize.Height;
            else if (c is TrackBar) {
                //trackbar no longer preserves height when Autosize = true
                expected.Height = newSize.Height;
                result.IncCounters(expected, c.Size, "FAIL: set Size", p.log);
            }
            else
                result.IncCounters(expected, c.Size, "FAIL: set Size", p.log);

            // restore minsize so as not to break subsequent sizing scenarios.
            c.MinimumSize = origMinSize;
            c.Size = origControlSize;
            return result;
        }

        protected virtual ScenarioResult set_UseWaitCursor(TParams p, bool value)
        {
            return get_UseWaitCursor(p);
        }

        protected virtual ScenarioResult get_UseWaitCursor(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

            ScenarioResult result = new ScenarioResult();
            bool initUseWait = c.UseWaitCursor;

            c.UseWaitCursor = false;

            Cursor origCursor = c.Cursor;

            c.UseWaitCursor = initUseWait;

            // set to true, verify that Cursor is Wait 
            p.log.WriteLine("original Cursor: " + origCursor);
            p.log.WriteLine("1. change UseWaitCursor from {0} to true", c.UseWaitCursor);
            c.UseWaitCursor = true;
            result.IncCounters(c.UseWaitCursor, "Failed: to set UseWaitCursor = true", p.log);
            result.IncCounters(c.Cursor.Equals(Cursors.WaitCursor), "Failed: to update Cursor to Wait, Cursor is " + c.Cursor, p.log);

            // set to false, verify Cursor went back to original
            p.log.WriteLine("2. change UseWaitCursor from {0} to false", c.UseWaitCursor);
            c.UseWaitCursor = false;
            result.IncCounters(!c.UseWaitCursor, "Failed: to set UseWaitCursor = false", p.log);
            result.IncCounters(c.Cursor.Equals(origCursor), p.log, BugDb.VSWhidbey, 142284, "Didn't preserve Cursor in process of changing UseWaitCursor ");
            p.log.WriteLine("3. change UseWaitCursor to true, change Cursor property");
            c.UseWaitCursor = true;
            result.IncCounters(c.UseWaitCursor, "Failed: to set UseWaitCursor = true", p.log);
            result.IncCounters(c.Cursor.Equals(Cursors.WaitCursor), "Failed: to update Cursor to Wait, Cursor is " + c.Cursor, p.log);

            Cursor newCursor = p.ru.GetCursor();

            p.log.WriteLine("set Cursor to " + newCursor);

            // make sure our random cursor in non-Wait
            while (newCursor.Equals(Cursors.WaitCursor))
                newCursor = p.ru.GetCursor();

            // Cursor should return WaitCursor while UseWaitCursor = true
            c.Cursor = newCursor;
            p.log.WriteLine("Cursor returns " + c.Cursor + " after setting to " + newCursor + ", UseWaitCursor = " + c.UseWaitCursor);
            result.IncCounters(c.Cursor.Equals(Cursors.WaitCursor), p.log, BugDb.VSWhidbey, 142284, "Cursor didn't return WaitCursor after setting to random cursor when UseWaitCursor = true");

            // Cursor should be restored to the new cursor after UseWait = false
            p.log.WriteLine("... set UseWaitCursor = false, verify new cursor is restored");
            c.UseWaitCursor = false;
            p.log.WriteLine("Cursor returns " + c.Cursor + " after setting UseWaitCursor = false ");
            result.IncCounters(c.Cursor.Equals(newCursor), "Failed to restore new Cursor: " + newCursor + " after setting UseWait = false", p.log);
            c.UseWaitCursor = p.ru.GetBoolean();	// for future scenarios
            return result;
        }

        protected virtual ScenarioResult get_AutoScrollOffset(TParams p)
        {
            c = GetControl(p);

            Point pt = p.ru.GetPoint(Int32.MinValue, Int32.MaxValue, Int32.MinValue, Int32.MaxValue);
            c.AutoScrollOffset = pt;

            return new ScenarioResult(pt.Equals(c.AutoScrollOffset), "Point mismatch: " + pt.ToString() + " vs. " + c.AutoScrollOffset.ToString());
        }

        protected virtual ScenarioResult set_AutoScrollOffset(TParams p, Point value)
        {
            return get_AutoScrollOffset(p);
        }

        protected virtual ScenarioResult Control_CheckForIllegalCrossThreadCalls(TParams p)
        {
            ScenarioResult result = new ScenarioResult();
            bool expected = false;
            bool initValue = Control.CheckForIllegalCrossThreadCalls;	// store initial value

            // check default value
            if (System.Diagnostics.Debugger.IsAttached)
                expected = true;

            result.IncCounters(initValue == expected, "default CheckForIllegalCrossThreadCalls returned unexpected value", p.log);
            if (initValue != expected)
                p.log.WriteLine("CheckForIllegalCrossThreadCalls = {0} when Debugger.IsAttached = {1}", initValue, expected);

            // verify Browsable = false & EditorBrowsable = Advanced
            Utilities.VerifyMemberBrowsable(new Control(), "CheckForIllegalCrossThreadCalls", false, EditorBrowsableState.Advanced, result, p.log);
            Control.CheckForIllegalCrossThreadCalls = true;
            result.IncCounters(Control.CheckForIllegalCrossThreadCalls, "Failed: returned false after explicitely setting to true", p.log);
            Control.CheckForIllegalCrossThreadCalls = false;
            result.IncCounters(!Control.CheckForIllegalCrossThreadCalls, "Failed: returned true after explicitely setting to false", p.log);

            // restore initial value
            Control.CheckForIllegalCrossThreadCalls = initValue;
            return result;
        }

        protected virtual ScenarioResult DrawToBitmap(TParams p, Bitmap bitmap, Rectangle targetBounds)
        {
            ScenarioResult result = new ScenarioResult();

            Bitmap mapA = new Bitmap(50, 50);
            Bitmap mapB = (Bitmap)mapA.Clone();
            c = GetControl(p);

            bool bSet = SecurityCheck(result,
                delegate
                {
                    c.DrawToBitmap(mapA, c.ClientRectangle);
                }, typeof(Control).GetMethod("DrawToBitmap"),
                LibSecurity.AllWindows);

            if(bSet)
                result.IncCounters(!Utilities.BitmapsIdentical(mapA, mapB), "nothing was drawn", p.log);

            return result;
        }

        // KEVINTAO: ShouldSerialize methods are now internal.  I'll keep this code around for
        //           now, in case we ever need a test for these again.
        /* ShouldSerializeMethods are now internal
        protected virtual ScenarioResult ShouldSerializeText(TParams p)
                {
                    ScenarioResult result = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    result.IncCounters(!c.ShouldSerializeText(), "FAILED initial state", p.log);

                    c.Text = p.ru.GetString(100);
                    result.IncCounters(c.ShouldSerializeText(), "FAILED after set value", p.log);

                    c.ResetText();
                    result.IncCounters(!c.ShouldSerializeText(), "FAILED after reset", p.log);

                    return result;
                }

               protected virtual ScenarioResult ShouldSerializeSize(TParams p)
               {
                    ScenarioResult result = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    Controls.Add(c);
                    Application.DoEvents();
                    result.IncCounters(!c.ShouldSerializeSize(), "FAILED initial state", p.log);

                    c.Size = p.ru.GetSize(1000, 1000);  // set a reasonable upper bound
                    result.IncCounters(c.ShouldSerializeSize(), "FAILED after set value", p.log);

                    return result;
               }

               protected virtual ScenarioResult ShouldSerializeLocation(TParams p)
               {
                    ScenarioResult result = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    Controls.Add(c);
                    Application.DoEvents();
                    result.IncCounters(!c.ShouldSerializeLocation(), "FAILED initial state", p.log);

                    c.Location = p.ru.GetPoint();
                    result.IncCounters(c.ShouldSerializeLocation(), "FAILED after set value", p.log);

                    return result;
               }

                protected virtual ScenarioResult ShouldSerializeRightToLeft(TParams p)
                {
                    ScenarioResult result = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    result.IncCounters(!c.ShouldSerializeRightToLeft(), "FAILED initial state", p.log);

                    // NOTE: Inherit is the default for RightToLeft, but c.RightToLeft will return RightToLeft.No, so
                    //       we can't pass c.RightToLeft to p.ru.GetDifferentEnumValue().
                    c.RightToLeft = (RightToLeft)p.ru.GetDifferentEnumValue(typeof(RightToLeft), (int)RightToLeft.Inherit);
                    result.IncCounters(c.ShouldSerializeRightToLeft(), "FAILED after set value", p.log);

                    c.ResetRightToLeft();
                    result.IncCounters(!c.ShouldSerializeRightToLeft(), "FAILED after reset", p.log);

                    return result;
                }

                protected virtual ScenarioResult ShouldSerializeFont(TParams p)
                {
                    ScenarioResult result = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    result.IncCounters(!c.ShouldSerializeFont(), "FAILED initial state", p.log);

                    c.Font = p.ru.GetFont();
                    result.IncCounters(c.ShouldSerializeFont(), "FAILED after set value", p.log);

                    c.ResetFont();
                    result.IncCounters(!c.ShouldSerializeFont(), "FAILED after reset", p.log);

                    return result;
                }

                protected virtual ScenarioResult ShouldSerializeForeColor(TParams p)
                {
                    ScenarioResult result = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    result.IncCounters(!c.ShouldSerializeForeColor(), "FAILED initial state", p.log);

                    c.ForeColor = p.ru.GetColor();
                    result.IncCounters(c.ShouldSerializeForeColor(), "FAILED after set value", p.log);

                    return result;
                }

                protected virtual ScenarioResult ShouldSerializeBackColor(TParams p)
                {
                    ScenarioResult result = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    result.IncCounters(!c.ShouldSerializeBackColor(), "FAILED initial state", p.log);

                    c.BackColor = p.ru.GetColor();
                    result.IncCounters(c.ShouldSerializeBackColor(), "FAILED after set value", p.log);

                    c.ResetBackColor();
                    result.IncCounters(!c.ShouldSerializeBackColor(), "FAILED after reset", p.log);

                    return result;
                }

                protected virtual ScenarioResult ShouldSerializeImeMode(TParams p) {
                    ScenarioResult sr = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    p.log.WriteLine("Initial state: " + c.ShouldSerializeImeMode().ToString());
                    sr.IncCounters(!c.ShouldSerializeImeMode(), "FAILED initial state", p.log);

                    ImeMode setValue = (ImeMode)p.ru.GetEnumValue(typeof(ImeMode));
                    c.ImeMode = setValue;
                    bool expectedResult = (setValue != ExpectedActualImeDefault(c));

                    sr.IncCounters(c.ShouldSerializeImeMode()==expectedResult, "FAILED after set value: set to " + setValue + " value returned: " + c.ShouldSerializeImeMode().ToString(), p.log);

                    return sr;
                }

                protected virtual ScenarioResult ShouldSerializeCursor(TParams p)
                {
                    ScenarioResult result = new ScenarioResult();

                    c = (Control)CreateObject(p);
                    result.IncCounters(!c.ShouldSerializeCursor(), "FAILED initial state", p.log);

                    c.Cursor = p.ru.GetCursor();
                    result.IncCounters(c.ShouldSerializeCursor() == (!c.Cursor.Equals(newC.Cursor)), "FAILED after set value", p.log);

                    c.ResetCursor();
                    result.IncCounters(!c.ShouldSerializeCursor(), "FAILED after reset", p.log);

                    return result;
                }

                protected ScenarioResult ShouldSerializeBindings(TParams p) {
                    p.log.WriteLine("Tested by DataBinding automation");
                    return ScenarioResult.Pass; 
                }
        */
                        //*********************************************************************
        // TODO (KevinTao 1/9/2001):
        // The code below is from Beta 1 XControl and XRichControl tests.  They are still valid
        // tests for methods and properties that are no longer publicly exposed or have been moved.
        // I'm keeing these here so we can make use of them in other tests if we choose to.
        //*********************************************************************
        // ??? Do we need special case for LinkLabel  ???
        // ======= DoubleCLick raises no event in Button --> need special ========
        // ====== using Clicked caused failures for Label ================
        // -------// --> using OnMouseUp  // ----------------------------
        /* BETA2: SendMessage is now Protected
        protected virtual ScenarioResult SendMessage(TParams p, Int32 msg, Int32 wParam, Int32 lParam)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            clicked = false;
            MouseEventHandler eh = new MouseEventHandler(this.Clicked);
            c.MouseUp += eh;

            c.SendMessage(win.WM_LBUTTONUP, 0, 0);
            Application.DoEvents();

            c.MouseUp -= eh;
            
            return new ScenarioResult(clicked);
        }

        // SendMessage with new parameters - calling previously existed SendMessage
        // (?) do we need to write special test for these 'ref'-parameters (?)
      protected virtual ScenarioResult SendMessage(TParams p, Int32 msg, ref short wParam, ref short lParam)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            return SendMessage(p, msg, wParam, lParam);
        }*/
                /* BETA2: TopLevel is now a property of Forms, not Controls
        protected virtual ScenarioResult set_TopLevel(TParams p, bool value)
        {
            return get_TopLevel(p);
        }

        protected virtual ScenarioResult get_TopLevel(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            bool b = c.TopLevel;
            p.log.WriteLine("TopLevel was " + b.ToString());
            try
            {
                c.TopLevel = !b;
                if (c.Parent != null)
                    return new ScenarioResult(false, "Shouldn't be allowed to set TopLevel for parented control");
            }
            catch (Exception)
            {
                if (c.Parent == null)
                    return new ScenarioResult(false, "Failed to set TopLevel for non-parented control");
            }
            bool bb = c.TopLevel;
            p.log.WriteLine("TopLevel is " + bb.ToString());
            if (c.Parent != null)
                return new ScenarioResult(b == bb);
            else
                return new ScenarioResult(b != bb);
        }*/
                // new UI methods in Control
        // if Handle is not created, return true
        // IF control IS NOT top-level without parent, parent.property returned
        //
        /*BETA2: UI Show*Cues methods are protected
       protected virtual ScenarioResult get_ShowKeyboardCues(TParams p)
       {
           if ((c = GetControl(p)) == null) return ScenarioResult.Fail;

           ScenarioResult result; 
           UIShowHelper(p, ShowMethod.Keyboard, out result);
           return result;
       }

       protected virtual ScenarioResult get_ShowFocusCues(TParams p)
       {
           if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
           ScenarioResult result; 
           UIShowHelper(p, ShowMethod.Focus, out result);
           return result;
       }

       // helper for UI Show*-methods
       protected enum ShowMethod {
           Keyboard,                   // ShowKeyboardCues
           Focus             // ShowFocusCues
       }

       //
       // Helper method to test both UI Show*Cues methods
       //
       protected virtual void UIShowHelper(TParams p, ShowMethod method, out ScenarioResult result)
       {
           if ((c = GetControl(p)) == null){
               result = ScenarioResult.Fail;
               return;
           }

           result = new ScenarioResult();
           
           bool bExpected = false;

           // - situation when Handle is not created yet
           // for newly created & not yet displayed control, Handle should not be created
           // for TabControl and TabPage Handle is created as soon as TabPage is added - so it's an exception
           // for ListBox handle is also created
           if (! (c is TabControl || c is TabPage || c is ListBox)) {
              p.log.WriteLine("1. Getting value for control without handle");
              Control temp = (Control)CreateObject(p);
              string descr = "FAILED: returned false for control without handle";
              if (temp.IsHandleCreated) {
                 descr = "FAILED: Handle was created for new, not yet dispayed control - investigation needed ";
              }

              switch ( method ) {
                  case ShowMethod.Keyboard :
                      bExpected = temp.ShowKeyboardCues;
                      break;
                  case ShowMethod.Focus :
                      bExpected = temp.ShowFocusCues;
                      break;
                  default :
                      throw new ArgumentException("Invalid ShowMethod: " + method.ToString());  
              }        

              result.IncCounters(!temp.IsHandleCreated && bExpected, descr, p.log);
              temp.Dispose();
           }

           // our tested control is already displayed - it should have Handle created
           if (!c.IsHandleCreated){ 
               result.IncCounters(false, "FAILED: Control's handle is not created - can't execute remainder of test", p.log);
               return;
           }

           p.log.WriteLine("2. Getting value for control with handle");
           if (!(c.TopLevel || c.Parent == null)) {         // our situation
               switch ( method ) {
                   case ShowMethod.Keyboard :
                       bExpected = (c.ShowKeyboardCues == c.Parent.ShowKeyboardCues);
                       break;
                   case ShowMethod.Focus :
                       bExpected = (c.ShowFocusCues == c.Parent.ShowFocusCues);
               }        
               result.IncCounters(bExpected, "FAILED: didn't return parent's value", p.log);
           }
           // modeling situation when control is TopLevel and without Parent
           if (c.Parent != null) {
               c.Parent = null;
           }
           if (!c.TopLevel) {
               c.TopLevel = true;
           }
           bool b = false; 
           switch ( method ) {
           case ShowMethod.Keyboard :
                   b = ((SendMessage(win.WM_QUERYUISTATE, 0, 0) & win.UISF_HIDEACCEL) == 0); 
                   bExpected = (c.ShowKeyboardCues == b);
                   break;
               case ShowMethod.Focus :
                   b = ((SendMessage(win.WM_QUERYUISTATE, 0, 0) & win.UISF_HIDEFOCUS) == 0); 
                   bExpected = (c.ShowFocusCues == b);
           }        
           result.IncCounters(bExpected, "FAILED: unexpected value for top-level control without parent", p.log);
           
           // discard control we manipulated with and recreate it for further scenarios
           c.Dispose();
           p.target = (Control)this.CreateObject(p);
           c = GetControl(p);
           this.AddObjectToForm(p);  
       }
*/

        // Accessible event tests

        //EVENT_OBJECT_CREATE: Instanciate the control and make it visable on a form.  Verify this event fires as the AccessibleObject is created.
        #region Accessibility Tests
        protected virtual ScenarioResult TestAccessibleEvents(TParams p)
        {
	    if (Utilities.IsWin9x)
                return ScenarioResult.Pass;
            ScenarioResult sr = new ScenarioResult();
            sr.IncCounters(OBJECT_CREATE(p));
            sr.IncCounters(OBJECT_DESTROY(p));
            sr.IncCounters(OBJECT_FOCUS(p));
            sr.IncCounters(OBJECT_LOCATIONCHANGE(p));
            //sr.IncCounters(OBJECT_NAMECHANGE(p));
            //sr.IncCounters(OBJECT_DEFACTIONCHANGE(p));
            p.log.WriteLine("VSWhidbey# 371681 postponed.  OBJECT_NAMECHANGE and OBJECT_DEFACTIONCHANGE tests disabled");
            sr.IncCounters(OBJECT_PARENTCHANGE(p));
            return sr;
        }
        [Scenario(false)]
        protected virtual ScenarioResult OBJECT_CREATE(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            ScenarioResult sr = new ScenarioResult();
            bool prevVisible = this.Visible;
            this.Visible = true;
            try
            {
                using (AccessibleEventListener listener = new AccessibleEventListener(AccessibleEventListener.EVENT.OBJECT_CREATE))
                {
                    c = new Control();
                    this.Controls.Add(c);
                    Application.DoEvents();
                    sr.IncCounters(1 <= listener.FiredEvents.Count, "FAIL: expected OBJECT_CREATE accessible event to be fired once", p.log);
                    this.Controls.Remove(c);
                }
                return sr;
            }
            finally { this.Visible = prevVisible; }
        }

        ////EVENT_OBJECT_DEFACTIONCHANGE:  Default Action Changed.  Perform the action on the control that will cause the default action to change and verify the event fired.
        //[Scenario(false)]
        //protected virtual ScenarioResult OBJECT_DEFACTIONCHANGE(TParams p)
        //{
        //    if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
        //    ScenarioResult sr = new ScenarioResult();
        //    if (c is Form) ((Form)c).TopLevel = false;
        //    AddObjectToForm(p);
        //    using (AccessibleEventListener listener = new AccessibleEventListener(AccessibleEventListener.EVENT.OBJECT_DEFACTIONCHANGE))
        //    {
        //        p.log.WriteLine("DefaultActionDescription was: " + c.AccessibleDefaultActionDescription);
        //        c.AccessibleDefaultActionDescription = p.ru.GetString(20);
        //        p.log.WriteLine("DefaultActionDescription is: " + c.AccessibleDefaultActionDescription);
        //        Application.DoEvents();
        //        sr.IncCounters(1 <=listener.FiredEvents.Count, p.log, BugDb.VSWhidbey, 371681 );//"FAIL: expected OBJECT_DEFACTIONCHANGE accessible event to be fired once", p.log);
        //    }
        //    return sr;
        //}
        //EVENT_OBJECT_DESTROY: Dispose of the control object and verify that the Event fires.
        [Scenario(false)]
        protected virtual ScenarioResult OBJECT_DESTROY(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            ScenarioResult sr = new ScenarioResult();
            if (c is Form) ((Form)c).TopLevel = false;
            AddObjectToForm(p);
            c.Visible = true;
            using (AccessibleEventListener listener = new AccessibleEventListener(AccessibleEventListener.EVENT.OBJECT_DESTROY))
            {
                try
                {
                    c.Dispose();
                    Application.DoEvents();
                    sr.IncCounters(1 <= listener.FiredEvents.Count, "FAIL: expected OBJECT_DESTROY accessible event to be fired once", p.log);
                }
                finally
                {
                    this.Controls.Remove(c);
                    RecreateControl(p);
                }
            }
            return sr;
        }
        //EVENT_OBJECT_FOCUS: Should fire when the control gets focus.
        [Scenario(false)]
        protected virtual ScenarioResult OBJECT_FOCUS(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            ScenarioResult sr = new ScenarioResult();
            if (!c.CanFocus)
            { return ScenarioResult.Pass; }

            AddObjectToForm(p);
            //if (c is Form) ((Form)c).TopLevel = false;
            //if (AddControlToForm)
            //    this.Controls.Add(c);
            c.Visible = true;
            bool prevVisible = this.Visible;
            this.Visible = true;
            try
            {
                Button b = new Button();
                this.Controls.Add(b);
                SafeMethods.Focus(b);
                using (AccessibleEventListener listener = new AccessibleEventListener(AccessibleEventListener.EVENT.OBJECT_FOCUS))
                {
                    if (!AddControlToForm)
                        c.Show();
                    SafeMethods.Focus(c);

                    Application.DoEvents();
                    sr.IncCounters(1 <= listener.FiredEvents.Count, "FAIL: expected OBJECT_FOCUS accessible event to be fired once", p.log);
                }
                return sr;
            }
            finally { this.Visible = prevVisible; }
        }
        //EVENT_OBJECT_HIDE:  An object is hidden.  Verify by calling Hide on the object.
        [Scenario(false)]
        protected virtual ScenarioResult OBJECT_HIDE(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            ScenarioResult sr = new ScenarioResult();
            c = CreateObject(p) as Control;
            if (c is Form) ((Form)c).TopLevel = false;
            if (!AddControlToForm)
                c.Show();
            else
                this.Controls.Add(c);
            using (AccessibleEventListener listener = new AccessibleEventListener(AccessibleEventListener.EVENT.OBJECT_HIDE))
            {
                c.Hide();
                Application.DoEvents();
                sr.IncCounters(1 <= listener.FiredEvents.Count, "FAIL: expected OBJECT_HIDE accessible event to be fired once", p.log);
            }
            c.Show();
            return sr;
        }
        //EVENT_OBJECT_LOCATIONCHANGE: Fired on both a resize and a move.
        [Scenario(false)]
        protected virtual ScenarioResult OBJECT_LOCATIONCHANGE(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            ScenarioResult sr = new ScenarioResult();
            p.target = c = CreateObject(p) as Control;

            if (c is Form) ((Form)c).TopLevel = false;
            AddObjectToForm(p);

            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            c.Visible = true;
            using (AccessibleEventListener listener = new AccessibleEventListener(AccessibleEventListener.EVENT.OBJECT_LOCATIONCHANGE))
            {
                c.Location = new Point(c.Location.X + 1, c.Location.Y + 1);
                Application.DoEvents();
                sr.IncCounters(1 <= listener.FiredEvents.Count, "FAIL: expected OBJECT_LOCATIONCHANGE accessible event to be fired once when control moves", p.log);

                Size oldSize = c.Size;
                c.Size = new Size(c.Size.Width + 1, c.Size.Height + 1);
                Application.DoEvents();

                if (oldSize == c.Size)
                    sr.IncCounters(1 <= listener.FiredEvents.Count, "FAIL: size did not change and expected no OBJECT_LOCATIONCHANGE accessible event to be fired", p.log);
                else
                    sr.IncCounters(2 <= listener.FiredEvents.Count, "FAIL: expected OBJECT_LOCATIONCHANGE accessible event to be fired again when control is resized", p.log);
            }

            return sr;
        }
        ////EVENT_OBJECT_NAMECHANGE: Fired if the Accessible Name property is changed.  Verify by changing the Control. AccessibleName property.
        //[Scenario(false)]
        //protected virtual ScenarioResult OBJECT_NAMECHANGE(TParams p)
        //{
        //    if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
        //    ScenarioResult sr = new ScenarioResult();
        //    c = CreateObject(p) as Control;

        //    AddObjectToForm(p);

        //    using (AccessibleEventListener listener = new AccessibleEventListener(AccessibleEventListener.EVENT.OBJECT_NAMECHANGE))
        //    {
        //        c.AccessibleName = p.ru.GetString(20);
        //        Application.DoEvents();
        //        sr.IncCounters(1<= listener.FiredEvents.Count, p.log, BugDb.VSWhidbey, 371681 );//"FAIL: expected OBJECT_NAMECHANGE accessible event to be fired once", p.log);
        //    }
        //    return sr;
        //}
        //EVENT_OBJECT_PARENTCHANGE: Fired when the parent object changes.  Verify by changing the elements parent.
        [Scenario(false)]
        protected virtual ScenarioResult OBJECT_PARENTCHANGE(TParams p)
        {
            if ((c = GetControl(p)) == null) return ScenarioResult.Fail;
            ScenarioResult sr = new ScenarioResult();

            if (c is Form) ((Form)c).TopLevel = false;
            //top level control can't have parent
            if (!AddControlToForm)
                return new ScenarioResult(true);

            //			this.Controls.Add(c = CreateObject(p) as Control);
            c = CreateObject(p) as Control;
            if (c is Form) ((Form)c).TopLevel = false;
            this.Controls.Add(c);


            Panel pa = new Panel();
            this.Controls.Add(pa);
            Application.DoEvents();
            using (AccessibleEventListener listener = new AccessibleEventListener(AccessibleEventListener.EVENT.OBJECT_PARENTCHANGE))
            {
                pa.Controls.Add(c);
                Application.DoEvents();
                //This event could fire multiple times because of the parking window, that's not a problem
                sr.IncCounters(0 < listener.FiredEvents.Count, "FAIL: expected OBJECT_PARENTCHANGE accessible event to be fired once", p.log);
            }
            return sr;
        }
        #endregion Accessibility Tests
    }
}
