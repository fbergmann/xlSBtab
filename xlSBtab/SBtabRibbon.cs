using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;

namespace xlSBtab
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
      Worksheet sheet = ((Worksheet)e.Control.Context.Application.ActiveSheet);
      MessageBox.Show(SBtabModel.Validate(sheet), "Validation Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    

    private void OnImportSBMLClick(object sender, RibbonControlEventArgs e)
    {
      using (var dlg = new OpenFileDialog { Filter = "SBML files|*.xml;*.sbml|All files|*.*" })
      {
        if (dlg.ShowDialog() == DialogResult.OK)
        {
          Worksheet sheet = ((Worksheet)e.Control.Context.Application.ActiveSheet);
          bool isEmpty = sheet.UsedRange.Address == "$A$1" && sheet.Range["A1"].Value == null;          
          if (isEmpty  || MessageBox.Show("Warning, all content in this sheet will be replaced with the loaded file. Do you want to continue?", "Replace all content of this sheet?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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