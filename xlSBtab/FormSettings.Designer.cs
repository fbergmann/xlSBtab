namespace xlSBtab
{
  partial class FormSettings
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.cmdOk = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtPython = new System.Windows.Forms.TextBox();
      this.cmdBrowsePython = new System.Windows.Forms.Button();
      this.cmdBrowseSBtab = new System.Windows.Forms.Button();
      this.txtSbtabDir = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 296);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.cmdBrowseSBtab);
      this.panel1.Controls.Add(this.txtSbtabDir);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.cmdBrowsePython);
      this.panel1.Controls.Add(this.txtPython);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(3, 3);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(516, 259);
      this.panel1.TabIndex = 0;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.cmdOk);
      this.panel2.Controls.Add(this.cmdCancel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(3, 268);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(516, 25);
      this.panel2.TabIndex = 1;
      // 
      // cmdCancel
      // 
      this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cmdCancel.Location = new System.Drawing.Point(438, 2);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(75, 23);
      this.cmdCancel.TabIndex = 0;
      this.cmdCancel.Text = "&Cancel";
      this.cmdCancel.UseVisualStyleBackColor = true;
      // 
      // cmdOk
      // 
      this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.cmdOk.Location = new System.Drawing.Point(357, 2);
      this.cmdOk.Name = "cmdOk";
      this.cmdOk.Size = new System.Drawing.Size(75, 23);
      this.cmdOk.TabIndex = 1;
      this.cmdOk.Text = "&OK";
      this.cmdOk.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(18, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(97, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Python Interpreter: ";
      // 
      // txtPython
      // 
      this.txtPython.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPython.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.txtPython.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
      this.txtPython.Location = new System.Drawing.Point(121, 12);
      this.txtPython.Name = "txtPython";
      this.txtPython.Size = new System.Drawing.Size(311, 20);
      this.txtPython.TabIndex = 1;
      this.toolTip1.SetToolTip(this.txtPython, "Full path to the Python interpreter");
      // 
      // cmdBrowsePython
      // 
      this.cmdBrowsePython.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdBrowsePython.Location = new System.Drawing.Point(438, 10);
      this.cmdBrowsePython.Name = "cmdBrowsePython";
      this.cmdBrowsePython.Size = new System.Drawing.Size(75, 23);
      this.cmdBrowsePython.TabIndex = 2;
      this.cmdBrowsePython.Text = "...";
      this.cmdBrowsePython.UseVisualStyleBackColor = true;
      this.cmdBrowsePython.Click += new System.EventHandler(this.OnBrowsePythonClick);
      // 
      // cmdBrowseSBtab
      // 
      this.cmdBrowseSBtab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdBrowseSBtab.Location = new System.Drawing.Point(438, 36);
      this.cmdBrowseSBtab.Name = "cmdBrowseSBtab";
      this.cmdBrowseSBtab.Size = new System.Drawing.Size(75, 23);
      this.cmdBrowseSBtab.TabIndex = 5;
      this.cmdBrowseSBtab.Text = "...";
      this.cmdBrowseSBtab.UseVisualStyleBackColor = true;
      this.cmdBrowseSBtab.Click += new System.EventHandler(this.OnBrowseSBtabDirClick);
      // 
      // txtSbtabDir
      // 
      this.txtSbtabDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSbtabDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.txtSbtabDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
      this.txtSbtabDir.Location = new System.Drawing.Point(121, 38);
      this.txtSbtabDir.Name = "txtSbtabDir";
      this.txtSbtabDir.Size = new System.Drawing.Size(311, 20);
      this.txtSbtabDir.TabIndex = 4;
      this.toolTip1.SetToolTip(this.txtSbtabDir, "Full path to the SBtab root directory. ");
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(49, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "SBtab path: ";
      // 
      // FormSettings
      // 
      this.AcceptButton = this.cmdOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cmdCancel;
      this.ClientSize = new System.Drawing.Size(522, 296);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "FormSettings";
      this.ShowIcon = false;
      this.Text = "SBtab Settings";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button cmdOk;
    private System.Windows.Forms.Button cmdCancel;
    private System.Windows.Forms.Button cmdBrowsePython;
    private System.Windows.Forms.TextBox txtPython;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button cmdBrowseSBtab;
    private System.Windows.Forms.TextBox txtSbtabDir;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}