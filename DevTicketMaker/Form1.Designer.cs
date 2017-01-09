namespace DevTicketMaker {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.genButton = new System.Windows.Forms.Button();
            this.keyInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tidInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.verInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commkeyTypeCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // genButton
            // 
            this.genButton.Location = new System.Drawing.Point(12, 91);
            this.genButton.Name = "genButton";
            this.genButton.Size = new System.Drawing.Size(251, 27);
            this.genButton.TabIndex = 0;
            this.genButton.Text = "Generate";
            this.genButton.UseVisualStyleBackColor = true;
            this.genButton.Click += new System.EventHandler(this.genButton_Click);
            // 
            // keyInput
            // 
            this.keyInput.Location = new System.Drawing.Point(69, 38);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(194, 20);
            this.keyInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "TitleKey: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TitleID: ";
            // 
            // tidInput
            // 
            this.tidInput.Location = new System.Drawing.Point(69, 12);
            this.tidInput.Name = "tidInput";
            this.tidInput.Size = new System.Drawing.Size(194, 20);
            this.tidInput.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Version: ";
            // 
            // verInput
            // 
            this.verInput.Location = new System.Drawing.Point(69, 63);
            this.verInput.MaxLength = 5;
            this.verInput.Name = "verInput";
            this.verInput.Size = new System.Drawing.Size(51, 20);
            this.verInput.TabIndex = 5;
            this.verInput.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type:  ";
            // 
            // commkeyTypeCombo
            // 
            this.commkeyTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commkeyTypeCombo.FormattingEnabled = true;
            this.commkeyTypeCombo.Items.AddRange(new object[] {
            "Eshop",
            "System"});
            this.commkeyTypeCombo.Location = new System.Drawing.Point(191, 64);
            this.commkeyTypeCombo.Name = "commkeyTypeCombo";
            this.commkeyTypeCombo.Size = new System.Drawing.Size(72, 21);
            this.commkeyTypeCombo.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 127);
            this.Controls.Add(this.commkeyTypeCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.verInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tidInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyInput);
            this.Controls.Add(this.genButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Dev Ticket Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button genButton;
        private System.Windows.Forms.TextBox keyInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tidInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox verInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox commkeyTypeCombo;
    }
}

