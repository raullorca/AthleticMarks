namespace AthleticMarks. App
{
    partial class MainForm
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
            this.AthletesButton = new System.Windows.Forms.Button();
            this.TrialsButton = new System.Windows.Forms.Button();
            this.MarksButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AthletesButton
            // 
            this.AthletesButton.Location = new System.Drawing.Point(14, 14);
            this.AthletesButton.Margin = new System.Windows.Forms.Padding(5);
            this.AthletesButton.Name = "AthletesButton";
            this.AthletesButton.Size = new System.Drawing.Size(457, 42);
            this.AthletesButton.TabIndex = 0;
            this.AthletesButton.Text = "Atletes";
            this.AthletesButton.UseVisualStyleBackColor = true;
            this.AthletesButton.Click += new System.EventHandler(this.AthletesButton_Click);
            // 
            // TrialsButton
            // 
            this.TrialsButton.Location = new System.Drawing.Point(14, 98);
            this.TrialsButton.Margin = new System.Windows.Forms.Padding(5);
            this.TrialsButton.Name = "TrialsButton";
            this.TrialsButton.Size = new System.Drawing.Size(457, 42);
            this.TrialsButton.TabIndex = 1;
            this.TrialsButton.Text = "Proves";
            this.TrialsButton.UseVisualStyleBackColor = true;
            this.TrialsButton.Click += new System.EventHandler(this.TrialsButton_Click);
            // 
            // MarksButton
            // 
            this.MarksButton.Location = new System.Drawing.Point(14, 182);
            this.MarksButton.Margin = new System.Windows.Forms.Padding(5);
            this.MarksButton.Name = "MarksButton";
            this.MarksButton.Size = new System.Drawing.Size(457, 42);
            this.MarksButton.TabIndex = 2;
            this.MarksButton.Text = "Marques";
            this.MarksButton.UseVisualStyleBackColor = true;
            this.MarksButton.Click += new System.EventHandler(this.MarksButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(14, 266);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(457, 42);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Sortir";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 333);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MarksButton);
            this.Controls.Add(this.TrialsButton);
            this.Controls.Add(this.AthletesButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "Ranking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AthletesButton;
        private System.Windows.Forms.Button TrialsButton;
        private System.Windows.Forms.Button MarksButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

