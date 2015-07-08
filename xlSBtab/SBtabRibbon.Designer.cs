namespace ExcelAddIn1
{
  partial class SBtabRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SBtabRibbon()
      : base(Globals.Factory.GetRibbonFactory())
    {
      InitializeComponent();
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tab1 = this.Factory.CreateRibbonTab();
      this.group1 = this.Factory.CreateRibbonGroup();
      this.cmdImportSBML = this.Factory.CreateRibbonButton();
      this.cmdExport = this.Factory.CreateRibbonButton();
      this.cmdValidate = this.Factory.CreateRibbonButton();
      this.cmdSettings = this.Factory.CreateRibbonButton();
      this.tab1.SuspendLayout();
      this.group1.SuspendLayout();
      // 
      // tab1
      // 
      this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
      this.tab1.Groups.Add(this.group1);
      this.tab1.Label = "TabAddIns";
      this.tab1.Name = "tab1";
      // 
      // group1
      // 
      this.group1.Items.Add(this.cmdImportSBML);
      this.group1.Items.Add(this.cmdExport);
      this.group1.Items.Add(this.cmdValidate);
      this.group1.Items.Add(this.cmdSettings);
      this.group1.Label = "SBtab";
      this.group1.Name = "group1";
      // 
      // cmdImportSBML
      // 
      this.cmdImportSBML.Label = "Import SBML";
      this.cmdImportSBML.Name = "cmdImportSBML";
      this.cmdImportSBML.SuperTip = "Imports an SBML model and translates it to SBtab.";
      this.cmdImportSBML.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnImportSBMLClick);
      // 
      // cmdExport
      // 
      this.cmdExport.Label = "Export SBML";
      this.cmdExport.Name = "cmdExport";
      this.cmdExport.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnExportSBMLClick);
      // 
      // cmdValidate
      // 
      this.cmdValidate.Label = "Validate";
      this.cmdValidate.Name = "cmdValidate";
      this.cmdValidate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnValidateClick);
      // 
      // cmdSettings
      // 
      this.cmdSettings.Label = "Settings";
      this.cmdSettings.Name = "cmdSettings";
      this.cmdSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OnSettingsClick);
      // 
      // SBtabRibbon
      // 
      this.Name = "SBtabRibbon";
      this.RibbonType = "Microsoft.Excel.Workbook";
      this.Tabs.Add(this.tab1);
      this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.OnRibbonLoad);
      this.tab1.ResumeLayout(false);
      this.tab1.PerformLayout();
      this.group1.ResumeLayout(false);
      this.group1.PerformLayout();

    }

    #endregion

    internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
    internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton cmdValidate;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton cmdImportSBML;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton cmdExport;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton cmdSettings;
  }

  partial class ThisRibbonCollection
  {
    internal SBtabRibbon SBtabRibbon
    {
      get { return this.GetRibbon<SBtabRibbon>(); }
    }
  }
}
