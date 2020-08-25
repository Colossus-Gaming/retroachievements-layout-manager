using CefSharp;
using CefSharp.Web;
using CefSharp.WinForms;
using Retro_Achievement_Tracker.Properties;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace Retro_Achievement_Tracker
{
    partial class FocusLayoutWindow
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
            this.breakerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.focusAchievementTitleLabel = new System.Windows.Forms.Label();
            this.focusAchievementDescriptionLabel = new System.Windows.Forms.Label();
            this.focusAchievementButtonLeft = new System.Windows.Forms.Button();
            this.focusAchievementButtonRight = new System.Windows.Forms.Button();
            this.focusAchievementPictureBox = new System.Windows.Forms.PictureBox();
            this.setFocusButton = new System.Windows.Forms.Button();
            this.hideFocusButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chromiumWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.customizationGroupBox = new System.Windows.Forms.GroupBox();
            this.fontOutlineColorHexCodeLabel = new System.Windows.Forms.Label();
            this.fontColorHexCodeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fontOutlineSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.fontOutlineCheckbox = new System.Windows.Forms.CheckBox();
            this.fontOutlineColorPickerButton = new System.Windows.Forms.Button();
            this.fontOutlineColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.fontFamilyNameLabel = new System.Windows.Forms.Label();
            this.fontColorPicker = new System.Windows.Forms.Button();
            this.fontColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.fontColorLabel = new System.Windows.Forms.Label();
            this.fontSelectionButton = new System.Windows.Forms.Button();
            this.fontFamilyLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.backgroundColorHexCodeLabel = new System.Windows.Forms.Label();
            this.backgroundColorPickerButton = new System.Windows.Forms.Button();
            this.backgroundColorDisplayBox = new System.Windows.Forms.PictureBox();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.customizationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontOutlineSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontOutlineColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontColorDisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColorDisplayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // breakerLabel
            // 
            this.breakerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.breakerLabel.Location = new System.Drawing.Point(4, 95);
            this.breakerLabel.Name = "breakerLabel";
            this.breakerLabel.Size = new System.Drawing.Size(215, 2);
            this.breakerLabel.TabIndex = 10002;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(5, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 2);
            this.label1.TabIndex = 10003;
            // 
            // focusAchievementTitleLabel
            // 
            this.focusAchievementTitleLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusAchievementTitleLabel.Location = new System.Drawing.Point(70, 32);
            this.focusAchievementTitleLabel.Name = "focusAchievementTitleLabel";
            this.focusAchievementTitleLabel.Size = new System.Drawing.Size(150, 60);
            this.focusAchievementTitleLabel.TabIndex = 6;
            // 
            // focusAchievementDescriptionLabel
            // 
            this.focusAchievementDescriptionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.focusAchievementDescriptionLabel.Location = new System.Drawing.Point(4, 101);
            this.focusAchievementDescriptionLabel.Name = "focusAchievementDescriptionLabel";
            this.focusAchievementDescriptionLabel.Size = new System.Drawing.Size(216, 139);
            this.focusAchievementDescriptionLabel.TabIndex = 5;
            // 
            // focusAchievementButtonLeft
            // 
            this.focusAchievementButtonLeft.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonLeft.Location = new System.Drawing.Point(154, 243);
            this.focusAchievementButtonLeft.Name = "focusAchievementButtonLeft";
            this.focusAchievementButtonLeft.Size = new System.Drawing.Size(30, 20);
            this.focusAchievementButtonLeft.TabIndex = 9;
            this.focusAchievementButtonLeft.Text = "<";
            this.focusAchievementButtonLeft.UseVisualStyleBackColor = true;
            this.focusAchievementButtonLeft.Click += new System.EventHandler(this.MoveHuntIndexLeft);
            // 
            // focusAchievementButtonRight
            // 
            this.focusAchievementButtonRight.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusAchievementButtonRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.focusAchievementButtonRight.Location = new System.Drawing.Point(190, 243);
            this.focusAchievementButtonRight.Name = "focusAchievementButtonRight";
            this.focusAchievementButtonRight.Size = new System.Drawing.Size(30, 20);
            this.focusAchievementButtonRight.TabIndex = 10;
            this.focusAchievementButtonRight.Text = ">";
            this.focusAchievementButtonRight.UseVisualStyleBackColor = true;
            this.focusAchievementButtonRight.Click += new System.EventHandler(this.MoveHuntIndexRight);
            // 
            // focusAchievementPictureBox
            // 
            this.focusAchievementPictureBox.Location = new System.Drawing.Point(4, 32);
            this.focusAchievementPictureBox.Name = "focusAchievementPictureBox";
            this.focusAchievementPictureBox.Size = new System.Drawing.Size(60, 60);
            this.focusAchievementPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.focusAchievementPictureBox.TabIndex = 21;
            this.focusAchievementPictureBox.TabStop = false;
            // 
            // setFocusButton
            // 
            this.setFocusButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.setFocusButton.Location = new System.Drawing.Point(4, 243);
            this.setFocusButton.Name = "setFocusButton";
            this.setFocusButton.Size = new System.Drawing.Size(60, 20);
            this.setFocusButton.TabIndex = 10001;
            this.setFocusButton.Text = "Set";
            this.setFocusButton.UseVisualStyleBackColor = true;
            this.setFocusButton.Click += new System.EventHandler(this.SetFocusButton_Click);
            // 
            // hideFocusButton
            // 
            this.hideFocusButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideFocusButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hideFocusButton.Location = new System.Drawing.Point(70, 243);
            this.hideFocusButton.Name = "hideFocusButton";
            this.hideFocusButton.Size = new System.Drawing.Size(60, 20);
            this.hideFocusButton.TabIndex = 10001;
            this.hideFocusButton.Text = "Hide";
            this.hideFocusButton.UseVisualStyleBackColor = true;
            this.hideFocusButton.Click += new System.EventHandler(this.HideFocusButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.breakerLabel);
            this.groupBox1.Controls.Add(this.focusAchievementPictureBox);
            this.groupBox1.Controls.Add(this.focusAchievementButtonRight);
            this.groupBox1.Controls.Add(this.hideFocusButton);
            this.groupBox1.Controls.Add(this.focusAchievementButtonLeft);
            this.groupBox1.Controls.Add(this.focusAchievementTitleLabel);
            this.groupBox1.Controls.Add(this.setFocusButton);
            this.groupBox1.Controls.Add(this.focusAchievementDescriptionLabel);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 270);
            this.groupBox1.TabIndex = 10002;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Focus";
            // 
            // chromiumWebBrowser
            // 
            this.chromiumWebBrowser.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser.Location = new System.Drawing.Point(240, 0);
            this.chromiumWebBrowser.Name = "chromiumWebBrowser";
            this.chromiumWebBrowser.Size = new System.Drawing.Size(1920, 1080);
            this.chromiumWebBrowser.TabIndex = 0;
            // 
            // customizationGroupBox
            // 
            this.customizationGroupBox.Controls.Add(this.backgroundColorHexCodeLabel);
            this.customizationGroupBox.Controls.Add(this.backgroundColorPickerButton);
            this.customizationGroupBox.Controls.Add(this.backgroundColorDisplayBox);
            this.customizationGroupBox.Controls.Add(this.backgroundColorLabel);
            this.customizationGroupBox.Controls.Add(this.fontOutlineColorHexCodeLabel);
            this.customizationGroupBox.Controls.Add(this.fontColorHexCodeLabel);
            this.customizationGroupBox.Controls.Add(this.label3);
            this.customizationGroupBox.Controls.Add(this.fontOutlineSizeUpDown);
            this.customizationGroupBox.Controls.Add(this.fontOutlineCheckbox);
            this.customizationGroupBox.Controls.Add(this.fontOutlineColorPickerButton);
            this.customizationGroupBox.Controls.Add(this.fontOutlineColorDisplayBox);
            this.customizationGroupBox.Controls.Add(this.fontFamilyNameLabel);
            this.customizationGroupBox.Controls.Add(this.fontColorPicker);
            this.customizationGroupBox.Controls.Add(this.fontColorDisplayBox);
            this.customizationGroupBox.Controls.Add(this.fontColorLabel);
            this.customizationGroupBox.Controls.Add(this.fontSelectionButton);
            this.customizationGroupBox.Controls.Add(this.fontFamilyLabel);
            this.customizationGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customizationGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customizationGroupBox.Location = new System.Drawing.Point(13, 282);
            this.customizationGroupBox.Name = "customizationGroupBox";
            this.customizationGroupBox.Size = new System.Drawing.Size(224, 250);
            this.customizationGroupBox.TabIndex = 10003;
            this.customizationGroupBox.TabStop = false;
            this.customizationGroupBox.Text = "Options";
            // 
            // fontOutlineColorHexCodeLabel
            // 
            this.fontOutlineColorHexCodeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorHexCodeLabel.Location = new System.Drawing.Point(12, 194);
            this.fontOutlineColorHexCodeLabel.Name = "fontOutlineColorHexCodeLabel";
            this.fontOutlineColorHexCodeLabel.Size = new System.Drawing.Size(80, 22);
            this.fontOutlineColorHexCodeLabel.TabIndex = 34;
            // 
            // fontColorHexCodeLabel
            // 
            this.fontColorHexCodeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontColorHexCodeLabel.Location = new System.Drawing.Point(12, 143);
            this.fontColorHexCodeLabel.Name = "fontColorHexCodeLabel";
            this.fontColorHexCodeLabel.Size = new System.Drawing.Size(80, 22);
            this.fontColorHexCodeLabel.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "px";
            // 
            // fontOutlineSizeUpDown
            // 
            this.fontOutlineSizeUpDown.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineSizeUpDown.Location = new System.Drawing.Point(50, 219);
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
            this.fontOutlineSizeUpDown.TabIndex = 28;
            this.fontOutlineSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fontOutlineSizeUpDown.ValueChanged += FontOutlineSizeUpDown_ValueChanged;
            // 
            // fontOutlineCheckbox
            // 
            this.fontOutlineCheckbox.AutoSize = true;
            this.fontOutlineCheckbox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineCheckbox.Location = new System.Drawing.Point(9, 169);
            this.fontOutlineCheckbox.Name = "fontOutlineCheckbox";
            this.fontOutlineCheckbox.Size = new System.Drawing.Size(74, 22);
            this.fontOutlineCheckbox.TabIndex = 27;
            this.fontOutlineCheckbox.Text = "Outline";
            this.fontOutlineCheckbox.UseVisualStyleBackColor = true;
            this.fontOutlineCheckbox.CheckedChanged += FontOutlineCheckbox_CheckedChanged;
            // 
            // fontOutlineColorPickerButton
            // 
            this.fontOutlineColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontOutlineColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontOutlineColorPickerButton.Location = new System.Drawing.Point(124, 194);
            this.fontOutlineColorPickerButton.Name = "fontOutlineColorPickerButton";
            this.fontOutlineColorPickerButton.Size = new System.Drawing.Size(75, 23);
            this.fontOutlineColorPickerButton.TabIndex = 26;
            this.fontOutlineColorPickerButton.Text = "Picker";
            this.fontOutlineColorPickerButton.UseVisualStyleBackColor = true;
            this.fontOutlineColorPickerButton.Click += fontOutlineColorPickerButton_Click;
            // 
            // fontOutlineColorDisplayBox
            // 
            this.fontOutlineColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fontOutlineColorDisplayBox.Location = new System.Drawing.Point(98, 194);
            this.fontOutlineColorDisplayBox.Name = "fontOutlineColorDisplayBox";
            this.fontOutlineColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.fontOutlineColorDisplayBox.TabIndex = 25;
            this.fontOutlineColorDisplayBox.TabStop = false;
            // 
            // fontFamilyNameLabel
            // 
            this.fontFamilyNameLabel.AutoSize = true;
            this.fontFamilyNameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyNameLabel.Location = new System.Drawing.Point(9, 37);
            this.fontFamilyNameLabel.Name = "fontFamilyNameLabel";
            this.fontFamilyNameLabel.Size = new System.Drawing.Size(42, 14);
            this.fontFamilyNameLabel.TabIndex = 23;
            this.fontFamilyNameLabel.Text = "Name:";
            // 
            // fontColorPicker
            // 
            this.fontColorPicker.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontColorPicker.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontColorPicker.Location = new System.Drawing.Point(124, 143);
            this.fontColorPicker.Name = "fontColorPicker";
            this.fontColorPicker.Size = new System.Drawing.Size(75, 23);
            this.fontColorPicker.TabIndex = 22;
            this.fontColorPicker.Text = "Picker";
            this.fontColorPicker.UseVisualStyleBackColor = true;
            this.fontColorPicker.Click += colorPickerButton_Click;
            // 
            // fontColorDisplayBox
            // 
            this.fontColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fontColorDisplayBox.Location = new System.Drawing.Point(98, 143);
            this.fontColorDisplayBox.Name = "fontColorDisplayBox";
            this.fontColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.fontColorDisplayBox.TabIndex = 21;
            this.fontColorDisplayBox.TabStop = false;
            // 
            // fontColorLabel
            // 
            this.fontColorLabel.AutoSize = true;
            this.fontColorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontColorLabel.Location = new System.Drawing.Point(9, 123);
            this.fontColorLabel.Name = "fontColorLabel";
            this.fontColorLabel.Size = new System.Drawing.Size(64, 15);
            this.fontColorLabel.TabIndex = 20;
            this.fontColorLabel.Text = "Font Color";
            // 
            // fontSelectionButton
            // 
            this.fontSelectionButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontSelectionButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontSelectionButton.Location = new System.Drawing.Point(7, 97);
            this.fontSelectionButton.Name = "fontSelectionButton";
            this.fontSelectionButton.Size = new System.Drawing.Size(108, 23);
            this.fontSelectionButton.TabIndex = 19;
            this.fontSelectionButton.Text = "Select Font";
            this.fontSelectionButton.UseVisualStyleBackColor = true;
            this.fontSelectionButton.Click += fontSelectionButton_Click;
            // 
            // fontFamilyLabel
            // 
            this.fontFamilyLabel.AutoSize = true;
            this.fontFamilyLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontFamilyLabel.Location = new System.Drawing.Point(6, 18);
            this.fontFamilyLabel.Name = "fontFamilyLabel";
            this.fontFamilyLabel.Size = new System.Drawing.Size(71, 15);
            this.fontFamilyLabel.TabIndex = 18;
            this.fontFamilyLabel.Text = "Font Family";
            // 
            // label4
            // 
            this.backgroundColorHexCodeLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorHexCodeLabel.Location = new System.Drawing.Point(12, 71);
            this.backgroundColorHexCodeLabel.Name = "label4";
            this.backgroundColorHexCodeLabel.Size = new System.Drawing.Size(80, 22);
            this.backgroundColorHexCodeLabel.TabIndex = 38;
            // 
            // backgroundColorPickerButton
            // 
            this.backgroundColorPickerButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorPickerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backgroundColorPickerButton.Location = new System.Drawing.Point(124, 71);
            this.backgroundColorPickerButton.Name = "backgroundColorPickerButton";
            this.backgroundColorPickerButton.Size = new System.Drawing.Size(75, 23);
            this.backgroundColorPickerButton.TabIndex = 37;
            this.backgroundColorPickerButton.Text = "Picker";
            this.backgroundColorPickerButton.UseVisualStyleBackColor = true;
            this.backgroundColorPickerButton.Click += backgroundColorPickerButton_Click;
            // 
            // backgroundColorDisplayBox
            // 
            this.backgroundColorDisplayBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.backgroundColorDisplayBox.Location = new System.Drawing.Point(98, 71);
            this.backgroundColorDisplayBox.Name = "backgroundColorDisplayBox";
            this.backgroundColorDisplayBox.Size = new System.Drawing.Size(22, 22);
            this.backgroundColorDisplayBox.TabIndex = 36;
            this.backgroundColorDisplayBox.TabStop = false;
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.AutoSize = true;
            this.backgroundColorLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundColorLabel.Location = new System.Drawing.Point(9, 51);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(105, 15);
            this.backgroundColorLabel.TabIndex = 35;
            this.backgroundColorLabel.Text = "Background Color";
            // 
            // FocusLayoutWindow
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1720, 541);
            this.Controls.Add(this.customizationGroupBox);
            this.Controls.Add(this.chromiumWebBrowser);
            this.Controls.Add(this.groupBox1);
            this.Name = "FocusLayoutWindow";
            this.Text = "Retro Achievement - Layout - Focus";
            ((System.ComponentModel.ISupportInitialize)(this.focusAchievementPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.customizationGroupBox.ResumeLayout(false);
            this.customizationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontOutlineSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontOutlineColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontColorDisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundColorDisplayBox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label focusAchievementTitleLabel;
        private System.Windows.Forms.Label focusAchievementDescriptionLabel;
        private System.Windows.Forms.Button focusAchievementButtonLeft;
        private System.Windows.Forms.Button focusAchievementButtonRight;
        private System.Windows.Forms.PictureBox focusAchievementPictureBox;
        private System.Windows.Forms.Button setFocusButton;
        private System.Windows.Forms.Button hideFocusButton;
        private System.Windows.Forms.GroupBox groupBox1;
        public ChromiumWebBrowser chromiumWebBrowser;
        private System.Windows.Forms.GroupBox customizationGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown fontOutlineSizeUpDown;
        private System.Windows.Forms.CheckBox fontOutlineCheckbox;
        private System.Windows.Forms.Button fontOutlineColorPickerButton;
        private System.Windows.Forms.PictureBox fontOutlineColorDisplayBox;
        private System.Windows.Forms.Label fontFamilyNameLabel;
        private System.Windows.Forms.Button fontColorPicker;
        private System.Windows.Forms.PictureBox fontColorDisplayBox;
        private System.Windows.Forms.Label fontColorLabel;
        private System.Windows.Forms.Button fontSelectionButton;
        private System.Windows.Forms.Label fontFamilyLabel;
        private System.Windows.Forms.Label fontOutlineColorHexCodeLabel;
        private System.Windows.Forms.Label fontColorHexCodeLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label breakerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label backgroundColorHexCodeLabel;
        private System.Windows.Forms.Button backgroundColorPickerButton;
        private System.Windows.Forms.PictureBox backgroundColorDisplayBox;
        private System.Windows.Forms.Label backgroundColorLabel;
    }
}