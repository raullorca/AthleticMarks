namespace AthleticMarks.App
{
    partial class TrialEditForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.numberAthletesLabel = new System.Windows.Forms.Label();
            this.measurementTypeLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.numberAthletesTextBox = new System.Windows.Forms.TextBox();
            this.measurementTypeComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(30, 394);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 42);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel·lar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // numberAthletesLabel
            // 
            this.numberAthletesLabel.AutoSize = true;
            this.numberAthletesLabel.Location = new System.Drawing.Point(25, 210);
            this.numberAthletesLabel.Name = "numberAthletesLabel";
            this.numberAthletesLabel.Size = new System.Drawing.Size(149, 29);
            this.numberAthletesLabel.TabIndex = 20;
            this.numberAthletesLabel.Text = "Num. Atletes";
            // 
            // measurementTypeLabel
            // 
            this.measurementTypeLabel.AutoSize = true;
            this.measurementTypeLabel.Location = new System.Drawing.Point(25, 116);
            this.measurementTypeLabel.Name = "measurementTypeLabel";
            this.measurementTypeLabel.Size = new System.Drawing.Size(93, 29);
            this.measurementTypeLabel.TabIndex = 19;
            this.measurementTypeLabel.Text = "Mesura";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(25, 25);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 29);
            this.nameLabel.TabIndex = 18;
            this.nameLabel.Text = "Nom prova";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(25, 68);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(580, 34);
            this.nameTextBox.TabIndex = 15;
            // 
            // numberAthletesTextBox
            // 
            this.numberAthletesTextBox.Location = new System.Drawing.Point(25, 253);
            this.numberAthletesTextBox.Name = "numberAthletesTextBox";
            this.numberAthletesTextBox.Size = new System.Drawing.Size(137, 34);
            this.numberAthletesTextBox.TabIndex = 17;
            this.numberAthletesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.birthYearTextBox_KeyPress);
            // 
            // measurementTypeComboBox
            // 
            this.measurementTypeComboBox.FormattingEnabled = true;
            this.measurementTypeComboBox.Location = new System.Drawing.Point(25, 159);
            this.measurementTypeComboBox.Name = "measurementTypeComboBox";
            this.measurementTypeComboBox.Size = new System.Drawing.Size(280, 37);
            this.measurementTypeComboBox.TabIndex = 16;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(455, 394);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(150, 42);
            this.okButton.TabIndex = 21;
            this.okButton.Text = "Aceptar";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // TrialEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 477);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.numberAthletesLabel);
            this.Controls.Add(this.measurementTypeLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.numberAthletesTextBox);
            this.Controls.Add(this.measurementTypeComboBox);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrialEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label numberAthletesLabel;
        private System.Windows.Forms.Label measurementTypeLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox numberAthletesTextBox;
        private System.Windows.Forms.ComboBox measurementTypeComboBox;
        private System.Windows.Forms.Button okButton;
    }
}