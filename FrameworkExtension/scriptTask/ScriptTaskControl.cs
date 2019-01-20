﻿using System;
using System.Windows.Forms;

namespace Automation.FrameworkExtension.scriptTask
{
    public partial class ScriptTaskControl : UserControl
    {

        public ScriptStationTask ScriptStationTask;

        public ScriptTaskControl()
        {
            InitializeComponent();
        }

        private void ScriptTaskControl_Load(object sender, EventArgs e)
        {
            if (ScriptStationTask != null)
            {
                scintillaResettingScript.AppendText(ScriptStationTask.ResettingScript);
            }
        }
        private void buttonCompileResettingScript_Click(object sender, EventArgs e)
        {
            if (ScriptStationTask != null)
            {
                ShowError("Compiling Resetting Script Start......");

                ScriptStationTask.ResettingScript = scintillaResettingScript.Text;
                try
                {
                    ScriptStationTask?.CompileResettingScript();
                    ShowError("Compiling Resetting Script Success!");
                }
                catch (Exception ex)
                {
                    ShowError($"Compile Resetting Script Error: {ex.Message}");
                }
            }
        }



        public void ShowError(string log)
        {
            richTextBoxCompileResettingScriptOutput.AppendText($"{DateTime.Now.ToString("yyyyMMdd-HHmmss.fff")}: {log}\r\n");
        }

        private void buttonSaveResettingScript_Click(object sender, EventArgs e)
        {
            ScriptStationTask.ResettingScript = scintillaResettingScript.Text;

            ScriptStationTask.Save();

            ShowError($"Save Resetting Script Finish!");
        }
    }
}
