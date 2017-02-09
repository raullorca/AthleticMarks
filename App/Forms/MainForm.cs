using AthleticMarks.Data.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AthleticMarks.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void InitializeCustomComponent()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AthletesButton_Click(object sender, EventArgs e)
        {
            using (var unit = new RankingContext())
                CallForm(new AtletheForm(unit));
        }

        private void CallForm(Form form)
        {
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            return;
        }

        private void TrialsButton_Click(object sender, EventArgs e)
        {
            using (var unit = new RankingContext())
                CallForm(new TrialForm(unit));
        }

        private void MarksButton_Click(object sender, EventArgs e)
        {
            using (var unit = new RankingContext())
                CallForm(new MarkForm(unit));
        }
    }
}