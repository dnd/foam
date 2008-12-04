using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Foam
{
	/// <summary>
	/// Summary description for frmSP.
	/// </summary>
	public class frmSP : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.SaveFileDialog sfdSQL;
		private System.Windows.Forms.Button btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSP(string SPName, string ProcedureOutput)
		{
			InitializeComponent();

			//Set the default save name to the stored precedure name.
			sfdSQL.FileName = SPName + ".sql";
			//Fill up the display box
			txtOutput.Text = ProcedureOutput;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSP));
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.sfdSQL = new System.Windows.Forms.SaveFileDialog();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(6, 5);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(607, 470);
			this.txtOutput.TabIndex = 0;
			this.txtOutput.Text = "";
			this.txtOutput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOutput_KeyUp);
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnClose.Location = new System.Drawing.Point(538, 480);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// sfdSQL
			// 
			this.sfdSQL.DefaultExt = "sql";
			this.sfdSQL.Filter = "SQL Query Files (*.sql)|*.sql|All Files (*.*)|*.*";
			this.sfdSQL.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdSQL_FileOk);
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSave.Location = new System.Drawing.Point(456, 480);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmSP
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 504);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnSave,
																		  this.btnClose,
																		  this.txtOutput});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmSP";
			this.Text = "FOR XML EXPLICIT Stored Procedure Output";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e) {
			sfdSQL.ShowDialog();
		}

		private void txtOutput_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e) {
			//Check for CTRL+A for select all.
			if (e.Control && e.KeyCode == Keys.A)
				txtOutput.SelectAll();
		}

		private void sfdSQL_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
			string FileName = sfdSQL.FileName;
			
			FileStream fs = File.Create(FileName);
			fs.Close();
			StreamWriter sw = File.AppendText(FileName);
			sw.Write(txtOutput.Text);
			sw.Close();
		}
	}
}
