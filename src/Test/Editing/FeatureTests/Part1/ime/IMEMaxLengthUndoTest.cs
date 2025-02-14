// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows.Controls;
using System.Windows.Input;

using Microsoft.Test;
using Microsoft.Test.Discovery;

using Test.Uis.Data;
using Test.Uis.Loggers;
using Test.Uis.TestTypes;
using Test.Uis.Utils;

namespace Test.Uis.TextEditing
{
    [Test(2, "IME", "IMEMaxLengthUndoTest_Korean", MethodParameters = "/TestCaseType:IMEMaxLengthUndoTest /locale=Korean", Timeout = 120, Keywords = "KoreanIME")]    
    [Test(0, "IME", "IMEMaxLengthUndoTest_Japanese", MethodParameters = "/TestCaseType:IMEMaxLengthUndoTest /locale=Japanese", Timeout = 120, Keywords = "JapaneseIME")]
    [Test(0, "IME", "IMEMaxLengthUndoTest_ChinesePinyin", MethodParameters = "/TestCaseType:IMEMaxLengthUndoTest /locale=ChinesePinyin", Timeout = 120, Keywords = "ChinesePinyinIME")]
    [Test(2, "IME", "IMEMaxLengthUndoTest_ChineseQuanPin", MethodParameters = "/TestCaseType:IMEMaxLengthUndoTest /locale=ChineseQuanPin", Timeout = 120, Keywords = "ChineseQuanPinIME")] 
    public class IMEMaxLengthUndoTest : ManagedCombinatorialTestCase
    {
        #region Main flow

        /// <summary>Starts the combination</summary>
        protected override void DoRunCombination()
        {
            if (_textBox == null)
            {
                _textBox = new TextBox();
                _textBox.Height = 200;                
                _textBox.FontSize = 24;                
            }
            if (_testTextBox == null)
            {            
                _testTextBox = new TextBox();
                _testTextBox.Height = 100;
                _testTextBox.FontSize = 24;                
            }
                                            
            if(_panel == null)
            {
                _panel = new StackPanel();            
                _panel.Children.Add(_textBox);
                _panel.Children.Add(_testTextBox);
                MainWindow.Content = _panel;
            }            

            SetTestVariables();            

            QueueDelegate(PerformTestActions);
        }

        private void PerformTestActions()
        {
            if (!_isIMESetupDone)
            {
                Log("Load IME keyboard");
                IMEHelper.SetUpIMEKeyboardLayout(_locale, _testTextBox, MainWindow);
                _isIMESetupDone = true;
            }             

            // Put the caret at the end of the contents
            _textBox.Select(_textBox.Text.Length, 0);
            // Put the focus in the actual TextBox where test is done
            _textBox.Focus();
            Microsoft.Test.Threading.DispatcherHelper.DoEvents();

            KeyboardInput.TypeString(_contentToTypeInIME);
            Microsoft.Test.Threading.DispatcherHelper.DoEvents(IMEHelper.CiceroWaitTimeMs);
            
            // Perform undo operation
            ApplicationCommands.Undo.Execute(null, _textBox);

            VerifyContentAfterTyping();

            NextCombination();
        }

        private void SetTestVariables()
        {            
            switch (_locale)
            {
                case IMELocales.Korean:
                    _contentToTypeInIME = koreanTypeSequence;
                    _composedStringByIME = koreanCompositedString;
                    break;
                case IMELocales.Japanese:
                    _contentToTypeInIME = japaneseTypeSequence;
                    _composedStringByIME = japaneseCompositedString;
                    break;
                case IMELocales.ChinesePinyin:
                    _contentToTypeInIME = chinesePinyinTypeSequence;
                    _composedStringByIME = chinesePinyinCompositedString;
                    break;
                case IMELocales.ChineseQuanPin:
                    _contentToTypeInIME = chineseQuanPinTypeSequence;
                    _composedStringByIME = chineseQuanPinCompositedString;
                    break;
            }

            _textBox.Text = _testTextBox.Text = string.Empty; // Clean up from previous combinations
            _textBox.IsUndoEnabled = _isUndoEnabled;
            _textBox.MaxLength = _maxLength;          
        }

        private void VerifyContentAfterTyping()
        {
            Verifier.Verify(_textBox.Text == _composedStringByIME, "Verifying contents after typing followed by undo: Actual[" +
                _textBox.Text + "] Expected[" + _composedStringByIME + "]", true);  
        }

        #endregion

        #region Private fields

        // Combinatorial engine variables; set to default values
        private IMELocales _locale = IMELocales.Korean;
        private int _maxLength = 0;        
        private bool _isUndoEnabled = true;

        private StackPanel _panel;
        private TextBox _textBox;
        private TextBox _testTextBox; // Used just to set the appropriate Ime mode
        private bool _isIMESetupDone = false;

        private string _contentToTypeInIME = string.Empty;
        private string _composedStringByIME = string.Empty;

        private const string koreanTypeSequence = "qixmsqixm";
        private const string koreanCompositedString = "뱌튼";

        private const string japaneseTypeSequence = "ae{ENTER}ae{ENTER}";
        private const string japaneseCompositedString = "あえ";

        private const string chinesePinyinTypeSequence = "nihao{SPACE}{ENTER}nihao{SPACE}{ENTER}";
        private const string chinesePinyinCompositedString = "你好";

        private const string chineseQuanPinTypeSequence = "nihao{SPACE}nihao{SPACE}";
        private const string chineseQuanPinCompositedString = "你好";

        #endregion
    }
}