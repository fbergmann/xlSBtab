using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn1
{
  public partial class SBtabRibbon
  {
    private SBtabModel Model { get; set; }

    private void OnRibbonLoad(object sender, RibbonUIEventArgs e)
    {
      Model = new SBtabModel();
    }

    private void OnValidateClick(object sender, RibbonControlEventArgs e)
    {
      MessageBox.Show("Validate Document");
    }

    

    private void OnImportSBMLClick(object sender, RibbonControlEventArgs e)
    {
      using (var dlg = new OpenFileDialog { Filter = "SBML files|*.xml;*.sbml|All files|*.*" })
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          Worksheet sheet = ((Worksheet)e.Control.Context.Application.ActiveSheet);
          SBtabModel.LoadFile(dlg.FileName, sheet);
        }
      }
    }

    

    private void OnExportSBMLClick(object sender, RibbonControlEventArgs e)
    {

      using (var dlg = new SaveFileDialog { Filter = "SBML files|*.xml;*.sbml|All files|*.*" })
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          Worksheet sheet = ((Worksheet)e.Control.Context.Application.ActiveSheet);
          if (!SBtabModel.SaveSheetAs(dlg.FileName, sheet))
          {
            MessageBox.Show("Please verify that the excel sheet represents a valid SBtab file", "Export failed",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
    }

    private void OnSettingsClick(object sender, RibbonControlEventArgs e)
    {
      using (var dlg = new FormSettings())
      {
        dlg.LoadSettings();
        if (dlg.ShowDialog() == DialogResult.OK)
          dlg.SaveSettings();
      }
    }
  }
}