﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using DND;

namespace Foam
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmFoam : System.Windows.Forms.Form
	{
		private bool m_Parsed;
		private SQLXML m_SqlXml;

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnBuildProcedure;
		private System.Windows.Forms.OpenFileDialog ofdPath;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtDocPath;
		private System.Windows.Forms.ColumnHeader clmParamName;
		private System.Windows.Forms.ColumnHeader clmDataType;
		private System.Windows.Forms.ColumnHeader clmLength;
		private System.Windows.Forms.ComboBox cboDataType;
		private System.Windows.Forms.TextBox txtParameterName;
		private System.Windows.Forms.TextBox txtLengthPrecision;
		private System.Windows.Forms.Button btnAddParam;
		private System.Windows.Forms.Button btnRemoveParam;
		private System.Windows.Forms.ListView lstParameters;
		private System.Windows.Forms.ColumnHeader clmField;
		private System.Windows.Forms.ColumnHeader clmSort;
		private System.Windows.Forms.ComboBox cboSort;
		private System.Windows.Forms.Button btnParseXML;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox txtSPName;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.ListView lstOrderBy;
		private System.Windows.Forms.TextBox txtConstraints;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ComboBox cboOrderBy;
		private System.Windows.Forms.ComboBox cboBlocks;
		private System.Windows.Forms.Button btnRemoveOrderBy;
		private System.Windows.Forms.Button btnAddOrderBy;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ListView lstConstraints;
		private System.Windows.Forms.Button btnRemoveConstraint;
		private System.Windows.Forms.Button btnAddConstraint;
		private System.Windows.Forms.GroupBox grpParameters;
		private System.Windows.Forms.GroupBox grpOrderBy;
		private System.Windows.Forms.GroupBox grpConstraints;
		private System.Windows.Forms.LinkLabel aDND;
		private System.Windows.Forms.Button btnOrderByUp;
		private System.Windows.Forms.Button btnOrderByDown;
		private System.Windows.Forms.Button btnNewProcedure;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmFoam()
		{
			InitializeComponent();
			
			m_Parsed = false;
			m_SqlXml = new SQLXML("FoamXMLStoredProcedure");
	
			ToggleGroups(false);
			cboSort.SelectedIndex = 0;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFoam));
			this.btnClose = new System.Windows.Forms.Button();
			this.btnBuildProcedure = new System.Windows.Forms.Button();
			this.ofdPath = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtDocPath = new System.Windows.Forms.TextBox();
			this.grpParameters = new System.Windows.Forms.GroupBox();
			this.btnRemoveParam = new System.Windows.Forms.Button();
			this.btnAddParam = new System.Windows.Forms.Button();
			this.cboDataType = new System.Windows.Forms.ComboBox();
			this.txtLengthPrecision = new System.Windows.Forms.TextBox();
			this.txtParameterName = new System.Windows.Forms.TextBox();
			this.lstParameters = new System.Windows.Forms.ListView();
			this.clmParamName = new System.Windows.Forms.ColumnHeader();
			this.clmDataType = new System.Windows.Forms.ColumnHeader();
			this.clmLength = new System.Windows.Forms.ColumnHeader();
			this.grpOrderBy = new System.Windows.Forms.GroupBox();
			this.btnOrderByDown = new System.Windows.Forms.Button();
			this.btnOrderByUp = new System.Windows.Forms.Button();
			this.btnRemoveOrderBy = new System.Windows.Forms.Button();
			this.btnAddOrderBy = new System.Windows.Forms.Button();
			this.cboOrderBy = new System.Windows.Forms.ComboBox();
			this.cboSort = new System.Windows.Forms.ComboBox();
			this.lstOrderBy = new System.Windows.Forms.ListView();
			this.clmField = new System.Windows.Forms.ColumnHeader();
			this.clmSort = new System.Windows.Forms.ColumnHeader();
			this.grpConstraints = new System.Windows.Forms.GroupBox();
			this.lstConstraints = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.btnRemoveConstraint = new System.Windows.Forms.Button();
			this.btnAddConstraint = new System.Windows.Forms.Button();
			this.txtConstraints = new System.Windows.Forms.TextBox();
			this.cboBlocks = new System.Windows.Forms.ComboBox();
			this.btnParseXML = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtSPName = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.aDND = new System.Windows.Forms.LinkLabel();
			this.btnNewProcedure = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.grpParameters.SuspendLayout();
			this.grpOrderBy.SuspendLayout();
			this.grpConstraints.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnClose.Location = new System.Drawing.Point(711, 420);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "&Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnBuildProcedure
			// 
			this.btnBuildProcedure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuildProcedure.Location = new System.Drawing.Point(591, 420);
			this.btnBuildProcedure.Name = "btnBuildProcedure";
			this.btnBuildProcedure.Size = new System.Drawing.Size(117, 23);
			this.btnBuildProcedure.TabIndex = 6;
			this.btnBuildProcedure.Text = "Build &Procedure";
			this.btnBuildProcedure.Click += new System.EventHandler(this.btnBuildProcedure_Click);
			// 
			// ofdPath
			// 
			this.ofdPath.Filter = "XML Document (*.xml)|*.xml|All Files (*.*)|*.*";
			this.ofdPath.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdPath_FileOk);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnBrowse,
																					this.txtDocPath});
			this.groupBox1.Location = new System.Drawing.Point(5, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(515, 52);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "XML Document";
			// 
			// btnBrowse
			// 
			this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBrowse.Location = new System.Drawing.Point(429, 19);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 20);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "&Browse";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtDocPath
			// 
			this.txtDocPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDocPath.Location = new System.Drawing.Point(8, 19);
			this.txtDocPath.Name = "txtDocPath";
			this.txtDocPath.Size = new System.Drawing.Size(412, 20);
			this.txtDocPath.TabIndex = 0;
			this.txtDocPath.Text = "";
			this.txtDocPath.Leave += new System.EventHandler(this.txtDocPath_Leave);
			// 
			// grpParameters
			// 
			this.grpParameters.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.btnRemoveParam,
																						this.btnAddParam,
																						this.cboDataType,
																						this.txtLengthPrecision,
																						this.txtParameterName,
																						this.lstParameters});
			this.grpParameters.Location = new System.Drawing.Point(7, 69);
			this.grpParameters.Name = "grpParameters";
			this.grpParameters.Size = new System.Drawing.Size(314, 169);
			this.grpParameters.TabIndex = 2;
			this.grpParameters.TabStop = false;
			this.grpParameters.Text = "Parameters";
			// 
			// btnRemoveParam
			// 
			this.btnRemoveParam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRemoveParam.Location = new System.Drawing.Point(251, 45);
			this.btnRemoveParam.Name = "btnRemoveParam";
			this.btnRemoveParam.Size = new System.Drawing.Size(57, 20);
			this.btnRemoveParam.TabIndex = 4;
			this.btnRemoveParam.Text = "Remove";
			this.btnRemoveParam.Click += new System.EventHandler(this.btnRemoveParam_Click);
			// 
			// btnAddParam
			// 
			this.btnAddParam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddParam.Location = new System.Drawing.Point(170, 45);
			this.btnAddParam.Name = "btnAddParam";
			this.btnAddParam.Size = new System.Drawing.Size(78, 20);
			this.btnAddParam.TabIndex = 3;
			this.btnAddParam.Text = "Add / Edit";
			this.btnAddParam.Click += new System.EventHandler(this.btnAddParam_Click);
			// 
			// cboDataType
			// 
			this.cboDataType.Items.AddRange(new object[] {
															 "BigInt",
															 "Binary",
															 "Bit",
															 "Char",
															 "DateTime",
															 "Decimal",
															 "Float",
															 "Image",
															 "Int",
															 "Money",
															 "NChar",
															 "NText",
															 "NVarChar",
															 "Real",
															 "SmallDateTime",
															 "SmallInt",
															 "SmallMoney",
															 "Text",
															 "Timestamp",
															 "TinyInt",
															 "UniqueIdentifier",
															 "VarBinary",
															 "VarChar"});
			this.cboDataType.Location = new System.Drawing.Point(155, 21);
			this.cboDataType.Name = "cboDataType";
			this.cboDataType.Size = new System.Drawing.Size(97, 21);
			this.cboDataType.TabIndex = 1;
			this.cboDataType.Text = "(Data Type)";
			// 
			// txtLengthPrecision
			// 
			this.txtLengthPrecision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLengthPrecision.Location = new System.Drawing.Point(262, 21);
			this.txtLengthPrecision.Name = "txtLengthPrecision";
			this.txtLengthPrecision.Size = new System.Drawing.Size(46, 20);
			this.txtLengthPrecision.TabIndex = 2;
			this.txtLengthPrecision.Text = "(Length)";
			this.txtLengthPrecision.Leave += new System.EventHandler(this.txtLengthPrecision_Leave);
			this.txtLengthPrecision.Enter += new System.EventHandler(this.txtLengthPrecision_Enter);
			// 
			// txtParameterName
			// 
			this.txtParameterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtParameterName.Location = new System.Drawing.Point(5, 21);
			this.txtParameterName.Name = "txtParameterName";
			this.txtParameterName.Size = new System.Drawing.Size(136, 20);
			this.txtParameterName.TabIndex = 0;
			this.txtParameterName.Text = "(Parameter Name)";
			this.txtParameterName.Leave += new System.EventHandler(this.txtParameterName_Leave);
			this.txtParameterName.Enter += new System.EventHandler(this.txtParameterName_Enter);
			// 
			// lstParameters
			// 
			this.lstParameters.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstParameters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.clmParamName,
																							this.clmDataType,
																							this.clmLength});
			this.lstParameters.FullRowSelect = true;
			this.lstParameters.GridLines = true;
			this.lstParameters.HideSelection = false;
			this.lstParameters.Location = new System.Drawing.Point(5, 68);
			this.lstParameters.MultiSelect = false;
			this.lstParameters.Name = "lstParameters";
			this.lstParameters.Size = new System.Drawing.Size(303, 94);
			this.lstParameters.TabIndex = 5;
			this.lstParameters.View = System.Windows.Forms.View.Details;
			this.lstParameters.SelectedIndexChanged += new System.EventHandler(this.lstParameters_SelectedIndexChanged);
			// 
			// clmParamName
			// 
			this.clmParamName.Text = "Parameter Name";
			this.clmParamName.Width = 133;
			// 
			// clmDataType
			// 
			this.clmDataType.Text = "Data Type";
			this.clmDataType.Width = 100;
			// 
			// clmLength
			// 
			this.clmLength.Text = "Length";
			this.clmLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.clmLength.Width = 50;
			// 
			// grpOrderBy
			// 
			this.grpOrderBy.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.btnOrderByDown,
																					 this.btnOrderByUp,
																					 this.btnRemoveOrderBy,
																					 this.btnAddOrderBy,
																					 this.cboOrderBy,
																					 this.cboSort,
																					 this.lstOrderBy});
			this.grpOrderBy.Location = new System.Drawing.Point(7, 243);
			this.grpOrderBy.Name = "grpOrderBy";
			this.grpOrderBy.Size = new System.Drawing.Size(314, 169);
			this.grpOrderBy.TabIndex = 3;
			this.grpOrderBy.TabStop = false;
			this.grpOrderBy.Text = "ORDER BY";
			// 
			// btnOrderByDown
			// 
			this.btnOrderByDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOrderByDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnOrderByDown.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnOrderByDown.Image")));
			this.btnOrderByDown.Location = new System.Drawing.Point(146, 45);
			this.btnOrderByDown.Name = "btnOrderByDown";
			this.btnOrderByDown.Size = new System.Drawing.Size(21, 20);
			this.btnOrderByDown.TabIndex = 3;
			this.btnOrderByDown.Click += new System.EventHandler(this.btnOrderByDown_Click);
			// 
			// btnOrderByUp
			// 
			this.btnOrderByUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOrderByUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnOrderByUp.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnOrderByUp.Image")));
			this.btnOrderByUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnOrderByUp.Location = new System.Drawing.Point(122, 45);
			this.btnOrderByUp.Name = "btnOrderByUp";
			this.btnOrderByUp.Size = new System.Drawing.Size(21, 20);
			this.btnOrderByUp.TabIndex = 2;
			this.btnOrderByUp.Click += new System.EventHandler(this.btnOrderByUp_Click);
			// 
			// btnRemoveOrderBy
			// 
			this.btnRemoveOrderBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRemoveOrderBy.Location = new System.Drawing.Point(251, 45);
			this.btnRemoveOrderBy.Name = "btnRemoveOrderBy";
			this.btnRemoveOrderBy.Size = new System.Drawing.Size(57, 20);
			this.btnRemoveOrderBy.TabIndex = 5;
			this.btnRemoveOrderBy.Text = "Remove";
			this.btnRemoveOrderBy.Click += new System.EventHandler(this.btnRemoveOrderBy_Click);
			// 
			// btnAddOrderBy
			// 
			this.btnAddOrderBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddOrderBy.Location = new System.Drawing.Point(170, 45);
			this.btnAddOrderBy.Name = "btnAddOrderBy";
			this.btnAddOrderBy.Size = new System.Drawing.Size(78, 20);
			this.btnAddOrderBy.TabIndex = 4;
			this.btnAddOrderBy.Text = "Add / Edit";
			this.btnAddOrderBy.Click += new System.EventHandler(this.btnAddOrderBy_Click);
			// 
			// cboOrderBy
			// 
			this.cboOrderBy.Location = new System.Drawing.Point(5, 21);
			this.cboOrderBy.Name = "cboOrderBy";
			this.cboOrderBy.Size = new System.Drawing.Size(235, 21);
			this.cboOrderBy.TabIndex = 0;
			this.cboOrderBy.Text = "(Field)";
			// 
			// cboSort
			// 
			this.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSort.Items.AddRange(new object[] {
														 "ASC",
														 "DESC"});
			this.cboSort.Location = new System.Drawing.Point(247, 21);
			this.cboSort.Name = "cboSort";
			this.cboSort.Size = new System.Drawing.Size(61, 21);
			this.cboSort.TabIndex = 1;
			// 
			// lstOrderBy
			// 
			this.lstOrderBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstOrderBy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.clmField,
																						 this.clmSort});
			this.lstOrderBy.FullRowSelect = true;
			this.lstOrderBy.GridLines = true;
			this.lstOrderBy.Location = new System.Drawing.Point(5, 68);
			this.lstOrderBy.Name = "lstOrderBy";
			this.lstOrderBy.Size = new System.Drawing.Size(303, 94);
			this.lstOrderBy.TabIndex = 6;
			this.lstOrderBy.View = System.Windows.Forms.View.Details;
			this.lstOrderBy.SelectedIndexChanged += new System.EventHandler(this.lstOrderBy_SelectedIndexChanged);
			// 
			// clmField
			// 
			this.clmField.Text = "Field";
			this.clmField.Width = 228;
			// 
			// clmSort
			// 
			this.clmSort.Text = "Sort";
			this.clmSort.Width = 55;
			// 
			// grpConstraints
			// 
			this.grpConstraints.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.lstConstraints,
																						 this.btnRemoveConstraint,
																						 this.btnAddConstraint,
																						 this.txtConstraints,
																						 this.cboBlocks});
			this.grpConstraints.Location = new System.Drawing.Point(325, 69);
			this.grpConstraints.Name = "grpConstraints";
			this.grpConstraints.Size = new System.Drawing.Size(461, 343);
			this.grpConstraints.TabIndex = 4;
			this.grpConstraints.TabStop = false;
			this.grpConstraints.Text = "Constraint Clauses";
			// 
			// lstConstraints
			// 
			this.lstConstraints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstConstraints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.columnHeader1,
																							 this.columnHeader2});
			this.lstConstraints.FullRowSelect = true;
			this.lstConstraints.GridLines = true;
			this.lstConstraints.Location = new System.Drawing.Point(5, 242);
			this.lstConstraints.Name = "lstConstraints";
			this.lstConstraints.Size = new System.Drawing.Size(450, 94);
			this.lstConstraints.TabIndex = 4;
			this.lstConstraints.View = System.Windows.Forms.View.Details;
			this.lstConstraints.SelectedIndexChanged += new System.EventHandler(this.lstConstraints_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Block";
			this.columnHeader1.Width = 330;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Constraints";
			this.columnHeader2.Width = 100;
			// 
			// btnRemoveConstraint
			// 
			this.btnRemoveConstraint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnRemoveConstraint.Location = new System.Drawing.Point(398, 219);
			this.btnRemoveConstraint.Name = "btnRemoveConstraint";
			this.btnRemoveConstraint.Size = new System.Drawing.Size(57, 20);
			this.btnRemoveConstraint.TabIndex = 3;
			this.btnRemoveConstraint.Text = "Remove";
			this.btnRemoveConstraint.Click += new System.EventHandler(this.btnRemoveConstraint_Click);
			// 
			// btnAddConstraint
			// 
			this.btnAddConstraint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnAddConstraint.Location = new System.Drawing.Point(317, 219);
			this.btnAddConstraint.Name = "btnAddConstraint";
			this.btnAddConstraint.Size = new System.Drawing.Size(78, 20);
			this.btnAddConstraint.TabIndex = 2;
			this.btnAddConstraint.Text = "Add / Edit";
			this.btnAddConstraint.Click += new System.EventHandler(this.btnAddConstraint_Click);
			// 
			// txtConstraints
			// 
			this.txtConstraints.AcceptsTab = true;
			this.txtConstraints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtConstraints.Location = new System.Drawing.Point(5, 46);
			this.txtConstraints.Multiline = true;
			this.txtConstraints.Name = "txtConstraints";
			this.txtConstraints.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConstraints.Size = new System.Drawing.Size(450, 170);
			this.txtConstraints.TabIndex = 1;
			this.txtConstraints.Text = "";
			// 
			// cboBlocks
			// 
			this.cboBlocks.Location = new System.Drawing.Point(5, 21);
			this.cboBlocks.Name = "cboBlocks";
			this.cboBlocks.Size = new System.Drawing.Size(450, 21);
			this.cboBlocks.TabIndex = 0;
			this.cboBlocks.Text = "(Block)";
			// 
			// btnParseXML
			// 
			this.btnParseXML.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnParseXML.Location = new System.Drawing.Point(489, 420);
			this.btnParseXML.Name = "btnParseXML";
			this.btnParseXML.Size = new System.Drawing.Size(99, 23);
			this.btnParseXML.TabIndex = 5;
			this.btnParseXML.Text = "Parse &XML";
			this.btnParseXML.Click += new System.EventHandler(this.btnParseXML_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtSPName});
			this.groupBox5.Location = new System.Drawing.Point(525, 12);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(260, 52);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Procedure Name";
			// 
			// txtSPName
			// 
			this.txtSPName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSPName.Location = new System.Drawing.Point(8, 19);
			this.txtSPName.Name = "txtSPName";
			this.txtSPName.Size = new System.Drawing.Size(244, 20);
			this.txtSPName.TabIndex = 0;
			this.txtSPName.Text = "FoamXMLStoredProcedure";
			// 
			// listBox1
			// 
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 95);
			this.listBox1.TabIndex = 0;
			// 
			// aDND
			// 
			this.aDND.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
			this.aDND.LinkColor = System.Drawing.Color.Navy;
			this.aDND.Location = new System.Drawing.Point(7, 421);
			this.aDND.Name = "aDND";
			this.aDND.Size = new System.Drawing.Size(214, 17);
			this.aDND.TabIndex = 8;
			this.aDND.TabStop = true;
			this.aDND.Text = "http://www.digitalnothing.com";
			this.aDND.VisitedLinkColor = System.Drawing.Color.Navy;
			this.aDND.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aDND_LinkClicked);
			// 
			// btnNewProcedure
			// 
			this.btnNewProcedure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnNewProcedure.Location = new System.Drawing.Point(387, 420);
			this.btnNewProcedure.Name = "btnNewProcedure";
			this.btnNewProcedure.Size = new System.Drawing.Size(99, 23);
			this.btnNewProcedure.TabIndex = 9;
			this.btnNewProcedure.Text = "&New Procedure";
			this.btnNewProcedure.Click += new System.EventHandler(this.btnNewProcedure_Click);
			// 
			// frmFoam
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 447);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnNewProcedure,
																		  this.groupBox5,
																		  this.btnParseXML,
																		  this.grpOrderBy,
																		  this.grpParameters,
																		  this.groupBox1,
																		  this.btnBuildProcedure,
																		  this.btnClose,
																		  this.grpConstraints,
																		  this.aDND});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmFoam";
			this.Text = "Foam - digital nothing design";
			this.groupBox1.ResumeLayout(false);
			this.grpParameters.ResumeLayout(false);
			this.grpOrderBy.ResumeLayout(false);
			this.grpConstraints.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmFoam());
		}
		
		private void ToggleGroups(bool OnOff) {
			grpOrderBy.Enabled = OnOff;
			grpConstraints.Enabled = OnOff;
		}

		private void btnBuildProcedure_Click(object sender, System.EventArgs e) {
			//ArrayLists are used to keep track of the exact order of the entries.
			//This is because hashtables assign their own order for speed of lookups.
			ArrayList ParameterOrder;
			ArrayList ConstraintsOrder;
			ArrayList OrderByOrder;

			string msg = m_SqlXml.LoadXML(txtDocPath.Text);

			//Make sure the XML loaded properly
			if (msg.Length > 0) {
				MessageBox.Show(msg);
			} else {
				m_SqlXml.ProcedureName = txtSPName.Text;
				m_SqlXml.Parameters = ParameterHash(out ParameterOrder);
				m_SqlXml.Constraints = ConstraintHash(out ConstraintsOrder);
				m_SqlXml.OrderBy = OrderByHash(out OrderByOrder);
				m_SqlXml.ParametersOrder = ParameterOrder;
				m_SqlXml.ConstraintsOrder = ConstraintsOrder;
				m_SqlXml.OrderByOrder = OrderByOrder;
				m_SqlXml.Parse();

				string SPOutput = m_SqlXml.BuildQuery();

				frmSP fSP = new frmSP(m_SqlXml.ProcedureName, SPOutput);
				fSP.ShowDialog(this);
			}
		}

		private void ClearDynamicCBOs() {
			//Clear the dynamic boxes.
			cboOrderBy.Items.Clear();
			cboBlocks.Items.Clear();

			cboOrderBy.Text = "(Field)";
			cboBlocks.Text = "(Block)";
		}

		private void ClearLists() {
			lstConstraints.Items.Clear();
			lstOrderBy.Items.Clear();
			lstParameters.Items.Clear();
		}

		private Hashtable ParameterHash(out ArrayList ParameterOrder) {
			Hashtable Params = new Hashtable();
			ParameterOrder = new ArrayList();

			//Build a simple  list of paramters
			for (int n = 0; n < lstParameters.Items.Count; n++) {
				//Verify that the parameter doesn't exist in the list.
				if (!Params.ContainsKey(lstParameters.Items[n].Text)) {
					string DataType = lstParameters.Items[n].SubItems[1].Text + (lstParameters.Items[n].SubItems[2].Text.Length > 0?"(" + lstParameters.Items[n].SubItems[2].Text + ")":"");
					Params.Add(lstParameters.Items[n].Text, DataType);
					ParameterOrder.Add(lstParameters.Items[n].Text);
				}
			}
			return Params;
		}

		private Hashtable OrderByHash(out ArrayList OrderByOrder) {
			Hashtable OrderBy = new Hashtable();
			OrderByOrder = new ArrayList();

			//Build a simple  list of paramters
			for (int n = 0; n < lstOrderBy.Items.Count; n++) {
				//Verify that the parameter doesn't exist in the list.
				if (!OrderBy.ContainsKey(lstOrderBy.Items[n].Text)) {
					OrderBy.Add(lstOrderBy.Items[n].Text, lstOrderBy.Items[n].SubItems[1].Text);
					OrderByOrder.Add(lstOrderBy.Items[n].Text);
				}
			}
			return OrderBy;
		}

		private Hashtable ConstraintHash(out ArrayList ConstraintsOrder) {
			Hashtable Constraints = new Hashtable();
			ConstraintsOrder = new ArrayList();

			//Build a simple  list of paramters
			for (int n = 0; n < lstConstraints.Items.Count; n++) {
				//Verify that the parameter doesn't exist in the list.
				if (!Constraints.ContainsKey(lstConstraints.Items[n].Text)) {
					Constraints.Add(lstConstraints.Items[n].Text, lstConstraints.Items[n].SubItems[1].Text);
					ConstraintsOrder.Add(lstConstraints.Items[n].Text);
				}
			}
			return Constraints;
		}

		private void btnClose_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void txtParameterName_Enter(object sender, System.EventArgs e) {
			if (txtParameterName.Text == "(Parameter Name)")
				txtParameterName.Text = "";
		}

		private void txtLengthPrecision_Enter(object sender, System.EventArgs e) {
			if (txtLengthPrecision.Text == "(Length)")
				txtLengthPrecision.Text = "";
		}

		private void txtParameterName_Leave(object sender, System.EventArgs e) {
			if (txtParameterName.Text == "")
				txtParameterName.Text = "(Parameter Name)";
		}

		private void txtLengthPrecision_Leave(object sender, System.EventArgs e) {
			if (txtLengthPrecision.Text == "")
				txtLengthPrecision.Text = "(Length)";
		}

		private void btnAddParam_Click(object sender, System.EventArgs e) {
			string ParamName = (txtParameterName.Text.Substring(0,1) != "@"?"@" + txtParameterName.Text:txtParameterName.Text);
			string Length = (txtLengthPrecision.Text == "(Length)"?"":txtLengthPrecision.Text);
			string DataType = "";

			DataType = GetCBOValue(cboDataType);

			//Verify that we have the necessary fields
			if (ParamName == "@(Parameter Name)" || DataType == "") {
				MessageBox.Show("Please make sure you have specified a parameter name, and data type.");
			} else {
				bool Updated = false;

				//See if there is an already existing parameter in the list to update.
				for (int n = 0; n < lstParameters.Items.Count; n++) {
					if (lstParameters.Items[n].Text == ParamName) {
						lstParameters.Items[n].SubItems[1].Text = DataType;
						lstParameters.Items[n].SubItems[2].Text = Length;
						Updated = true;
						break;
					}
				}

				//If something wasn't updated, then add the new item.
				if (!Updated) {
					ListViewItem NewParam = lstParameters.Items.Add(ParamName);
					NewParam.SubItems.Add(DataType);
					NewParam.SubItems.Add(Length);
				}

				txtParameterName.Text = "";
				txtParameterName.Focus();
			}
		}

		private void btnParseXML_Click(object sender, System.EventArgs e) {
			string msg = m_SqlXml.LoadXML(txtDocPath.Text);
			
			//Make sure the XML loaded properly
			if (msg.Length > 0) {
				MessageBox.Show(msg);
			} else {
				//Check if the doc has been parsed once.
				//If it has, then we need to clear CBOs, 
				//and possibly the lists if the user wants
				//us to.
				DialogResult dr = DialogResult.No;

				if (m_Parsed) {
					dr = MessageBox.Show("Would you like to clear all lists?", "Parse XML", MessageBoxButtons.YesNo);
				}

				//Clear all lists
				if (dr == DialogResult.Yes)
					ClearLists();

				//Always clear the dynamic CBOs to prevent multiple same entries
				ClearDynamicCBOs();

				//Attempt to parse the doc
				if (m_SqlXml.Parse()) {
				//Populatethe combo boxes so users can work
				PopulateComboBoxes();
				ToggleGroups(true);
				m_Parsed = true;
				MessageBox.Show("XML parsing succcessful.");
				} else {
					MessageBox.Show("XML parsing failed.");
				}
			}
		}

		private void PopulateComboBoxes() {
			//Retrieve the parsed nodes.
			ArrayList nodes = m_SqlXml.Nodes;
			Hashtable levels = m_SqlXml.Levels;

			//Populate the OrderBy CBO
			for (int n = 0; n < nodes.Count; n++) {
				SQLNode node = (SQLNode)nodes[n];
				string tmpPath = node.FullPath + "." + node.Name;

				//Drop off the initial #document. tag.
				tmpPath = tmpPath.Replace("#document.", "");

				if (tmpPath.Length > 0) {
					if (tmpPath.Substring(tmpPath.Length - 1, 1) != ".") {
						//We only want full path fields for OrderBy
						cboOrderBy.Items.Add(tmpPath);					
					}
				}
			}

			//Populate the Constraints CBO
			int FindLevel = 0;
			int MaxLevel = 0;
			
			//Find the maximum level
			foreach(DictionaryEntry d in levels) {
				if (((int)d.Value) > MaxLevel)
					MaxLevel = (int)d.Value;
			}
			
			//RUn through the collection again, only this time, build the CBO
			while (FindLevel <= MaxLevel) {
				foreach (DictionaryEntry d in levels) {
					if (((int)d.Value) == FindLevel) {
						//Don't add the initial root.
						if((string)d.Key != "#document") {
							//Drop off the initial #document. tag before adding.
							cboBlocks.Items.Add(((string)d.Key).Replace("#document.", ""));
						}
						FindLevel++;
					}
				}
			}			
		}

		private string GetCBOValue(ComboBox cbo) {
			string val = "";

			// If the user has keyed in their own text in the drop down
			//	it will cause a nasty error to be thrown.
			try {
				val = cbo.SelectedItem.ToString();
			} catch {
				for (int n = 0; n < cbo.Items.Count; n++) {
					if (cbo.Items[n].ToString().ToLower() == cbo.Text.ToLower()) {
						val = cbo.Items[n].ToString();
						break;
					}
				}
			}
			return val;
		}

		private void btnBrowse_Click(object sender, System.EventArgs e) {
			ofdPath.InitialDirectory = txtDocPath.Text;
			ofdPath.ShowDialog();
		}

		private void ofdPath_FileOk(object sender, System.ComponentModel.CancelEventArgs e) {
			txtDocPath.Text = ofdPath.FileName;
			
			EventArgs args = new EventArgs();
			btnParseXML_Click(this, args);
		}

		private void lstParameters_SelectedIndexChanged(object sender, System.EventArgs e) {
			foreach(int si in lstParameters.SelectedIndices) {
				txtParameterName.Text = lstParameters.Items[si].Text;
				cboDataType.Text = lstParameters.Items[si].SubItems[1].Text;
				txtLengthPrecision.Text = lstParameters.Items[si].SubItems[2].Text;
			}
		}

		private void btnRemoveParam_Click(object sender, System.EventArgs e) {
			string ParamName = (txtParameterName.Text.Substring(0,1) != "@"?"@" + txtParameterName.Text:txtParameterName.Text);
			bool RemovedParam = false;

			//Loop through the paramters list
			for(int n = 0; n < lstParameters.Items.Count; n++) {
				if (lstParameters.Items[n].Text == ParamName) {
					ListViewItem item = lstParameters.Items[n];
					lstParameters.Items.Remove(item);
					RemovedParam = true;
					break;
				}
			}

			if (RemovedParam) {
				txtParameterName.Text = "";
				txtParameterName.Focus();
				cboDataType.Text = "(Data Type)";
				txtLengthPrecision.Text = "(Length)";
				MessageBox.Show(ParamName + " has been removed.");
			} else {
				MessageBox.Show(ParamName + " does not exist in the list.");
			}
		}

		private void btnAddOrderBy_Click(object sender, System.EventArgs e) {
			string OrderField = GetCBOValue(cboOrderBy);
			//Make sure we have the appropriate fields
			if (OrderField == "") {
				MessageBox.Show("Please select the field you would like to order by.");
			} else {
				bool Updated = false;

				//See if there is an already existing parameter in the list to update.
				for (int n = 0; n < lstOrderBy.Items.Count; n++) {
					if (lstOrderBy.Items[n].Text == OrderField) {
						lstOrderBy.Items[n].SubItems[1].Text = cboSort.SelectedItem.ToString();
						Updated = true;
						break;
					}
				}

				//If something wasn't updated, then add the new item.
				if (!Updated) {
					ListViewItem NewParam = lstOrderBy.Items.Add(OrderField);
					NewParam.SubItems.Add(cboSort.SelectedItem.ToString());
				}

				cboOrderBy.Text = "(Field)";
				cboSort.SelectedIndex = 0;
				cboOrderBy.Focus();
			}
		}

		private void btnRemoveOrderBy_Click(object sender, System.EventArgs e) {
			string OrderField = GetCBOValue(cboOrderBy);
			bool RemovedOrderBy = false;
			
			//Loop through the paramters list
			for(int n = 0; n < lstOrderBy.Items.Count; n++) {
				if (lstOrderBy.Items[n].Text == OrderField) {
					ListViewItem item = lstOrderBy.Items[n];
					lstOrderBy.Items.Remove(item);
					RemovedOrderBy = true;
					break;
				}
			}

			if (RemovedOrderBy) {
				cboOrderBy.Text = "(Field)";
				cboOrderBy.Focus();
				cboSort.SelectedIndex = 0;
				MessageBox.Show("ORDER BY " + OrderField + " has been removed.");
			} else {
				MessageBox.Show("No ORDER BY for " + OrderField + " could be found in the list.");
			}
		}

		private void btnAddConstraint_Click(object sender, System.EventArgs e) {
			string Block = GetCBOValue(cboBlocks);
			//Make sure we have the appropriate fields
			if (Block == "" || txtConstraints.Text == "") {
				MessageBox.Show("Please make sure you have entered constraints and selected a block to add the constraints to.");
			} else {
				bool Updated = false;
				string Constraints = txtConstraints.Text;
				
				if (Constraints.Length > 2) {
					while (Constraints.Substring(Constraints.Length - 2, 2) == "\r\n") {
						Constraints = Constraints.Substring(0, Constraints.Length - 2);
						if (Constraints.Length < 2)
							break;
					}
				}

				//See if there is an already existing parameter in the list to update.
				for (int n = 0; n < lstConstraints.Items.Count; n++) {
					if (lstConstraints.Items[n].Text == Block) {
						lstConstraints.Items[n].SubItems[1].Text = Constraints;
						Updated = true;
						break;
					}
				}

				//If something wasn't updated, then add the new item.
				if (!Updated) {
					ListViewItem NewParam = lstConstraints.Items.Add(Block);
					NewParam.SubItems.Add(Constraints);
				}

				txtConstraints.Text = "";
				cboBlocks.Text = "(Block)";
				cboBlocks.Focus();
			}
		}

		private void btnRemoveConstraint_Click(object sender, System.EventArgs e) {
			string Block = GetCBOValue(cboBlocks);
			bool RemovedBlock = false;
			
			//Loop through the paramters list
			for(int n = 0; n < lstConstraints.Items.Count; n++) {
				if (lstConstraints.Items[n].Text == Block) {
					ListViewItem item = lstConstraints.Items[n];
					lstConstraints.Items.Remove(item);
					RemovedBlock = true;
					break;
				}
			}

			if (RemovedBlock) {
				cboBlocks.Text = "(Block)";
				cboBlocks.Focus();
				txtConstraints.Text = "";
				MessageBox.Show("The constraints on " + Block + " have been removed.");
			} else {
				MessageBox.Show("No constraints for " + Block + " could be found in the list.");
			}
		}

		private void lstOrderBy_SelectedIndexChanged(object sender, System.EventArgs e) {
			foreach(int si in lstOrderBy.SelectedIndices) {
				cboOrderBy.Text = lstOrderBy.Items[si].Text;
				cboSort.SelectedIndex = cboSort.FindStringExact(lstOrderBy.Items[si].SubItems[1].Text);
			}		
		}

		private void aDND_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("http://www.digitalnothing.com/?foam");
		}

		private void lstConstraints_SelectedIndexChanged(object sender, System.EventArgs e) {
			foreach(int si in lstConstraints.SelectedIndices) {
				cboBlocks.Text = lstConstraints.Items[si].Text;
				txtConstraints.Text = lstConstraints.Items[si].SubItems[1].Text;
			}	
		}

		private void btnOrderByUp_Click(object sender, System.EventArgs e) {
			string OrderField = GetCBOValue(cboOrderBy);

			if (OrderField != "") {
				//Locate the selected item
				for (int n = 0; n < lstOrderBy.Items.Count; n++) {
					//Check for the field, and only if it isn't at the top.
					if (lstOrderBy.Items[n].Text == OrderField && n != 0) {
						//Get the list item to move
						ListViewItem item = lstOrderBy.Items[n];
						//Remove the old list item
						lstOrderBy.Items.Remove(item);
						//Add the item back in 1 up from where it was
						lstOrderBy.Items.Insert(n - 1, item);
						break;
					}
				}			
			}
		}

		private void btnOrderByDown_Click(object sender, System.EventArgs e) {
			string OrderField = GetCBOValue(cboOrderBy);

			if (OrderField != "") {
				//Locate the selected item
				for (int n = 0; n < lstOrderBy.Items.Count; n++) {
					//Check for the field, and only if it isn't at the bottom.
					if (lstOrderBy.Items[n].Text == OrderField && n < (lstOrderBy.Items.Count - 1)) {
						//Get the list item to move
						ListViewItem item = lstOrderBy.Items[n];
						//Remove the old list item
						lstOrderBy.Items.Remove(item);
						//Add the item back in 1 down from where it was
						lstOrderBy.Items.Insert(n + 1, item);
						break;
					}
				}			
			}
		}

		private void btnNewProcedure_Click(object sender, System.EventArgs e) {
			//Clear all fields, lists, and dynamic boxes
			txtDocPath.Text = "";
			txtSPName.Text = "";

			txtParameterName.Text = "(Parameter Name)";
			cboDataType.Text = "(Data Type)";
			txtLengthPrecision.Text = "(Length)";
			cboSort.Text = "ASC";
			txtConstraints.Text = "";

			ClearLists();
			ClearDynamicCBOs();

			//Toggle parsed flag
			m_Parsed = false;
		}

		private void txtDocPath_Leave(object sender, System.EventArgs e) {
			if (txtDocPath.Text.Length > 0) {
				EventArgs args = new EventArgs();
				btnParseXML_Click(this, args);
			}
	}
	}
}
