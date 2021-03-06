﻿namespace SignatureToDetour
{
    partial class signatureToDetourForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(signatureToDetourForm));
            this.functionSignatureTextBox = new System.Windows.Forms.TextBox();
            this.makeDetourBtn = new System.Windows.Forms.Button();
            this.outputTextbox = new System.Windows.Forms.TextBox();
            this.signatureLabel = new System.Windows.Forms.Label();
            this.outputNameLabel = new System.Windows.Forms.Label();
            this.functionNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addSignatureBtn = new System.Windows.Forms.Button();
            this.signatureListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // functionSignatureTextBox
            // 
            this.functionSignatureTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionSignatureTextBox.Location = new System.Drawing.Point(12, 86);
            this.functionSignatureTextBox.Multiline = true;
            this.functionSignatureTextBox.Name = "functionSignatureTextBox";
            this.functionSignatureTextBox.Size = new System.Drawing.Size(426, 69);
            this.functionSignatureTextBox.TabIndex = 1;
            this.functionSignatureTextBox.Text = "Example: char sub_12345()";
            this.functionSignatureTextBox.Enter += new System.EventHandler(this.functionSignatureTextBox_Enter);
            // 
            // makeDetourBtn
            // 
            this.makeDetourBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.makeDetourBtn.Location = new System.Drawing.Point(12, 347);
            this.makeDetourBtn.Name = "makeDetourBtn";
            this.makeDetourBtn.Size = new System.Drawing.Size(420, 38);
            this.makeDetourBtn.TabIndex = 4;
            this.makeDetourBtn.Text = "Make Detour";
            this.makeDetourBtn.UseVisualStyleBackColor = true;
            this.makeDetourBtn.Click += new System.EventHandler(this.MakeDetour_Click);
            // 
            // outputTextbox
            // 
            this.outputTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextbox.Location = new System.Drawing.Point(12, 419);
            this.outputTextbox.Multiline = true;
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.Size = new System.Drawing.Size(425, 304);
            this.outputTextbox.TabIndex = 5;
            // 
            // signatureLabel
            // 
            this.signatureLabel.AutoSize = true;
            this.signatureLabel.Location = new System.Drawing.Point(12, 67);
            this.signatureLabel.Name = "signatureLabel";
            this.signatureLabel.Size = new System.Drawing.Size(92, 13);
            this.signatureLabel.TabIndex = 5;
            this.signatureLabel.Text = "IDA Pro Signature";
            // 
            // outputNameLabel
            // 
            this.outputNameLabel.AutoSize = true;
            this.outputNameLabel.Location = new System.Drawing.Point(12, 25);
            this.outputNameLabel.Name = "outputNameLabel";
            this.outputNameLabel.Size = new System.Drawing.Size(117, 13);
            this.outputNameLabel.TabIndex = 6;
            this.outputNameLabel.Text = "Output Function Name:";
            // 
            // functionNameTextBox
            // 
            this.functionNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionNameTextBox.Location = new System.Drawing.Point(12, 41);
            this.functionNameTextBox.Name = "functionNameTextBox";
            this.functionNameTextBox.Size = new System.Drawing.Size(422, 20);
            this.functionNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Output:";
            // 
            // addSignatureBtn
            // 
            this.addSignatureBtn.Location = new System.Drawing.Point(11, 161);
            this.addSignatureBtn.Name = "addSignatureBtn";
            this.addSignatureBtn.Size = new System.Drawing.Size(75, 23);
            this.addSignatureBtn.TabIndex = 2;
            this.addSignatureBtn.Text = "Add Signature";
            this.addSignatureBtn.UseVisualStyleBackColor = true;
            this.addSignatureBtn.Click += new System.EventHandler(this.addSignatureBtn_Click);
            // 
            // signatureListBox
            // 
            this.signatureListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureListBox.FormattingEnabled = true;
            this.signatureListBox.Location = new System.Drawing.Point(11, 205);
            this.signatureListBox.Name = "signatureListBox";
            this.signatureListBox.Size = new System.Drawing.Size(426, 121);
            this.signatureListBox.TabIndex = 3;
            // 
            // signatureToDetourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(449, 735);
            this.Controls.Add(this.signatureListBox);
            this.Controls.Add(this.addSignatureBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputTextbox);
            this.Controls.Add(this.makeDetourBtn);
            this.Controls.Add(this.functionNameTextBox);
            this.Controls.Add(this.outputNameLabel);
            this.Controls.Add(this.signatureLabel);
            this.Controls.Add(this.functionSignatureTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "signatureToDetourForm";
            this.Text = "Signature to Detour Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox functionSignatureTextBox;
        private System.Windows.Forms.Button makeDetourBtn;
        private System.Windows.Forms.TextBox outputTextbox;
        private System.Windows.Forms.Label signatureLabel;
        private System.Windows.Forms.Label outputNameLabel;
        private System.Windows.Forms.TextBox functionNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addSignatureBtn;
        private System.Windows.Forms.ListBox signatureListBox;
    }
}

