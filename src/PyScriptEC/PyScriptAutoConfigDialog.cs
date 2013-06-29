// Created by Jim Kornelsen on Nov 14 2011
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ECInterfaces;                     // for IEncConverter

namespace SilEncConverters40
{
    public class PyScriptAutoConfigDialog : SilEncConverters40.AutoConfigDialog
    {
        // set at the end of Initialize (to block certain events until we're ready for them)
        protected bool m_bInitialized = false;

        public PyScriptAutoConfigDialog (
            IEncConverters aECs,
            string strDisplayName,
            string strFriendlyName,
            string strConverterIdentifier,
            ConvType eConversionType,
            string strLhsEncodingId,
            string strRhsEncodingId,
            int lProcessTypeFlags,
            bool bIsInRepository)
        {
            Util.DebugWriteLine(this, "ctor1 BEGIN");
			InitializeComponent();
            Util.DebugWriteLine(this, "Initialized component.");
			base.Initialize (
                aECs,
                PyScriptEncConverter.strHtmlFilename,
                strDisplayName,
                strFriendlyName,
                strConverterIdentifier,
                eConversionType,
                strLhsEncodingId,
                strRhsEncodingId,
                lProcessTypeFlags,
                bIsInRepository);
            Util.DebugWriteLine(this, "Initialized base.");
            // if we're editing a CC table/spellfixer project, then set the
            // Converter Spec and say it's unmodified
            if (m_bEditMode)
            {
                Util.DebugWriteLine(this, "Edit mode");
				System.Diagnostics.Debug.Assert(
                    !String.IsNullOrEmpty(ConverterIdentifier));
                textBoxFileSpec.Text = ConverterIdentifier;
                IsModified = false;
            }
            m_bInitialized = true;
            Util.DebugWriteLine(this, "END");
		}

        public PyScriptAutoConfigDialog (
            IEncConverters aECs,
            string strFriendlyName,
            string strConverterIdentifier,
            ConvType eConversionType,
            string strTestData)
        {
            Util.DebugWriteLine(this, "ctor2 BEGIN");
            InitializeComponent();
            base.Initialize (
                aECs,
                strFriendlyName,
                strConverterIdentifier,
                eConversionType,
                strTestData);
            Util.DebugWriteLine(this, "END");
        }

        private System.Windows.Forms.Label labelScriptFile;
        private System.Windows.Forms.TextBox textBoxFileSpec;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialogBrowse;

        private System.Windows.Forms.GroupBox groupBoxExpects;
        private System.Windows.Forms.RadioButton radioButtonExpectsUnicode;
        private System.Windows.Forms.RadioButton radioButtonExpectsLegacy;
        private System.Windows.Forms.GroupBox groupBoxReturns;
        private System.Windows.Forms.RadioButton radioButtonReturnsLegacy;
        private System.Windows.Forms.RadioButton radioButtonReturnsUnicode;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        // This code does not get generated by Designer, so modify it directly.
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelScriptFile = new System.Windows.Forms.Label();
            this.textBoxFileSpec = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.openFileDialogBrowse = new System.Windows.Forms.OpenFileDialog();

            this.groupBoxExpects = new System.Windows.Forms.GroupBox();
            this.radioButtonExpectsLegacy = new System.Windows.Forms.RadioButton();
            this.radioButtonExpectsUnicode = new System.Windows.Forms.RadioButton();
            this.groupBoxReturns = new System.Windows.Forms.GroupBox();
            this.radioButtonReturnsLegacy = new System.Windows.Forms.RadioButton();
            this.radioButtonReturnsUnicode = new System.Windows.Forms.RadioButton();

            this.tabControl.SuspendLayout();
            this.tabPageSetup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxExpects.SuspendLayout();
            this.groupBoxReturns.SuspendLayout();
            this.SuspendLayout();

            // 
            // tableLayoutPanel1
            // 
            this.tabPageSetup.Controls.Add(this.tableLayoutPanel1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(596, 394);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.TabIndex = 1;

            this.tableLayoutPanel1.Controls.Add(this.labelScriptFile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFileSpec, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonBrowse,    2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxExpects, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxReturns, 1, 2);

            // 
            // labelScriptFile
            // 
            this.labelScriptFile.Name = "labelScriptFile";
            this.labelScriptFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelScriptFile.AutoSize = true;
            this.labelScriptFile.Text = "Python script file:";
            this.labelScriptFile.TabIndex = 0;
            // 
            // textBoxFileSpec
            // 
            this.textBoxFileSpec.Name = "textBoxFileSpec";
            this.textBoxFileSpec.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxFileSpec.Size = new System.Drawing.Size(390, 30);
            this.textBoxFileSpec.Margin = new Padding(0);
            this.textBoxFileSpec.TabIndex = 1;
            this.textBoxFileSpec.TextChanged += new System.EventHandler(this.textBoxFileSpec_TextChanged);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonBrowse.AutoSize = true;
            this.buttonBrowse.Margin = new Padding(0);
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // openFileDialogBrowse
            // 
            this.openFileDialogBrowse.DefaultExt = "py";
            this.openFileDialogBrowse.Filter = "Python scrips (*.py)|*.py";
            this.openFileDialogBrowse.Title = "Browse for Python script";

            // 
            // groupBoxExpects
            // 
            this.groupBoxExpects.Controls.Add(this.radioButtonExpectsUnicode);
            this.groupBoxExpects.Controls.Add(this.radioButtonExpectsLegacy);
            this.groupBoxExpects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxExpects.Name = "groupBoxExpects";
            this.groupBoxExpects.Size = new System.Drawing.Size(384, 77);
            this.groupBoxExpects.TabIndex = 3;
            this.groupBoxExpects.TabStop = false;
            this.groupBoxExpects.Text = "Python function expects";
            // 
            // radioButtonExpectsUnicode
            // 
            this.radioButtonExpectsUnicode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonExpectsUnicode.AutoSize = true;
            this.radioButtonExpectsUnicode.Location = new System.Drawing.Point(50, 30);
            this.radioButtonExpectsUnicode.Name = "radioButtonExpectsUnicode";
            this.radioButtonExpectsUnicode.Size = new System.Drawing.Size(100, 17);
            this.radioButtonExpectsUnicode.TabIndex = 0;
            this.radioButtonExpectsUnicode.TabStop = true;
            this.radioButtonExpectsUnicode.Text = "Unicode String";
            this.radioButtonExpectsUnicode.UseVisualStyleBackColor = true;
            this.radioButtonExpectsUnicode.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonExpectsLegacy
            // 
            this.radioButtonExpectsLegacy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonExpectsLegacy.AutoSize = true;
            this.radioButtonExpectsLegacy.Location = new System.Drawing.Point(200, 30);
            this.radioButtonExpectsLegacy.Name = "radioButtonExpectsLegacy";
            this.radioButtonExpectsLegacy.Size = new System.Drawing.Size(125, 17);
            this.radioButtonExpectsLegacy.TabIndex = 0;
            this.radioButtonExpectsLegacy.TabStop = true;
            this.radioButtonExpectsLegacy.Text = "Non-Unicode Bytes";
            this.radioButtonExpectsLegacy.UseVisualStyleBackColor = true;
            this.radioButtonExpectsLegacy.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBoxReturns
            // 
            this.groupBoxReturns.Controls.Add(this.radioButtonReturnsUnicode);
            this.groupBoxReturns.Controls.Add(this.radioButtonReturnsLegacy);
            this.groupBoxReturns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReturns.Name = "groupBoxReturns";
            this.groupBoxReturns.Size = new System.Drawing.Size(384, 77);
            this.groupBoxReturns.TabIndex = 4;
            this.groupBoxReturns.TabStop = false;
            this.groupBoxReturns.Text = "Python function returns";
            // 
            // radioButtonReturnsUnicode
            // 
            this.radioButtonReturnsUnicode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonReturnsUnicode.AutoSize = true;
            this.radioButtonReturnsUnicode.Location = new System.Drawing.Point(50, 30);
            this.radioButtonReturnsUnicode.Name = "radioButtonReturnsUnicode";
            this.radioButtonReturnsUnicode.Size = new System.Drawing.Size(100, 17);
            this.radioButtonReturnsUnicode.TabIndex = 0;
            this.radioButtonReturnsUnicode.TabStop = true;
            this.radioButtonReturnsUnicode.Text = "Unicode String";
            this.radioButtonReturnsUnicode.UseVisualStyleBackColor = true;
            this.radioButtonReturnsUnicode.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonReturnsLegacy
            // 
            this.radioButtonReturnsLegacy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonReturnsLegacy.AutoSize = true;
            this.radioButtonReturnsLegacy.Location = new System.Drawing.Point(200, 30);
            this.radioButtonReturnsLegacy.Name = "radioButtonReturnsLegacy";
            this.radioButtonReturnsLegacy.Size = new System.Drawing.Size(125, 17);
            this.radioButtonReturnsLegacy.TabIndex = 0;
            this.radioButtonReturnsLegacy.TabStop = true;
            this.radioButtonReturnsLegacy.Text = "Non-Unicode String";
            this.radioButtonReturnsLegacy.UseVisualStyleBackColor = true;
            this.radioButtonReturnsLegacy.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);

            // 
            // Button Help
            // 
            this.helpProvider.SetHelpString(this.buttonApply, "Click this button to apply the configured values for this converter");
            this.helpProvider.SetShowHelp(  this.buttonApply, true);
            this.helpProvider.SetHelpString(this.buttonCancel, "Click this button to cancel this dialog");
            this.helpProvider.SetShowHelp(  this.buttonCancel, true);
            this.helpProvider.SetHelpString(this.buttonOK, "Click this button to accept the configured values for this converter");
            this.helpProvider.SetShowHelp(  this.buttonOK, true);
            this.helpProvider.SetHelpString(this.buttonSaveInRepository, "Click to add this converter to the system repository permanently.");
            this.helpProvider.SetShowHelp(  this.buttonSaveInRepository, true);

            // 
            // PyScriptAutoConfigDialog
            // 
            this.ClientSize = new System.Drawing.Size(634, 479);
            this.Name = "PyScriptAutoConfigDialog";
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.buttonApply, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.buttonOK, 0);
            this.Controls.SetChildIndex(this.buttonSaveInRepository, 0);
            this.tabControl.ResumeLayout(false);
            this.tabPageSetup.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxExpects.ResumeLayout(false);
            this.groupBoxExpects.PerformLayout();
            this.groupBoxReturns.ResumeLayout(false);
            this.groupBoxReturns.PerformLayout();
            this.ResumeLayout(false);
        }

        protected void UpdateUI(bool bVisible)
        {
            Util.DebugWriteLine(this, "BEGIN");
            buttonSaveInRepository.Visible =
                groupBoxExpects.Visible =
                groupBoxReturns.Visible = bVisible;
            Util.DebugWriteLine(this, "END");
		}

        protected override void SetConvTypeControls()
        {
            SetRbValuesFromConvType(radioButtonExpectsUnicode, radioButtonExpectsLegacy, radioButtonReturnsUnicode,
                radioButtonReturnsLegacy);
        }

        // this method is called either when the user clicks the "Apply" or "OK" buttons *OR* if she
        //  tries to switch to the Test or Advanced tab. This is the dialog's one opportunity
        //  to make sure that the user has correctly configured a legitimate converter.
        protected override bool OnApply()
        {
            Util.DebugWriteLine(this, "BEGIN");
            // Get the converter identifier from the Setup tab controls.
            ConverterIdentifier = textBoxFileSpec.Text;
            SetConvTypeFromRbControls(radioButtonExpectsUnicode, radioButtonExpectsLegacy,
                radioButtonReturnsUnicode, radioButtonReturnsLegacy);

            // if we're actually on the setup tab, then do some further checking as well.
            if (tabControl.SelectedTab == tabPageSetup)
            {
                // only do these message boxes if we're on the Setup tab itself, because if this OnApply
                //  is being called as a result of the user switching to the Test tab, that code will
                //  already put up an error message and we don't need two error messages.
                if (String.IsNullOrEmpty(ConverterIdentifier))
                {
                    MessageBox.Show(this, "Choose a Python script first!", EncConverters.cstrCaption);
                    return false;
                }
                else if (!File.Exists(ConverterIdentifier))
                {
                    MessageBox.Show(this, "File doesn't exist!", EncConverters.cstrCaption);
                    return false;
                }
            }
            Util.DebugWriteLine(this, "END");
            return base.OnApply();
        }

/*
        protected override bool ShouldRemoveBeforeAdd
        {
            get { return true; }
        }

        protected override bool ShouldFriendlyNameBeReadOnly
        {
            get { return false; }
        }

        protected override bool GetFontMapping(string strFriendlyName, out string strLhsFont, out string strRhsFont)
        {
            return base.GetFontMapping(strFriendlyName, out strLhsFont, out strRhsFont);
        }
*/

        protected override string ProgID
        {
            get { return typeof(PyScriptEncConverter).FullName; }
        }

        protected override string ImplType
        {
            get { return EncConverters.strTypeSILPyScript; }
        }

        protected override string DefaultFriendlyName
        {
            // as the default, make it the same as the table name (w/o extension)
            get { return Path.GetFileNameWithoutExtension(ConverterIdentifier); }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConverterIdentifier))
                openFileDialogBrowse.InitialDirectory = Path.GetDirectoryName(ConverterIdentifier);
            else
                openFileDialogBrowse.InitialDirectory = Util.CommonAppDataPath() + EncConverters.strDefMapsTablesPath;

            if (openFileDialogBrowse.ShowDialog() == DialogResult.OK)
            {
                ResetFields();
                textBoxFileSpec.Text = openFileDialogBrowse.FileName;
            }
        }

        private void textBoxFileSpec_TextChanged(object sender, EventArgs e)
        {
            if (m_bInitialized) // but only do this after we're already initialized
            {
                IsModified = (((TextBox)sender).Text.Length > 0);
                //ProcessType &= ~(int)ProcessTypeFlags.SpellingFixerProject;
                UpdateUI(IsModified);
            }
        }

/*
        protected override bool SetupTabSelected_MakeSaveInRepositoryVisible
        {
            get { return !IsSpellFixerProject; }
        }

        private void buttonAddSpellFixer_Click(object sender, EventArgs e)
        {
            try
            {
                SpellFixerByReflection aSF = new SpellFixerByReflection();
                aSF.LoginProject();
                ((EncConverters)m_aECs).Reinitialize();
                FriendlyName = aSF.SpellFixerEncConverterName;
                m_aEC = m_aECs[FriendlyName];
                if (m_aEC != null)
                {
                    textBoxFileSpec.Text = ConverterIdentifier = m_aEC.ConverterIdentifier;
                    ConversionType = m_aEC.ConversionType;
                    ProcessType = m_aEC.ProcessType;
                    UpdateUI(false);
                    aSF.QueryForSpellingCorrectionIfTableEmpty("incorect");
                    aSF.EditSpellingFixes();
                    IsInRepository = true;
                }
            }
            catch (Exception)
            {
                // usually just a "no project selected message, so .... ignoring it
                // MessageBox.Show(ex.Message, EncConverters.cstrCaption);
            }
        }
*/

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            IsModified = true;
        }
    }
}

