using CefSharp.Web;
using CefSharp.WinForms;
using Retro_Achievement_Tracker.Models;
using Retro_Achievement_Tracker.Properties;

namespace Retro_Achievement_Tracker
{
    partial class StatsLayoutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsLayoutWindow));
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.fontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.fontOutlineColorPickerButton = new System.Windows.Forms.Button();
            this.fontOutlineColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.fontOutlineColorHexCodeLabel = new System.Windows.Forms.Label();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.fontFamilyNameLabel = new System.Windows.Forms.Label();
            this.fontColorPicker = new System.Windows.Forms.Button();
            this.fontColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.fontColorHexCodeLabel = new System.Windows.Forms.Label();
            this.fontColorLabel = new System.Windows.Forms.Label();
            this.fontSelectionButton = new System.Windows.Forms.Button();
            this.fontFamilyLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontOutlineSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontOutlineColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontOutlineSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // chromiumWebBrowser
            // 
            this.chromiumWebBrowser.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser.Location = new System.Drawing.Point(240, 0);
            this.chromiumWebBrowser.Name = "chromiumWebBrowser";
            this.chromiumWebBrowser.Size = new System.Drawing.Size(1920, 1080);
            this.chromiumWebBrowser.TabIndex = 0;
            this.chromiumWebBrowser.Dock = System.Windows.Forms.DockStyle.None;
            // 
            // statsGroupBox
            // 
            this.statsGroupBox.Controls.Add(this.label2);
            this.statsGroupBox.Controls.Add(this.label1);
            this.statsGroupBox.Controls.Add(this.fontOutlineSizeUpDown);
            this.statsGroupBox.Controls.Add(this.fontOutlineCheckbox);
            this.statsGroupBox.Controls.Add(this.fontOutlineColorPickerButton);
            this.statsGroupBox.Controls.Add(this.fontOutlineColorDisplayBox);
            this.statsGroupBox.Controls.Add(this.fontOutlineColorHexCodeLabel);
            this.statsGroupBox.Controls.Add(this.fontSizeLabel);
            this.statsGroupBox.Controls.Add(this.fontFamilyNameLabel);
            this.statsGroupBox.Controls.Add(this.fontColorPicker);
            this.statsGroupBox.Controls.Add(this.fontColorDisplayBox);
            this.statsGroupBox.Controls.Add(this.fontColorHexCodeLabel);
            this.statsGroupBox.Controls.Add(this.fontColorLabel);
            this.statsGroupBox.Controls.Add(this.fontSelectionButton);
            this.statsGroupBox.Controls.Add(this.fontFamilyLabel);
            this.statsGroupBox.Font = new System.Drawing.Font("Calibri", 13.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(222, 348);
            this.statsGroupBox.TabIndex = 1;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Stats";
            // 
            // fontOutlineCheckbox
            // 
            this.fontOutlineCheckbox.AutoSize = true;
            this.fontOutlineCheckbox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineCheckbox.Location = new System.Drawing.Point(7, 155);
            this.fontOutlineCheckbox.Name = "fontOutlineCheckbox";
            this.fontOutlineCheckbox.Size = new System.Drawing.Size(74, 22);
            this.fontOutlineCheckbox.TabIndex = 14;
            this.fontOutlineCheckbox.Text = "Outline";
            this.fontOutlineCheckbox.UseVisualStyleBackColor = true;
            this.fontOutlineCheckbox.CheckedChanged += FontOutlineCheckbox_CheckedChanged;
            // 
            // fontOutlineColorPickerButton
            // 
            this.fontOutlineColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontOutlineColorPickerButton.Location = new System.Drawing.Point(122, 180);
            this.fontOutlineColorPickerButton.Name = "fontOutlineColorPickerButton";
            this.fontOutlineColorPickerButton.Size = new System.Drawing.Size(75, 23);
            this.fontOutlineColorPickerButton.TabIndex = 13;
            this.fontOutlineColorPickerButton.Text = "Picker";
            this.fontOutlineColorPickerButton.UseVisualStyleBackColor = true;
            this.fontOutlineColorPickerButton.Click += fontOutlineColorPickerButton_Click;
            // 
            // fontOutlineColorDisplayBox
            // 
            this.fontOutlineColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fontOutlineColorDisplayBox.Location = new System.Drawing.Point(96, 180);
            this.fontOutlineColorDisplayBox.Name = "fontOutlineColorDisplayBox";
            this.fontOutlineColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.fontOutlineColorDisplayBox.TabIndex = 12;
            this.fontOutlineColorDisplayBox.TabStop = false;
            // 
            // fontOutlineColorHexCodeLabel
            // 
            this.fontOutlineColorHexCodeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorHexCodeLabel.Location = new System.Drawing.Point(10, 180);
            this.fontOutlineColorHexCodeLabel.Name = "fontOutlineColorHexCodeLabel";
            this.fontOutlineColorHexCodeLabel.Size = new System.Drawing.Size(80, 22);
            this.fontOutlineColorHexCodeLabel.TabIndex = 11;
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSizeLabel.Location = new System.Drawing.Point(10, 59);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(32, 14);
            this.fontSizeLabel.TabIndex = 10;
            this.fontSizeLabel.Text = "Size:";
            // 
            // fontFamilyNameLabel
            // 
            this.fontFamilyNameLabel.AutoSize = true;
            this.fontFamilyNameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyNameLabel.Location = new System.Drawing.Point(10, 41);
            this.fontFamilyNameLabel.Name = "fontFamilyNameLabel";
            this.fontFamilyNameLabel.Size = new System.Drawing.Size(42, 14);
            this.fontFamilyNameLabel.TabIndex = 9;
            this.fontFamilyNameLabel.Text = "Name:";
            // 
            // fontColorPicker
            // 
            this.fontColorPicker.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontColorPicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontColorPicker.Location = new System.Drawing.Point(122, 129);
            this.fontColorPicker.Name = "fontColorPicker";
            this.fontColorPicker.Size = new System.Drawing.Size(75, 23);
            this.fontColorPicker.TabIndex = 8;
            this.fontColorPicker.Text = "Picker";
            this.fontColorPicker.UseVisualStyleBackColor = true;
            this.fontColorPicker.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // fontColorDisplayBox
            // 
            this.fontColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fontColorDisplayBox.Location = new System.Drawing.Point(96, 129);
            this.fontColorDisplayBox.Name = "fontColorDisplayBox";
            this.fontColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.fontColorDisplayBox.TabIndex = 7;
            this.fontColorDisplayBox.TabStop = false;
            // 
            // fontColorHexCodeLabel
            // 
            this.fontColorHexCodeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontColorHexCodeLabel.Location = new System.Drawing.Point(10, 129);
            this.fontColorHexCodeLabel.Name = "fontColorHexCodeLabel";
            this.fontColorHexCodeLabel.Size = new System.Drawing.Size(80, 22);
            this.fontColorHexCodeLabel.TabIndex = 6;
            // 
            // fontColorLabel
            // 
            this.fontColorLabel.AutoSize = true;
            this.fontColorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontColorLabel.Location = new System.Drawing.Point(7, 109);
            this.fontColorLabel.Name = "fontColorLabel";
            this.fontColorLabel.Size = new System.Drawing.Size(64, 15);
            this.fontColorLabel.TabIndex = 5;
            this.fontColorLabel.Text = "Font Color";
            // 
            // fontSelectionButton
            // 
            this.fontSelectionButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSelectionButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontSelectionButton.Location = new System.Drawing.Point(10, 82);
            this.fontSelectionButton.Name = "fontSelectionButton";
            this.fontSelectionButton.Size = new System.Drawing.Size(108, 23);
            this.fontSelectionButton.TabIndex = 1;
            this.fontSelectionButton.Text = "Select Font";
            this.fontSelectionButton.UseVisualStyleBackColor = true;
            this.fontSelectionButton.Click += new System.EventHandler(this.fontSelectionButton_Click);
            // 
            // fontFamilyLabel
            // 
            this.fontFamilyLabel.AutoSize = true;
            this.fontFamilyLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyLabel.Location = new System.Drawing.Point(7, 22);
            this.fontFamilyLabel.Name = "fontFamilyLabel";
            this.fontFamilyLabel.Size = new System.Drawing.Size(71, 15);
            this.fontFamilyLabel.TabIndex = 0;
            this.fontFamilyLabel.Text = "Font Family";
            // 
            // fontOutlineSizeUpDown
            // 
            this.fontOutlineSizeUpDown.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineSizeUpDown.Location = new System.Drawing.Point(48, 205);
            this.fontOutlineSizeUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fontOutlineSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontOutlineSizeUpDown.Name = "fontOutlineSizeUpDown";
            this.fontOutlineSizeUpDown.Size = new System.Drawing.Size(46, 23);
            this.fontOutlineSizeUpDown.TabIndex = 15;
            this.fontOutlineSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontOutlineSizeUpDown.ValueChanged += FontOutlineSizeUpDown_ValueChanged;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "px";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 14);
            this.label2.TabIndex = 17;
            this.label2.Text = "Size:";
            // 
            // StatsLayoutWindow
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(744, 367);
            this.Controls.Add(this.statsGroupBox);
            this.Controls.Add(this.chromiumWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatsLayoutWindow";
            this.Text = "Retro Achievement - Layout - Stats";
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontOutlineColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontOutlineSizeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public ChromiumWebBrowser chromiumWebBrowser;
        private System.Windows.Forms.GroupBox statsGroupBox;
        private System.Windows.Forms.Button fontSelectionButton;
        private System.Windows.Forms.Label fontFamilyLabel;
        private System.Windows.Forms.Button fontColorPicker;
        private System.Windows.Forms.PictureBox fontColorDisplayBox;
        private System.Windows.Forms.Label fontColorHexCodeLabel;
        private System.Windows.Forms.Label fontColorLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.Label fontFamilyNameLabel;
        private System.Windows.Forms.CheckBox fontOutlineCheckbox;
        private System.Windows.Forms.Button fontOutlineColorPickerButton;
        private System.Windows.Forms.PictureBox fontOutlineColorDisplayBox;
        private System.Windows.Forms.Label fontOutlineColorHexCodeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown fontOutlineSizeUpDown;
        private System.Windows.Forms.Label label2;
    }
}