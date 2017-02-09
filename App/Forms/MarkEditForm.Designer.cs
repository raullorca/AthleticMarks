namespace AthleticMarks.App
{
    partial class MarkEditForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.twoNumber = new System.Windows.Forms.Label();
            this.threeNumber = new System.Windows.Forms.Label();
            this.fourNumber = new System.Windows.Forms.Label();
            this.oneNumber = new System.Windows.Forms.Label();
            this.trackPanel = new System.Windows.Forms.Panel();
            this.trackOutdoor = new System.Windows.Forms.RadioButton();
            this.trackIndoor = new System.Windows.Forms.RadioButton();
            this.categoryTextbox = new System.Windows.Forms.TextBox();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.receiptTextbox = new System.Windows.Forms.TextBox();
            this.receiptLabel = new System.Windows.Forms.Label();
            this.commentsTextbox = new System.Windows.Forms.TextBox();
            this.townLabel = new System.Windows.Forms.Label();
            this.townTextbox = new System.Windows.Forms.TextBox();
            this.athtetesLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.dateMarkLabel = new System.Windows.Forms.Label();
            this.athlete1Textbox = new System.Windows.Forms.TextBox();
            this.athlete2Textbox = new System.Windows.Forms.TextBox();
            this.athlete3Textbox = new System.Windows.Forms.TextBox();
            this.athlete4Textbox = new System.Windows.Forms.TextBox();
            this.markValueLabel = new System.Windows.Forms.Label();
            this.trialLabel = new System.Windows.Forms.Label();
            this.trackLabel = new System.Windows.Forms.Label();
            this.trialTextbox = new System.Windows.Forms.TextBox();
            this.markValueTextbox = new System.Windows.Forms.TextBox();
            this.searchTrialButton = new System.Windows.Forms.Button();
            this.searchAthlete3Button = new System.Windows.Forms.Button();
            this.searchAthlete2Button = new System.Windows.Forms.Button();
            this.searchAthlete1Button = new System.Windows.Forms.Button();
            this.searchAthlete4Button = new System.Windows.Forms.Button();
            this.removeAthlete4Button = new System.Windows.Forms.Button();
            this.removeAthlete1Button = new System.Windows.Forms.Button();
            this.removeAthlete2Button = new System.Windows.Forms.Button();
            this.removeAthlete3Button = new System.Windows.Forms.Button();
            this.measurementTypeName = new System.Windows.Forms.Label();
            this.dateMarkDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saisonTextbox = new System.Windows.Forms.TextBox();
            this.saisonLabel = new System.Windows.Forms.Label();
            this.trackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(30, 542);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 42);
            this.cancelButton.TabIndex = 36;
            this.cancelButton.Text = "Cancel·lar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(708, 542);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(150, 42);
            this.okButton.TabIndex = 37;
            this.okButton.Text = "Aceptar";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // twoNumber
            // 
            this.twoNumber.AutoSize = true;
            this.twoNumber.Location = new System.Drawing.Point(167, 157);
            this.twoNumber.Name = "twoNumber";
            this.twoNumber.Size = new System.Drawing.Size(32, 29);
            this.twoNumber.TabIndex = 9;
            this.twoNumber.Text = "2:";
            // 
            // threeNumber
            // 
            this.threeNumber.AutoSize = true;
            this.threeNumber.Location = new System.Drawing.Point(167, 201);
            this.threeNumber.Name = "threeNumber";
            this.threeNumber.Size = new System.Drawing.Size(32, 29);
            this.threeNumber.TabIndex = 13;
            this.threeNumber.Text = "3:";
            // 
            // fourNumber
            // 
            this.fourNumber.AutoSize = true;
            this.fourNumber.Location = new System.Drawing.Point(167, 245);
            this.fourNumber.Name = "fourNumber";
            this.fourNumber.Size = new System.Drawing.Size(32, 29);
            this.fourNumber.TabIndex = 17;
            this.fourNumber.Text = "4:";
            // 
            // oneNumber
            // 
            this.oneNumber.AutoSize = true;
            this.oneNumber.Location = new System.Drawing.Point(167, 113);
            this.oneNumber.Name = "oneNumber";
            this.oneNumber.Size = new System.Drawing.Size(32, 29);
            this.oneNumber.TabIndex = 5;
            this.oneNumber.Text = "1:";
            // 
            // trackPanel
            // 
            this.trackPanel.Controls.Add(this.trackOutdoor);
            this.trackPanel.Controls.Add(this.trackIndoor);
            this.trackPanel.Location = new System.Drawing.Point(215, 22);
            this.trackPanel.Name = "trackPanel";
            this.trackPanel.Size = new System.Drawing.Size(436, 38);
            this.trackPanel.TabIndex = 1;
            // 
            // trackOutdoor
            // 
            this.trackOutdoor.AutoSize = true;
            this.trackOutdoor.Location = new System.Drawing.Point(268, 3);
            this.trackOutdoor.Name = "trackOutdoor";
            this.trackOutdoor.Size = new System.Drawing.Size(143, 33);
            this.trackOutdoor.TabIndex = 1;
            this.trackOutdoor.TabStop = true;
            this.trackOutdoor.Text = "Aire Lliure";
            this.trackOutdoor.UseVisualStyleBackColor = true;
            // 
            // trackIndoor
            // 
            this.trackIndoor.AutoSize = true;
            this.trackIndoor.Location = new System.Drawing.Point(14, 2);
            this.trackIndoor.Name = "trackIndoor";
            this.trackIndoor.Size = new System.Drawing.Size(120, 33);
            this.trackIndoor.TabIndex = 0;
            this.trackIndoor.TabStop = true;
            this.trackIndoor.Text = "Coberta";
            this.trackIndoor.UseVisualStyleBackColor = true;
            // 
            // categoryTextbox
            // 
            this.categoryTextbox.Location = new System.Drawing.Point(212, 330);
            this.categoryTextbox.Name = "categoryTextbox";
            this.categoryTextbox.ReadOnly = true;
            this.categoryTextbox.Size = new System.Drawing.Size(200, 34);
            this.categoryTextbox.TabIndex = 27;
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(30, 421);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(136, 29);
            this.commentsLabel.TabIndex = 32;
            this.commentsLabel.Text = "Comentaris";
            // 
            // receiptTextbox
            // 
            this.receiptTextbox.Location = new System.Drawing.Point(212, 462);
            this.receiptTextbox.Name = "receiptTextbox";
            this.receiptTextbox.Size = new System.Drawing.Size(564, 34);
            this.receiptTextbox.TabIndex = 35;
            this.receiptTextbox.Leave += new System.EventHandler(this.receiptTextbox_Leave);
            // 
            // receiptLabel
            // 
            this.receiptLabel.AutoSize = true;
            this.receiptLabel.Location = new System.Drawing.Point(30, 465);
            this.receiptLabel.Name = "receiptLabel";
            this.receiptLabel.Size = new System.Drawing.Size(146, 29);
            this.receiptLabel.TabIndex = 34;
            this.receiptLabel.Text = "Comprobant";
            // 
            // commentsTextbox
            // 
            this.commentsTextbox.Location = new System.Drawing.Point(213, 418);
            this.commentsTextbox.Name = "commentsTextbox";
            this.commentsTextbox.Size = new System.Drawing.Size(564, 34);
            this.commentsTextbox.TabIndex = 33;
            this.commentsTextbox.Leave += new System.EventHandler(this.commentsTextbox_Leave);
            // 
            // townLabel
            // 
            this.townLabel.AutoSize = true;
            this.townLabel.Location = new System.Drawing.Point(30, 377);
            this.townLabel.Name = "townLabel";
            this.townLabel.Size = new System.Drawing.Size(58, 29);
            this.townLabel.TabIndex = 30;
            this.townLabel.Text = "Lloc";
            // 
            // townTextbox
            // 
            this.townTextbox.Location = new System.Drawing.Point(212, 374);
            this.townTextbox.Name = "townTextbox";
            this.townTextbox.Size = new System.Drawing.Size(564, 34);
            this.townTextbox.TabIndex = 31;
            this.townTextbox.Leave += new System.EventHandler(this.townTextbox_Leave);
            // 
            // athtetesLabel
            // 
            this.athtetesLabel.AutoSize = true;
            this.athtetesLabel.Location = new System.Drawing.Point(30, 177);
            this.athtetesLabel.Name = "athtetesLabel";
            this.athtetesLabel.Size = new System.Drawing.Size(92, 29);
            this.athtetesLabel.TabIndex = 31;
            this.athtetesLabel.Text = "Atletes:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(30, 333);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(118, 29);
            this.categoryLabel.TabIndex = 26;
            this.categoryLabel.Text = "Categoria";
            // 
            // dateMarkLabel
            // 
            this.dateMarkLabel.AutoSize = true;
            this.dateMarkLabel.Location = new System.Drawing.Point(30, 289);
            this.dateMarkLabel.Name = "dateMarkLabel";
            this.dateMarkLabel.Size = new System.Drawing.Size(62, 29);
            this.dateMarkLabel.TabIndex = 21;
            this.dateMarkLabel.Text = "Data";
            // 
            // athlete1Textbox
            // 
            this.athlete1Textbox.Location = new System.Drawing.Point(212, 110);
            this.athlete1Textbox.Name = "athlete1Textbox";
            this.athlete1Textbox.ReadOnly = true;
            this.athlete1Textbox.Size = new System.Drawing.Size(562, 34);
            this.athlete1Textbox.TabIndex = 6;
            // 
            // athlete2Textbox
            // 
            this.athlete2Textbox.Location = new System.Drawing.Point(212, 154);
            this.athlete2Textbox.Name = "athlete2Textbox";
            this.athlete2Textbox.ReadOnly = true;
            this.athlete2Textbox.Size = new System.Drawing.Size(562, 34);
            this.athlete2Textbox.TabIndex = 10;
            // 
            // athlete3Textbox
            // 
            this.athlete3Textbox.Location = new System.Drawing.Point(212, 198);
            this.athlete3Textbox.Name = "athlete3Textbox";
            this.athlete3Textbox.ReadOnly = true;
            this.athlete3Textbox.Size = new System.Drawing.Size(562, 34);
            this.athlete3Textbox.TabIndex = 14;
            // 
            // athlete4Textbox
            // 
            this.athlete4Textbox.Location = new System.Drawing.Point(212, 242);
            this.athlete4Textbox.Name = "athlete4Textbox";
            this.athlete4Textbox.ReadOnly = true;
            this.athlete4Textbox.Size = new System.Drawing.Size(562, 34);
            this.athlete4Textbox.TabIndex = 18;
            // 
            // markValueLabel
            // 
            this.markValueLabel.AutoSize = true;
            this.markValueLabel.Location = new System.Drawing.Point(435, 289);
            this.markValueLabel.Name = "markValueLabel";
            this.markValueLabel.Size = new System.Drawing.Size(79, 29);
            this.markValueLabel.TabIndex = 23;
            this.markValueLabel.Text = "Marca";
            // 
            // trialLabel
            // 
            this.trialLabel.AutoSize = true;
            this.trialLabel.Location = new System.Drawing.Point(30, 69);
            this.trialLabel.Name = "trialLabel";
            this.trialLabel.Size = new System.Drawing.Size(75, 29);
            this.trialLabel.TabIndex = 2;
            this.trialLabel.Text = "Prova";
            // 
            // trackLabel
            // 
            this.trackLabel.AutoSize = true;
            this.trackLabel.Location = new System.Drawing.Point(30, 28);
            this.trackLabel.Name = "trackLabel";
            this.trackLabel.Size = new System.Drawing.Size(66, 29);
            this.trackLabel.TabIndex = 0;
            this.trackLabel.Text = "Pista";
            // 
            // trialTextbox
            // 
            this.trialTextbox.Location = new System.Drawing.Point(212, 66);
            this.trialTextbox.Name = "trialTextbox";
            this.trialTextbox.ReadOnly = true;
            this.trialTextbox.Size = new System.Drawing.Size(564, 34);
            this.trialTextbox.TabIndex = 3;
            // 
            // markValueTextbox
            // 
            this.markValueTextbox.Location = new System.Drawing.Point(537, 286);
            this.markValueTextbox.Name = "markValueTextbox";
            this.markValueTextbox.Size = new System.Drawing.Size(237, 34);
            this.markValueTextbox.TabIndex = 24;
            this.markValueTextbox.Leave += new System.EventHandler(this.markValueTextbox_Leave);
            // 
            // searchTrialButton
            // 
            this.searchTrialButton.Location = new System.Drawing.Point(783, 66);
            this.searchTrialButton.Name = "searchTrialButton";
            this.searchTrialButton.Size = new System.Drawing.Size(40, 34);
            this.searchTrialButton.TabIndex = 4;
            this.searchTrialButton.Text = "...";
            this.searchTrialButton.UseVisualStyleBackColor = true;
            this.searchTrialButton.Click += new System.EventHandler(this.searchTrialButton_Click);
            // 
            // searchAthlete3Button
            // 
            this.searchAthlete3Button.Location = new System.Drawing.Point(783, 198);
            this.searchAthlete3Button.Name = "searchAthlete3Button";
            this.searchAthlete3Button.Size = new System.Drawing.Size(40, 34);
            this.searchAthlete3Button.TabIndex = 15;
            this.searchAthlete3Button.Text = "...";
            this.searchAthlete3Button.UseVisualStyleBackColor = true;
            this.searchAthlete3Button.Click += new System.EventHandler(this.searchAthlete3Button_Click);
            // 
            // searchAthlete2Button
            // 
            this.searchAthlete2Button.Location = new System.Drawing.Point(782, 154);
            this.searchAthlete2Button.Name = "searchAthlete2Button";
            this.searchAthlete2Button.Size = new System.Drawing.Size(40, 34);
            this.searchAthlete2Button.TabIndex = 11;
            this.searchAthlete2Button.Text = "...";
            this.searchAthlete2Button.UseVisualStyleBackColor = true;
            this.searchAthlete2Button.Click += new System.EventHandler(this.searchAthlete2Button_Click);
            // 
            // searchAthlete1Button
            // 
            this.searchAthlete1Button.Location = new System.Drawing.Point(783, 110);
            this.searchAthlete1Button.Name = "searchAthlete1Button";
            this.searchAthlete1Button.Size = new System.Drawing.Size(40, 34);
            this.searchAthlete1Button.TabIndex = 7;
            this.searchAthlete1Button.Text = "...";
            this.searchAthlete1Button.UseVisualStyleBackColor = true;
            this.searchAthlete1Button.Click += new System.EventHandler(this.searchAthlete1Button_Click);
            // 
            // searchAthlete4Button
            // 
            this.searchAthlete4Button.Location = new System.Drawing.Point(783, 242);
            this.searchAthlete4Button.Name = "searchAthlete4Button";
            this.searchAthlete4Button.Size = new System.Drawing.Size(40, 34);
            this.searchAthlete4Button.TabIndex = 19;
            this.searchAthlete4Button.Text = "...";
            this.searchAthlete4Button.UseVisualStyleBackColor = true;
            this.searchAthlete4Button.Click += new System.EventHandler(this.searchAthlete4Button_Click);
            // 
            // removeAthlete4Button
            // 
            this.removeAthlete4Button.Location = new System.Drawing.Point(838, 242);
            this.removeAthlete4Button.Name = "removeAthlete4Button";
            this.removeAthlete4Button.Size = new System.Drawing.Size(40, 34);
            this.removeAthlete4Button.TabIndex = 20;
            this.removeAthlete4Button.Text = "X";
            this.removeAthlete4Button.UseVisualStyleBackColor = true;
            // 
            // removeAthlete1Button
            // 
            this.removeAthlete1Button.Location = new System.Drawing.Point(838, 110);
            this.removeAthlete1Button.Name = "removeAthlete1Button";
            this.removeAthlete1Button.Size = new System.Drawing.Size(40, 34);
            this.removeAthlete1Button.TabIndex = 8;
            this.removeAthlete1Button.Text = "X";
            this.removeAthlete1Button.UseVisualStyleBackColor = true;
            this.removeAthlete1Button.Click += new System.EventHandler(this.removeAthlete1Button_Click);
            // 
            // removeAthlete2Button
            // 
            this.removeAthlete2Button.Location = new System.Drawing.Point(837, 154);
            this.removeAthlete2Button.Name = "removeAthlete2Button";
            this.removeAthlete2Button.Size = new System.Drawing.Size(40, 34);
            this.removeAthlete2Button.TabIndex = 12;
            this.removeAthlete2Button.Text = "X";
            this.removeAthlete2Button.UseVisualStyleBackColor = true;
            // 
            // removeAthlete3Button
            // 
            this.removeAthlete3Button.Location = new System.Drawing.Point(838, 198);
            this.removeAthlete3Button.Name = "removeAthlete3Button";
            this.removeAthlete3Button.Size = new System.Drawing.Size(40, 34);
            this.removeAthlete3Button.TabIndex = 16;
            this.removeAthlete3Button.Text = "X";
            this.removeAthlete3Button.UseVisualStyleBackColor = true;
            // 
            // measurementTypeName
            // 
            this.measurementTypeName.AutoSize = true;
            this.measurementTypeName.Location = new System.Drawing.Point(780, 289);
            this.measurementTypeName.Name = "measurementTypeName";
            this.measurementTypeName.Size = new System.Drawing.Size(37, 29);
            this.measurementTypeName.TabIndex = 25;
            this.measurementTypeName.Text = "---";
            // 
            // dateMarkDateTimePicker
            // 
            this.dateMarkDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateMarkDateTimePicker.Location = new System.Drawing.Point(212, 284);
            this.dateMarkDateTimePicker.Name = "dateMarkDateTimePicker";
            this.dateMarkDateTimePicker.Size = new System.Drawing.Size(200, 34);
            this.dateMarkDateTimePicker.TabIndex = 22;
            this.dateMarkDateTimePicker.ValueChanged += new System.EventHandler(this.dateMarkDateTimePicker_ValueChanged);
            // 
            // saisonTextbox
            // 
            this.saisonTextbox.Location = new System.Drawing.Point(580, 330);
            this.saisonTextbox.Name = "saisonTextbox";
            this.saisonTextbox.ReadOnly = true;
            this.saisonTextbox.Size = new System.Drawing.Size(194, 34);
            this.saisonTextbox.TabIndex = 29;
            // 
            // saisonLabel
            // 
            this.saisonLabel.AutoSize = true;
            this.saisonLabel.Location = new System.Drawing.Point(435, 333);
            this.saisonLabel.Name = "saisonLabel";
            this.saisonLabel.Size = new System.Drawing.Size(139, 29);
            this.saisonLabel.TabIndex = 28;
            this.saisonLabel.Text = "Temporada";
            // 
            // MarkEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 625);
            this.Controls.Add(this.saisonTextbox);
            this.Controls.Add(this.saisonLabel);
            this.Controls.Add(this.dateMarkDateTimePicker);
            this.Controls.Add(this.measurementTypeName);
            this.Controls.Add(this.removeAthlete4Button);
            this.Controls.Add(this.removeAthlete1Button);
            this.Controls.Add(this.removeAthlete2Button);
            this.Controls.Add(this.removeAthlete3Button);
            this.Controls.Add(this.searchAthlete4Button);
            this.Controls.Add(this.searchAthlete1Button);
            this.Controls.Add(this.searchAthlete2Button);
            this.Controls.Add(this.searchAthlete3Button);
            this.Controls.Add(this.searchTrialButton);
            this.Controls.Add(this.twoNumber);
            this.Controls.Add(this.threeNumber);
            this.Controls.Add(this.fourNumber);
            this.Controls.Add(this.oneNumber);
            this.Controls.Add(this.trackPanel);
            this.Controls.Add(this.categoryTextbox);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.receiptTextbox);
            this.Controls.Add(this.receiptLabel);
            this.Controls.Add(this.commentsTextbox);
            this.Controls.Add(this.townLabel);
            this.Controls.Add(this.townTextbox);
            this.Controls.Add(this.athtetesLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.dateMarkLabel);
            this.Controls.Add(this.athlete1Textbox);
            this.Controls.Add(this.athlete2Textbox);
            this.Controls.Add(this.athlete3Textbox);
            this.Controls.Add(this.athlete4Textbox);
            this.Controls.Add(this.markValueLabel);
            this.Controls.Add(this.trialLabel);
            this.Controls.Add(this.trackLabel);
            this.Controls.Add(this.trialTextbox);
            this.Controls.Add(this.markValueTextbox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarkEditForm";
            this.trackPanel.ResumeLayout(false);
            this.trackPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label twoNumber;
        private System.Windows.Forms.Label threeNumber;
        private System.Windows.Forms.Label fourNumber;
        private System.Windows.Forms.Label oneNumber;
        private System.Windows.Forms.Panel trackPanel;
        private System.Windows.Forms.RadioButton trackOutdoor;
        private System.Windows.Forms.RadioButton trackIndoor;
        private System.Windows.Forms.TextBox categoryTextbox;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox receiptTextbox;
        private System.Windows.Forms.Label receiptLabel;
        private System.Windows.Forms.TextBox commentsTextbox;
        private System.Windows.Forms.Label townLabel;
        private System.Windows.Forms.TextBox townTextbox;
        private System.Windows.Forms.Label athtetesLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label dateMarkLabel;
        private System.Windows.Forms.TextBox athlete1Textbox;
        private System.Windows.Forms.TextBox athlete2Textbox;
        private System.Windows.Forms.TextBox athlete3Textbox;
        private System.Windows.Forms.TextBox athlete4Textbox;
        private System.Windows.Forms.Label markValueLabel;
        private System.Windows.Forms.Label trialLabel;
        private System.Windows.Forms.Label trackLabel;
        private System.Windows.Forms.TextBox trialTextbox;
        private System.Windows.Forms.TextBox markValueTextbox;
        private System.Windows.Forms.Button searchTrialButton;
        private System.Windows.Forms.Button searchAthlete3Button;
        private System.Windows.Forms.Button searchAthlete2Button;
        private System.Windows.Forms.Button searchAthlete1Button;
        private System.Windows.Forms.Button searchAthlete4Button;
        private System.Windows.Forms.Button removeAthlete4Button;
        private System.Windows.Forms.Button removeAthlete1Button;
        private System.Windows.Forms.Button removeAthlete2Button;
        private System.Windows.Forms.Button removeAthlete3Button;
        private System.Windows.Forms.Label measurementTypeName;
        private System.Windows.Forms.DateTimePicker dateMarkDateTimePicker;
        private System.Windows.Forms.TextBox saisonTextbox;
        private System.Windows.Forms.Label saisonLabel;
    }
}