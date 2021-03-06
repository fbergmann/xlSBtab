﻿using System;
using System.IO;
using System.Windows.Forms;

namespace xlSBtab
{
  public partial class FormSettings : Form
  {
    public FormSettings()
    {
      InitializeComponent();
    }

    public void LoadSettings()
    {
      txtPython.Text = SBtabSettings.Instance.PythonInterpreter;
      txtSbtabDir.Text = SBtabSettings.Instance.SBtabDir;
    }

    public void SaveSettings()
    {
      SBtabSettings.Instance.PythonInterpreter = txtPython.Text;
      SBtabSettings.Instance.SBtabDir = txtSbtabDir.Text;
      SBtabSettings.Instance.Save();
    }


    private void OnBrowseSBtabDirClick(object sender, EventArgs e)
    {
      var root = txtSbtabDir.Text;
      using (var dlg = new FolderBrowserDialog { Description = "Select SBtab script dir", SelectedPath = root})
      {
        if (dlg.ShowDialog() == DialogResult.OK)
          txtSbtabDir.Text = dlg.SelectedPath;
      }
    }

    private void OnBrowsePythonClick(object sender, EventArgs e)
    {
      var dir = Path.GetDirectoryName(txtPython.Text);
      var name = Path.GetFileName(txtPython.Text);
      using (var dlg = new OpenFileDialog { Title = "Select Python interpreter", 
        Filter = "Executable files|*.exe;*.bat;*.cmd|All files|*.*", 
        FileName = name, InitialDirectory = dir})
      {
        if (dlg.ShowDialog() == DialogResult.OK)
          txtPython.Text = dlg.FileName;
      }
    }
  }
}
